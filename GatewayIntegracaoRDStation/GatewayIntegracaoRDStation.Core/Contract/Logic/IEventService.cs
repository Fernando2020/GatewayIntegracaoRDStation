using GatewayIntegracaoRDStation.Core.ValueObjects.Events;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using System.Threading.Tasks;

namespace GatewayIntegracaoRDStation.Core.Contract.Logic
{
    /// <summary>
    /// Represents event service
    /// </summary>
    public interface IEventService
    {
        Task<IBusinessResult<PostEventResponse>> PostEvents<T>(PostEventRequest<T> postEventRequest);
    }
}
