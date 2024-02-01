using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiTienda.DataAccess.Contexts;
using MiTienda.DataAccess.Entities;
using MiTienda.Domain.Entities;

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
        public IEnumerable<ArticuloDB> Get()
        {
            return _context.Articulos.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloDB>> GetArticulo(int id)
        {
            if (_context.Articulos == null)
            {
                return NotFound();
            }
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }


        [HttpPost]
        public async Task<ActionResult<ArticuloDB>> PostProduct(Articulo articulo)
        {
            if (_context.Articulos == null)
            {
                return Problem("Entity set 'MiTiendaContexto.Articulos'  is null.");
            }
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.IdArticulo }, articulo);
        }
    }
}
