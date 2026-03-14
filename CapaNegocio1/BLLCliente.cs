using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio1
{
    public class BLLCliente
    {
        DALCliente objetoDAL = new DALCliente();

        public DataTable View()
        {
            DataTable tabla = new DataTable();
            tabla = objetoDAL.View();
            return tabla;
        }
        public void Create(string nombre, string apellido, string dni, string email, string telefono)
        {
            objetoDAL.Create(nombre, apellido, dni, email, telefono);
        }
        public void Update(string nombre, string apellido, string dni, string email, string telefono, int id)
        {
            objetoDAL.Update(nombre, apellido, dni, email, telefono, id);
        }
        public void Delete(int id)
        {
            objetoDAL.Delete(id);
        }
    }
}
