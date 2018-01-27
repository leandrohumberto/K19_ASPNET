using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    [Table("Estados")]
    class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Governador Governador { get; set; }
    }
}
