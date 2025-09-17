using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VMT.ERP.Utils.Guards;
using VMT.ERP.Utils.Helpers.Jwt;
using VMT.ERP.Utils.Interfaces.Token.AccessToken;
using VMT.ERP.Utils.Interfaces.Token.Configuration;
using VMT.ERP.Utils.Security.Models.Jwt;
using VMT.ERP.Utils.Security.Token.AccessToken;
using VMT.ERP.Utils.Security.Token.Configuration;

namespace VMT.ERP.Utils.Extension
{
    public static class ExtensionService
    {
        public static IServiceCollection AddUtils(this IServiceCollection services, IConfiguration config)
        {
            services.AddTokenService(config);
            services.AddAuthenticationService(config);

            return services;
        }

        public static IServiceCollection AddTokenService(this IServiceCollection services, IConfiguration config)
        {
            var sectionJwt = config.GetSection("JwtSettings");
            services.Configure<JwtSettings>(sectionJwt);

            services.AddScoped<ITokenConfigurationService, TokenConfigurationService>();
            services.AddScoped<IAccessTokenService, AccessTokenService>();

            return services;
        }

        public static IServiceCollection AddAuthenticationService(this IServiceCollection services, IConfiguration config)
        {
            var jwtSettings = config.GetSection("JwtSettings").Get<JwtSettings>();

            var jwtSettingsConfigMessage = JwtMessage.JwtSettingsConfigMessage;
            Guard.NotNull(jwtSettings, jwtSettingsConfigMessage);

            var sectionKey = jwtSettings!.Key;
            var keyConfigMessage = JwtMessage.KeyConfigMessage;
            Guard.NotNullOrEmpty(sectionKey, keyConfigMessage);

            var sectionIssuer = jwtSettings!.Issuer;
            var issuerConfigMessage = JwtMessage.IssuerConfigMessage;
            Guard.NotNullOrEmpty(sectionIssuer, issuerConfigMessage);

            var sectionAudience = jwtSettings!.Audience;
            var audienceConfigMessage = JwtMessage.AudienceConfigMessage;
            Guard.NotNullOrEmpty(sectionAudience, audienceConfigMessage);

            var jwtBearer = JwtBearerDefaults.AuthenticationScheme;
            services
                .AddAuthentication(jwtBearer)
                .AddJwtBearer(options =>
                {
                    var validateIssuerKey = true;
                    var key = config["JwtSettings:Key"]!;
                    var encoding = Encoding.UTF8.GetBytes(key);
                    var issuerSigningKey = new SymmetricSecurityKey(encoding);

                    var validateIssuer = true;
                    var issuer = config["JwtSettings:Issuer"];

                    var validateAudience = true;
                    var audience = config["JwtSettings:Audience"];

                    var lifeTime = true;

                    var clock = TimeSpan.Zero;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = validateIssuerKey,
                        IssuerSigningKey = issuerSigningKey,

                        ValidateIssuer = validateIssuer,
                        ValidIssuer = issuer,

                        ValidateAudience = validateAudience,
                        ValidAudience = audience,

                        ValidateLifetime = lifeTime,

                        ClockSkew = clock
                    };
                });

            return services;
        }
    }
}