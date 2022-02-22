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
        public async Task<IBusinessResult<PostEventResponse>> PostEvent(PostEventRequest postEventRequest)
        {
            // note: IGetByCustomerBuilder can be injected through class constructor as class member

            // add operations/steps with IGetByCustomerBuilder builder
            ServiceProviderHelper.GetService<IPostEventBuilder>()
                ?.Builder(pipeline);

            // run pipeline with package with content (int -> id)
            await pipeline.ExecuteAsync(postEventRequest.ToMessage());

            // try to get response content
            PostEventResponse result = pipeline.GetMessage()
                .GetContent<PostEventResponse>();

            // checks if there are any records
            if (result != null)
            {
                // reply with standard message for record not found
                return Messages.RECORD_NOT_FOUND
                    .ToMessageResult(MessageType.Error)
                        .ToBusiness<PostEventResponse>();
            }

            return result.ToBusiness();
        }

        #endregion
    }
}
