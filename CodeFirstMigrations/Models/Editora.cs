using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstMigrations.Models
{
    public class Editora
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "o campo email é obrigatório")]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [ForeignKey("EditoraId")]
        public virtual IList<Livro> Livros { get; set; }
    }
}
