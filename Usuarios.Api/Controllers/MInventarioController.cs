using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventario.Api.Models;
using Inventario.Api.Data;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosInventarioController : ControllerBase
    {
        private readonly InventarioDBContext _context;

        public MovimientosInventarioController(InventarioDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientoInventario>>> GetMovimientos()
        {
            var movimientos = await _context.MovimientosInventario
                        .AsNoTracking()
                        .ToListAsync();
            return Ok(movimientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoInventario>> GetMovimiento(int id)
        {
            var movimiento = await _context.MovimientosInventario
                        .AsNoTracking()
                        .FirstOrDefaultAsync(i => i.IdMovimiento == id);

            if (movimiento == null) return NotFound();

            return Ok(movimiento);
        }

        [HttpPost]
        public async Task<ActionResult<MovimientoInventario>> CrearMovimiento(MovimientoInventario movimiento)
        {
            _context.MovimientosInventario.Add(movimiento);
            await _context.SaveChangesAsync();

            return Ok(movimiento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarMovimiento(int id, MovimientoInventario movimiento)
        {
            if (id != movimiento.IdMovimiento) return BadRequest();

            _context.Entry(movimiento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarMovimiento(int id)
        {
            var movimiento = await _context.MovimientosInventario.FindAsync(id);
            if (movimiento == null) return NotFound();

            _context.MovimientosInventario.Remove(movimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
