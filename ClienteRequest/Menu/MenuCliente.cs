using ClienteRequest.Models;
using ClienteRequest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientRequest.Menu
{
    public class MenuCliente
    {

        public void MenuDoCliente()
        {
            Cliente cliente = new Cliente();
            ClienteServices clienteservices = new ClienteServices();
            EnderecoCliente enderecoCliente = new EnderecoCliente();
            int opcao = -1;
            do
            {
                Console.WriteLine("------------Menu Cliente-------------------");
                Console.WriteLine("|       1- Cadastrar cliente.             |");
                Console.WriteLine("|       2- Cadastrar endereço do cliente. |");
                Console.WriteLine("|       3- Atualizar cliente.             |");
                Console.WriteLine("|       4- Deletar endereço do cliente.   |");
                Console.WriteLine("|       5- Deletar cliente.               |");
                Console.WriteLine("|       6- Buscar cliente por ID.         |");
                Console.WriteLine("|       7- Buscar todos os clientes.      |");
                Console.WriteLine("|       0-Voltar para o menu principal    |");
                Console.WriteLine("-------------------------------------------");
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Insira o nome do cliente:");
                    cliente.Nome = Console.ReadLine();
                    Console.WriteLine("Insira o CNPJ do cliente:");
                    cliente.CNPJ = Console.ReadLine();
                    Console.WriteLine("Insira o telefone do cliente:");
                    cliente.Telefone = Console.ReadLine();
                    clienteservices.EnviarCliente(cliente);
                }
                else if (opcao == 2)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID do cliente:");
                    enderecoCliente.IdCliente = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Insira a Cidade do Cliente:");
                    enderecoCliente.Cidade = Console.ReadLine();
                    Console.WriteLine($"Insira o Estado do Cliente");
                    enderecoCliente.Estado = Console.ReadLine();
                    Console.WriteLine("Insira o Numero  do local");
                    enderecoCliente.Numero = Console.ReadLine();
                    Console.WriteLine("Insira o nome da Rua do cliente");
                    enderecoCliente.Rua = Console.ReadLine();
                    clienteservices.EnviarEndereco(enderecoCliente);
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o novo Nome do cliente");
                    cliente.Nome = Console.ReadLine();
                    Console.WriteLine("Insira o novo CNPJ do cliente");
                    cliente.CNPJ = Console.ReadLine();
                    Console.WriteLine("Insira o novo Telefone do cliente");
                    cliente.Telefone = Console.ReadLine();
                    clienteservices.AtualizarCliente(id, cliente);
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID do Endereço que você deseja deletar:");
                    int id = Convert.ToInt32(Console.ReadLine());

                    clienteservices.DeletarEnderecoCliente(id);
                    
                }
                else if (opcao == 5)
                {
                    
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID do cliente que você deseja deletar:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    clienteservices.DeletarCliente(id);
                }
                else if (opcao == 6)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID do cliente que você deseja encontrar:");
                    int id = Convert.ToInt32(Console.ReadLine());

                    var tal = clienteservices.BuscarPorCliente(id);

                    Console.WriteLine($"Nome :{tal.Nome} | CNPJ : {tal.CNPJ} | Telefone : {tal.Telefone} ");
                }
                else if (opcao == 7)
                {
                    Console.WriteLine("-----------------------------");
                    var tal = clienteservices.BuscarTodos();

                    foreach (var test in tal)
                    {
                        Console.WriteLine("ID: " + test.Id);
                        Console.WriteLine("Nome: " + test.Nome);
                        Console.WriteLine("CNPJ: " + test.CNPJ);
                        Console.WriteLine("Telefone: " + test.Telefone);
                        Console.WriteLine("");

                    }
                }
            }
            while (opcao != 0);                 
        }
    }
}
