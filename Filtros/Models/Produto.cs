using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Filtros.Models
{
    public class Produto
    {
        [HiddenInput(DisplayValue = false)]
        public int ProdutoID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Preco { get; set; }
    }
}