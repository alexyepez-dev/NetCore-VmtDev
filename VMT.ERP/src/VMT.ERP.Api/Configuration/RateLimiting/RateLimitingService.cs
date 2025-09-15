using Microsoft.AspNetCore.RateLimiting;
using System.Text.Json;
using System.Threading.RateLimiting;
using VMT.ERP.Utils.Guards;
using VMT.ERP.Utils.Helpers.Api;
using VMT.ERP.Utils.Helpers.Message;
using VMT.ERP.Utils.Helpers.RateLimit;
using VMT.ERP.Utils.RateLimiting.Options;
using VMT.ERP.Utils.RateLimiting.Policies;

namespace VMT.ERP.Api.Configuration.RateLimiting
{
    public static class RateLimitingService
    {
        public static IServiceCollection AddRateLimiting(this IServiceCollection services, IConfiguration config)
        {
            var limitOptions = GeneralRateLimitOptions.RateLimiting;
            var limitPolicies = GeneralRateLimitPolicies.RateLimitPolicies;

            var getSectionLimitOptions = config.GetSection(limitOptions);
            var getSectionLimitPolicies = config.GetSection(limitPolicies);

            services.Configure<GeneralRateLimitOptions>(getSectionLimitOptions);
            services.Configure<GeneralRateLimitPolicies>(getSectionLimitPolicies);

            var optionsOfRateLimiting = new GeneralRateLimitOptions();
            var policiesOfRateLimiting = new GeneralRateLimitPolicies();

            config.GetSection(limitOptions).Bind(optionsOfRateLimiting);
            config.GetSection(limitPolicies).Bind(policiesOfRateLimiting);

            services.AddRateLimiter(options =>
            {
                #region FixedPolicyUtils
                var fixedPolicy = policiesOfRateLimiting.FixedPolicy;
                var fixedPolicyMessage = RateLimitMessage.FixedPolicyMessage;
                var fixedPolicyGuard = Guard.NotNull(fixedPolicy, fixedPolicyMessage);
                #endregion

                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;

                    var hasRetryAfter = context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter);

                    var response = new ApiResponse<object>(
                        false,
                        ResponseStatusCode.TooManyRequests,
                        ResponseStatusCode.TooManyRequestsMessage,
                        hasRetryAfter
                            ? $"Demasiadas solicitudes. Intenta de nuevo en {retryAfter.TotalSeconds} segundos."
                            : "Demasiadas solicitudes. Intenta de nuevo más tarde.",
                        null!
                    );

                    var json = JsonSerializer.Serialize(response);
                    await context.HttpContext.Response.WriteAsync(json, token);
                };

                options.AddFixedWindowLimiter(fixedPolicyGuard, opt =>
                {
                    var value = optionsOfRateLimiting.Window;
                    var permitLimit = optionsOfRateLimiting.PermitLimit;
                    var time = TimeSpan.FromSeconds(value);
                    var queue = QueueProcessingOrder.OldestFirst;

                    opt.PermitLimit = permitLimit;
                    opt.Window = time;
                    opt.QueueProcessingOrder = queue;
                });

                options.AddSlidingWindowLimiter(policiesOfRateLimiting.SlidingPolicy ?? throw new InvalidOperationException(), opt =>
                {
                    var value = optionsOfRateLimiting.Window;
                    var permitLimit = optionsOfRateLimiting.PermitLimit;
                    var time = TimeSpan.FromSeconds(value);
                    var queue = QueueProcessingOrder.OldestFirst;
                    var segments = optionsOfRateLimiting.SegmentsPerWindow;

                    opt.PermitLimit = permitLimit;
                    opt.Window = time;
                    opt.QueueProcessingOrder = queue;
                    opt.SegmentsPerWindow = segments;
                });

                options.AddTokenBucketLimiter(policiesOfRateLimiting.TokenPolicy ?? throw new InvalidOperationException(), opt =>
                {
                    var value = optionsOfRateLimiting.ReplenishmentPeriod;
                    var time = TimeSpan.FromSeconds(value);
                    var queue = QueueProcessingOrder.OldestFirst;
                    var tokenPeriod = optionsOfRateLimiting.TokensPerPeriod;
                    var tokenLimit = optionsOfRateLimiting.TokenLimit;

                    opt.TokenLimit = tokenLimit;
                    opt.ReplenishmentPeriod = time;
                    opt.QueueProcessingOrder = queue;
                    opt.TokensPerPeriod = tokenPeriod;
                });

                options.AddConcurrencyLimiter(policiesOfRateLimiting.ConcurrencyPolicy ?? throw new InvalidOperationException(), opt =>
                {
                    var permitLimit = optionsOfRateLimiting.PermitLimit;
                    var queue = QueueProcessingOrder.OldestFirst;

                    opt.PermitLimit = permitLimit;
                    opt.QueueProcessingOrder = queue;
                });

                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                {
                    var global = "Global";
                    var permitLimit = optionsOfRateLimiting.GlobalPermitLimit;
                    var value = optionsOfRateLimiting.Window;
                    var time = TimeSpan.FromSeconds(value);
                    var queue = QueueProcessingOrder.OldestFirst;

                    var configOfFixedWindow = new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = permitLimit,
                        Window = time,
                        QueueProcessingOrder = queue
                    };

                    return RateLimitPartition.GetFixedWindowLimiter(global, partition => configOfFixedWindow);
                });

                options.GlobalLimiter = PartitionedRateLimiter.CreateChained(
                    PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    {
                        var userAgent = httpContext.Request.Headers.UserAgent.ToString();
                        var permitLimit = optionsOfRateLimiting.PartitionedPermitLimit;
                        var value = optionsOfRateLimiting.Window;
                        var time = TimeSpan.FromMinutes(value);
                        var queue = QueueProcessingOrder.OldestFirst;

                        var configOfFixedWindow = new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = permitLimit,
                            Window = time,
                            QueueProcessingOrder = queue
                        };

                        return RateLimitPartition.GetFixedWindowLimiter(userAgent, partition => configOfFixedWindow);
                    }),

                    PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    {
                        var userAgent = httpContext.Request.Headers.UserAgent.ToString();
                        var permitLimit = optionsOfRateLimiting.GlobalPermitLimit;
                        var value = 1;
                        var time = TimeSpan.FromHours(value);
                        var queue = QueueProcessingOrder.OldestFirst;

                        var configOfFixedWindow = new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = permitLimit,
                            Window = time,
                            QueueProcessingOrder = queue
                        };

                        return RateLimitPartition.GetFixedWindowLimiter(userAgent, partition => configOfFixedWindow);
                    })
                );
            });

            return services;
        }
    }
}