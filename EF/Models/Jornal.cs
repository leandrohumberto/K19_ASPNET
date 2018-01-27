using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    [Table("Jornais")]
    class Jornal
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}
