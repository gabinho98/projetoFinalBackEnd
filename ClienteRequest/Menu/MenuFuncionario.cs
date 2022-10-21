using ClienteRequest.Models;
using ClienteRequest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientRequest.Menu
{
    public class MenuFuncionario
    {
        
        public void MenuDoFuncionario()
        {
            int opcao = -1;
            do
            {
                Funcionario funcionario = new Funcionario();
                FuncionarioServices funcionarioService = new FuncionarioServices();
                Console.WriteLine("------------Menu de Funcionario------------");
                Console.WriteLine("|         1-Cadastrar funcionário:        |");
                Console.WriteLine("|         2-Atualizar funcionario:        |");
                Console.WriteLine("|         3-Deletar funcionario:          |");
                Console.WriteLine("|         4-Buscar Funcionário por ID:    |");
                Console.WriteLine("|         5-Buscar todos os funcionarios: |");                               
                Console.WriteLine("|         0-Voltar para o menu principal  |");
                Console.WriteLine("-------------------------------------------");
                opcao = Convert.ToInt32(Console.ReadLine());
                if (opcao == 1)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Insira o nome do funcionário:");
                    funcionario.Nome = Console.ReadLine();
                    Console.WriteLine("Insira o CPF do funcionário:");
                    funcionario.CPF = Console.ReadLine();
                    Console.WriteLine("Insira o Cargo do funcionário:");
                    funcionario.Cargo = Console.ReadLine();
                    funcionarioService.EnviarFuncionario(funcionario);
                }
                else if (opcao == 2)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o novo Nome do funcionario");
                    funcionario.Nome = Console.ReadLine();
                    Console.WriteLine("Insira o novo cargo do funcionario");
                    funcionario.Cargo = Console.ReadLine();
                    Console.WriteLine("Insira o novo CPF do funcionario");
                    funcionario.CPF = Console.ReadLine();
                    funcionarioService.AtualizarFuncionario(id, funcionario);
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID do funcionario que você deseja deletar:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    funcionarioService.DeletarFuncionario(id);
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID do funcionário que você deseja encontrar:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var tal = funcionarioService.BuscarPorFuncionario(id);
                    Console.WriteLine($"Nome :{tal.Nome} | CPF : {tal.CPF} | Cargo : {tal.Cargo} ");
                }
                else if (opcao == 5)
                {
                    Console.WriteLine("-----------------------------");
                    var tal = funcionarioService.BuscarTodos();

                    foreach (var test in tal)
                    {
                        Console.WriteLine("ID: " + test.Id);
                        Console.WriteLine("Nome: " + test.Nome);
                        Console.WriteLine("Cargo: " +test.Cargo);
                        Console.WriteLine("CPF: " + test.CPF);
                        Console.WriteLine("");
                    }
                }
            }
            while (opcao != 0);
        }
    }
}
