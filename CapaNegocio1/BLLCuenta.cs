using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio1
{
   
    public class BLLCuenta
    {
        DALCuenta objetoDAL = new DALCuenta();
        public DataTable View()
        {
            DataTable tabla = new DataTable();
            tabla = objetoDAL.View();
            return tabla;
        }
        public void Create(string numeroCuenta, int clienteId, string tipoCuenta, decimal saldo)
        {
            objetoDAL.Create(numeroCuenta, clienteId, tipoCuenta, saldo);
        }
        public void Update(string numeroCuenta, int clienteId, string tipoCuenta, decimal saldo)
        {
            objetoDAL.Update(numeroCuenta, clienteId, tipoCuenta, saldo);
        }
        public void Delete(string numeroCuenta)
        {
            objetoDAL.Delete(numeroCuenta);
        }
    }
}
