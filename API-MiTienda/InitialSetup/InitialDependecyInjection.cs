using Microsoft.EntityFrameworkCore;
using MiTienda.Application.Contracts;
using MiTienda.Application.Services;
using MiTienda.DataAccess.Contexts;
using MiTienda.DataAccess.Contracts;
using MiTienda.DataAccess.Repositories;
using MiTienda.Domain.Contracts;

namespace API_MiTienda.InitialSetup
{
    public static class InitialDependecyInjection
    {
        //public static IServiceCollection InitialIjections(this IServiceCollection services, string configuration)
        //{
        //    services.AddControllers();

        //    services.AddEndpointsApiExplorer();
        //    services.AddSwaggerGen();

        //    services.AddDbContext<MiTiendaContexto>(
        //        options => options.UseSqlServer(configuration),
        //        ServiceLifetime.Scoped
        //        );
        //    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        //    //Generic queries
        //    services.AddScoped(typeof(IQueryService<>), typeof(QueryService<>));

        //    //Managers
        //    services.AddScoped<IManageStockService, StockManageService>();


        //    //servicios.AddSignalR(); VER QUE ES

        //    return services;
        //}
        public static IServiceCollection InitialCharges(this IServiceCollection servicios, string conectionString)
        {
            servicios.AddControllers();

            servicios.AddEndpointsApiExplorer();
            servicios.AddSwaggerGen();

            servicios.AddDbContext<ITiendaEF,MiTiendaContexto >(
                options => options.UseSqlServer(conectionString),
                ServiceLifetime.Scoped
                );

            servicios.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //Generic queries
            servicios.AddScoped(typeof(IQueryService<>), typeof(QueryService<>));

            //Managers
            servicios.AddScoped<IManageArticuloService, ArticuloManageService>();
            servicios.AddScoped<IManageStockService, StockManageService>();

            return servicios;
        }

    }
}
