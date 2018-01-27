using EF.Contexts;
using EF.Repositorios;
using System;
using System.Globalization;

namespace EF.Telas
{
    class TelaRelatorioPesonalizado : ITela
    {
        private ITela _anterior;
        private GranaContext _context;

        public string Nome { get; set; }

        public TelaRelatorioPesonalizado(ITela anterior, GranaContext context)
        {
            _anterior = anterior;
            _context = context;
            Nome = "Relatório Personalizado";
        }

        public ITela Mostra()
        {
            Console.WriteLine($">>> {Nome} <<<");
            Console.WriteLine();

            CultureInfo cultureInfo = CultureInfo.CurrentUICulture;
            DateTime inicio = GetData(cultureInfo, "Digite a data inicial (ex.: {0}): ");
            DateTime fim = GetData(cultureInfo, "Digite a data final (ex.: {0}): ");

            ReceitaRepositorio receitaRepositorio = new ReceitaRepositorio(_context);
            DespesaRepositorio despesaRepositorio = new DespesaRepositorio(_context);

            double receitas = receitaRepositorio.SomaReceitas(inicio, fim).GetValueOrDefault();
            double despesas = despesaRepositorio.SomaDespesas(inicio, fim).GetValueOrDefault();

            Console.WriteLine("Receitas: {0}", receitas.ToString("c", cultureInfo));
            Console.WriteLine("Despesas: {0}", despesas.ToString("c", cultureInfo));
            Console.WriteLine("Saldo do período: {0}", (receitas - despesas).ToString("c", cultureInfo));
            Console.ReadKey();
            Console.WriteLine();

            return _anterior;
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
