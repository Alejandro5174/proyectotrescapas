using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio1
{
    public class BLLLogon
    {
        DALLogon objetoDAL = new DALLogon();

        public void Create(string usuario, string password, int nivel)
        {
            objetoDAL.Create(usuario, password, nivel);
        }
    }
}
