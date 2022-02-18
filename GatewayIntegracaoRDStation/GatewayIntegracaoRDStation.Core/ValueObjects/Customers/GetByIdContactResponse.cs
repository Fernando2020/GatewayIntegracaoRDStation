using GatewayIntegracaoRDStation.Core.Enums;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Customers
{
    public class GetByIdContactResponse
    {
        public ContactType Type { get; set; }
        public string Description { get; set; }
    }
}
