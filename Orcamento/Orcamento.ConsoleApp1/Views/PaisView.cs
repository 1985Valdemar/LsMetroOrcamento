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
    public class PaisView
    {
        //****** Metodo Menu ******
        public void CadastrarMenu()
        {
            //****** METODO LIMPAR & MOSTRAR CABECALHO ******
            MetodosViews.Cabecalho("Bem vindo Cadastro");

            //****** VAI BUSCAR LISTA ******
            //****** CRIANDO OBJETO PARA USAR ******
            PaisRepository paisRepository = new PaisRepository();

            //****** CRIANDO OBJETO PAIS ******
            Pais pais = new Pais();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite Nome País: ");
            pais.Nome = Console.ReadLine();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite População: ");
            pais.Populacao = Convert.ToInt32(Console.ReadLine());

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite Seu Idioma: ");
            pais.Idioma = Console.ReadLine();

            //****** CRIANDO cliente1 NO TXT ******
            Console.WriteLine(paisRepository.Create(pais));

            MetodosViews.Mensagem("\n***** Obrigado Por Cadastrar *****\n");

            //****** IMPRIMINDO DADOS EM TXT ******
            Console.WriteLine(pais);

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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Bem ao Sistema Lsmetro Orçamentos");
            Console.WriteLine("Escolha Uma das Opçãos Abaixo:");
            Console.WriteLine("1 - Listar");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite a Opção Desejada: ");
        }
        private void EscolheMenu(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    ListarPaises();
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
        private void ListarPaises()
        {
            //****** METODO LIMPAR & MOSTRAR CABECALHO ******
            MetodosViews.Cabecalho("Lista Paises");

            //****** VAI BUSCAR LISTA ******
            PaisRepository paisRepository = new PaisRepository();

            //****** CRIANDO VARIAVEL PARA ARMAZENAR GetAll ******
            var paises = paisRepository.GetAll();

            //****** VERIFICAÇÃO DA LISTA E TRAZENDO PAISES ******
            if (paises.Count > 0)
            {
                foreach (var pais in paises)
                {
                    Console.WriteLine(pais);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                MetodosViews.Mensagem("Nenhum País cadastrado ainda.");
            }
        }

    }
}
