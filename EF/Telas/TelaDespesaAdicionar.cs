using EF.Contexts;
using EF.Models;
using EF.Repositorios;
using System;
using System.Collections.Generic;
using System.Globalization;
using EF.Utils;

namespace EF.Telas
{
    class TelaDespesaAdicionar : ITela
    {
        private ITela _anterior;
        private GranaContext _context;

        public string Nome { get; set; }

        public TelaDespesaAdicionar(ITela anterior, GranaContext context)
        {
            _anterior = anterior;
            _context = context;
            Nome = "Adicionar Despesa";
        }

        public ITela Mostra()
        {
            Console.WriteLine($">>> {Nome} <<<");
            Console.WriteLine();

            string nome = GetNome();
            CultureInfo cultureInfo = CultureInfo.CurrentUICulture;
            double valor = GetValor(cultureInfo);
            DateTime data = GetData(cultureInfo);
            string tipo = GetTipo(cultureInfo);

            new DespesaRepositorio(_context).Adiciona(new Despesa
            {
                Nome = nome,
                Valor = valor,
                Tipo = tipo,
                Data = data
            });
            
            Console.WriteLine("Despesa adicionada");
            Console.ReadKey();
            Console.WriteLine();
            return _anterior;
        }

        private static string GetNome()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            return nome;
        }

        private static string GetTipo(CultureInfo cultureInfo)
        {
            Dictionary<int, string> tipos = new Dictionary<int, string>();

            string[] opcoesTipoDespesa = Enum.GetNames(typeof(TipoDespesa));

            for (int i = 0; i < opcoesTipoDespesa.Length; i++)
            {
                string nome = opcoesTipoDespesa[i].SplitCamelCase();
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

        private static DateTime GetData(CultureInfo cultureInfo)
        {
            DateTime data;
            while (true)
            {
                Console.Write("Digite a data (ex.: {0}): ", DateTime.Today.ToString("d", cultureInfo));

                if (!DateTime.TryParseExact(Console.ReadLine(), "d", cultureInfo, DateTimeStyles.None, out data))
                {
                    Console.WriteLine("Data incorreta");
                    continue;
                }

                return data;
            }
        }

        private static double GetValor(CultureInfo cultureInfo)
        {
            double valor;
            while (true)
            {
                Console.Write("Digite o valor: ");
                NumberStyles style = NumberStyles.Currency;

                if (!double.TryParse(Console.ReadLine(), style, cultureInfo, out valor) || valor < 0.0)
                {
                    Console.WriteLine("Valor incorreto");
                    continue;
                }

                return valor;
            }
        }
    }
}
