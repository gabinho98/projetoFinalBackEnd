using ClienteRequest.Models;
using ClienteRequest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClientRequest.Menu;

namespace ClienteRequest
{
    public class Program
    {

        static void Main(string[] args)
        {
            int opcao = -1;
            do
            {
                MenuCliente menuCliente = new MenuCliente();
                MenuFuncionario menuFuncionario = new MenuFuncionario();
                MenuObra menuObra = new MenuObra();
                MenuOS menuOS = new MenuOS();
                Console.WriteLine("");
                Console.WriteLine("------------Sistema Empreiteira------------");
                Console.WriteLine("|       1-Menu do Cliente                 |");
                Console.WriteLine("|       2-Menu do Funcionario             |");
                Console.WriteLine("|       3-Menu da Obra                    |");
                Console.WriteLine("|       4-Menu da Ordem de Servico        |");
                Console.WriteLine("|       0-Sair                            |");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Digite uma opcao: ");
                Console.WriteLine("");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.Clear();
                    Console.WriteLine("Opção incorreta, por favor escolha uma das opcões do menu: ");
                    opcao = -1;
                }
                if (opcao == 1)
                {
                    menuCliente.MenuDoCliente();
                    Console.Clear();
                }
                else if (opcao == 2)
                {
                    menuFuncionario.MenuDoFuncionario();
                    Console.Clear();

                }
                else if (opcao == 3)
                {
                    menuObra.MenuDaObra();
                    Console.Clear();

                }
                else if (opcao == 4)
                {
                    menuOS.MenuDaOS();
                    Console.Clear();
                }
                else if (opcao < 0 || opcao > 4)
                {
                    Console.Clear();
                    Console.WriteLine("Opção incorreta, por favor escolha uma das opcões do menu: ");
                }
            }
            while (opcao != 0);
        }


    }
}