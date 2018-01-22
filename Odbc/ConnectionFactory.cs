using System.Data.Odbc;
using System.Text;

namespace Odbc
{
    static class ConnectionFactory
    {
        public static OdbcConnection CreateConnection(string database = "livraria", string user = "sa", string password = "esqueci")
        {
            string driver = @"{SQL Server}";
            string servidor = @".\EXPRESS_2012";
            string baseDeDados = @"livraria";
            string usuario = $@"{user}";
            string senha = $@"{password}";
            StringBuilder connectionString = new StringBuilder();
            connectionString.Append("driver=");
            connectionString.Append(driver);
            connectionString.Append(";server=");
            connectionString.Append(servidor);
            connectionString.Append(";database=");
            connectionString.Append(baseDeDados);
            connectionString.Append(";uid=");
            connectionString.Append(usuario);
            connectionString.Append(";pwd=");
            connectionString.Append(senha);
            return new OdbcConnection(connectionString.ToString());
        }
    }
}
