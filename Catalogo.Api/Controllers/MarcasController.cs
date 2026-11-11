using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catalogo.Api.Models;
using Catalogo.Api.Data;

namespace Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly CatalogoDBContext _context;

        public MarcasController(CatalogoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            var marcas = await _context.Categorias
                        .AsNoTracking()
                        .ToListAsync();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            var marca = await _context.Marcas
                        .AsNoTracking()
                        .FirstOrDefaultAsync(i => i.IdMarca == id);

            if (marca == null) return NotFound();

            return Ok(marca);
        }

        [HttpPost]
        public async Task<ActionResult<Marca>> CrearMarca(Marca marca)
        {
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            return Ok(marca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarMarca(int id, Marca marca)
        {
            if (id != marca.IdMarca) return BadRequest();

            _context.Entry(marca).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarMarca(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null) return NotFound();

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
