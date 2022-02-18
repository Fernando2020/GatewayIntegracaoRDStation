using System.Collections.Generic;

namespace GatewayIntegracaoRDStation.Core.ValueObjects.Customers
{
    public class GetByIdCustomerResponse : GetByCustomerResponse
    {
        public IList<GetByIdContactResponse> Contacts { get; set; }
    }
}
