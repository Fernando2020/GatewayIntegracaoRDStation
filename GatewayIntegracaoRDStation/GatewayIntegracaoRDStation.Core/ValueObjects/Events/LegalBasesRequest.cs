using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class LegalBasesRequest
    {
        [JsonProperty("category")]
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
