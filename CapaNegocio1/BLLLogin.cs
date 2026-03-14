using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio1
{
    public class BLLLogin
    {
        DALLogin objetoDAL = new DALLogin();
        public bool Login(string usuario, string password)
        {
            return objetoDAL.Login(usuario, password);
        }
    }
}
