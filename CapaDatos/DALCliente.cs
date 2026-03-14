using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DALCliente
    {
        DALConexion conexion = new DALConexion();

        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        DataTable tabla = new DataTable();

        public DataTable View()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_LeerClientes";
            comando.CommandType = CommandType.StoredProcedure;

            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();

            return tabla;
        }
        public void Create(string nombre, string apellido, string dni, string email, string telefono)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_CrearCliente";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Apellido", apellido);
            comando.Parameters.AddWithValue("@DNI", dni);
            comando.Parameters.AddWithValue("@Email", email);
            comando.Parameters.AddWithValue("@Telefono", telefono);

            comando.ExecuteNonQuery();

            conexion.CerrarConexion();
        }


        public void Update(string nombre, string apellido, string dni, string email, string telefono, int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_ActualizarCliente";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ClienteID", id);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Apellido", apellido);
            comando.Parameters.AddWithValue("@DNI", dni);
            comando.Parameters.AddWithValue("@Email", email);
            comando.Parameters.AddWithValue("@Telefono", telefono);

            comando.ExecuteNonQuery();

            conexion.CerrarConexion();
        }
        public void Delete(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EliminarCliente";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@ClienteID", id);

            comando.ExecuteNonQuery();

            conexion.CerrarConexion();
        }
    }
}
