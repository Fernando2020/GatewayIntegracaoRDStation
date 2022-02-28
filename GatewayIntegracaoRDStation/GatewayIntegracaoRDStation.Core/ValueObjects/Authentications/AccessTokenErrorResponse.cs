using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Authentications
{
    public class AccessTokenErrorResponse
    {
        [JsonProperty("errors")]
        [JsonPropertyName("errors")]
        public List<ErrorAuthResponse> Errors { get; set; }
    }
}
