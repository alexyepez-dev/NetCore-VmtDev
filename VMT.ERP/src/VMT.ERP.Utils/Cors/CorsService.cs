using Microsoft.Extensions.DependencyInjection;
using VMT.ERP.Utils.Environments;
using VMT.ERP.Utils.Helpers.Cors;

namespace VMT.ERP.Utils.Cors
{
    public static class CorsService
    {
        public static IServiceCollection AddCorsService(this IServiceCollection services)
        {
            var policie = CorsMessage.CorsPolicies;
            var url = UrlClient.UrlEnvironmentClient;
            services
                .AddCors(options => options
                .AddPolicy(policie, policy => policy
                .WithOrigins(url)
                .AllowAnyHeader()
                .AllowAnyMethod()
            ));

            return services;
        }
    }
}