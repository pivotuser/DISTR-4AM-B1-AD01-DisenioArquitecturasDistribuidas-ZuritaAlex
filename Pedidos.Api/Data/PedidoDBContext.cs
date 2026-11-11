using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Models;

namespace Pedidos.Api.Data
{
    public class PedidoDBContext : DbContext
    {
        public PedidoDBContext(DbContextOptions<PedidoDBContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<DetallePedido> DetallePedidos { get; set; }



    }
}
