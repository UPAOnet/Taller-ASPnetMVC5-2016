using System.ComponentModel.DataAnnotations;

namespace MiPrimeraWebApp.Models
{
    public class EquipoModel
    {
        [Key]
        public int IDEquipo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int  Copas { get; set; }
        public int IDPais { get; set; }
        [Required]
        public PaisModel Pais { get; set; }
    }
}

