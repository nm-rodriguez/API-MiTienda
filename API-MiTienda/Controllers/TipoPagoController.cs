using Microsoft.AspNetCore.Mvc;
using MiTienda.Application.Contracts;
using MiTienda.Domain.Entities;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagoController: ControllerBase
    {

        private readonly IQueryService<TipoPago> _queryService;
        private readonly IManageArticuloService _manageService;

        public TipoPagoController(IQueryService<TipoPago> queryService, IManageArticuloService manageService)
        {
            _queryService = queryService;
            _manageService = manageService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoPago>> Get()
        {
            var tipoPagos = _queryService.GetAll();
            return Ok(tipoPagos);
        }
    }
}
