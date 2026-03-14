using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DALLogon
    {
        DALConexion conexion = new DALConexion();

        public void Create(string usuario, string password, int nivel)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Usuario (Usuario,Password,NivelSeguridad) VALUES (@usuario,@password,@nivel)";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@password", password);
            comando.Parameters.AddWithValue("@nivel", nivel);

            comando.ExecuteNonQuery();

            conexion.CerrarConexion();
        }
    }
}
