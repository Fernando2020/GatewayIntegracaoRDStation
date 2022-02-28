using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class PostEventErrorResponse
    {
        [JsonProperty("errors")]
        [JsonPropertyName("errors")]
        public List<ErrorEventResponse> Errors { get; set; }
    }
}
