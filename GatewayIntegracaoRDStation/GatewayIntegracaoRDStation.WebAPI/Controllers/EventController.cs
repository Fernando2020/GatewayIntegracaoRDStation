using GatewayIntegracaoRDStation.Application;
using GatewayIntegracaoRDStation.Core.ValueObjects.Customers;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events;
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
        /// Event
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ActionResult<IBusinessResult<PostEventResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResult<IBusinessResult<PostEventResponse>>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ActionResult<IBusinessResult<PostEventResponse>>), StatusCodes.Status400BadRequest)]
        [Route("", Name = "EventPost")]
        public async Task<ActionResult<IBusinessResult<PostEventResponse>>> EventPost(PostEventRequest postEventRequest)
        {
            var result = await FacadeService.EventService.PostEvent(postEventRequest);
            // checks for failure in the notification context
            if (NotificationContext.HasErrorNotifications)
            {
                return BadRequest(NotificationContext.ToBusiness<GetByIdCustomerResponse>());
            }
            else if (result.HasData())
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        #endregion
    }
}
