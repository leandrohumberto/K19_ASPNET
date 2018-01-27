using EF.Models;
using System;
using System.Collections.Generic;

namespace EF
{
    class AdicionaFaturaLigacao
    {
        static void Main(string[] args)
        {
            char continua = 's';

            while (continua == 's' || continua == 'S')
            {
                using (EfContext context = new EfContext())
                {
                    Ligacao ligacao1 = new Ligacao { Duracao = GetDuracao("Digite o tempo da primeira ligação: ") };
                    Ligacao ligacao2 = new Ligacao { Duracao = GetDuracao("Digite o tempo da segunda ligação: ") };

                    Fatura fatura = new Fatura() { Ligacoes = new List<Ligacao> { ligacao1, ligacao2 } };

                    ligacao1.Fatura = fatura;
                    ligacao2.Fatura = fatura;

                    context.Ligacoes.AddRange(new[] { ligacao1, ligacao2 });
                    context.Faturas.Add(fatura);
                    context.SaveChanges();

                    Console.WriteLine("Primeira ligação registrada com o ID {0}", ligacao1.Id);
                    Console.WriteLine("Segunda ligação registrada com o ID {0}", ligacao2.Id);
                    Console.WriteLine("Fatura registrada com o ID {0}", fatura.Id);

                    Console.WriteLine("Repetir? (S/N) ");
                    continua = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }

        private static int GetDuracao(string mensagem = "Digite a duração: ")
        {
            while (true)
            {
                int duracao;
                Console.Write(mensagem);

                if (!int.TryParse(Console.ReadLine(), out duracao))
                {
                    Console.WriteLine("Número inválido!");
                    Console.Write("Tentar novamente? (S/N)");
                    char continua = Console.ReadKey().KeyChar;

                    if (continua != 's' && continua != 'S')
                    {
                        Environment.Exit(0);
                    }

                    Console.WriteLine();

                }
                else
                {
                    return duracao;
                }
            }
        }
    }
}
