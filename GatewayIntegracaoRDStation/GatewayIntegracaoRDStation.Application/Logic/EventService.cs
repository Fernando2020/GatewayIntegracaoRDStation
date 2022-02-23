using GatewayIntegracaoRDStation.Core.Contract.Logic;
using GatewayIntegracaoRDStation.Core.Contract.Pipe.Builders;
using GatewayIntegracaoRDStation.Core.Resources;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events;
using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using Mvp24Hours.Core.Enums;
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

            await pipeline.ExecuteAsync(postEventRequest.Data.ToMessage("data"));

            PostEventResponse result = pipeline.GetMessage()
                .GetContent<PostEventResponse>();

            if (result == null)
            {
                return Messages.RECORD_NOT_FOUND
                    .ToMessageResult(MessageType.Error)
                        .ToBusiness<PostEventResponse>();
            }

            return result.ToBusiness();
        }

        #endregion
    }
}
