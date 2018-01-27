using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    [Table("Autores")]
    class Autor
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
