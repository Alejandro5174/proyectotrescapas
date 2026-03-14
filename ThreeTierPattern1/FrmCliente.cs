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
    public partial class FrmCliente : Form
    {
        BLLCliente objetoCN = new BLLCliente();

        private int id = 0;
        private bool Editar = false;
        public FrmCliente()
        {
            InitializeComponent();
        }
        private void ViewAllClientes()
        {
            BLLCliente objeto = new BLLCliente();
            dataGridView1.DataSource = objeto.View();
        }

        private void ClearControls()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {
            ViewAllClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    if (txtNombre.Text == "")
                    {
                        MessageBox.Show("Falta ingresar el Nombre");
                        txtNombre.Focus();
                        return;
                    }

                    objetoCN.Create(
                        txtNombre.Text,
                        txtApellido.Text,
                        txtDNI.Text,
                        txtEmail.Text,
                        txtTelefono.Text
                    );

                    MessageBox.Show("Cliente guardado correctamente");

                    ViewAllClientes();
                    ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos: " + ex.Message);
                }
            }

            if (Editar == true)
            {
                try
                {
                    objetoCN.Update(
                        txtNombre.Text,
                        txtApellido.Text,
                        txtDNI.Text,
                        txtEmail.Text,
                        txtTelefono.Text,
                        id
                    );

                    MessageBox.Show("Cliente actualizado correctamente");

                    ViewAllClientes();
                    ClearControls();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo actualizar los datos: " + ex.Message);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;

                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                txtDNI.Text = dataGridView1.CurrentRow.Cells["DNI"].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();

                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClienteID"].Value);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClienteID"].Value);

                objetoCN.Delete(id);

                MessageBox.Show("Cliente eliminado correctamente");

                ViewAllClientes();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
