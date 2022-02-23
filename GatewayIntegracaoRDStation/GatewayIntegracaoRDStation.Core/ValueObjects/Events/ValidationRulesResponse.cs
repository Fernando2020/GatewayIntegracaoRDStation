using Newtonsoft.Json;
using System.Collections.Generic;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class ValidationRulesResponse
    {
        [JsonProperty("valid_options")]
        public List<string> ValidOptions { get; set; }
    }
}
