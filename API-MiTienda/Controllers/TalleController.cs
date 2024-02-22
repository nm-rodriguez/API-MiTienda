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
    public class TalleController : ControllerBase
    {
        private IManageTalleService _manageService;

        public TalleController(IManageTalleService manageService)
        {
            _manageService = manageService;
        }

        #region GETS
        [HttpGet]
        public ActionResult<IEnumerable<TalleDTO>> GetAllTalles()
        {
            try
            {
                var talles = _manageService.GetTalles();
                return Ok(talles);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal.");
            }
        }

        [HttpGet("id/{idordni:int}")]
        public ActionResult<TalleDTO> GetTalleById(int idTalle)
        {
            try
            {
                var talle = _manageService.GetTalleById(idTalle);

                if (talle == null)
                    return NotFound($"No existe el talle buscado. Por favor reintente su busqueda con un valor diferente.");

                return Ok(talle);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal. Verifica el id.");
            }

        }

        [HttpGet("nombreOrcuil/{nombreOrcuil}")]
        public ActionResult<TalleDTO> GetTalleByNombreOrCuil(string nombreOrcuil)
        {
            try
            {
                var talle = _manageService.GetTallesByNombreOrCuil(nombreOrcuil);

                if (talle == null)
                    return NotFound($"No existe el talle buscado. Por favor reintente su busqueda con un valor diferente.");

                return Ok(talle);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal. Verifica el id.");
            }

        }

        #endregion


        [HttpPost]
        public ActionResult<TalleDTO> PostTalle(TalleDTO newTalle)
        {
            try
            {
                var message = _manageService.CreateTalle(newTalle);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }

        }

        [HttpPut]
        public ActionResult<TalleDTO> UpdateTalle([FromBody] TalleDTO talle)
        {
            try
            {
                var message = _manageService.UpdateTalle(talle);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }
        }

        [HttpDelete("{idTalle:int}")]
        public ActionResult<int> DeleteArticulo(int idTalle)
        {
            try
            {
                var message = _manageService.DeleteTalle(idTalle);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Algo salió mal. Detalles: {ex.Message}");
            }
            
        }
    }
}
