using EF.Models;
using System;

namespace EF
{
    class AdicionaJornal
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            using (EfContext context = new EfContext())
            {
                for (int i = 0; i < 50; i++)
                {
                    Jornal jornal = new Jornal
                    {
                        Nome = "Jornal " + (i + 1).ToString("00"),
                        Preco = random.Next(1, 16) * random.Next(1, 16)
                    };

                    context.Jornais.Add(jornal);
                }

                context.SaveChanges();

                Console.WriteLine("Lista de Jornais\n");

                foreach (var revista in context.Jornais)
                {
                    Console.WriteLine("{0} - {1}", revista.Nome, 
                        revista.Preco.ToString("c", System.Globalization.CultureInfo.CurrentUICulture));
                }
            }
        }
    }
}
