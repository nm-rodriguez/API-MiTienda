using Microsoft.AspNetCore.Mvc;
using MiTienda.Application.Contracts;
using MiTienda.Application.DTOs;
using MiTienda.Domain.Entities;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController: ControllerBase
    {
        private IManagePagoService _pagoService;

        public PagoController(IManagePagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpPost("realizarPago")]
        public ActionResult<Pago> PostPago([FromBody] PagoPostDTO pagoPost)
        {
            try
            {
                Pago pago = _pagoService.CrearPago(pagoPost);
                return pago;
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }
        }
    }
}
