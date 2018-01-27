using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    [Table("Departamentos")]
    class Departamento
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
