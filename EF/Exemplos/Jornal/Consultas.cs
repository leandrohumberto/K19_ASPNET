using EF.Models;
using System;
using System.Linq;

namespace EF
{
    class Consultas
    {
        static void Main(string[] args)
        {
            using (EfContext ctx = new EfContext())
            {
                /* Recuperando a quantidade de jornais */
                int contador = ctx.Jornais.Count();
                Console.WriteLine("Há " + contador + " jornais.\n");

                /* Recuperando a quantidade de jornais com preço acima de 100 */
                contador = ctx.Jornais.Count(x => x.Preco > 100);
                Console.WriteLine("Há " + contador + " jornais com preço acima de 100.\n");
                
                /* Somando os preços dos jornais */
                double soma = ctx.Jornais.Sum(x => x.Preco);
                Console.WriteLine("A soma dos preços das jornais é " + soma + "\n");
                
                /* Recuperando o preço do jornal mais caro */
                double precoMaximo = ctx.Jornais.Max(x => x.Preco);
                Console.WriteLine("O preço do jornal mais caro é " + precoMaximo + "\n");

                /* Recuperando o preço do jornal mais barato */
                double precoMinimo = ctx.Jornais.Min(x => x.Preco);
                Console.WriteLine("O preço do jornal mais barato é " + precoMinimo + "\n");

                /* Recuperando a média dos preços dos jornais */
                double media = ctx.Jornais.Average(x => x.Preco);
                Console.WriteLine("A média dos preços dos jornais é " + media + "\n");
                
                /* Recuperando todos os jornais */
                var jornais = ctx.Jornais;
                Console.WriteLine("Todos os jornais : ");

                foreach (Jornal jornal in jornais)
                {
                    Console.WriteLine("Id: " + jornal.Id);
                    Console.WriteLine("Nome : " + jornal.Nome);
                    Console.WriteLine("Preço : " + jornal.Preco);
                    Console.WriteLine();
                }

                /* Recuperando os jornais com preço acima de 100 */
                var jornaisCaros = ctx.Jornais.Where(x => x.Preco > 100);
                Console.WriteLine("Jornais com preço acima de 100: ");

                foreach (Jornal jornal in jornaisCaros)
                {
                    Console.WriteLine("Id: " + jornal.Id);
                    Console.WriteLine("Nome : " + jornal.Nome);
                    Console.WriteLine("Preço : " + jornal.Preco);
                    Console.WriteLine();
                }
            }
        }
    }
}
