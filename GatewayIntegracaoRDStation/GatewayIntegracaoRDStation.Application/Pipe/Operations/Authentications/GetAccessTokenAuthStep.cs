using GatewayIntegracaoRDStation.Core.Resources;
using GatewayIntegracaoRDStation.Core.ValueObjects.Authentication;
using GatewayIntegracaoRDStation.Core.ValueObjects.Authentications;
using Microsoft.Extensions.Caching.Distributed;
using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Extensions;
using Mvp24Hours.Helpers;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GatewayIntegracaoRDStation.Application.Pipe.Operations.Authentications
{
    public class GetAccessTokenAuthStep : OperationBaseAsync
    {
        private readonly IDistributedCache _cache;
        public GetAccessTokenAuthStep(IDistributedCache cache)
        {
            _cache = cache;
        }

        private async Task<string> GetAccessToken(string code)
        {
            return await _cache.GetStringAsync($"access_token_{code}");
        }

        private async Task<string> GetRefreshToken(string code)
        {
            return await _cache.GetStringAsync($"refresh_token_{code}");
        }

        private async Task SetCredentialsAsync(string code, AccessTokenResponse accessTokenResponse)
        {
            var expiresIn = TimeSpan.FromSeconds(accessTokenResponse.ExpiresIn * 0.99);

            await _cache.SetStringAsync($"access_token_{code}", accessTokenResponse.AccessToken,
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = expiresIn
                });

            await _cache.SetStringAsync($"refresh_token_{code}", accessTokenResponse.RefreshToken);
        }

        public override async Task ExecuteAsync(IPipelineMessage input)
        {
            if (!input.HasContent("code"))
            {
                input.Messages.AddMessage("code", Messages.PARAMETER_REQUIRED, Mvp24Hours.Core.Enums.MessageType.Error);
                return;
            }

            var code = input.GetContent<string>("code");

            var urlBase = ConfigurationHelper.GetSettings<string>("RDStation:UrlBase");
            var dictionary = ConfigurationHelper
                .GetSettings<Dictionary<string, AccessTokenRequest>>("RDStation:AppsConfiguration");

            if (string.IsNullOrEmpty(urlBase) || dictionary == null || !dictionary.ContainsKey(code))
            {
                input.Messages.AddMessage("rdstation_appsettings", Messages.RECORD_NOT_FOUND, Mvp24Hours.Core.Enums.MessageType.Error);
                return;
            }

            var accessTokenRequest = dictionary[code];

            if(!accessTokenRequest.ClientId.HasValue() || !accessTokenRequest.ClientSecret.HasValue())
            {
                input.Messages.AddMessage("rdstation_appsettings", Messages.RECORD_NOT_FOUND, Mvp24Hours.Core.Enums.MessageType.Error);
                return;
            }

            var accessToken = await GetAccessToken(code);

            if (!accessToken.HasValue())
            {
                var refreshToken = await GetRefreshToken(code);

                if (refreshToken.HasValue())
                {
                    accessTokenRequest.RefreshToken = refreshToken;
                }
                else
                {
                    accessTokenRequest.Code = code;
                }

                var json = JsonConvert.SerializeObject(accessTokenRequest, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                var url = $"{urlBase}/auth/token";
                var response = await WebRequestHelper.PostAsync(url, json);

                var error = response.ToDeserialize<AccessTokenErrorResponse>();

                if (error.Errors.AnyOrNotNull())
                {
                    input.Messages.AddMessage("rdstation_access_token", Messages.RECORD_NOT_FOUND, Mvp24Hours.Core.Enums.MessageType.Error);
                    return;
                }

                var result = response.ToDeserialize<AccessTokenResponse>();

                await SetCredentialsAsync(code, result);

                accessToken = result.AccessToken;
            }

            input.AddContent("urlBase", urlBase);
            input.AddContent("accessToken", accessToken);
        }
    }
}
