using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class PostEventRequest
    {
        [JsonPropertyName("event_type")]
        public string EventType { get; set; }

        [JsonPropertyName("event_family")]
        public string EventFamily { get; set; }

        [JsonPropertyName("payload")]
        public PayloadRequest PayloadRequest { get; set; }
    }
}
