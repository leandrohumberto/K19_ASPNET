using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odbc
{
    class AlteraEditora
    {
        static void Main(string[] args)
        {
            using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
            {
                char continua = 's';
                Editora editora = new Editora();

                while (continua == 's' || continua == 'S')
                {
                    Console.Write("Digite o ID da editora que deseja alterar: ");
                    editora.Id = Convert.ToInt64(Console.ReadLine());
                    string sql = "SELECT TOP 1 id FROM editoras WHERE id = ?";
                    OdbcCommand command = new OdbcCommand(sql, conexao);
                    command.Parameters.AddWithValue("@ID", editora.Id);
                    conexao.Open();
                    var retorno = command.ExecuteScalar();

                    if (retorno == null)
                    {
                        Console.WriteLine($"Editora com o ID {editora.Id} não encontrada!");
                        Console.Write("Tentar novamente? (S/N) ");
                        continua = Console.ReadKey().KeyChar;
                        continue;
                    }

                    Console.Write("Digite o novo nome da editora :");
                    editora.Nome = Console.ReadLine();
                    Console.Write("Digite o novo email da Editora :");
                    editora.Email = Console.ReadLine();
                    sql = "UPDATE Editoras SET nome = ?, email = ? WHERE id = ?";
                    command = new OdbcCommand(sql, conexao);
                    command.Parameters.AddWithValue("@Nome ", editora.Nome);
                    command.Parameters.AddWithValue("@Email ", editora.Email);
                    command.Parameters.AddWithValue("@Id ", editora.Id);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Editora atualizada!");
                        Console.Write("Deseja fazer uma nova alteração? (S/N) ");
                        continua = Console.ReadKey().KeyChar;
                    }
                    else
                    {
                        Console.WriteLine($"Editora com o ID {editora.Id} não encontrada!");
                        Console.Write("Tentar novamente? (S/N) ");
                        continua = Console.ReadKey().KeyChar;
                    }
                }
            }
        }
    }
}
