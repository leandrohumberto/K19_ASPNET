using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    [Table("Ligacoes")]
    class Ligacao
    {
        public long Id { get; set; }
        public int Duracao { get; set; }
        public Fatura Fatura { get; set; }
    }
}
