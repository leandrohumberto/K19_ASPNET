using EF.Contexts;
using EF.Models;
using EF.Repositorios;
using EF.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EF.Telas
{
    class TelaDespesaConsultaTipo : ITela
    {
        private ITela _anterior;
        private GranaContext _context;

        public string Nome { get; set; }

        public TelaDespesaConsultaTipo(ITela anterior, GranaContext context)
        {
            _anterior = anterior;
            _context = context;
            Nome = "Despesas por Tipo";
        }

        public ITela Mostra()
        {
            Console.WriteLine($">>> {Nome} <<<");
            Console.WriteLine();

            CultureInfo cultureInfo = CultureInfo.CurrentUICulture;
            string tipoDespesa = GetTipoDespesa(cultureInfo);
            MostrarDespesasPorTipo(cultureInfo, tipoDespesa);
            Console.WriteLine();
            return _anterior;
        }

        private void MostrarDespesasPorTipo(CultureInfo cultureInfo, string tipo)
        {
            DespesaRepositorio receitaRepositorio = new DespesaRepositorio(_context);
            List<Despesa> despesas = receitaRepositorio.BuscaPorTipo(tipo);

            if (despesas.Count <= 0)
            {
                Console.WriteLine("Não há despesas registradas referentes ao tipo escolhido");
                Console.ReadKey();
                Console.WriteLine();
                return;
            }

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
                    receitaRepositorio.Remove(despesas[opcao - 1]);
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

        private static string GetTipoDespesa(CultureInfo cultureInfo)
        {
            Dictionary<int, string> tipos = new Dictionary<int, string>();

            string[] opcoesTipoReceita = Enum.GetNames(typeof(TipoReceita));

            for (int i = 0; i < opcoesTipoReceita.Length; i++)
            {
                string nome = opcoesTipoReceita[i].SplitCamelCase();
                tipos.Add(i + 1, nome);
                Console.WriteLine("{0}. {1}", i + 1, nome);
            }

            while (true)
            {
                Console.Write("Escolha o tipo: (número 1 a {0}): ", tipos.Count);
                int indice;

                if (!int.TryParse(Console.ReadLine(), NumberStyles.Integer, cultureInfo, out indice) || indice < 1 || indice > 5)
                {
                    Console.WriteLine("Tipo incorreto");
                    continue;
                }

                return tipos[indice];
            }
        }
    }
}
