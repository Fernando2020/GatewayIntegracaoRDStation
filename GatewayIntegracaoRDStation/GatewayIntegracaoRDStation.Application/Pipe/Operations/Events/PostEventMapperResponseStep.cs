using GatewayIntegracaoRDStation.Core.Resources;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events;
using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Extensions;
using Mvp24Hours.Infrastructure.Pipe.Operations.Custom;
using System.Threading.Tasks;

namespace GatewayIntegracaoRDStation.Application.Pipe.Operations.Events
{
    public class PostEventMapperResponseStep : OperationMapperAsync<PostEventResponse>
    {
        public override async Task<PostEventResponse> MapperAsync(IPipelineMessage input)
        {
            if (!input.HasContent("postEventResponse"))
            {
                input.Messages.AddMessage("postEventResponse", Messages.RECORD_NOT_FOUND, Mvp24Hours.Core.Enums.MessageType.Error);
                return await Task.FromResult<PostEventResponse>(default);
            }

            var result = input.GetContent<PostEventResponse>("postEventResponse");

            return await result.TaskResult();
        }
    }
}
