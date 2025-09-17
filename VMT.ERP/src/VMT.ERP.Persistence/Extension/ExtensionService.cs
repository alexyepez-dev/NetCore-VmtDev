using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VMT.ERP.Persistence.Database;
using VMT.ERP.Persistence.UnitOfWork.Implements;
using VMT.ERP.Persistence.UnitOfWork.Interface;

namespace VMT.ERP.Persistence.Extension
{
    public static class ExtensionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            var connection = config.GetConnectionString("ConnectionDB");
            services.AddDbContext<BaseErpContext>(options => options.UseSqlServer(connection));

            services.AddUnitOfWork();

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorkService>();

            return services;
        }
    }
}