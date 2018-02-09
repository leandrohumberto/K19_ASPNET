using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Curso
    {
        static int contador;

        public Curso()
        {
            contador++;
            Id = contador;
        }

        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(3)]
        [MinLength(3)]
        public string Sigla { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Nome { get; set; }
    }
}