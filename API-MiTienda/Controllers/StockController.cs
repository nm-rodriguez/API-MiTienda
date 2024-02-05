using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiTienda.Application.Contracts;
using MiTienda.DataAccess.Contexts;
using MiTienda.DataAccess.PersistenceEntities;
using System.Collections;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IQueryService<StockDB> _querysService;
        private IManageStockService _manageService;

        public StockController(IQueryService<StockDB> querysService, IManageStockService manageService)
        {
            _querysService = querysService;
            _manageService = manageService;
        }

        [HttpGet]
        //public async Task<ActionResult<IEnumerable>> Get()
        public IEnumerable<StockDB> Get()
        {
            var stocks = /*await*/ _querysService.GetAll();

            //.Include(a => a.Talle)
            //.Include(a => a.Color)
            //.Include(a => a.Articulo).ThenInclude(s => s.Marca)
            //.Include(a => a.Articulo).ThenInclude(s => s.Categoria)
            //.ToListAsync();
            return stocks;
            //return Ok();
        }
    }
}
