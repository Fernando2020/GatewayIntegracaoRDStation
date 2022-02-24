﻿using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Authentication
{
    public class AccessTokenRequest
    {
        [JsonProperty("client_id")]
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("client_secret")]
        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonProperty("refresh_token")]
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
