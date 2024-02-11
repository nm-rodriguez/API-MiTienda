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
            //var articulos = _queryServiceArticulo.GetAllWithRelatedData()
            //    .Include(a => a.Marca)
            //    .Include(a => a.Categoria);
            var articulos = _manageService.GetArticulos();

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
                _manageService.CreateArticulo(articulo);
                return CreatedAtAction("GetArticuloById", new { id = articulo.Id }, articulo.Id);
        }

        [HttpDelete("{idArticulo}")]
        public ActionResult<Articulo> DeleteArticulo(int idArticulo)
        {
            _manageService.DeleteArticulo(idArticulo);
            return Ok($"Articulo id: {idArticulo} eliminado");
        }

        [HttpPut]
        public ActionResult<Articulo> UpdateArticulo([FromBody] Articulo articulo)
        {
            _manageService.UpdateArticulo(articulo);
            return Ok($"Articulo id: {articulo} actualizado");
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
