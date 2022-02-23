using Newtonsoft.Json;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class LegalBasesRequest
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
