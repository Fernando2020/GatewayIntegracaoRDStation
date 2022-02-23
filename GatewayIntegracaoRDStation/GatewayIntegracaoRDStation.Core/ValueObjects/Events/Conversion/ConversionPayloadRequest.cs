using Newtonsoft.Json;
using System.Collections.Generic;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events.Conversion
{
    public class ConversionPayloadRequest
    {
        [JsonProperty("conversion_identifier")]
        public string ConversionIdentifier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("personal_phone")]
        public string PersonalPhone { get; set; }

        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        [JsonProperty("linkedin")]
        public string Linkedin { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("cf_custom_field_api_identifier")]
        public string CfCustomFieldApiIdentifier { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("company_site")]
        public string CompanySite { get; set; }

        [JsonProperty("company_address")]
        public string CompanyAddress { get; set; }

        [JsonProperty("client_tracking_id")]
        public string ClientTrackingId { get; set; }

        [JsonProperty("traffic_source")]
        public string TrafficSource { get; set; }

        [JsonProperty("traffic_medium")]
        public string TrafficMedium { get; set; }

        [JsonProperty("traffic_campaign")]
        public string TrafficCampaign { get; set; }

        [JsonProperty("traffic_value")]
        public string TrafficValue { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("available_for_mailing")]
        public bool AvailableForMailing { get; set; }

        [JsonProperty("legal_bases")]
        public List<LegalBasesRequest> LegalBases { get; set; }
    }
}
