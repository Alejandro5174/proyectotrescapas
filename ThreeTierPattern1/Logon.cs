using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio1;

namespace ThreeTierPattern1
{
    public partial class Logon : Form
    {
        BLLLogon objetoCN = new BLLLogon();
        public Logon()
        {
            InitializeComponent();
        }

        private void btnGaurdar_Click(object sender, EventArgs e)
        {
            objetoCN.Create(txtUsuario.Text,txtPassword.Text,Convert.ToInt32(txtNivelSeg.Text));

            MessageBox.Show("Usuario creado correctamente");

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
