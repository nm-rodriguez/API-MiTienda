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
        private  IManageArticuloService _manageService;

        public ArticuloController(IQueryService<Articulo> queryServiceArticulo, IQueryService<Marca> queryServiceMarca, IQueryService<Categoria> queryServiceCategoria, IManageArticuloService manageService)
        {
            _queryServiceArticulo = queryServiceArticulo;
            _manageService = manageService;
        }

        #region GETS
        [HttpGet]
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

        [HttpGet("id/{id}")]
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

        [HttpGet("codigo/{codigo}")]
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

                return StatusCode(400,"Algo salió mal. Verifica el código.");
            }
        }


        //0..n articulos con ese idCategoria
        //[HttpGet("articulos/{idCategoria}")]
        //public ActionResult<Articulo> GetArticulobByCategoria(int idCategoria)
        //{
        //    if (_queryServiceArticulo.GetAll() == null) 
        //        return NotFound();

        //    List<Articulo> articulo = _queryServiceArticulo
        //        .GetBy(a => a.Categoria.Id == idCategoria)
        //        .Include(a => a.Marca)
        //        .Include(a => a.Categoria)
        //        .ToList();

        //    if (articulo == null) 
        //        return NotFound();

        //    return Ok(articulo);
        //}

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


        [HttpDelete("{idArticulo}")]
        public ActionResult<ArticuloDTO> DeleteArticulo(int idArticulo)
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



        //[HttpGet("Marcas")]
        //public ActionResult<IEnumerable<Marca>> GetMarcas()
        //{
        //    var marcas = a.GetAllWithRelatedData();

        //    return Ok(marcas);
        //}
        //[HttpGet("Categorias")]
        //public ActionResult<IEnumerable<Categoria>> GetCategorias()
        //{
        //    var categorias = _queryServiceArticulo.GetAllWithRelatedData();
        //    return Ok(categorias);
        //}
    }
}
