using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Models;
using Pedidos.Api.Data;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly PedidoDBContext _context;

        public ClientesController(PedidoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _context.Clientes
                        .AsNoTracking()
                        .ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                        .AsNoTracking()
                        .FirstOrDefaultAsync(i => i.IdCliente == id);

            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CrearCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarCliente(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente) return BadRequest();

            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
