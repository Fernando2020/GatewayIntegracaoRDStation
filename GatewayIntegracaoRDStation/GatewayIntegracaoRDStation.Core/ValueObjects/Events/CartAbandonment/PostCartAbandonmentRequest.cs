using Newtonsoft.Json;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events.CartAbandonment
{
    public class PostCartAbandonmentRequest
    {
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("event_family")]
        public string EventFamily { get; set; }

        [JsonProperty("payload")]
        public CartAbandonmentPayloadRequest Payload { get; set; }
    }
}
