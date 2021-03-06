using FluentValidation.AspNetCore;
using GatewayIntegracaoRDStation.WebAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mvp24Hours.Extensions;
using Mvp24Hours.WebAPI.Extensions;

namespace GatewayIntegracaoRDStation.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            #region [ Mvp24Hours ]
            services.AddMvp24HoursWebEssential();
            services.AddMvp24HoursWebJson();
            services.AddMvp24HoursWebSwagger("Integration with RD Station API", xmlCommentsFileName: "GatewayIntegracaoRDStation.WebAPI.xml", enableExample: true);
            services.AddMvp24HoursWebGzip();
            services.AddMvp24HoursPipelineAsync();
            services.AddMvp24HoursCaching();
            services.AddMvp24HoursCachingRedis(Configuration.GetConnectionString("RedisDbContext"));
            #endregion

            services.AddMyTelemetry();
            services.AddMyServices(Configuration);
            services.AddValidations();

            services.AddControllers();
            services.AddMvc().AddFluentValidation();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // check environment
            app.UseMvp24HoursExceptionHandling();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (!env.IsProduction())
            {
                app.UseMvp24HoursSwagger("Integration with RD Station API");
            }

            app.UseMvp24Hours();
        }
    }
}
