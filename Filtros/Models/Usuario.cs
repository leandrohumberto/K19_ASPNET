using System.ComponentModel.DataAnnotations;

namespace Filtros.Models
{
    public class Usuario
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}