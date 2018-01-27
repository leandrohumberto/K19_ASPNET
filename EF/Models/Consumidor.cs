using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    [Table("Consumidores")]
    class Consumidor
    {
        public long Id { get; set; }
        public string Nome { get; set; }
    }
}
