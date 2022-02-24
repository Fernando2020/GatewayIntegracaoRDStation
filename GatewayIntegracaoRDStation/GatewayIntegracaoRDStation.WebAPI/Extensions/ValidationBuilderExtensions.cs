using FluentValidation;
using GatewayIntegracaoRDStation.Core.Validators.Events.CartAbandonment;
using GatewayIntegracaoRDStation.Core.Validators.Events.Conversion;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.CartAbandonment;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.Conversion;
using Microsoft.Extensions.DependencyInjection;

namespace GatewayIntegracaoRDStation.WebAPI.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ValidationBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<PostConversionRequest>, PostConversionRequestValidator>();
            services.AddSingleton<IValidator<PayloadConversionRequest>, PayloadConversionRequestValidator>();
            services.AddSingleton<IValidator<PostCartAbandonmentRequest>, PostCartAbandonmentRequestValidator>();
            services.AddSingleton<IValidator<PayloadCartAbandonmentRequest>, PayloadCartAbandonmentRequestValidator>();

            return services;
        }
    }
}
