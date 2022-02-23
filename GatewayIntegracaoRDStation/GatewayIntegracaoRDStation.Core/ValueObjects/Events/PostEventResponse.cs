using Newtonsoft.Json;
using System.Collections.Generic;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class PostEventResponse
    {
        [JsonProperty("event_uuid")]
        public string EventId { get; set; }

        [JsonProperty("errors")]
        public List<ErrorEventResponse> Errors { get; set; }
    }
}
