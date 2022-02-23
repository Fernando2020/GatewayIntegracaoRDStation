using GatewayIntegracaoRDStation.Application.Logic;
using GatewayIntegracaoRDStation.Application.Pipe.Builders;
using GatewayIntegracaoRDStation.Core.Contract.Logic;
using GatewayIntegracaoRDStation.Core.Contract.Pipe.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace GatewayIntegracaoRDStation.WebAPI.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();

            // pipeline - builders
            services.AddScoped<IPostEventBuilder, PostEventBuilder>();

            return services;
        }
    }
}
