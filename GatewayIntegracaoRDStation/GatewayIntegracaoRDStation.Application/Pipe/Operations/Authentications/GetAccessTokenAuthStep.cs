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
                AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJodHRwczovL2FwaS5yZC5zZXJ2aWNlcyIsInN1YiI6IkRHRkJLSURDRm9oc2IwMnllc3BDOU5MdEtnLXhmeGtQRm1pX1B5cGNVV1FAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vYXBwLnJkc3RhdGlvbi5jb20uYnIvYXBpL3YyLyIsImFwcF9uYW1lIjoiRWNvbW1lcmNlIFR1cmlzbW8iLCJleHAiOjE2NDU3MDgxMjMsImlhdCI6MTY0NTYyMTcyMywic2NvcGUiOiIifQ.oxsjrZyw1-my_bjRcPklAzGZQmgvorssOZuxUSwVKdgEpsbM7Gh2igkiMKsPHXiLDoc-q4oWKpjZjlj1jPNVzcLLUncO6NSn6-1J8oPduNNJPzKH4fNTS1GUIg61oFeXqW-WrvQ0h8z2oDopU_LAKsFjsjo9K4WbXlmBn4OW4VHfvQYE7PdDwu2PVQ0VUPuqYz3ph2JCYYv57c77Lejz8bdBGBCmQz89uu3GEw48Oj6fYa830hWnO9VWAXSHQP0EffzQt81ztLFuodLgCe0ZmTt9O2WFR-8PMJFSL61XDvFY_o4oF-kCx-0URoOWDfnYdYZkUjDK3KVcrPwPsbgz2Q",
                ExpiresIn = 86400,
                RefreshToken = "iZhfZM0cqtyb09icTjUibnZxo2Re0T3bHXUr5yu8nA94"
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
