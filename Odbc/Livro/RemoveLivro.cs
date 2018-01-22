using System;
using System.Data.Odbc;

namespace Odbc
{
    class RemoveLivro
    {
        static void Main(string[] args)
        {
            using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
            {
                char continua = 's';

                while (continua == 's' || continua == 'S')
                {
                    Console.Write("Digite o ID do livro que deseja remover: ");
                    string input = Console.ReadLine();
                    long id;

                    if (long.TryParse(input, out id))
                    {
                        string sql = "DELETE livros WHERE id = ?";
                        OdbcCommand command = new OdbcCommand(sql, conexao);
                        command.Parameters.AddWithValue("@Id", id);
                        conexao.Open();

                        if (command.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine($"Livro com ID {id} foi removido!");
                            Console.WriteLine("Remover outro livro? (S/N) ");
                            continua = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($"Livro com ID {id} não encontrado!");
                            Console.WriteLine("Tentar novamente? (S/N) ");
                            continua = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ID {input} inválido!");
                    }
                }
            }
        }
    }
}
