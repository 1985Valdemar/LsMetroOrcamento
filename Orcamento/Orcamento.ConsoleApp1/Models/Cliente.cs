using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento.ConsoleApp1.Models
{
    public class Cliente:BaseModel
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }
        public string Cpf { get; set; }

        public override string ToString()
        {
            //base maykon
            return $"{this.Id};{this.Nome};{this.Sobrenome};{this.Cpf}";
        }
    }
}
