using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApiRecargas.Model;
using Microsoft.Data.SqlClient;



namespace WebApiRecargas.Data
{
    public class VentaTotalRepository : IVentaTotalRepository
    {
        public VentaTotalRepository()
        {

        }

        async Task<List<VentaTotal>> IVentaTotalRepository.GetVentaTotal()
        {

            Conexion bd = new Conexion();
            List<VentaTotal> ventas = new List<VentaTotal>();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("VentasPorOperador", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                await conn.OpenAsync();
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ventas.Add(new VentaTotal
                        {
                            Id_Operador = int.Parse(dr["Id_Operador"].ToString()),
                            Cantidad = int.Parse(dr["Cantidad"].ToString()),
                            ValorTotal = int.Parse(dr["Ventas_Total"].ToString()),
                            Operador = dr["Operador"].ToString(),
                            Vendedor = dr["Vendedor"].ToString()
                        });
                    }
                    dr.Close();
                    return ventas;
                }
                else
                {
                    return ventas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        async Task<string> IVentaTotalRepository.AgregaRecarga(AgregaRecarga agregaRecarga)
        {
            Conexion bd = new Conexion();
            string messageResult = string.Empty;
            SqlConnection conn = new SqlConnection(bd.ConexionString());

            try
            {
                SqlCommand cmd = new SqlCommand("AgregaRecarga", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@Id_Vendedor", SqlDbType.Int).Value = agregaRecarga.Id_Vendedor;
                cmd.Parameters.Add("@Id_Operador", SqlDbType.Int).Value = agregaRecarga.Id_Operador;
                cmd.Parameters.Add("@Numero_Celular", SqlDbType.VarChar).Value = agregaRecarga.Numero_Celular;
                cmd.Parameters.Add("@Valor", SqlDbType.Int).Value = agregaRecarga.Valor;


                await conn.OpenAsync();
                messageResult = cmd.ExecuteScalar().ToString();

                return messageResult;
            }
            catch (Exception ex)
            {
                return messageResult = "Se presento una excepción: " + ex.Message;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        async Task<List<Vendedor>> IVentaTotalRepository.GetVendedores()
        {

            Conexion bd = new Conexion();
            List<Vendedor> vendedor = new List<Vendedor>();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("Listavendedores", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                await conn.OpenAsync();
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        vendedor.Add(new Vendedor
                        {
                            Id_Vendedor = int.Parse(dr["Id_Vendedor"].ToString()),
                            Nombre_Vendedor = dr["Nombre_Vendedor"].ToString()
                        });
                    }
                    dr.Close();
                    return vendedor;
                }
                else
                {
                    return vendedor;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        async Task<List<Operador>> IVentaTotalRepository.GetOperadores()
        {

            Conexion bd = new Conexion();
            List<Operador> operador = new List<Operador>();
            SqlConnection conn = new SqlConnection(bd.ConexionString());
            try
            {
                SqlCommand cmd = new SqlCommand("ListaOperadores", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                await conn.OpenAsync();
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        operador.Add(new Operador
                        {
                            id_Operador = int.Parse(dr["id_Operador"].ToString()),
                            nombre_Operador = dr["nombre_Operador"].ToString()
                        });
                    }
                    dr.Close();
                    return operador;
                }
                else
                {
                    return operador;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
