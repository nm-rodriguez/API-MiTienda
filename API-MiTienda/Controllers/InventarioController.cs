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
    public class InventarioController : ControllerBase
    {
        private IManageInventarioService _manageService;

        public InventarioController(IManageInventarioService manageService)
        {
            _manageService = manageService;
        }

        #region GETS
        [HttpGet]
        public ActionResult<IEnumerable<InventarioDTO>> GetAllInventarios()
        {
            try
            {
                var inventarios = _manageService.GetInventarios();
                return Ok(inventarios);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal.");
            }
        }

        [HttpGet("getInventarioByIdOrDni")]
        public ActionResult<InventarioDTO> GetInventarioByIdorDni(int idordni)
        {
            try
            {
                var inventario = _manageService.GetInventarioByIdOrDni(idordni);

                if (inventario == null)
                    return NotFound($"No existe el inventario buscado. Por favor reintente su busqueda con un valor diferente.");

                return Ok(inventario);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal. Verifica el id.");
            }

        }

        [HttpGet("getInventarioByNombreOrCuil")]
        public ActionResult<InventarioDTO> GetInventarioByNombreOrCuil(string nombreOrcuil)
        {
            try
            {
                var inventario = _manageService.GetInventariosByNombreOrCuil(nombreOrcuil);

                if (inventario == null)
                    return NotFound($"No existe el inventario buscado. Por favor reintente su busqueda con un valor diferente.");

                return Ok(inventario);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal. Verifica el id.");
            }

        }

        #endregion


        [HttpPost]
        public ActionResult<InventarioDTO> PostInventario(InventarioDTO newInventario)
        {
            try
            {
                var message = _manageService.CreateInventario(newInventario);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }

        }

        [HttpPut]
        public ActionResult<InventarioDTO> UpdateInventario([FromBody] InventarioDTO inventario)
        {
            try
            {
                var message = _manageService.UpdateInventario(inventario);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }
        }

        [HttpDelete("{idInventario:int}")]
        public ActionResult<int> DeleteArticulo(int idInventario)
        {
            try
            {
                var message = _manageService.DeleteInventario(idInventario);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }
            
        }
    }
}
