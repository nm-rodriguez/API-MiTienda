using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiTienda.Application.Contracts;
using MiTienda.Application.DTOs;
using MiTienda.Domain.Entities;
using System.Collections;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IQueryService<Articulo> _queryServiceArticulo;
        private IManageArticuloService _manageService;

        public ArticuloController(IQueryService<Articulo> queryServiceArticulo, IQueryService<Marca> queryServiceMarca, IQueryService<Categoria> queryServiceCategoria, IManageArticuloService manageService)
        {
            _queryServiceArticulo = queryServiceArticulo;
            _manageService = manageService;
        }

        #region GETS
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsADMIN")]
        public ActionResult<IEnumerable<ArticuloDTO>> GetAllArticulos()
        {
            try
            {
                var articulos = _manageService.GetArticulos();
                return Ok(articulos);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal.");
            }
        }


        [HttpGet("getArticuloById")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsVendedor")]
        public ActionResult<Articulo> GetArticuloById(int id)
        {
            try
            {
                var articulo = _manageService.GetArticuloById(id);

                if (articulo == null)
                    return NotFound($"No existe el articulo con el id: {id}. Por favor ingrese un id valido.");

                return Ok(articulo);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal. Verifica el id.");
            }

        }

        [HttpGet("getArticuloByCodigoBarra")]
        public ActionResult<Articulo> GetArticuloByCodigo(string codigo)
        {
            try
            {
                var articulo = _manageService.GetArticuloByCodigoBarras(codigo);

                if (articulo == null)
                    return NotFound($"No existe el articulo con el codigo: {codigo}. Por favor ingrese un codigo de barras valido.");

                return Ok(articulo);
            }
            catch (Exception)
            {

                return StatusCode(400, "Algo salió mal. Verifica el código.");
            }
        }


        [HttpGet("getArticulosByCodigoBarra")]
        public ActionResult<Articulo> GetArticulosByCodigoBarra(string codigoBarra)
        {
            try
            {
                var articulos = _manageService.GetArticulosByCodigoBarras(codigoBarra);

                if (articulos == null)
                    return NotFound($"No existe combinaciones para el codigo buscado. Por favor reintente su busqueda con un valor diferente.");

                return Ok(articulos);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal. Verifica el Codigo de Barra.");
            }

        }

        [HttpGet("getArticulosByMarca")]
        public ActionResult<Articulo> GetArticulosByMarca(string? Marca)
        {
            try
            {
                var articulos = _manageService.GetArticulosByMarca(Marca);

                if (articulos == null)
                    return NotFound($"No existen articulos para la marca buscada. Por favor reintente su busqueda con un valor diferente.");

                return Ok(articulos);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal. Verifica el Codigo de Barra.");
            }

        }

        [HttpGet("getArticulosByCategoria")]
        public ActionResult<Articulo> GetArticulosByCategoria(string? Categoria)
        {
            try
            {
                var articulos = _manageService.GetArticulosByCategoria(Categoria);

                if (articulos == null)
                    return NotFound($"No existen articulos para la Categoria buscada. Por favor reintente su busqueda con un valor diferente.");

                return Ok(articulos);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal. Verifica el Codigo de Barra.");
            }

        }

        [HttpGet("getArticulosByFiltros")]
        public ActionResult<Articulo> GetArticulosFiltrados(string? codigoBarra = null, string? marca = null, string? categoria = null)
        {
            try
            {
                var articulos = _manageService.GetArticulosFiltrados(codigoBarra, marca, categoria);

                if (articulos == null)
                    return NotFound($"No existen articulos para la combinacion buscada. Por favor reintente su busqueda con un valor diferente.");

                return Ok(articulos);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal. Verifica el Codigo de Barra.");
            }

        }


        #endregion


        [HttpPost]
        //public async Task<ActionResult<ArticuloDB>> PostArticulo([FromBody] ArticuloDB articulo)
        public ActionResult<ArticuloDTO> PostArticulo([FromBody] ArticuloDTO articulo)
        {
            try
            {
                var message = _manageService.CreateArticulo(articulo);
                return Ok(message);
            }
            catch (Exception)
            {
                return StatusCode(400, "Algo salió mal.");
            }

        }


        [HttpDelete("DeleteArticulo")]
        public ActionResult<int> DeleteArticulo(int idArticulo)
        {
            var message = _manageService.DeleteArticulo(idArticulo);
            return Ok(message);
        }

        [HttpPut]
        public ActionResult<ArticuloDTO> UpdateArticulo([FromBody] ArticuloDTO articulo)
        {
            var message = _manageService.UpdateArticulo(articulo);
            return Ok(message);
        }


    }
}
