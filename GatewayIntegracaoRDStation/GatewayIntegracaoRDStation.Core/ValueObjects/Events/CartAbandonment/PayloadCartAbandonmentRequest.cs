using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events.CartAbandonment
{
    public class PayloadCartAbandonmentRequest
    {
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("cf_cart_id")]
        [JsonPropertyName("cf_cart_id")]
        public string CfCartId { get; set; }

        [JsonProperty("cf_cart_total_items")]
        [JsonPropertyName("cf_cart_total_items")]
        public int CfCartTotalItems { get; set; }

        [JsonProperty("cf_cart_status")]
        [JsonPropertyName("cf_cart_status")]
        public string CfCartStatus { get; set; }

        [JsonProperty("legal_bases")]
        [JsonPropertyName("legal_bases")]
        public List<LegalBasesRequest> LegalBases { get; set; }
    }
}
