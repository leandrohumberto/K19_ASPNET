using System;
using System.Data.Odbc;

namespace Odbc
{
    class InsereEditora
    {
        static void Main(string[] args)
        {
            Editora e = new Editora();
            char continua = 's';

            while (continua == 's' || continua == 'S')
            {
                Console.Write("Digite o nome da editora: ");
                e.Nome = Console.ReadLine();

                Console.Write("Digite o e-mail da editora: ");
                e.Email = Console.ReadLine();

                string sql = $@"INSERT INTO Editoras (Nome, Email)
                OUTPUT INSERTED.id
                VALUES (?, ?)";

                using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
                {
                    OdbcCommand command = new OdbcCommand(sql, conexao);
                    command.Parameters.AddWithValue("@Nome", e.Nome);
                    command.Parameters.AddWithValue("@Email", e.Email);
                    conexao.Open();
                    e.Id = command.ExecuteScalar() as long?;
                }

                Console.WriteLine("Editora cadastrada com Id: " + e.Id);
                Console.Write("Inserir novo registro? (S/N) ");
                continua = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
