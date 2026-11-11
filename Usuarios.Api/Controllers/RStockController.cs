using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventario.Api.Models;
using Inventario.Api.Data;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasStockController : ControllerBase
    {
        private readonly InventarioDBContext _context;

        public ReservasStockController(InventarioDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaStock>>> GetReservas()
        {
            var reservas = await _context.ReservasStock
                        .AsNoTracking()
                        .ToListAsync();
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaStock>> GetReserva(int id)
        {
            var reserva = await _context.ReservasStock
                        .AsNoTracking()
                        .FirstOrDefaultAsync(i => i.IdReserva == id);

            if (reserva == null) return NotFound();

            return Ok(reserva);
        }

        [HttpPost]
        public async Task<ActionResult<ReservaStock>> CrearReserva(ReservaStock reserva)
        {
            _context.ReservasStock.Add(reserva);
            await _context.SaveChangesAsync();

            return Ok(reserva);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarReserva(int id, ReservaStock reserva)
        {
            if (id != reserva.IdReserva) return BadRequest();

            _context.Entry(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarReserva(int id)
        {
            var reserva = await _context.ReservasStock.FindAsync(id);
            if (reserva == null) return NotFound();

            _context.ReservasStock.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
