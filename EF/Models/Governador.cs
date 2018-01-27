using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    [Table("Governadores")]
    class Governador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
