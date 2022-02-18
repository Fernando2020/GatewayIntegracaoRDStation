using GatewayIntegracaoRDStation.Application.Pipe.Operations.Customers;
using GatewayIntegracaoRDStation.Core.Contract.Pipe.Builders;
using Mvp24Hours.Core.Contract.Infrastructure.Pipe;

namespace GatewayIntegracaoRDStation.Application.Pipe.Builders
{
    public class GetByIdCustomerBuilder : IGetByIdCustomerBuilder
    {
        public IPipelineAsync Builder(IPipelineAsync pipeline) => pipeline
            .Add<GetCustomerClientStep>()
            .Add<GetByIdCustomerMapperResponseStep>();
    }
}
