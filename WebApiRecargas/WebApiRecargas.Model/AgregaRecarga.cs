using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRecargas.Model
{
    public class AgregaRecarga
    {
        public int Id_Vendedor { get; set; }
        public int Id_Operador { get; set; }
        public string Numero_Celular { get; set; }
        public int Valor { get; set; }
    }
}
