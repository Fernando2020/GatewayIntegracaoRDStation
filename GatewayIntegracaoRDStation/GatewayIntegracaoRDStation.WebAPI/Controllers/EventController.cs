using GatewayIntegracaoRDStation.Application;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.CartAbandonment;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.Conversion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using System.Threading.Tasks;

namespace GatewayIntegracaoRDStation.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        #region [ Actions / Resources ]

        /// <summary>
        /// Evento de conversão
        /// </summary>
        [HttpPost("PostConversion/{code}")]
        [ProducesResponseType(typeof(ActionResult<IBusinessResult<PostEventResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResult<IBusinessResult<PostEventResponse>>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IBusinessResult<PostEventResponse>>> Conversion(string code, [FromBody] PostConversionRequest postConversionRequest)
        {
            var request = new PostEventRequest<PostConversionRequest>(code, postConversionRequest);

            var result = await FacadeService.EventService.PostEvents(request);

            if (result.HasErrors)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Evento de abandono de carrinho
        /// </summary>
        [HttpPost("PostCartAbandonment/{code}")]
        [ProducesResponseType(typeof(ActionResult<IBusinessResult<PostEventResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResult<IBusinessResult<PostEventResponse>>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IBusinessResult<PostEventResponse>>> CartAbandonment(string code, [FromBody] PostCartAbandonmentRequest postCartAbandonmentRequest)
        {
            var request = new PostEventRequest<PostCartAbandonmentRequest>(code, postCartAbandonmentRequest);

            var result = await FacadeService.EventService.PostEvents(request);

            if (result.HasErrors)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        #endregion
    }
}
