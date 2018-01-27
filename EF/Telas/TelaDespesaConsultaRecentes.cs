using EF.Contexts;
using EF.Models;
using EF.Repositorios;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EF.Telas
{
    class TelaDespesaConsultaRecentes : ITela
    {
        private ITela _anterior;
        private GranaContext _context;

        public string Nome { get; set; }

        public TelaDespesaConsultaRecentes(ITela anterior, GranaContext context)
        {
            _anterior = anterior;
            _context = context;
            Nome = "Últimas Despesas Adicionadas";
        }

        public ITela Mostra()
        {
            Console.WriteLine($">>> {Nome} <<<");
            Console.WriteLine();

            DespesaRepositorio repositorio = new DespesaRepositorio(_context);
            List<Despesa> despesas = repositorio.BuscaRecentes();

            if (despesas.Count <= 0)
            {
                Console.WriteLine("Não há despesas registradas");
                Console.ReadKey();
                Console.WriteLine();
                return _anterior;
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

                int opcao;
                NumberStyles style = NumberStyles.Integer;
                CultureInfo cultureInfo = CultureInfo.CurrentUICulture;

                if (!int.TryParse(Console.ReadLine(), style, cultureInfo, out opcao) || opcao < 0 || opcao > despesas.Count)
                {
                    Console.WriteLine("Opção incorreta");
                    Console.WriteLine();
                    continue;
                }


                if (opcao != 0)
                {
                    repositorio.Remove(despesas[opcao - 1]);
                    despesas.RemoveAt(opcao - 1);
                    Console.WriteLine();
                    Console.WriteLine("Despesa removida");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    return _anterior;
                }
            }
        }
    }
}
