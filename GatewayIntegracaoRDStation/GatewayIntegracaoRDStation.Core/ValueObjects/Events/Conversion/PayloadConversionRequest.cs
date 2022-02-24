using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events.Conversion
{
    public class PayloadConversionRequest
    {
        [JsonProperty("conversion_identifier")]
        [JsonPropertyName("conversion_identifier")]
        public string ConversionIdentifier { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonProperty("job_title")]
        [JsonPropertyName("job_title")]
        public string JobTitle { get; set; }

        [JsonProperty("state")]
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonProperty("city")]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonProperty("personal_phone")]
        [JsonPropertyName("personal_phone")]
        public string PersonalPhone { get; set; }

        [JsonProperty("mobile_phone")]
        [JsonPropertyName("mobile_phone")]
        public string MobilePhone { get; set; }

        [JsonProperty("twitter")]
        [JsonPropertyName("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("facebook")]
        [JsonPropertyName("facebook")]
        public string Facebook { get; set; }

        [JsonProperty("linkedin")]
        [JsonPropertyName("linkedin")]
        public string Linkedin { get; set; }

        [JsonProperty("website")]
        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonProperty("cf_custom_field_api_identifier")]
        [JsonPropertyName("cf_custom_field_api_identifier")]
        public string CfCustomFieldApiIdentifier { get; set; }

        [JsonProperty("company_name")]
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("company_site")]
        [JsonPropertyName("company_site")]
        public string CompanySite { get; set; }

        [JsonProperty("company_address")]
        [JsonPropertyName("company_address")]
        public string CompanyAddress { get; set; }

        [JsonProperty("client_tracking_id")]
        [JsonPropertyName("client_tracking_id")]
        public string ClientTrackingId { get; set; }

        [JsonProperty("traffic_source")]
        [JsonPropertyName("traffic_source")]
        public string TrafficSource { get; set; }

        [JsonProperty("traffic_medium")]
        [JsonPropertyName("traffic_medium")]
        public string TrafficMedium { get; set; }

        [JsonProperty("traffic_campaign")]
        [JsonPropertyName("traffic_campaign")]
        public string TrafficCampaign { get; set; }

        [JsonProperty("traffic_value")]
        [JsonPropertyName("traffic_value")]
        public string TrafficValue { get; set; }

        [JsonProperty("tags")]
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("available_for_mailing")]
        [JsonPropertyName("available_for_mailing")]
        public bool AvailableForMailing { get; set; }

        [JsonProperty("legal_bases")]
        [JsonPropertyName("legal_bases")]
        public List<LegalBasesRequest> LegalBases { get; set; }
    }
}
