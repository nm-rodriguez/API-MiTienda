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

        public TipoPagoController(IQueryService<TipoPago> queryService)
        {
            _queryService = queryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoPago>> Get()
        {
            var tipoPagos = _queryService.GetAll();
            return Ok(tipoPagos);
        }
    }
}
