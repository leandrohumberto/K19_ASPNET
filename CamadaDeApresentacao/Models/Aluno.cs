using System.Web.Mvc;

namespace CamadaDeApresentacao.Models
{
    public class Aluno
    {
        [HiddenInput(DisplayValue = false)]
        public int AlunoID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}