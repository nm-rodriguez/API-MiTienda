using MiTienda.Application.Contracts;
using MiTienda.DataAccess.Contexts;

namespace MiTienda.Application.Services
{
    public class ArticuloManageService : IManageArticuloService
    {
        private readonly MiTiendaContexto _context;

        public ArticuloManageService(MiTiendaContexto context)
        {
            _context = context;
        }

        public void CreateArticulo(string idStock)
        {
            throw new NotImplementedException();
        }

        public void CreateStock(string idStock)
        {
            throw new NotImplementedException();
        }

        public void DeleteArticulo(string idStock)
        {
            throw new NotImplementedException();
        }

        public void DeleteStock(string idStock)
        {
            throw new NotImplementedException();
        }

        public void UpdateArticulo(string idStock)
        {
            throw new NotImplementedException();
        }

        public void UpdateStock(string idStock)
        {
            throw new NotImplementedException();
        }
    }
}
