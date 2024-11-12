using System.ComponentModel.DataAnnotations;

namespace EjemploABMCompleto.Models
{
    public class Parque
    {
        // Los siguientes son los valores posibles de la propiedad EdadObjetivo
        public static string[] EdadesObjetivo = new string[] { "Niños", "Adolescentes", "Adultos", "Adultos Mayores" };
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre no puede estar vacio")]
        public string Nombre { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        [Required(ErrorMessage = "Edad Objetivo no puede estar vacio")]
        public string EdadObjetivo { get; set; }

        // Relacion uno a muchos con Atraccion
        public List<Atraccion> Atracciones { get; set; } = new List<Atraccion>();
    }
}
