using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Authentications
{
    public class ErrorAuthResponse
    {
        [JsonProperty("error_type")]
        [JsonPropertyName("error_type")]
        public string ErrorType { get; set; }

        [JsonProperty("error_message")]
        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }
    }
}
