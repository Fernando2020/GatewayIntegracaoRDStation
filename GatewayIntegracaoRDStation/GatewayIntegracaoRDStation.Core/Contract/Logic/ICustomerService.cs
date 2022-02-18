using GatewayIntegracaoRDStation.Core.ValueObjects.Customers;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GatewayIntegracaoRDStation.Core.Contract.Logic
{
    /// <summary>
    /// Represents customer service
    /// </summary>
    public interface ICustomerService
    {
        Task<IBusinessResult<IList<GetByCustomerResponse>>> GetBy(GetByCustomerFilterRequest filter);
        Task<IBusinessResult<GetByIdCustomerResponse>> GetById(int id);
    }
}
