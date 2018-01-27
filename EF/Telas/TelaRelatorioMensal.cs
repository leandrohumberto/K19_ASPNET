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
    class TelaRelatorioMensal : ITela
    {
        private ITela _anterior;
        private GranaContext _context;

        public string Nome { get; set; }

        public TelaRelatorioMensal(ITela anterior, GranaContext context)
        {
            _anterior = anterior;
            _context = context;
            Nome = "Relatório Mensal";
        }

        public ITela Mostra()
        {
            Console.WriteLine($">>> {Nome} <<<");
            Console.WriteLine();

            CultureInfo cultureInfo = CultureInfo.CurrentUICulture;
            int mes = GetMes(cultureInfo);
            int ano = GetAno(cultureInfo);

            DateTime inicio = new DateTime(ano, mes, 1);
            DateTime fim = new DateTime(ano, mes, 1);
            fim = fim.AddMonths(1).AddDays(-1);

            ReceitaRepositorio receitaRepositorio = new ReceitaRepositorio(_context);
            DespesaRepositorio despesaRepositorio = new DespesaRepositorio(_context);

            double receitas = receitaRepositorio.SomaReceitas(inicio, fim).GetValueOrDefault();
            double despesas = despesaRepositorio.SomaDespesas(inicio, fim).GetValueOrDefault();

            Console.WriteLine("Receitas: {0}", receitas.ToString("c", cultureInfo));
            Console.WriteLine("Despesas: {0}", despesas.ToString("c", cultureInfo));
            Console.WriteLine("Saldo: {0}", (receitas - despesas).ToString("c", cultureInfo));
            Console.ReadKey();
            return _anterior;
        }

        private int GetMes(CultureInfo cultureInfo, string mensagem = "Digite o mês (número de 1 a 12): ")
        {
            int mes;
            while (true)
            {
                Console.Write(mensagem);
                NumberStyles style = NumberStyles.Integer;

                if (!int.TryParse(Console.ReadLine(), style, cultureInfo, out mes) || mes < 1 || mes > 12)
                {
                    Console.WriteLine("Valor incorreto");
                    continue;
                }

                return mes;
            }
        }

        private int GetAno(CultureInfo cultureInfo, string mensagem = "Digite o ano (número de 1900 a 3000): ")
        {
            int ano;
            while (true)
            {
                Console.Write(mensagem);
                NumberStyles style = NumberStyles.Integer;

                if (!int.TryParse(Console.ReadLine(), style, cultureInfo, out ano) || ano < 1900 || ano > 3000)
                {
                    Console.WriteLine("Valor incorreto");
                    continue;
                }

                return ano;
            }
        }
    }
}
