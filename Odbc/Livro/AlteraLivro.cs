using System;
using System.Data.Odbc;
using System.Globalization;

namespace Odbc
{
    class AlteraLivro
    {
        static void Main(string[] args)
        {
            Livro livro = new Livro();
            char continua = 's';

            while (continua == 's' || continua == 'S')
            {
                livro.Id = GetIdLivro();
                livro.Titulo = GetNomeLivro();
                livro.Preco = GetPrecoLivro();
                livro.EditoraId = GetIdEditora();

                string sql = $@"UPDATE Livros SET Titulo = ?, Preco = ?, Editora_Id = ? WHERE Id = ?";

                using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
                {
                    OdbcCommand command = new OdbcCommand(sql, conexao);
                    command.Parameters.AddWithValue("@Titulo", livro.Titulo);
                    command.Parameters.AddWithValue("@Preco", livro.Preco);
                    command.Parameters.AddWithValue("@EditoraId", livro.EditoraId);
                    command.Parameters.AddWithValue("@Id", livro.Id);
                    conexao.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Livro cadastrado com Id: " + livro.Id);
                        Console.Write("Inserir novo registro? (S/N) ");
                        continua = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"Livro com o ID {livro.Id} não encontrado!");
                        Console.Write("Tentar novamente? (S/N) ");
                        continua = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }

            }
        }

        static string GetNomeLivro()
        {
            Console.Write("Digite o novo título do livro: ");
            return Console.ReadLine().Trim();
        }

        static decimal GetPrecoLivro()
        {
            while (true)
            {
                Console.Write("Digite o novo preço do livro: ");
                string input = Console.ReadLine().Trim();
                decimal preco;

                if (!decimal.TryParse(input, NumberStyles.Currency, new CultureInfo("pt-BR"), out preco))
                {
                    Console.WriteLine($"Preço {input} inválido!");
                }
                else
                {
                    return preco;
                }
            }
        }

        static long? GetIdLivro()
        {
            while (true)
            {
                Console.Write("Digite o ID do livro que deseja alterar: ");
                string id = Console.ReadLine().Trim();

                using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
                {
                    string sql = $"SELECT id FROM livros WHERE id = ?";
                    OdbcCommand command = new OdbcCommand(sql, conexao);
                    command.Parameters.AddWithValue("@Id", id);
                    conexao.Open();
                    var livroId = command.ExecuteScalar() as long?;

                    if (livroId == null)
                    {
                        Console.WriteLine($"Livro com o ID {id} não encontrado!");
                    }
                    else
                    {
                        return livroId;
                    }
                }
            }
        }

        static long? GetIdEditora()
        {
            while (true)
            {
                Console.Write("Digite o nome da nova editora: ");
                string editora = Console.ReadLine().Trim();

                using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
                {
                    string sql = $"SELECT id FROM editoras WHERE Nome LIKE '%{editora}%'";
                    OdbcCommand command = new OdbcCommand(sql, conexao);
                    conexao.Open();
                    var editoraId = command.ExecuteScalar() as long?;

                    if (editoraId == null)
                    {
                        Console.WriteLine($"Editora com o nome \"{editora}\" não encontrada!");
                    }
                    else
                    {
                        return editoraId;
                    }
                }
            }
        }
    }
}
