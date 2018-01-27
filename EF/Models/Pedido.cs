using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    [Table("Pedidos")]
    class Pedido
    {
        public long Id { get; set; }
        public Consumidor Consumidor { get; set; }
    }
}
