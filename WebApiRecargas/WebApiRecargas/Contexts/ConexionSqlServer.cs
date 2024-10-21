using Microsoft.EntityFrameworkCore;

namespace WebApiRecargas.Contexts
{
    public class ConexionSqlServer : DbContext
    {
        public ConexionSqlServer(DbContextOptions<ConexionSqlServer> options) : base (options){
        }
    }
}
