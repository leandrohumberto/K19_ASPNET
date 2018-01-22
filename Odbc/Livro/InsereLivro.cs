using System;
using System.Data.Odbc;
using System.Globalization;

namespace Odbc
{
    class InsereLivro
    {
        static void Main(string[] args)
        {
            Livro livro = new Livro();
            char continua = 's';

            while (continua == 's' || continua == 'S')
            {
                livro.Titulo = GetNomeLivro();
                livro.Preco = GetPrecoLivro();
                livro.EditoraId = GetIdEditora();

                string sql = $@"INSERT INTO Livros (Titulo, Preco, Editora_Id)
                OUTPUT INSERTED.id
                VALUES (?, ?, ?)";

                using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
                {
                    OdbcCommand command = new OdbcCommand(sql, conexao);
                    command.Parameters.AddWithValue("@Titulo", livro.Titulo);
                    command.Parameters.AddWithValue("@Preco", livro.Preco);
                    command.Parameters.AddWithValue("@EditoraId", livro.EditoraId);
                    conexao.Open();
                    livro.Id = command.ExecuteScalar() as long?;
                }

                Console.WriteLine("Livro cadastrado com Id: " + livro.Id);
                Console.Write("Inserir novo registro? (S/N) ");
                continua = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static string GetNomeLivro()
        {
            Console.Write("Digite o título do livro: ");
            return Console.ReadLine().Trim();
        }

        static decimal GetPrecoLivro()
        {
            while (true)
            {
                Console.Write("Digite preço do livro: ");
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

        static long? GetIdEditora()
        {
            while (true)
            {
                Console.Write("Digite o nome da editora: ");
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
