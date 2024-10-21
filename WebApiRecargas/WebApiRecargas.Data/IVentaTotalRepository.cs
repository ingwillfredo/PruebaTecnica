using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRecargas.Model;

namespace WebApiRecargas.Data
{
    public interface IVentaTotalRepository
    {
        Task<List<VentaTotal>> GetVentaTotal();
        Task<string> AgregaRecarga(AgregaRecarga agregaRecarga);
        Task<List<Vendedor>> GetVendedores();
        Task<List<Operador>> GetOperadores();
    }
}
