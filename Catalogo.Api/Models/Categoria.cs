using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Catalogo.Api.Models
{

    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [Column("IdCategoria")]
        public int IdCategoria { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}
