using MiTienda.Application.Contracts;
using MiTienda.Application.Services;
using MiTienda.DataAccess.Repositories;
using MiTienda.Domain.Contracts;

namespace API_MiTienda.InitialSetup
{
    public static class InitialDependecyInjection
    {
        public static IServiceCollection InitialIjections(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //Generic queries
            services.AddScoped(typeof(IQueryService<>), typeof(QueryService<>));
           
            //Managers
            services.AddScoped<IManageStockService, StockManageService>();


            //servicios.AddSignalR(); VER QUE ES

            return services;
        }
    }
}
