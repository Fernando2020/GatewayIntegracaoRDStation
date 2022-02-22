using GatewayIntegracaoRDStation.Application.Pipe.Operations.Authentications;
using GatewayIntegracaoRDStation.Core.Contract.Pipe.Builders;
using Mvp24Hours.Core.Contract.Infrastructure.Pipe;

namespace GatewayIntegracaoRDStation.Application.Pipe.Builders
{
    public class PostEventBuilder : IPostEventBuilder
    {
        public IPipelineAsync Builder(IPipelineAsync pipeline) => pipeline
            .Add<GetCodeAuthStep>();

    }
}
