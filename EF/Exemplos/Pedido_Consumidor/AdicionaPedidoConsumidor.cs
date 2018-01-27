using EF.Models;
using System;

namespace EF
{
    class AdicionaPedidoConsumidor
    {
        static void Main(string[] args)
        {
            using (EfContext context = new EfContext())
            {
                char continua = 's';

                while (continua == 's' || continua == 'S')
                {
                    Consumidor consumidor = new Consumidor();
                    Console.Write("Digite o nome do consumidor: ");
                    consumidor.Nome = Console.ReadLine();

                    Pedido pedido = new Pedido
                    {
                        Consumidor = consumidor
                    };

                    context.Pedidos.Add(pedido);
                    context.SaveChanges();

                    Console.WriteLine("Consumidor cadastrado com o ID {0}", consumidor.Id);
                    Console.WriteLine("Pedido cadastrado com o ID {0}", pedido.Id);
                    Console.Write("Repetir? (S/N) ");
                    continua = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
    }
}
