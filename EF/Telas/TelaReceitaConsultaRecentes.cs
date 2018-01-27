using EF.Contexts;
using EF.Models;
using EF.Repositorios;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EF.Telas
{
    class TelaReceitaConsultaRecentes : ITela
    {
        private ITela _anterior;
        private GranaContext _context;

        public string Nome { get; set; }

        public TelaReceitaConsultaRecentes(ITela anterior, GranaContext context)
        {
            _anterior = anterior;
            _context = context;
            Nome = "Últimas Receitas Adicionadas";
        }

        public ITela Mostra()
        {
            Console.WriteLine($">>> {Nome} <<<");
            Console.WriteLine();

            ReceitaRepositorio repositorio = new ReceitaRepositorio(_context);
            List<Receita> receitas = repositorio.BuscaRecentes();

            if (receitas.Count <= 0)
            {
                Console.WriteLine("Não há receitas registradas");
                Console.ReadKey();
                Console.WriteLine();
                return _anterior;
            }

            while (true)
            {
                for (int i = 0; i < receitas.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, receitas[i]);
                }

                Console.WriteLine();
                Console.WriteLine("Digite o número da receita que deseja remover");
                Console.WriteLine("Digite 0 para voltar");

                int opcao;
                NumberStyles style = NumberStyles.Integer;
                CultureInfo cultureInfo = CultureInfo.CurrentUICulture;

                if (!int.TryParse(Console.ReadLine(), style, cultureInfo, out opcao) || opcao < 0 || opcao > receitas.Count)
                {
                    Console.WriteLine("Opção incorreta");
                    Console.WriteLine();
                    continue;
                }


                if (opcao != 0)
                {
                    repositorio.Remove(receitas[opcao - 1]);
                    receitas.RemoveAt(opcao - 1);
                    Console.WriteLine();
                    Console.WriteLine("Receita removida");
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
