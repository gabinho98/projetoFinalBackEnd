using ClienteRequest.Models;
using ClienteRequest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientRequest.Menu
{
    public class MenuOS
    {
        public void MenuDaOS()
        {
            int opcao = -1;
            do
            {
                OS oS = new OS();
                OSServices osService = new OSServices();
                Console.WriteLine("--------------Menu da Ordem de Servico---------------");
                Console.WriteLine("|         1-Cadastrar ordem de serviço:             |");
                Console.WriteLine("|         2-Atualizar ordem de serviço:             |");
                Console.WriteLine("|         3-Deletar ordem de serviço:               |");
                Console.WriteLine("|         4-Buscar todas ordens de serviço:         |");
                Console.WriteLine("|         5-Buscar ordem de serviço por ID:         |");
                Console.WriteLine("|         0-Voltar para o menu principal            |");
                Console.WriteLine("-----------------------------------------------------");
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Insira o valor da ordem de serviço:");
                    oS.ValordaObra = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Insira o ID do cliente:");
                    oS.IdCliente = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o ID do funcionário:");
                    oS.IdFuncionario = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o ID da obra:");
                    oS.IdObra = Convert.ToInt32(Console.ReadLine());
                    osService.EnviarOS(oS);
                }

                else if (opcao == 2)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID da Ordem de Serviço:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o valor da obra:");
                    oS.ValordaObra = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Insira o ID do cliente:");
                    oS.IdCliente = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o ID di funcionario:");
                    oS.IdFuncionario = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insira o o ID da obra:");
                    oS.IdObra = Convert.ToInt32(Console.ReadLine());
                    osService.AtualizarOS(id, oS);
                }

                else if (opcao == 3)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID da ordem de serviço que você deseja deletar:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    //osService.DeletarOS(id);
                    var resultado = osService.DeletarOS(id);
                    Console.WriteLine(resultado);
                }

                else if (opcao == 4)
                {
                    Console.WriteLine("-----------------------------");
                    var tal = osService.BuscarTodos();

                    if (tal != null)
                    {
                        foreach (var test in tal)
                        {
                            Console.WriteLine("Ordem De Serviço: " + test.OrdemDeServico);
                            Console.WriteLine("Valor da Obra: R$" + test.ValordaObra);
                            Console.WriteLine("Nome do cliente: " + test.NomeCliente);
                            Console.WriteLine("Nome do funcionario: " + test.NomeFuncionario);
                            Console.WriteLine("Descricao da obra: " + test.DescricaoDaObra);
                            Console.WriteLine("Data de inicio da obra: " + test.DataDeInicio);
                            Console.WriteLine("Data de termino da obra: " + test.PrevisaoDeTermino);
                            Console.WriteLine("");
                        }
                    }

                }
                else if (opcao == 5)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Digite o ID da ordem de serviço que você deseja encontrar:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var test = osService.BuscarPorOS(id);
                    Console.WriteLine("");
                    Console.WriteLine("Valor da Obra: R$" + test.ValordaObra);
                    Console.WriteLine("Nome do cliente: " + test.NomeCliente);
                    Console.WriteLine("Nome do funcionario: " + test.NomeFuncionario);
                    Console.WriteLine("Descricao da obra: " + test.DescricaoDaObra);
                    Console.WriteLine("Data de inicio da obra: " + test.DataDeInicio);
                    Console.WriteLine("Data de termino da obra: " + test.PrevisaoDeTermino);
                    Console.WriteLine("");
                }
            }
            while (opcao != 0);

        }

    }
}
