using System.Data.Odbc;

namespace Odbc
{
    class CriaTabelaEditora
    {
        static void Main(string[] args)
        {
            using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
            {
                conexao.Open();
                string sql = @"CREATE TABLE Editoras (
                    id BIGINT IDENTITY(1,1), 
                    nome VARCHAR(255) NOT NULL, 
                    email VARCHAR(255) NOT NULL, 
                    CONSTRAINT PK_Editoras PRIMARY KEY CLUSTERED (id asc)
                )";
                OdbcCommand command = new OdbcCommand(sql, conexao);
                command.ExecuteNonQuery();
            }
        }
    }
}
