using Microsoft.AspNetCore.RateLimiting;

namespace VMT.ERP.Api.Configuration.RateLimiting
{
    public static class RateLimitingService
    {
        public static IServiceCollection AddRateLimiting(this IServiceCollection services)
        {
            services.AddRateLimiter(
                options => options
                .AddFixedWindowLimiter());

            return services;
        }
    }
}