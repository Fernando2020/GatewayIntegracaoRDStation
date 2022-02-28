using GatewayIntegracaoRDStation.Core.Contract.Logic;
using GatewayIntegracaoRDStation.Core.Contract.Pipe.Builders;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events;
using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using Mvp24Hours.Extensions;
using Mvp24Hours.Helpers;
using System.Threading.Tasks;

namespace GatewayIntegracaoRDStation.Application.Logic
{
    public class EventService : IEventService
    {
        #region [ Fields / Properties ]

        private readonly IPipelineAsync pipeline;

        #endregion

        #region [ Ctors ]

        /// <summary>
        /// 
        /// </summary>
        public EventService(IPipelineAsync _pipeline)
        {
            pipeline = _pipeline;
        }

        #endregion

        #region [ Actions ]
        public async Task<IBusinessResult<PostEventResponse>> PostEvents<T>(PostEventRequest<T> postEventRequest)
        {
            ServiceProviderHelper.GetService<IPostEventBuilder>()
                ?.Builder(pipeline);

            var pipelineMessage = postEventRequest.Code.ToMessage("code");
            
            pipelineMessage.AddContent("data", postEventRequest.Data);

            await pipeline.ExecuteAsync(pipelineMessage);

            var message = pipeline.GetMessage();

            if (message.IsFaulty)
            {
                return message
                    .Messages
                    .ToBusiness<PostEventResponse>();
            }

            return message
                .GetContent<PostEventResponse>()
                .ToBusiness();
        }

        #endregion
    }
}
