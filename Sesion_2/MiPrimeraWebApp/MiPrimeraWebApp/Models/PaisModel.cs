using System.ComponentModel.DataAnnotations;

namespace MiPrimeraWebApp.Models
{
    public class PaisModel
    {
        [Key]
        public int IDPais { get; set; }
        [Required]
        public string  Nombre { get; set; }
    }
}

