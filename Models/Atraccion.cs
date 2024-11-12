using System.ComponentModel.DataAnnotations;

namespace EjemploABMCompleto.Models
{
    public class Atraccion
    {
        // Los siguientes son los valores posibles de la propiedad Tipo
        public static string[] Tipos = new string[] { "Mecanica", "Acuatica", "Electrica", "Juegos de Mesa" };
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre no pude estar vacio")]
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Nombre no pude estar vacio")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Edad minima no pude estar vacio")]
        public int EdadMinima { get; set; }

        [Required(ErrorMessage = "Edad maxima no pude estar vacio")]
        public int EdadMaxima { get; set; }

        [Required(ErrorMessage = "Altura minima no pude estar vacio")]
        public int AlturaMinima { get; set; }

        [Required(ErrorMessage = "Altura maxima no pude estar vacio")]
        public int AlturaMaxima { get; set; }

        [Required(ErrorMessage = "FotoUrl no pude estar vacio")]
        public string? FotoUrl { get; set; }

        // Relacion muchos a uno con Parque
        [Required(ErrorMessage = "Parque no pude estar vacio")]
        public int IdParque { get; set; }
        public Parque? Parque { get; set; }
    }
}
