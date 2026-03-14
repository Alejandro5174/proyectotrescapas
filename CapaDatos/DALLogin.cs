using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DALLogin
    {
        DALConexion conexion = new DALConexion();

        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public bool Login(string usuario, string password)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Usuario WHERE Usuario=@usuario AND Password=@password";
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@password", password);

            leer = comando.ExecuteReader();

            if (leer.HasRows)
            {
                conexion.CerrarConexion();
                return true;
            }
            else
            {
                conexion.CerrarConexion();
                return false;
            }
        }

    }
}
