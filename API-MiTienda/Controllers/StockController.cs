using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiTienda.DataAccess.Contexts;
using System.Collections;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private MiTiendaContexto _context;

        public StockController(MiTiendaContexto context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> Get()
        {
            var stocks = await _context.Stocks
                .Include(a => a.Talle)
                .Include(a => a.Color)
                .Include(a => a.Articulo).ThenInclude(s => s.Marca )
                .Include(a => a.Articulo).ThenInclude(s => s.Categoria)
                .ToListAsync();
            return stocks;
        }
    }
}
