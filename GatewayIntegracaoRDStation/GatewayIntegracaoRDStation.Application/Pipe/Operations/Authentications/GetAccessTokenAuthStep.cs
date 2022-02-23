using GatewayIntegracaoRDStation.Core.ValueObjects.Authentication;
using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Extensions;
using Mvp24Hours.Helpers;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GatewayIntegracaoRDStation.Application.Pipe.Operations.Authentications
{
    public class GetAccessTokenAuthStep : OperationBaseAsync
    {
        private AccessTokenResponse ProviderAccessTokenResponse()
        {
            // Banco de dados ?
            return new AccessTokenResponse
            {
                AccessToken = "",
                ExpiresIn = 86400,
                RefreshToken = ""
            };
        }

        public override async Task<IPipelineMessage> ExecuteAsync(IPipelineMessage input)
        {
            var accessTokenResponse = ProviderAccessTokenResponse();

            var urlBase = ConfigurationHelper.GetSettings("RDStation:UrlBase");
            var accessTokenRequest = ConfigurationHelper.GetSettings<AccessTokenRequest>("RDStation");

            if (!urlBase.HasValue())
            {
                NotificationContext.Add("GetAccessTokenAuthStep", "Não foi encontrado a UrlBase do RDStation (appsettings).", Mvp24Hours.Core.Enums.MessageType.Error);
            }

            if (!accessTokenRequest.ClientId.HasValue() || !accessTokenRequest.ClientSecret.HasValue())
            {
                NotificationContext.Add("GetAccessTokenAuthStep", "Não foram encontradas as configurações do RDStation (appsettings).", Mvp24Hours.Core.Enums.MessageType.Error);
            }

            if (NotificationContext.HasErrorNotifications)
            {
                input.SetLock();
                return input;
            }

            if (accessTokenResponse != null)
            {
                accessTokenRequest.Code = null;
                accessTokenRequest.RefreshToken = accessTokenResponse.RefreshToken;
            }

            var json = JsonConvert.SerializeObject(accessTokenRequest, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var response = await WebRequestHelper.PostAsync($"{urlBase}/auth/token", json);

            var result = response.ToDeserialize<AccessTokenResponse>();

            if (result == null || result.Errors.Count > 0)
            {
                NotificationContext.Add("GetAccessTokenAuthStep", "Não foi possível obter o access_token do RDStation.", Mvp24Hours.Core.Enums.MessageType.Error);
                input.SetLock();
                return input;
            }

            input.AddContent("urlBase", urlBase);
            input.AddContent("accessTokenResponse", result);

            return input;
        }
    }
}
