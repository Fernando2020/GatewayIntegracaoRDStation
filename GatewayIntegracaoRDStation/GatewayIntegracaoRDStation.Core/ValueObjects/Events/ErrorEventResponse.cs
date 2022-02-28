using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class ErrorEventResponse
    {
        [JsonProperty("error_type")]
        [JsonPropertyName("error_type")]
        public string ErrorType { get; set; }

        [JsonProperty("error_message")]
        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("validation_rules")]
        [JsonPropertyName("validation_rules")]
        public ValidationRulesResponse ValidationRules { get; set; }

        [JsonProperty("path")]
        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
}
