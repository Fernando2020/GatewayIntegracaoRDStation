using GatewayIntegracaoRDStation.Core.Contract.Logic;
using Mvp24Hours.Helpers;

namespace GatewayIntegracaoRDStation.Application
{
    /// <summary>
    /// Provides all services available for use in this project
    /// </summary>
    public abstract class FacadeService
    {
        #region [ Services ]
        /// <summary>
        /// <see cref="GatewayIntegracaoRDStation.Core.Contract.Logic.ICustomerService"/>
        /// </summary>
        public static ICustomerService CustomerService
        {
            get { return ServiceProviderHelper.GetService<ICustomerService>(); }
        }
        /// <summary>
        /// <see cref="GatewayIntegracaoRDStation.Core.Contract.Logic.IEventService"/>
        /// </summary>
        public static IEventService EventService
        {
            get { return ServiceProviderHelper.GetService<IEventService>(); }
        }
        #endregion
    }
}
