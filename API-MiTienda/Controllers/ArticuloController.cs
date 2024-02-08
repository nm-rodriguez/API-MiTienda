using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiTienda.Application.Contracts;
using MiTienda.DataAccess.Contexts;

using MiTienda.Domain.Entities;
using System.Collections;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IQueryService<Articulo> _queryService;
        private readonly IManageArticuloService _manageService;

        public ArticuloController(IQueryService<Articulo> queryService, IManageArticuloService manageService)
        {
            _queryService = queryService;
            _manageService = manageService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Articulo>> GetAllArticulos()
        {
            var articulos = _queryService.GetAllWithRelatedData()
                .Include(a => a.Marca)
                .Include(a => a.Categoria);
            
                return Ok(articulos);
        }

        [HttpGet("Marcas")]
        public ActionResult<IEnumerable<Articulo>> GetMarcas()
        {
            var marcas = _queryService.GetAllWithRelatedData();

            return Ok(marcas);
        }
        [HttpGet("Categorias")]
        public async Task<ActionResult<IEnumerable>> GetCategorias()
        {
            var categorias = _queryService.GetAllWithRelatedData();
            return Ok(categorias);
        }


        [HttpGet("{id}")]
        public  ActionResult<Articulo> GetArticulo(int id)
        {
            if (_queryService.GetAll() == null)
            {
                return NotFound();
            }
            Articulo? articulo =  _queryService.GetBy(a => a.Id == id).SingleOrDefault();

            //var articulo = await _queryService.GetAllWithRelatedData()
            //    .Include(a => a.Marca)
            //    .Include(a => a.Categoria)
            //    .FirstOrDefaultAsync<Articulo>(x => x.Id == id);

            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(articulo);
        }

        [HttpGet("articulos/{idCat}")]
        public  ActionResult<Articulo> GetArticulobByCategoria(int idCat)
        {
            if (_queryService.GetAll() == null)
            {
                return NotFound();
            }
            List<Articulo> articulo =  _queryService.GetBy(a => a.Categoria.Id == idCat).ToList();

            //var articulo = await _queryService.GetAllWithRelatedData()
            //    .Include(a => a.Marca)
            //    .Include(a => a.Categoria)
            //    .FirstOrDefaultAsync<Articulo>(x => x.Id == id);

            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(articulo);
        }


        //[HttpPost]
        ////public async Task<ActionResult<ArticuloDB>> PostArticulo([FromBody] ArticuloDB articulo)
        //public async Task<ActionResult<Articulo>> PostArticulo([FromBody] Articulo articulo)
        //{

        //    try
        //    {
        //        if (_queryService.GetAllWithRelatedData() == null)
        //        {
        //            return Problem("Entity set 'MiTiendaContexto.Articulos'  is null.");
        //        }

        //        //buscar la manera de que muestre error cuando se carga un id incorrecto 
        //        //articulo.Marca = _queryService.GetAll().FirstOrDefault(x => x.Id = articulo.Marca.Id);
        //        //articulo.Categoria = _queryService.Categorias.FindAsync(articulo.Categoria.IdCategoria);
        //        //articulo.PrecioFinal = articulo.Costo * (1 + articulo.MargenGanancia);
        //        //articulo.NetoGravado = articulo.Costo * (articulo.MargenGanancia);


        //        _manageService.CreateArticulo(articulo);
        //        _manageService.SaveChangesAsync();

        //        return CreatedAtAction("GetArticulo", new { id = articulo.IdArticulo }, articulo);
        //        //return Ok($"Articulo registrado: {articulo.Descripcion}");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, $"Se produjo un error interno: {e.Message}");
        //    }
        //}


    }
}
