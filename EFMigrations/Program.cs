using EFMigrations.Models;

namespace EFMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new K19Context())
            {
                db.Editoras.Add(new Editora
                {
                    Nome = "K19",
                    Email = "contato@k19.com.br",
                    Telefone = "(11) 3434-5656"
                });
                db.SaveChanges();
            }
        }
    }
}
