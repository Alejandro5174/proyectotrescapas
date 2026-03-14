using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DALCuenta
    {
        DALConexion conexion = new DALConexion();

        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        DataTable tabla = new DataTable();

        public DataTable View()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Cuenta";
            comando.CommandType = CommandType.Text;

            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();

            return tabla;
        }
        public void Create(string numeroCuenta, int clienteId, string tipoCuenta, decimal saldo)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "INSERT INTO Cuenta (NumeroCuenta,ClienteID,TipoCuenta,Saldo) VALUES (@numero,@cliente,@tipo,@saldo)";

            comando.Parameters.AddWithValue("@numero", numeroCuenta);
            comando.Parameters.AddWithValue("@cliente", clienteId);
            comando.Parameters.AddWithValue("@tipo", tipoCuenta);
            comando.Parameters.AddWithValue("@saldo", saldo);

            comando.ExecuteNonQuery();

            conexion.CerrarConexion();
        }
        public void Update(string numeroCuenta, int clienteId, string tipoCuenta, decimal saldo)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "UPDATE Cuenta SET ClienteID=@cliente, TipoCuenta=@tipo, Saldo=@saldo WHERE NumeroCuenta=@numero";

            comando.Parameters.AddWithValue("@numero", numeroCuenta);
            comando.Parameters.AddWithValue("@cliente", clienteId);
            comando.Parameters.AddWithValue("@tipo", tipoCuenta);
            comando.Parameters.AddWithValue("@saldo", saldo);

            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
        public void Delete(string numeroCuenta)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "DELETE FROM Cuenta WHERE NumeroCuenta=@numero";

            comando.Parameters.AddWithValue("@numero", numeroCuenta);

            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
    }
}
