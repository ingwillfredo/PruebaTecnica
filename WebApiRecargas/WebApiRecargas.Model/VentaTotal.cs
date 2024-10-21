using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRecargas.Model
{
    public class VentaTotal
    {
        public int Id_Operador { get; set; }
        public int Cantidad { get; set; }
        public int ValorTotal { get; set; }
        public string Operador { get; set; }
        public string Vendedor { get; set; }
    }
}
