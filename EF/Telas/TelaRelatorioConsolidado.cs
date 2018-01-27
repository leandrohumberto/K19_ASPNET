using EF.Contexts;
using EF.Repositorios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Telas
{
    class TelaRelatorioConsolidado : ITela
    {
        private ITela _anterior;
        private GranaContext _context;

        public string Nome { get; set; }

        public TelaRelatorioConsolidado(ITela anterior, GranaContext context)
        {
            _anterior = anterior;
            _context = context;
            Nome = "Relatório Consolidado";
        }

        public ITela Mostra()
        {
            Console.WriteLine($">>> {Nome} <<<");
            Console.WriteLine();

            DateTime data = GetData(CultureInfo.CurrentUICulture);
            ReceitaRepositorio receitaRepositorio = new ReceitaRepositorio(_context);
            DespesaRepositorio despesaRepositorio = new DespesaRepositorio(_context);

            double receitas = receitaRepositorio.SomaReceitasAte(data).GetValueOrDefault();
            double despesas = despesaRepositorio.SomaDespesasAte(data).GetValueOrDefault();

            Console.WriteLine("Saldo: {0}", (receitas - despesas).ToString("c", CultureInfo.CurrentUICulture));
            Console.WriteLine();
            Console.ReadKey();
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
