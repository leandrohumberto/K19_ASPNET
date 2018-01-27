using EF.Contexts;
using EF.Models;
using EF.Repositorios;
using System;

namespace EF.Telas
{
    class TelaGeraDados : ITela
    {
        private ITela _anterior;
        private GranaContext _context;

        public string Nome { get; set; }

        public TelaGeraDados(ITela anterior, GranaContext context)
        {
            _anterior = anterior;
            _context = context;
            Nome = "Gerar dados";
        }

        public ITela Mostra()
        {
            Console.WriteLine($">>> {Nome} <<<");
            Console.WriteLine();

            Console.WriteLine("Gerando dados...");

            ReceitaRepositorio receitaRepositorio = new ReceitaRepositorio(_context);
            DespesaRepositorio despesaRepositorio = new DespesaRepositorio(_context);

            // Receitas
            for (int i = 0; i < 36; i++)
            {
                receitaRepositorio.Adiciona(new Receita
                {
                    Nome = "Salário K19",
                    Tipo = "Salário",
                    Valor = 8000.0,
                    Data = new DateTime(2014, 1, 10).AddMonths(i)
                });
            }

            for (int i = 0; i < 36; i++)
            {
                receitaRepositorio.Adiciona(new Receita
                {
                    Nome = "VA",
                    Tipo = "Vale Alimentação",
                    Valor = 400.0,
                    Data = new DateTime(2014, 1, 10).AddMonths(i)
                });
            }

            for (int i = 0; i < 36; i++)
            {
                receitaRepositorio.Adiciona(new Receita
                {
                    Nome = "VR",
                    Tipo = "Vale Refeição",
                    Valor = 500.0,
                    Data = new DateTime(2014, 1, 10).AddMonths(i)
                });
            }

            for (int i = 0; i < 36; i++)
            {
                receitaRepositorio.Adiciona(new Receita
                {
                    Nome = "Aluguel Casa BH",
                    Tipo = "Aluguel",
                    Valor = 1000.0,
                    Data = new DateTime(2014, 1, 10).AddMonths(i)
                });
            }

            // Despesas
            for (int i = 0; i < 36; i++)
            {
                despesaRepositorio.Adiciona(new Despesa
                {
                    Nome = "Aluguel Apto SP",
                    Tipo = "Aluguel",
                    Valor = 1800.0,
                    Data = new DateTime(2014, 1, 10).AddMonths(i)
                });
            }

            for (int i = 0; i < 36; i++)
            {
                despesaRepositorio.Adiciona(new Despesa
                {
                    Nome = "Compras Supermercado",
                    Tipo = "Alimentação",
                    Valor = 1000.0,
                    Data = new DateTime(2014, 1, 10).AddMonths(i)
                });
            }

            for (int i = 0; i < 36; i++)
            {
                despesaRepositorio.Adiciona(new Despesa
                {
                    Nome = "Combustível",
                    Tipo = "Transporte",
                    Valor = 400.0,
                    Data = new DateTime(2014, 1, 10).AddMonths(i)
                });
            }

            for (int i = 0; i < 36; i++)
            {
                despesaRepositorio.Adiciona(new Despesa
                {
                    Nome = "Cinema",
                    Tipo = "Lazer",
                    Valor = 200.0,
                    Data = new DateTime(2014, 1, 10).AddMonths(i)
                });
            }

            Console.WriteLine("Dados gerados");
            Console.ReadKey();
            Console.WriteLine();

            return _anterior;
        }
    }
}
