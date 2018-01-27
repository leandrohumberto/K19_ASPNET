using EF.Models;
using System;

namespace EF
{
    class InsereClienteComEF
    {
        static void Main(string[] args)
        {
            using (EfContext context = new EfContext())
            {
                char continua = 's';

                while (continua == 's' || continua == 'S')
                {
                    Cliente cliente = new Cliente();

                    Console.Write("Digite o nome do cliente: ");
                    cliente.Nome = Console.ReadLine();

                    Console.Write("Digite o CPF do cliente: ");
                    cliente.Cpf = Console.ReadLine();

                    Endereco endereco = new Endereco();
                    cliente.Endereco = endereco;

                    Console.WriteLine("Digite o endereço do cliente");
                    Console.Write("País: ");
                    endereco.Pais = Console.ReadLine();

                    Console.Write("Estado: ");
                    endereco.Estado = Console.ReadLine();

                    Console.Write("Cidade: ");
                    endereco.Cidade = Console.ReadLine();

                    Console.Write("Logradouro: ");
                    endereco.Logradouro = Console.ReadLine();

                    Console.Write("Número: ");
                    endereco.Numero = Console.ReadLine();

                    Console.Write("Complemento: ");
                    endereco.Complemento = Console.ReadLine();

                    Console.Write("CEP: ");
                    endereco.Cep = Console.ReadLine();

                    context.Clientes.Add(cliente);
                    context.SaveChanges();

                    Console.WriteLine($"Cliente cadastrado com o ID {cliente.Id}");
                    Console.Write("Cadastrar novo cliente? (S/N) ");
                    continua = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                }
            }
        }
    }
}
