using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VMT.ERP.Persistence.Database;

namespace VMT.ERP.Persistence.Extension
{
    public static class ExtensionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            var connection = config.GetConnectionString("ConnectionDB");
            services.AddDbContext<BaseErpContext>(options => options.UseSqlServer(connection));

            return services;
        }
    }
}