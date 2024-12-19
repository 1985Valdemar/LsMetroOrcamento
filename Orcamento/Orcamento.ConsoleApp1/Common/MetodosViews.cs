using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento.ConsoleApp1.Common
{
    public static class MetodosViews
    {
        //****** METODO LIMPAR & MOSTRAR CABECALHO ******
        public static void Cabecalho(string titulo) 
        {
            Console.WriteLine(titulo);
            Thread.Sleep(3000);

        }

        //****** METODO mostrar e limpar msg ******

        public static void Mensagem(string texto) 
        {
            Console.Clear();
            Console.WriteLine(texto);
        }

        //****** METODO LIMPAR ******

        public static void Limpar() 
        {
            Thread.Sleep(3000);
            Console.Clear();
        }




    }
}
