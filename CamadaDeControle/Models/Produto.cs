using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CamadaDeControle.Models
{
    public class Produto
    {
        [HiddenInput(DisplayValue = false)]

        public int ProdutoID { get; set; }

        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Descrição do Produto")]
        public string Descricao { get; set; }

        [Display(Name = "Preço do Produto")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Preco { get; set; }
    }
}