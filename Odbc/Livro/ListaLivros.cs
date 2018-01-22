using System;
using System.Data.Odbc;

namespace Odbc
{
    class ListaLivros
    {
        static void Main(string[] args)
        {
            using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
            {
                string sql = @"SELECT livros.id, livros.titulo, livros.preco, editoras.nome FROM livros
                    INNER JOIN editoras
                    ON editoras.id = livros.editora_id";
                OdbcCommand command = new OdbcCommand(sql, conexao);
                conexao.Open();
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    long id = 0;
                    string titulo = "";
                    decimal preco = 0;
                    string editora = "";

                    if (!reader.IsDBNull(0)) id = reader.GetInt64(0);
                    if (!reader.IsDBNull(1)) titulo = reader.GetString(1);
                    if (!reader.IsDBNull(2)) preco = reader.GetDecimal(2);
                    if (!reader.IsDBNull(3)) editora = reader.GetString(3);

                    Console.WriteLine("{0} : {1} - {2} - {3}", id, titulo, preco, editora);
                }
            }
        }
    }
}
