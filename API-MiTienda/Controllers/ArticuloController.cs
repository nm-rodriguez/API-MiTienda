//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MiTienda.DataAccess.Contexts;
//using MiTienda.DataAccess.PersistenceEntities;
//using MiTienda.Domain.Entities;
//using System.Collections;

//namespace API_MiTienda.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ArticuloController : ControllerBase
//    {
//        private MiTiendaContexto _context;

//        public ArticuloController(MiTiendaContexto context)
//        {
//            this._context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable>> Get()
//        {
//            var articulos = await _context.Articulos
//                .Include(a => a.Marca)
//                .Include(a => a.Categoria)
//                .ToListAsync();
//            return articulos;
//        }
//        [HttpGet("Marcas")]
//        public async Task<ActionResult<IEnumerable>> GetMarcas()
//        {
//            var marcas = await _context.Marcas
//                .ToListAsync();
//            return marcas;
//        }
//        [HttpGet("Categorias")]
//        public async Task<ActionResult<IEnumerable>> GetCategorias()
//        {
//            var categorias = await _context.Categorias
//                .ToListAsync();
//            return categorias;
//        }


//        [HttpGet("{id}")]
//        public async Task<ActionResult<ArticuloDB>> GetArticulo(int id)
//        {
//            if (_context.Articulos == null)
//            {
//                return NotFound();
//            }
//            var articulo = await _context.Articulos
//                .Include(a => a.Marca)
//                .Include(a => a.Categoria)
//                .FirstOrDefaultAsync<ArticuloDB>(x => x.IdArticulo == id);

//            if (articulo == null)
//            {
//                return NotFound();
//            }

//            return articulo;
//        }


//        [HttpPost]
//        //public async Task<ActionResult<ArticuloDB>> PostArticulo([FromBody] ArticuloDB articulo)
//        public async Task<ActionResult<ArticuloDB>> PostArticulo([FromBody] ArticuloDB articulo)
//        {

//            try
//            {
//                if (_context.Articulos == null)
//                {
//                    return Problem("Entity set 'MiTiendaContexto.Articulos'  is null.");
//                }
               
//                //buscar la manera de que muestre error cuando se carga un id incorrecto 
//                articulo.Marca = await _context.Marcas.FindAsync(articulo.Marca.IdMarca);
//                articulo.Categoria = await _context.Categorias.FindAsync(articulo.Categoria.IdCategoria);
//                articulo.PrecioFinal = articulo.Costo * (1+articulo.MargenGanancia);
//                articulo.NetoGravado = articulo.Costo * (articulo.MargenGanancia);


//                await _context.Articulos.AddAsync(articulo);
//                await _context.SaveChangesAsync();

//                return CreatedAtAction("GetArticulo", new { id = articulo.IdArticulo }, articulo);
//                //return Ok($"Articulo registrado: {articulo.Descripcion}");
//            }
//            catch (Exception e)
//            {
//                return StatusCode(500,$"Se produjo un error interno: {e.Message}");
//            }
//        }

       
//    }
//}
