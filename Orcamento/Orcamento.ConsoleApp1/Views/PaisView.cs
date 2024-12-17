using Orcamento.ConsoleApp1.Common;
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
            MetodosView.Cabecalho("Bem vindo Cadastro");

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

            Console.WriteLine("\n***** Obrigado Por Cadastrar *****\n");

            //****** IMPRIMINDO DADOS EM TXT ******
            Console.WriteLine(pais);

        }
    }
}
