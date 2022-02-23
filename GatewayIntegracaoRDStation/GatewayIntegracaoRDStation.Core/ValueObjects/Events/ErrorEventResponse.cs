using Newtonsoft.Json;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class ErrorEventResponse
    {
        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("validation_rules")]
        public ValidationRulesResponse ValidationRules { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
