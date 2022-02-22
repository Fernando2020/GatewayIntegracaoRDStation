using GatewayIntegracaoRDStation.Core.ValueObjects.Customers;
using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Pipe.Operations.Custom;
using System.Threading.Tasks;

namespace GatewayIntegracaoRDStation.Application.Pipe.Operations.Authentications
{
    public class GetCodeAuthMapperResponseStep : OperationMapperAsync<GetByCustomerResponse>
    {
        public override Task<GetByCustomerResponse> MapperAsync(IPipelineMessage input)
        {
            throw new System.NotImplementedException();
        }
    }
}
