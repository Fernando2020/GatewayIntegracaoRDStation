using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class ValidationRulesResponse
    {
        [JsonPropertyName("valid_options")]
        public List<string> ValidOptions { get; set; }
    }
}
