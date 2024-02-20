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
    public class ClienteController : ControllerBase
    {
        private IManageClienteService _manageService;

        public ClienteController(IManageClienteService manageService)
        {
            _manageService = manageService;
        }

        #region GETS
        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTO>> GetAllClientes()
        {
            try
            {
                var clientes = _manageService.GetClientes();
                return Ok(clientes);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal.");
            }
        }

        [HttpGet("id/{idordni:int}")]
        public ActionResult<ClienteDTO> GetClienteByIdorDni(int idordni)
        {
            try
            {
                var cliente = _manageService.GetClienteByIdOrDni(idordni);

                if (cliente == null)
                    return NotFound($"No existe el cliente buscado. Por favor reintente su busqueda con un valor diferente.");

                return Ok(cliente);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal. Verifica el id.");
            }

        }

        #endregion


        [HttpPost]
        public ActionResult<ClienteDTO> PostCliente(ClienteDTO cliente)
        {
            try
            {
                var message = _manageService.CreateCliente(cliente);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }

        }

        [HttpPut]
        public ActionResult<ClienteDTO> UpdateCliente([FromBody] ClienteDTO cliente)
        {
            try
            {
                var message = _manageService.UpdateCliente(cliente);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }
        }
    }
}
