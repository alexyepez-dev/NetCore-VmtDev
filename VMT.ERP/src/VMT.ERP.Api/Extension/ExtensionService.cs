using VMT.ERP.Api.Configuration.RateLimiting;
using VMT.ERP.Application.Extension;
using VMT.ERP.Persistence.Extension;
using VMT.ERP.Utils.Cors;
using VMT.ERP.Utils.Exceptions;
using VMT.ERP.Utils.Extension;
using VMT.ERP.Utils.Helpers.Cors;

namespace VMT.ERP.Api.Extension
{
    public static class ExtensionService
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            var exception = typeof(ExceptionManager);

            services.AddControllers(options => options.Filters.Add(exception));

            services.AddRateLimiting(config);

            services.AddApplication().AddPersistence(config).AddUtils(config);
            services.AddCorsService();

            return services;
        }

        public static IApplicationBuilder AddApp(this IApplicationBuilder app)
        {
            var policie = CorsMessage.CorsPolicies;

            app.UseCors(policie);
            app.UseRateLimiter();
            app.UseAuthentication();

            return app;
        }
    }
}