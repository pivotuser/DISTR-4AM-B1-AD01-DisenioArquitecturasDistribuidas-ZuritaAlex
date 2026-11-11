using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Models;
using Pedidos.Api.Data;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidoDBContext _context;

        public PedidosController(PedidoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            var pedidos = await _context.Pedidos
                        .AsNoTracking()
                        .ToListAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos
                        .AsNoTracking()
                        .FirstOrDefaultAsync(i => i.IdPedido == id);

            if (pedido == null) return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> CrearPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return Ok(pedido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarPedido(int id, Pedido pedido)
        {
            if (id != pedido.IdPedido) return BadRequest();

            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return NotFound();

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
