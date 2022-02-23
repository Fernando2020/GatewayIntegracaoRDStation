using Newtonsoft.Json;
using System.Collections.Generic;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events.CartAbandonment
{
    public class CartAbandonmentPayloadRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("cf_cart_id")]
        public string CfCartId { get; set; }

        [JsonProperty("cf_cart_total_items")]
        public int CfCartTotalItems { get; set; }

        [JsonProperty("cf_cart_status")]
        public string CfCartStatus { get; set; }

        [JsonProperty("legal_bases")]
        public List<LegalBasesRequest> LegalBases { get; set; }
    }
}
