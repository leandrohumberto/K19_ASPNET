using EF.Models;
using System;

namespace EF
{
    class AdicionaEstadoGovernador
    {
        static void Main(string[] args)
        {
            using (EfContext context = new EfContext())
            {
                char continua = 's';

                while (continua == 's' || continua == 'S')
                {
                    Governador governador = new Governador();
                    Console.Write("Digite o nome do governador: ");
                    governador.Nome = Console.ReadLine();

                    Estado estado = new Estado();
                    Console.Write("Digite o nome do estado: ");
                    estado.Nome = Console.ReadLine();

                    estado.Governador = governador;
                    context.Estados.Add(estado);
                    context.SaveChanges();

                    Console.WriteLine("Governador cadastrado com id: " + governador.Id);
                    Console.WriteLine("Estado cadastrado com id: " + estado.Id);
                    Console.Write("Realizar novo cadastro? (S/N) ");
                    continua = Console.ReadKey().KeyChar;
                }
            }
        }
    }
}
