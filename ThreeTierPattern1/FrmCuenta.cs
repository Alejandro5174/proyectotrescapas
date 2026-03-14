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
    public partial class FrmCuenta : Form
    {
        BLLCuenta objetoCN = new BLLCuenta();

        private int id = 0;
        private bool Editar = false;
        public FrmCuenta()
        {
            InitializeComponent();
        }
        private void LoadClientes()
        {
            BLLCliente objeto = new BLLCliente();

            cmbCliente.DataSource = objeto.View();
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ClienteID";
        }

        private void ViewAllCuentas()
        {
            BLLCuenta objeto = new BLLCuenta();
            dataGridView1.DataSource = objeto.View();
        }

        private void FrmCuenta_Load(object sender, EventArgs e)
        {
            ViewAllCuentas();
            LoadClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.Create(
                        txtNumeroCuenta.Text,
                        Convert.ToInt32(cmbCliente.SelectedValue),
                        txtTipoCuenta.Text,
                        Convert.ToDecimal(txtSaldo.Text)
                    );

                    MessageBox.Show("Cuenta creada correctamente");

                    ViewAllCuentas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }

            if (Editar == true)
            {
                try
                {
                    objetoCN.Update(
                        txtNumeroCuenta.Text,
                        Convert.ToInt32(cmbCliente.SelectedValue),
                        txtTipoCuenta.Text,
                        Convert.ToDecimal(txtSaldo.Text)
                    );

                    MessageBox.Show("Cuenta actualizada correctamente");

                    ViewAllCuentas();

                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message);
                }
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;

                txtNumeroCuenta.Text = dataGridView1.CurrentRow.Cells["NumeroCuenta"].Value.ToString();
                txtTipoCuenta.Text = dataGridView1.CurrentRow.Cells["TipoCuenta"].Value.ToString();
                txtSaldo.Text = dataGridView1.CurrentRow.Cells["Saldo"].Value.ToString();

                cmbCliente.SelectedValue = dataGridView1.CurrentRow.Cells["ClienteID"].Value;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string numero = dataGridView1.CurrentRow.Cells["NumeroCuenta"].Value.ToString();

                objetoCN.Delete(numero);

                MessageBox.Show("Cuenta eliminada correctamente");

                ViewAllCuentas();
            }
            else
            {
                MessageBox.Show("Seleccione una cuenta");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Editar = true;

                txtNumeroCuenta.Text = dataGridView1.CurrentRow.Cells["NumeroCuenta"].Value.ToString();
                txtTipoCuenta.Text = dataGridView1.CurrentRow.Cells["TipoCuenta"].Value.ToString();
                txtSaldo.Text = dataGridView1.CurrentRow.Cells["Saldo"].Value.ToString();

                cmbCliente.SelectedValue = dataGridView1.CurrentRow.Cells["ClienteID"].Value;
            }
            else
            {
                MessageBox.Show("Seleccione una cuenta para editar");
            }
        }
    }
}
