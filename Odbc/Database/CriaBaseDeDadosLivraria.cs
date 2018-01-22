using System.Data.Odbc;

namespace Odbc
{
    class CriaBaseDeDadosLivraria
    {
        static void Main(string[] args)
        {
            using (OdbcConnection conexao = ConnectionFactory.CreateConnection(database: "master"))
            {
                conexao.Open();
                string sql = @"IF EXISTS
                    (SELECT name FROM master.dbo.sysdatabases WHERE name = 'livraria')
                    DROP DATABASE livraria";
                OdbcCommand command = new OdbcCommand(sql, conexao);
                command.ExecuteNonQuery();

                sql = "CREATE DATABASE livraria";
                command = new OdbcCommand(sql, conexao);
                command.ExecuteNonQuery();
            }
        }
    }
}
