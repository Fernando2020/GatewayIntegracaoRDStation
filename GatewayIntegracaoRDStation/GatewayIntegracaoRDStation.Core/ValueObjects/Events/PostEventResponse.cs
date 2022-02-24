using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class PostEventResponse
    {
        [JsonProperty("event_uuid")]
        [JsonPropertyName("event_uuid")]
        public string EventId { get; set; }

        [JsonProperty("errors")]
        [JsonPropertyName("errors")]
        public List<ErrorEventResponse> Errors { get; set; }
    }
}
