using MiTienda.Application.Contracts;
using MiTienda.DataAccess.Contexts;

namespace MiTienda.Application.Services
{
    public class StockManageService : IManageStockService
    {
        private readonly MiTiendaContexto _context;

        public StockManageService(MiTiendaContexto context)
        {
            _context = context;
        }

        public void CreateStock(string idStock)
        {
            throw new NotImplementedException();
        }

        public void DeleteStock(string idStock)
        {
            throw new NotImplementedException();
        }

        public void UpdateStock(string idStock)
        {
            throw new NotImplementedException();
        }
    }
}
