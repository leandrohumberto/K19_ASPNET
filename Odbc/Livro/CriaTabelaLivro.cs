using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odbc
{
    class CriaTabelaLivro
    {
        static void Main(string[] args)
        {
            using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
            {
                conexao.Open();
                string sql = @"CREATE TABLE Livros (
                    id BIGINT IDENTITY(1,1), 
                    titulo VARCHAR(255) NOT NULL, 
                    preco DECIMAL(18,2) NOT NULL, 
                    editora_id BIGINT,
                    CONSTRAINT PK_Livros PRIMARY KEY CLUSTERED (id asc),
                    CONSTRAINT FK_Livros_Editora FOREIGN KEY (editora_id)
                        REFERENCES dbo.Editoras (id)
                        ON DELETE CASCADE
                        ON UPDATE CASCADE
                );";
                OdbcCommand command = new OdbcCommand(sql, conexao);
                command.ExecuteNonQuery();
            }
        }
    }
}
