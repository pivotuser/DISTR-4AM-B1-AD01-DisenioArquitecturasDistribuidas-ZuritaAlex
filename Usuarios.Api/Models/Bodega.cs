using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Api.Models
{
    [Table("Bodega")]
    public class Bodega
    {
        [Key]
        [Column("IdBodega")]
        public int IdBodega { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("Ciudad")]
        public string? Ciudad { get; set; }

        [Column("Direccion")]
        public string? Direccion { get; set; }
    }
}