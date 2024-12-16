using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orcamento.ConsoleApp1.Models
{
    public class Pais: BaseModel
    {
        public string Nome { get; set; }
        public int Populacao { get; set; }
        public string Idioma { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()};{this.Nome};{this.Populacao}{this.Idioma}";
        }
    }
}
