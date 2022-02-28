using FluentValidation;
using GatewayIntegracaoRDStation.Application.Logic;
using GatewayIntegracaoRDStation.Application.Pipe.Builders;
using GatewayIntegracaoRDStation.Application.Pipe.Operations.Authentications;
using GatewayIntegracaoRDStation.Core.Contract.Logic;
using GatewayIntegracaoRDStation.Core.Contract.Pipe.Builders;
using GatewayIntegracaoRDStation.Core.Validators.Events.CartAbandonment;
using GatewayIntegracaoRDStation.Core.Validators.Events.Conversion;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.CartAbandonment;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events.Conversion;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Mvp24Hours.Core.Enums.Infrastructure;
using Mvp24Hours.Core.Extensions;
using Mvp24Hours.Extensions;
using NLog;
using System;
using System.Linq;

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
            services.AddScoped<GetAccessTokenAuthStep>(sp =>
            {
                return new GetAccessTokenAuthStep(sp.GetRequiredService<IDistributedCache>());
            });

            // pipeline - builders
            services.AddScoped<IPostEventBuilder, PostEventBuilder>();

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<PostConversionRequest>, PostConversionRequestValidator>();
            services.AddSingleton<IValidator<PayloadConversionRequest>, PayloadConversionRequestValidator>();
            services.AddSingleton<IValidator<PostCartAbandonmentRequest>, PostCartAbandonmentRequestValidator>();
            services.AddSingleton<IValidator<PayloadCartAbandonmentRequest>, PayloadCartAbandonmentRequestValidator>();

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddMyTelemetry(this IServiceCollection services)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
#if DEBUG
            services.AddMvp24HoursTelemetry(TelemetryLevel.Verbose,
                (name, state) =>
                {
                    if (name.EndsWith("-object"))
                    {
                        logger.Trace($"{name}|body:{state.ToSerialize()}");
                    }
                    else
                    {
                        logger.Trace($"{name}|{string.Join("|", state)}");
                    }
                }
            );
#endif
            services.AddMvp24HoursTelemetry(TelemetryLevel.Error,
                (name, state) =>
                {
                    if (name.EndsWith("-failure"))
                    {
                        logger.Error(state.ElementAtOrDefault(0) as Exception);
                    }
                    else
                    {
                        logger.Error($"{name}|{string.Join("|", state)}");
                    }
                }
            );
            return services;
        }
    }
}
