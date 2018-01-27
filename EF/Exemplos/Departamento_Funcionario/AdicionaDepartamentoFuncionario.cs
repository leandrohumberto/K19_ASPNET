using EF.Models;
using System;
using System.Collections.Generic;

namespace EF
{
    class AdicionaDepartamentoFuncionario
    {
        static void Main(string[] args)
        {
            using (EfContext context = new EfContext())
            {
                char continua = 's';

                while (continua == 's' || continua == 'S')
                {
                    Funcionario f1 = new Funcionario();
                    Console.Write("Digite o nome do primeiro funcionário: ");
                    f1.Nome = Console.ReadLine();

                    Funcionario f2 = new Funcionario();
                    Console.Write("Digite o nome do segundo funcionário: ");
                    f2.Nome = Console.ReadLine();

                    Departamento depto = new Departamento();
                    Console.Write("Digite o nome do departamento: ");
                    depto.Nome = Console.ReadLine();

                    depto.Funcionarios = new List<Funcionario> { f1, f2, };

                    context.Departamentos.Add(depto);
                    context.SaveChanges();

                    Console.WriteLine(" Primeiro funcionário cadastrado com id :" + f1.Id);
                    Console.WriteLine(" Segundo funcionário cadastrado com id :" + f2.Id);
                    Console.WriteLine(" Departamento cadastrado com id :" + depto.Id);
                    Console.Write("Repetir? (S/N) ");
                    continua = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
    }
}
