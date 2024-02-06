using Microsoft.AspNetCore.Mvc;
using MiTienda.Application.Contracts;
using MiTienda.DataAccess.PersistenceEntities;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagoController: ControllerBase
    {

        private readonly IQueryService<TipoPagoDB> _queryService;
        private readonly IManageStockService _manageService;

        public TipoPagoController(IQueryService<TipoPagoDB> queryService, IManageStockService manageService)
        {
            _queryService = queryService;
            _manageService = manageService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoPagoDB>> Get()
        {
            var tipoPagos = _queryService.GetAll();
            return Ok(tipoPagos);
        }
    }
}
