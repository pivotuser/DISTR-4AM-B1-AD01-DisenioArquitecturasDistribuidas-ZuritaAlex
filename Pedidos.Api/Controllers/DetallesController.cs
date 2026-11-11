using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Models;
using Pedidos.Api.Data;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesController : ControllerBase
    {
        private readonly PedidoDBContext _context;

        public DetallesController(PedidoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetalles()
        {
            var detalles = await _context.DetallePedidos
                        .AsNoTracking()
                        .ToListAsync();
            return Ok(detalles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetalle(int id)
        {
            var detalle = await _context.DetallePedidos
                        .AsNoTracking()
                        .FirstOrDefaultAsync(i => i.IdDetalle == id);

            if (detalle == null) return NotFound();

            return Ok(detalle);
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedido>> CrearDetalle(DetallePedido detalle)
        {
            _context.DetallePedidos.Add(detalle);
            await _context.SaveChangesAsync();

            return Ok(detalle);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarDetalle(int id, DetallePedido detalle)
        {
            if (id != detalle.IdDetalle) return BadRequest();

            _context.Entry(detalle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarDetalle(int id)
        {
            var detalle = await _context.DetallePedidos.FindAsync(id);
            if (detalle == null) return NotFound();

            _context.DetallePedidos.Remove(detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
