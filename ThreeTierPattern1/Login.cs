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
    public partial class Login : Form
    {
        BLLLogin objetoCN = new BLLLogin();
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (objetoCN.Login(txtUsuario.Text, txtPassword.Text))
            {
                Principal frm = new Principal();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            Logon frm = new Logon();
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
