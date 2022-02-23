using GatewayIntegracaoRDStation.Core.ValueObjects.Authentications;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Authentication
{
    public class AccessTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("errors")]
        public List<ErrorAuthResponse> Errors { get; set; }
    }
}
