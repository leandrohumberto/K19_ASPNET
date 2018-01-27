using EF.Models;
using System;

namespace EF
{
    class AlteraEditoraComEF
    {
        static void Main(string[] args)
        {
            using (EfContext context = new EfContext())
            {
                char continua = 's';

                while (continua == 's' || continua == 'S')
                {
                    Console.Write("Digite o ID da editora que deseja alterar: ");
                    long id;

                    if (!long.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("ID inválido!");
                        Console.Write("Tentar novamente? (S/N) ");
                        continua = Repetir("Tentar novamente? (S/N) ");
                        Console.WriteLine();
                        Console.WriteLine();
                        continue;
                    }

                    Editora editora = context.Editoras.Find(id);

                    if (editora == null)
                    {
                        Console.WriteLine("Editora não encontrada!");
                        continua = Repetir("Tentar novamente? (S/N) ");
                        Console.WriteLine();
                        Console.WriteLine();
                        continue;
                    }

                    Console.Write("Digite o novo Nome da Editora: ");
                    editora.Nome = Console.ReadLine();
                    Console.Write("Digite o novo Email da Editora: ");
                    editora.Email = Console.ReadLine();
                    context.SaveChanges();
                    Console.Write("Os dados da editora foram atualizados!");
                    continua = Repetir();
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }

        static char Repetir(string mensagem = "Alterar outra editora? (S/N) ")
        {
            Console.Write(mensagem);
            return Console.ReadKey().KeyChar;
        }
    }
}
