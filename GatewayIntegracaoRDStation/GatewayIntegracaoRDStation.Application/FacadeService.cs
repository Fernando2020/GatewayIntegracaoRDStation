using GatewayIntegracaoRDStation.Core.Contract.Logic;
using Mvp24Hours.Helpers;

namespace GatewayIntegracaoRDStation.Application
{
    /// <summary>
    /// Provides all services available for use in this project
    /// </summary>
    public class FacadeService
    {
        #region [ Services ]
        /// <summary>
        /// <see cref="GatewayIntegracaoRDStation.Core.Contract.Logic.ICustomerService"/>
        /// </summary>
        public static ICustomerService CustomerService
        {
            get { return ServiceProviderHelper.GetService<ICustomerService>(); }
        }
        #endregion
    }
}
