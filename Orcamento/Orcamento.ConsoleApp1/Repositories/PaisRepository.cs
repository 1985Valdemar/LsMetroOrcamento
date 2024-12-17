using Orcamento.ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento.ConsoleApp1.Repositories
{
    public class PaisRepository
    {
        //****** INICIAR ID EM ZERO
        //****** _id para indicar que ficar nesta classe somente
        private static int _id = 0;

        //****** CRIAR VARIAVEL PARA ARMAZENAR NOME TXT
        private string _nomeArquivo = "listaDePaises.txt";


        //****** Construtor para carregar dados do arquivo e inicializar o ID
        public PaisRepository()
        {
            if (File.Exists(_nomeArquivo))
            {
                InicializarId();
            }
        }

        //****** Inicializa o ID baseado no maior ID presente no arquivo
        //****** Método para inicializar o ID baseado no maior ID presente no arquivo
        private void InicializarId()
        {
            using (StreamReader streamReader = new StreamReader(_nomeArquivo))
            {
                string linha;
                while ((linha = streamReader.ReadLine()) != null)
                {
                    // Dividir a linha em campos
                    string[] dados = linha.Split(";");
                    int id = Convert.ToInt32(dados[0]);
                    // Atualizar o ID para garantir que seja único
                    _id = Math.Max(_id, id);
                }
            }
        }

        //****** Método para criar um novo cliente e salvar no arquivo
        public string Create(Pais model)
        {
            //****** Incrementa o ID e adiciona ao modelo
            _id++;
            model.Id = _id;

            //****** Salvar o cliente no arquivo de texto
            using (StreamWriter sw = new StreamWriter(_nomeArquivo, append: true))
            {
                sw.WriteLine($"{model.Id};{model.Nome};{model.Populacao};{model.Idioma}");
            }

            return $"Pais: {model.Nome} cadastrado com sucesso!";
        }

        //****** Método para obter todos os clientes do arquivo
        public List<Pais> GetAll()
        {
            List<Pais> listaPaises = new List<Pais>();

            //****** Carrega os dados do arquivo de texto
            if (File.Exists(_nomeArquivo))
            {
                using (StreamReader streamReader = new StreamReader(_nomeArquivo))
                {
                    string linha;
                    while ((linha = streamReader.ReadLine()) != null)
                    {
                        // Dividir a linha em campos
                        string[] dados = linha.Split(";");

                        if (dados.Length < 4)
                        {
                            Console.WriteLine("Linha com dados insuficientes em países, ignorando...");
                            continue;
                        }


                        Pais pais = new Pais
                        {
                            Id = Convert.ToInt32(dados[0]),
                            Nome = dados[1],
                            Populacao = Convert.ToInt32(dados[2]),
                            Idioma = dados[3]
                        };
                        listaPaises.Add(pais);
                    }
                }
            }

            return listaPaises;
        }

        //****** Método para obter DADOS pelo ID
        public Pais GetById(int id)
        {
            //****** Busca o cliente pelo ID no arquivo de texto
            if (File.Exists(_nomeArquivo))
            {
                //****** LENDO ARQUIVO TXT
                using (StreamReader streamReader = new StreamReader(_nomeArquivo))
                {
                    string linha;
                    while ((linha = streamReader.ReadLine()) != null)
                    {
                        //****** Dividir a linha em campos
                        string[] dados = linha.Split(";");
                        if (Convert.ToInt32(dados[0]) == id)
                        {
                            return new Pais
                            {
                                Id = id,
                                Nome = dados[1],
                                Populacao = Convert.ToInt32(dados[2]),
                                Idioma = dados[3]
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
