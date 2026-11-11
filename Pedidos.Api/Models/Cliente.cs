using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Api.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("IdCliente")]
        public int IdCliente { get; set; }

        [Column("Nombres")]
        public string Nombres { get; set; } = string.Empty;

        [Column("Cedula")]
        public string Cedula { get; set; } = string.Empty;

        [Column("Correo")]
        public string? Correo { get; set; }

    }
}