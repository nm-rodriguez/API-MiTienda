using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiTienda.DataAccess.Contexts;
using MiTienda.DataAccess.Entities;
using MiTienda.Domain.Entities;
using System.Collections;

namespace API_MiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private MiTiendaContexto _context;

        public ArticuloController(MiTiendaContexto context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> Get()
        {
            var articulos = await _context.Articulos
                .Include(a => a.Marca)
                .Include(a => a.Categoria)
                .ToListAsync();
            return articulos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloDB>> GetArticulo(int id)
        {
            if (_context.Articulos == null)
            {
                return NotFound();
            }
            var articulo = await _context.Articulos
                .Include(a => a.Marca)
                .Include(a => a.Categoria)
                .FirstOrDefaultAsync<ArticuloDB>(x => x.IdArticulo == id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }


        [HttpPost]
        //public async Task<ActionResult<ArticuloDB>> PostArticulo([FromBody] ArticuloDB articulo)
        public ActionResult<ArticuloDB> PostArticulo([FromBody] ArticuloDB articulo)
        {
            if (_context.Articulos == null)
            {
                return Problem("Entity set 'MiTiendaContexto.Articulos'  is null.");
            }
            _context.Articulos.Add(new ArticuloDB()
            {
                Descripcion = articulo.Descripcion,
                CodigoBarras = articulo.CodigoBarras,
                Costo = articulo.Costo,
                MargenGanancia = articulo.MargenGanancia,
                PrecioFinal = articulo.PrecioFinal,
                NetoGravado = articulo.NetoGravado,
                PorcentajeIVA = articulo.PorcentajeIVA,
                Categoria = new CategoriaDB() { IdCategoria = articulo.Categoria.IdCategoria },
                Marca = new MarcaDB() { IdMarca = articulo.Marca.IdMarca }
            });
            //_context.Articulos.Add(articulo);
            _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", articulo.IdArticulo, articulo);
        }

        //[HttpPost]
        ////public async Task<ActionResult<ArticuloDB>> PostArticulo([FromBody] ArticuloDB articulo)
        //public ActionResult<MarcaDB> PostMarca([FromBody] MarcaDB marca)
        //{
        //    if (_context.Marcas == null)
        //    {
        //        return Problem("Entity set 'MiTiendaContexto.Articulos'  is null.");
        //    }
        //    //_context.Articulos.Add(new ArticuloDB() { 
        //    //    Descripcion = articulo.Descripcion,
        //    //    CodigoBarras = articulo.CodigoBarras,
        //    //    Costo = articulo.Costo,
        //    //    MargenGanancia = articulo.MargenGanancia,
        //    //    PrecioFinal = articulo.PrecioFinal,
        //    //    NetoGravado = articulo.NetoGravado,
        //    //    PorcentajeIVA = articulo.PorcentajeIVA,
        //    //    Categoria = new CategoriaDB() { IdCategoria = articulo.Categoria.IdCategoria },
        //    //    Marca = new MarcaDB() { IdMarca = articulo.Marca.IdMarca } 
        //    //});
        //    _context.Articulos.Add(marca);
        //    _context.SaveChangesAsync();

        //    return CreatedAtAction("GetArticulo", marca.IdArticulo, articulo);
        //}
    }
}
