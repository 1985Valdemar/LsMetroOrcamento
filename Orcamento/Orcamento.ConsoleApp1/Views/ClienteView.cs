using Orcamento.ConsoleApp1.Common;
using Orcamento.ConsoleApp1.Models;
using Orcamento.ConsoleApp1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento.ConsoleApp1.Views
{
    public class ClienteView
    {
        //****** Metodo Menu ******
        public void CadastrarMenu()
        {
            //****** METODO LIMPAR & MOSTRAR CABECALHO ******
            MetodosViews.Cabecalho("Bem vindo Cadastro");

            //****** VAI BUSCAR LISTA ******
            //****** CRIANDO OBJETO PARA USAR ******
            ClienteRepository clienteRepository = new ClienteRepository();

            //****** CRIANDO OBJETO ******
            Cliente cliente = new Cliente();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite Nome: ");
            cliente.Nome = Console.ReadLine();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite Sobrenome: ");
            cliente.Sobrenome = Console.ReadLine();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite Seu Cpf: ");
            cliente.Cpf = Console.ReadLine();

            //****** CRIANDO cliente1 NO TXT ******
            Console.WriteLine(clienteRepository.Create(cliente));

            MetodosViews.Mensagem("\n***** Obrigado Por Cadastrar *****\n");

            //****** IMPRIMINDO DADOS EM TXT ******
            Console.WriteLine(cliente);

        }

        public void Menu()
        {

            int opcao = -1;
            do
            {
                //****** VAI IMPRIMIR OPÇÕES ******
                imprimiMenu();

                //****** TRATANDO POSSIVEIS ERROS ******
                try
                {
                    //****** LÉ DIGITADO USUARIO ******
                    opcao = Convert.ToInt32(Console.ReadLine());

                    EscolheMenu(opcao);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite Apenas Numeros");
                }

            } while (opcao != 0);
        }
        public void imprimiMenu()
        {
            MetodosViews.Limpar();
            //****** INSERINDO COR ******
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Bem ao Sistema Lsmetro Orçamentos");
            Console.WriteLine("Escolha Uma das Opçãos Abaixo:");
            Console.WriteLine("1 - Listar Clientes");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite a Opção Desejada: ");
        }
        private void EscolheMenu(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    ListarClientes();
                    break;
                case 2:
                    CadastrarMenu();
                    break;
                case 0:
                    MetodosViews.Mensagem("Saindo");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    MetodosViews.Mensagem("Opçao Invalida");
                    break;

            }

        }
        private void ListarClientes()
        {
            //****** METODO LIMPAR & MOSTRAR CABECALHO ******
            MetodosViews.Cabecalho("Lista Cliente");

            //****** VAI BUSCAR LISTA ******
            ClienteRepository clienteRepository = new ClienteRepository();

            //****** CRIANDO VARIAVEL PARA ARMAZENAR GetAll ******
            var clientes = clienteRepository.GetAll();

            //****** VERIFICAÇÃO DA LISTA E TRAZENDO PAISES ******
            if (clientes.Count > 0)
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                MetodosViews.Mensagem("Nenhum Cliente cadastrado ainda.");
            }
        }
    }
}
