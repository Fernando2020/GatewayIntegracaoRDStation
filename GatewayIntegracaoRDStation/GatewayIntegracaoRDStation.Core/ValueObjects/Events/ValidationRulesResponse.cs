using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class ValidationRulesResponse
    {
        [JsonProperty("valid_options")]
        [JsonPropertyName("valid_options")]
        public List<string> ValidOptions { get; set; }
    }
}
