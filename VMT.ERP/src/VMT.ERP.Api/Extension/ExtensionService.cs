using VMT.ERP.Api.Configuration.RateLimiting;
using VMT.ERP.Application.Extension;
using VMT.ERP.Persistence.Extension;
using VMT.ERP.Utils.Exception;

namespace VMT.ERP.Api.Extension
{
    public static class ExtensionService
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            var exception = typeof(ExceptionManager);

            services.AddControllers(options => options.Filters.Add(exception));

            services.AddRateLimiting(config);

            services.AddApplication().AddPersistence(config);

            return services;
        }

        public static IApplicationBuilder AddApp(this IApplicationBuilder app)
        {
            app.UseRateLimiter();

            return app;
        }
    }
}