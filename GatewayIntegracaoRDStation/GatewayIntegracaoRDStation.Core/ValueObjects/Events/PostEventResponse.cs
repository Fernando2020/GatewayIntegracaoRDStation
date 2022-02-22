using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class PostEventResponse
    {
        [JsonPropertyName("event_uuid")]
        public string EventId { get; set; }

        [JsonPropertyName("errors")]
        public List<ErrorResponse> ErrorsResponse { get; set; }
    }
}
