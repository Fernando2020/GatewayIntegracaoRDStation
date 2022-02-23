using GatewayIntegracaoRDStation.Application;
using GatewayIntegracaoRDStation.Core.ValueObjects.Customers;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.CartAbandonment;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.Conversion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using Mvp24Hours.Extensions;
using Mvp24Hours.WebAPI.Controller;
using System.Threading.Tasks;

namespace GatewayIntegracaoRDStation.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseMvpController
    {
        #region [ Actions / Resources ]

        /// <summary>
        /// Evento de conversão
        /// </summary>
        [HttpPost("PostConversion")]
        [ProducesResponseType(typeof(ActionResult<IBusinessResult<PostEventResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResult<IBusinessResult<PostEventResponse>>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IBusinessResult<PostEventResponse>>> Conversion(PostConversionRequest postConversionRequest)
        {
            var request = new PostEventRequest<PostConversionRequest>(postConversionRequest);

            var result = await FacadeService.EventService.PostEvents(request);

            if (NotificationContext.HasErrorNotifications)
            {
                return BadRequest(NotificationContext.ToBusiness<GetByIdCustomerResponse>());
            }

            return Ok(result);
        }

        /// <summary>
        /// Evento de abandono de carrinho
        /// </summary>
        [HttpPost("PostCartAbandonment")]
        [ProducesResponseType(typeof(ActionResult<IBusinessResult<PostEventResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResult<IBusinessResult<PostEventResponse>>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IBusinessResult<PostEventResponse>>> CartAbandonment(PostCartAbandonmentRequest postCartAbandonmentRequest)
        {
            var request = new PostEventRequest<PostCartAbandonmentRequest>(postCartAbandonmentRequest);

            var result = await FacadeService.EventService.PostEvents(request);

            if (NotificationContext.HasErrorNotifications)
            {
                return BadRequest(NotificationContext.ToBusiness<GetByIdCustomerResponse>());
            }
                
            return Ok(result);
        }

        #endregion
    }
}
