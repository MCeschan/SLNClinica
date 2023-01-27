using System.ComponentModel.DataAnnotations;

namespace SLNClinica.Models
{
    public class Medico
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [RegularExpression(@"[A-Z]{2}[0-9]{4}")]
        public int Matricula { get; set; }
    }
}
