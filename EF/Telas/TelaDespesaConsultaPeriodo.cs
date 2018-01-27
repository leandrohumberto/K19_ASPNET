using EF.Contexts;
using EF.Models;
using EF.Repositorios;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EF.Telas
{
    class TelaDespesaConsultaPeriodo : ITela
    {
        private ITela _anterior;
        private GranaContext _context;

        public string Nome { get; set; }

        public TelaDespesaConsultaPeriodo(ITela anterior, GranaContext context)
        {
            _anterior = anterior;
            _context = context;
            Nome = "Despesas por período";
        }

        public ITela Mostra()
        {
            Console.WriteLine($">>> {Nome} <<<");
            Console.WriteLine();

            CultureInfo cultureInfo = CultureInfo.CurrentUICulture;
            DateTime? inicio = GetData(cultureInfo, "Digite a data inicial (ex.: {0}): ");
            DateTime? fim = GetData(cultureInfo, "Digite a data final (ex.: {0}): ");
            MostrarDespesas(cultureInfo, inicio.GetValueOrDefault(), fim.GetValueOrDefault());
            Console.WriteLine();
            return _anterior;
        }

        private void MostrarDespesas(CultureInfo cultureInfo, DateTime inicio, DateTime fim)
        {
            DespesaRepositorio despesaRepositorio = new DespesaRepositorio(_context);
            List<Despesa> despesas = despesaRepositorio.BuscaPorPeriodo(inicio, fim);

            if (despesas.Count <= 0)
            {
                Console.WriteLine("Não há despesas registradas no período escolhido");
                Console.ReadKey();
                Console.WriteLine();
                return;
            }

            while (true)
            {
                for (int i = 0; i < despesas.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, despesas[i]);
                }

                Console.WriteLine();
                Console.WriteLine("Digite o número da despesa que deseja remover");
                Console.WriteLine("Digite 0 para voltar");

                while (true)
                {
                    int opcao;

                    if (!int.TryParse(Console.ReadLine(), NumberStyles.Integer, cultureInfo, out opcao) || opcao < 0 || opcao > despesas.Count)
                    {
                        Console.WriteLine("Opção incorreta");
                        continue;
                    }

                    if (opcao != 0)
                    {
                        despesaRepositorio.Remove(despesas[opcao - 1]);
                        despesas.RemoveAt(opcao - 1);
                        Console.WriteLine();
                        Console.WriteLine("Despesa removida");
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static DateTime GetData(CultureInfo cultureInfo, string mensagem = "Digite a data (ex.: {0}): ")
        {
            DateTime data;
            while (true)
            {
                Console.Write(mensagem, DateTime.Today.ToString("d", cultureInfo));

                if (!DateTime.TryParseExact(Console.ReadLine(), "d", cultureInfo, DateTimeStyles.None, out data))
                {
                    Console.WriteLine("Data incorreta");
                    continue;
                }

                return data;
            }
        }
    }
}
