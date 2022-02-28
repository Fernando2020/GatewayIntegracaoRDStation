using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events.Conversion
{
    public class PostConversionRequest
    {
        [JsonProperty("event_type")]
        [JsonPropertyName("event_type")]
        public string EventType { get; set; }

        [JsonProperty("event_family")]
        [JsonPropertyName("event_family")]
        public string EventFamily { get; set; }

        [JsonProperty("payload")]
        [JsonPropertyName("payload")]
        public PayloadConversionRequest Payload { get; set; }
    }
}
