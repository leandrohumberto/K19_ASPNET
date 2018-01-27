using EF.Contexts;
using System;

namespace EF.Telas
{
    class TelaLimpaDados : ITela
    {
        private ITela _anterior;
        private GranaContext _context;

        public string Nome { get; set; }

        public TelaLimpaDados(ITela anterior, GranaContext context)
        {
            _anterior = anterior;
            _context = context;
            Nome = "Limpa Dados";
        }

        public ITela Mostra()
        {
            Console.WriteLine($">>> {Nome} <<<");
            Console.WriteLine();

            Console.WriteLine("Limpando dados...");

            _context.Database.ExecuteSqlCommand("DELETE FROM Despesas");
            _context.Database.ExecuteSqlCommand("DELETE FROM Receitas");

            Console.WriteLine("Dados limpos");
            Console.ReadKey();
            Console.WriteLine();

            return _anterior;
        }
    }
}
