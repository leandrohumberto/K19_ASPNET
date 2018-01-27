using EF.Models;
using System;

namespace EF
{
    class InsereEditoraComEF
    {
        static void Main(string[] args)
        {
            using (EfContext context = new EfContext())
            {
                char continua = 's';

                while (continua == 's' || continua == 'S')
                {

                    Editora editora = new Editora();

                    Console.Write("Digite o Nome da Editora: ");
                    editora.Nome = Console.ReadLine();
                    Console.Write("Digite o Email da Editora: ");
                    editora.Email = Console.ReadLine();
                    context.Editoras.Add(editora);
                    context.SaveChanges();
                    Console.WriteLine("Editora cadastrada com id: " + editora.Id);
                    Console.Write("Inserir novo registro? (S/N)? ");
                    continua = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
    }
}
