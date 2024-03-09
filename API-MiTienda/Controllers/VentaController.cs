using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiTienda.Application.Contracts;
using MiTienda.Application.DTOs;
using MiTienda.Domain.Entities;
using System.Collections;
using System.Drawing;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private IManageVentaService _manageService;

        public VentaController(IManageVentaService manageService)
        {
            _manageService = manageService;
        }

        [HttpPost]
        public ActionResult<VentaPostDTO> PostVenta(VentaPostDTO venta)
        {
            try
            {
                var message = _manageService.CrearVenta(venta);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<VentaDTO>> GetAllVentas()
        {
            try
            {
                var ventas = _manageService.GetVentas();
                return Ok(ventas);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal.");
            }
        }



        [HttpGet("ventaID")]
        public ActionResult<ClienteDTO> GetVentaById(int id)
        {
            //try
            //{
            //    var cliente = _manageService.GetClienteByIdOrDni(idordni);

            //    if (cliente == null)
            //        return NotFound($"No existe el cliente buscado. Por favor reintente su busqueda con un valor diferente.");

            //    return Ok(cliente);
            //}
            //catch (Exception)
            //{
            return StatusCode(400, "Algo salió mal. Verifica el id.");
            //}

        }

      

        

        [HttpPut]
        public ActionResult<ClienteDTO> UpdateVenta([FromBody] VentaDTO venta)
        {
            //try
            //{
            //    var message = _manageService.UpdateCliente(cliente);
            //    return Ok(message);
            //}
            //catch (Exception ex)
            //{
            //return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            //}
            return StatusCode(400);
        }

        [HttpDelete("{ventaIDint}")]
        public ActionResult<int> DeleteVenta(int idVenta)
        {
            //try
            //{
            //    var message = _manageService.DeleteCliente(idCliente);
            //    return Ok(message);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            //}
            return StatusCode(400);

        }
    }
}
