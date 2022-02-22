using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class PayloadRequest
    {
        [JsonPropertyName("conversion_identifier")]
        public string ConversionIdentifier { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("job_title")]
        public string JobTitle { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("personal_phone")]
        public string PersonalPhone { get; set; }

        [JsonPropertyName("mobile_phone")]
        public string MobilePhone { get; set; }

        [JsonPropertyName("twitter")]
        public string Twitter { get; set; }

        [JsonPropertyName("facebook")]
        public string Facebook { get; set; }

        [JsonPropertyName("linkedin")]
        public string Linkedin { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("cf_custom_field_api_identifier")]
        public string CfCustomFieldApiIdentifier { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("company_site")]
        public string CompanySite { get; set; }

        [JsonPropertyName("company_address")]
        public string CompanyAddress { get; set; }

        [JsonPropertyName("client_tracking_id")]
        public string ClientTrackingId { get; set; }

        [JsonPropertyName("traffic_source")]
        public string TrafficSource { get; set; }

        [JsonPropertyName("traffic_medium")]
        public string TrafficMedium { get; set; }

        [JsonPropertyName("traffic_campaign")]
        public string TrafficCampaign { get; set; }

        [JsonPropertyName("traffic_value")]
        public string TrafficValue { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("available_for_mailing")]
        public bool AvailableForMailing { get; set; }

        [JsonPropertyName("legal_bases")]
        public List<LegalBasesRequest> LegalBasesRequest { get; set; }
    }
}
