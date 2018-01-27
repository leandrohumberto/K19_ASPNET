using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    [Table("Livros")]
    class Livro
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Autor> Autores { get; set; }
    }
}
