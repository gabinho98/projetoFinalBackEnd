using ClienteRequest.Models;
using ClienteRequest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientRequest.Menu
{
    public class MenuObra
    {
        public void MenuDaObra()
        {
            int opcao = -1;
            do
            {
                Obra obra = new Obra();
                ObraServices obraService = new ObraServices();
                EnderecoObra enderecoObra = new EnderecoObra();
                Console.WriteLine("------------Menu de Obra-------------------");
                Console.WriteLine("|         1-Cadastrar obra:               |");
                Console.WriteLine("|         2-Cadastrar endereço da obra:   |");
                Console.WriteLine("|         3-Atualizar obra:               |");
                Console.WriteLine("|         4-Deletar obra:                 |");
                Console.WriteLine("|         5-Deletar endereço obra:        |");
                Console.WriteLine("|         6-Buscar todas as obras:        |");
                Console.WriteLine("|         7-Buscar obra por ID:           |");
                Console.WriteLine("|         0-Voltar para o menu principal  |");
                Console.WriteLine("-------------------------------------------");
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Insira a descrição da obra:");
                    obra.Descricao = Console.ReadLine();
                    Console.WriteLine("Insira a data de início da obra:");
                    obra.DatadeInicio = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Insira a previsão de termino:");
                    obra.PrevisaodeTermino = DateTime.Parse(Console.ReadLine());
                    obraService.EnviarObra(obra);
                }
                else if (opcao == 2)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID da obra:");
                    enderecoObra.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Digite o estado:");
                    enderecoObra.Estado = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Digite a cidade:");
                    enderecoObra.Cidade = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Digite a rua:");
                    enderecoObra.Rua = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Digite o número:");
                    enderecoObra.Numero = Convert.ToString(Console.ReadLine());
                    obraService.EnviarEnderecoObra(enderecoObra.Id, enderecoObra);
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID da obra:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira a descrição da obra:");
                    obra.Descricao = Console.ReadLine();
                    Console.WriteLine("Insira a data de início da obra:");
                    obra.DatadeInicio = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Insira o Cargo do funcionário:");
                    obra.PrevisaodeTermino = DateTime.Parse(Console.ReadLine());
                    obraService.AtualizarObra(id, obra);
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID da obra que você deseja deletar:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    obraService.DeletarObra(id);
                }
                else if (opcao == 5)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID do Endereço que você deseja deletar:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    obraService.DeletarEnderecoObra(id);
                }
                else if (opcao == 6)
                {
                    Console.WriteLine("-----------------------------");
                    var tal = obraService.BuscarTodos();

                    foreach (var test in tal)
                    {
                        Console.WriteLine("ID: " + test.Id);
                        Console.WriteLine("Descricao :" + test.Descricao);
                        Console.WriteLine("Data de inicio :" + test.DatadeInicio);
                        Console.WriteLine("Previsao de termino :" + test.PrevisaodeTermino);
                        Console.WriteLine("");

                    }
                }
                else if (opcao == 7)
                {
                    Console.WriteLine("Digite o ID da obra que você deseja encontrar:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var tal = obraService.BuscarPorObra(id);
                    Console.WriteLine($"Descricao :{tal.Descricao} | Data de inicio : {tal.DatadeInicio} | Previsao de termino : {tal.PrevisaodeTermino} ");
                }

            }
            while (opcao != 0);
        }
    }
}
