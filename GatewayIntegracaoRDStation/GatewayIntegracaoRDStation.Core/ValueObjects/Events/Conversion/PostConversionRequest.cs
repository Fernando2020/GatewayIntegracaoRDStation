using Newtonsoft.Json;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events.Conversion
{
    public class PostConversionRequest
    {
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("event_family")]
        public string EventFamily { get; set; }

        [JsonProperty("payload")]
        public ConversionPayloadRequest Payload { get; set; }
    }
}
