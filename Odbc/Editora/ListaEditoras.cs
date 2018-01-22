using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Odbc
{
    class ListaEditoras
    {
        static void Main(string[] args)
        {
            using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
            {
                string sql = "SELECT id, nome, email FROM Editoras";
                OdbcCommand command = new OdbcCommand(sql, conexao);
                conexao.Open();
                OdbcDataReader reader = command.ExecuteReader();
                List<Editora> lista = new List<Editora>();

                while (reader.Read())
                {
                    Editora editora = new Editora();

                    if (!reader.IsDBNull(0)) editora.Id = reader.GetInt64(0);
                    if (!reader.IsDBNull(1)) editora.Nome = reader.GetString(1);
                    if (!reader.IsDBNull(2)) editora.Email = reader.GetString(2);

                    lista.Add(editora);
                }

                foreach (var editora in lista)
                {
                    Console.WriteLine("{0} : {1} - {2}", editora.Id, editora.Nome, editora.Email);
                }
            }
        }
    }
}
