using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CamadaDeApresentacao.Models
{
    public class Usuario
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Nome do usuário")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataDeCadastramento { get; set; }
    }
}