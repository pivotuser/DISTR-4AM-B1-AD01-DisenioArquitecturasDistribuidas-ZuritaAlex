using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catalogo.Api.Models;
using Catalogo.Api.Data;

namespace Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CatalogoDBContext _context;

        public CategoriasController(CatalogoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            var categorias = await _context.Categorias
                        .AsNoTracking()
                        .ToListAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias
                        .AsNoTracking()
                        .FirstOrDefaultAsync(i => i.IdCategoria == id);

            if (categoria == null) return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> CrearCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarCategoria(int id, Categoria categoria)
        {
            if (id != categoria.IdCategoria) return BadRequest();

            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarCategoria(int id)
        {
            var inventario = await _context.Categorias.FindAsync(id);
            if (inventario == null) return NotFound();

            _context.Categorias.Remove(inventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
