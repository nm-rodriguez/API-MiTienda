using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiTienda.Application.Contracts;

using MiTienda.Domain.Entities;
using System.Collections;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IQueryService<Articulo> _queryServiceArticulo;
        private readonly IQueryService<Marca> _queryServiceMarca;
        private readonly IQueryService<Categoria> _queryServiceCategoria;
        private  IManageArticuloService _manageService;

        public ArticuloController(IQueryService<Articulo> queryServiceArticulo, IQueryService<Marca> queryServiceMarca, IQueryService<Categoria> queryServiceCategoria, IManageArticuloService manageService)
        {
            _queryServiceArticulo = queryServiceArticulo;
            _queryServiceMarca = queryServiceMarca;
            _queryServiceCategoria = queryServiceCategoria;
            _manageService = manageService;
        }



        #region GETS
        [HttpGet]
        public ActionResult<IEnumerable<Articulo>> GetAllArticulos()
        {
            var articulos = _queryServiceArticulo.GetAllWithRelatedData()
                .Include(a => a.Marca)
                .Include(a => a.Categoria);
            
                return Ok(articulos);
        }

        [HttpGet("{id}")]
        public ActionResult<Articulo> GetArticuloById(int id)
        {
            if (_queryServiceArticulo.GetAll() == null)
                return NotFound();
            
            var articulo = _queryServiceArticulo
                    .GetBy(a => a.Id == id)
                    .Include(a => a.Marca)
                    .Include(a => a.Categoria)
                    .SingleOrDefault();

            if (articulo == null)
                return NotFound();

            return Ok(articulo);
        }

        //0..n articulos con ese idCategoria
        [HttpGet("articulos/{idCategoria}")]
        public ActionResult<Articulo> GetArticulobByCategoria(int idCategoria)
        {
            if (_queryServiceArticulo.GetAll() == null) 
                return NotFound();

            List<Articulo> articulo = _queryServiceArticulo
                .GetBy(a => a.Categoria.Id == idCategoria)
                .Include(a => a.Marca)
                .Include(a => a.Categoria)
                .ToList();

            if (articulo == null) 
                return NotFound();

            return Ok(articulo);
        }

        #endregion


        [HttpPost]
        //public async Task<ActionResult<ArticuloDB>> PostArticulo([FromBody] ArticuloDB articulo)
        public ActionResult<Articulo> PostArticulo([FromBody] Articulo articulo)
        {

            try
            {
                if (_queryServiceArticulo.GetBy(x => x.Id == articulo.Id) == null)
                    return Problem("Entity set 'MiTiendaContexto.Articulos'  is null.");

                if (articulo == null)
                    return StatusCode(400, "Falta articulo");


                //buscar la manera de que muestre error cuando se carga un id incorrecto 
                articulo.Marca = (Marca)_queryServiceMarca.GetBy(x => x.Id == articulo.Marca.Id).SingleOrDefault();
                articulo.Categoria = (Categoria)_queryServiceCategoria.GetBy(x => x.Id == articulo.Categoria.Id).SingleOrDefault();
                articulo.PrecioFinal = articulo.Costo * (1 + articulo.MargenGanancia);
                articulo.NetoGravado = articulo.Costo * (articulo.MargenGanancia);


                _manageService.CreateArticulo(articulo);
                _manageService.SaveArticulo();

                return CreatedAtAction("GetArticuloById", new { id = articulo.Id }, articulo.Id);
                //return Ok($"Articulo registrado: {articulo.Descripcion}");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Se produjo un error interno: {e.Message}");
            }
        }

        [HttpDelete]
        public ActionResult<Articulo> DeleteArticulo(int idArticulo)
        {
            _manageService.DeleteArticulo(idArticulo);
            return Ok($"Articulo id: {idArticulo} eliminado");
        }



        //[HttpGet("Marcas")]
        //public ActionResult<IEnumerable<Marca>> GetMarcas()
        //{
        //    var marcas = _queryServiceArticulo.GetAllWithRelatedData();

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
