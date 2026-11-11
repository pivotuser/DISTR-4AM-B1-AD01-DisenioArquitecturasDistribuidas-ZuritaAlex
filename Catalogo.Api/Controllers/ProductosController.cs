using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catalogo.Api.Models;
using Catalogo.Api.Data;

namespace Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly CatalogoDBContext _context;

        public ProductosController(CatalogoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            var productos = await _context.Productos
                        .AsNoTracking()
                        .ToListAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProductos(int id)
        {
            var productos = await _context.Productos
                        .AsNoTracking()
                        .FirstOrDefaultAsync(i => i.IdProducto == id);

            if (productos == null) return NotFound();

            return Ok(productos);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> CrearProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return Ok(producto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarProducto(int id, Producto producto)
        {
            if (id != producto.IdProducto) return BadRequest();

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
