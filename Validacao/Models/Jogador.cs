using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Validacao.Models
{
    public class Jogador
    {
        [HiddenInput(DisplayValue = false)]
        public int JogadorID { get; set; }

        [Required(ErrorMessage = "O nome do jogador é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O número do jogador é obrigatório")]
        [Range(1, 99, ErrorMessage = "O número do jogador deve ser maior que 0 e menor 100")]
        public int? Numero { get; set; }

        [Required(ErrorMessage = "A altura do jogador é obrigatória")]
        [Range(0, double.MaxValue, ErrorMessage = "A altura do jogadornão pode ser negativa")]
        public double? Altura { get; set; }
    }
}