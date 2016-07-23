using System.ComponentModel.DataAnnotations;

namespace MiPrimeraWebApp.Models
{
    public class JugadorModel
    {
        [Key]
        public int IDJugador { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Posicion { get; set; }
        [Required]
        public double Estatura { get; set; }
        public int IDEquipo { get; set; }
        [Required]
        public EquipoModel Equipo { get; set; }
    }
}

