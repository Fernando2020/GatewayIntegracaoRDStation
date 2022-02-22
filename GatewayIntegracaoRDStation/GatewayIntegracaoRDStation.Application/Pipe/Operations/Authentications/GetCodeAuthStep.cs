using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using System.Threading.Tasks;

namespace GatewayIntegracaoRDStation.Application.Pipe.Operations.Authentications
{
    public class GetCodeAuthStep : OperationBaseAsync
    {
        public override Task<IPipelineMessage> ExecuteAsync(IPipelineMessage input)
        {
            throw new System.NotImplementedException();
        }
    }
}
