using Newtonsoft.Json;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Authentications
{
    public class ErrorAuthResponse
    {
        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
