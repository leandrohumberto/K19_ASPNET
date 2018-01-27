using System;
using System.Collections.Generic;

namespace EF.Telas
{
    class TelaMenu : ITela
    {
        private List<ITela> _filhas = new List<ITela>();

        public string Nome { get; set; }

        public TelaMenu(string nome)
        {
            Nome = nome;
        }

        public ITela Mostra()
        {
            Console.WriteLine($">>> {Nome} <<<");
            Console.WriteLine();

            for (int i = 0; i < _filhas.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, _filhas[i].Nome);
            }

            Console.WriteLine();

            while (true)
            {
                Console.Write("Escolha a opção: ");
                int opcao;

                if (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > _filhas.Count)
                {
                    Console.WriteLine("Opcão inválida!");
                    continue;
                }

                Console.WriteLine();
                return _filhas[opcao - 1];
            }
        }

        public void AdicionaFilha(ITela tela) => _filhas.Add(tela);
    }
}
