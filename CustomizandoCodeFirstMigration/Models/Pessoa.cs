using System.ComponentModel.DataAnnotations;

namespace CustomizandoCodeFirstMigration.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        [Required]
        public string TelefoneFixo { get; set; }

        public string TelefoneCelular { get; set; }
    }
}
