using EF.Models;
using System;
using System.Collections.Generic;

namespace EF
{
    class AdicionaLivroAutor
    {
        static void Main(string[] args)
        {
            using (EfContext context = new EfContext())
            {
                char continua = 's';

                while (continua == 's' || continua == 'S')
                {
                    Autor autor1 = new Autor();
                    Autor autor2 = new Autor();

                    Console.Write("Digite o nome do primeiro autor: ");
                    autor1.Nome = Console.ReadLine();
                    Console.Write("Digite o nome do segundo autor: ");
                    autor2.Nome = Console.ReadLine();

                    Livro livro1 = new Livro();
                    Livro livro2 = new Livro();

                    Console.Write("Digite o nome do primeiro livro: ");
                    livro1.Nome = Console.ReadLine();
                    Console.Write("Digite o nome do segundo livro: ");
                    livro2.Nome = Console.ReadLine();

                    livro1.Autores = new List<Autor> { autor1, autor2 };
                    livro2.Autores = new List<Autor> { autor1, autor2 };
                    autor1.Livros = new List<Livro> { livro1, livro2 };
                    autor2.Livros = new List<Livro> { livro1, livro2 };

                    context.Livros.AddRange(new[] { livro1, livro2 });
                    context.Autores.AddRange(new[] { autor1, autor2 });
                    context.SaveChanges();

                    Console.WriteLine("Primeiro autor cadastrado com o ID {0}", autor1.Id);
                    Console.WriteLine("Segundo autor cadastrado com o ID {0}", autor2.Id);
                    Console.WriteLine("Primeiro livro cadastrado com o ID {0}", livro1.Id);
                    Console.WriteLine("Segundo livro cadastrado com o ID {0}", livro2.Id);

                    Console.Write("Repetir? (S/N) ");
                    continua = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
    }
}
