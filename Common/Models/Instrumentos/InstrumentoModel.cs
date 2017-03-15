using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Instrumentos
{
    public class InstrumentoModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string Som { get; set; }
    }
}
