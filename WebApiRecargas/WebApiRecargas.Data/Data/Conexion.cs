namespace WebApiRecargas.Data
{
    public class Conexion
    {
        public string ConexionString()
        {
            string _CadenaConexion = string.Empty;

            //_CadenaConexion = "Data Source=INGWILLFREDO\\SQLEXPRESS;Initial Catalog=DB_Recargas;Persist Security Info=True;User ID=Will;Encrypt=False;Trust Server Certificate=True";
            _CadenaConexion = "Data Source=INGWILLFREDO\\SQLEXPRESS;Initial Catalog=DB_Recargas;User ID=Will;Password=Will0811";

            return _CadenaConexion;
        }
     }
}
