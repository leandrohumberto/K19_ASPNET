using System;
using System.Data.Odbc;

namespace Odbc
{
    class RemoveEditora
    {
        static void Main(string[] args)
        {
            using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
            {
                char continua = 's';

                while (continua == 's' || continua == 'S')
                {
                    Console.Write("Digite o ID da editora que deseja remover: ");
                    string input = Console.ReadLine();
                    long id;

                    if (long.TryParse(input, out id))
                    {
                        string sql = "DELETE editoras WHERE id = ?";
                        OdbcCommand command = new OdbcCommand(sql, conexao);
                        command.Parameters.AddWithValue("@Id", id);
                        conexao.Open();

                        if (command.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine($"Editora com ID {id} foi removida!");
                            Console.WriteLine("Remover outra editora? (S/N) ");
                            continua = Console.ReadKey().KeyChar;
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($"Edittora com ID {id} não encontrada!");
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
