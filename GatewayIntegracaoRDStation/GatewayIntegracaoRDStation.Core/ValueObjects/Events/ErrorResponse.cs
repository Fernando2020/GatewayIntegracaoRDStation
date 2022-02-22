using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class ErrorResponse
    {
        [JsonPropertyName("error_type")]
        public string ErrorType { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("validation_rules")]
        public ValidationRulesResponse ValidationRulesResponse { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
}
