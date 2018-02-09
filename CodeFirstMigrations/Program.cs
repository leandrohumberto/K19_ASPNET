using CodeFirstMigrations.Models;
using System;

namespace CodeFirstMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new K19Context())
            {
                Console.Write("Digite o nome da editora: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o e-mail da editora: ");
                string email = Console.ReadLine();
                db.Editoras.Add(new Editora
                {
                    Nome = nome,
                    Email = email
                });
                db.SaveChanges();
            }
        }
    }
}
