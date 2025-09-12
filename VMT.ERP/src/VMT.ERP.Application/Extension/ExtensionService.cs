using Microsoft.Extensions.DependencyInjection;
using VMT.ERP.Application.Bll.User;
using VMT.ERP.Application.Interfaces.User;

namespace VMT.ERP.Application.Extension
{
    public static class ExtensionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IGetAllUserBll, GetAllUserBll>();

            return services;
        }
    }
}