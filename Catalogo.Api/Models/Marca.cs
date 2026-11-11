using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Catalogo.Api.Models
{

    [Table("Marca")]
    public class Marca
    {
        [Key]
        [Column("IdMarca")]
        public int IdMarca { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string? PaisOrigen { get; set; }
    }
}
