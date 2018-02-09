using CustomizandoCodeFirstMigration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizandoCodeFirstMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new K19Context())
            {
                db.Pessoas.Add(new Pessoa
                {
                    Nome = "K19",
                    Email = "contato@k19.com.br",
                    TelefoneCelular = "(11) 2387-3791",
                    TelefoneFixo = "(11) 2387-3792"
                });
                db.SaveChanges();
            }
        }
    }
}
