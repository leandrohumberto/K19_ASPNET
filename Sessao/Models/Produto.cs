using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Sessao.Models
{
    public class Produto
    {
        [HiddenInput(DisplayValue = false)]
        public int ProdutoID { get; set; }

        [Display(Name = "Nome do Produto", ShortName = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        [Display(Name = "Preço do Produto", ShortName = "Preço")]
        [Required(ErrorMessage = "O preço é obrigatório")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public string Preco { get; set; }
    }
}