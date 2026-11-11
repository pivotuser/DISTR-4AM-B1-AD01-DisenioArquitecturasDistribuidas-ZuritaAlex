using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventario.Api.Models;
using Inventario.Api.Data;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasController : ControllerBase
    {
        private readonly InventarioDBContext _context;

        public BodegasController(InventarioDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bodega>>> GetBodegas()
        {
            var bodegas = await _context.Bodegas
                        .AsNoTracking()
                        .ToListAsync();
            return Ok(bodegas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bodega>> GetBodega(int id)
        {
            var bodega = await _context.Bodegas
                        .AsNoTracking()
                        .FirstOrDefaultAsync(i => i.IdBodega == id);

            if (bodega == null) return NotFound();

            return Ok(bodega);
        }

        [HttpPost]
        public async Task<ActionResult<Bodega>> CrearBodega(Bodega bodega)
        {
            _context.Bodegas.Add(bodega);
            await _context.SaveChangesAsync();

            return Ok(bodega);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarBodega(int id, Bodega bodega)
        {
            if (id != bodega.IdBodega) return BadRequest();

            _context.Entry(bodega).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarBodega(int id)
        {
            var bodega = await _context.Bodegas.FindAsync(id);
            if (bodega == null) return NotFound();

            _context.Bodegas.Remove(bodega);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
