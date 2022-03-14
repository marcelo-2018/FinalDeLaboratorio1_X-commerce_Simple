using System;
using System.Linq;
using System.Windows.Forms;
using SegundoParcial.Clases;

namespace SegundoParcial
{
    public partial class ConsultaCuentaCorriente : Form
    {
        private int indice;
        private Cliente clienteActual;

        public ConsultaCuentaCorriente()
        {
            InitializeComponent();

            ObtenerClientesCuenta();

            indice = 0;
        }

        private void btnPagar_Click(object sender, System.EventArgs e)
        {
            PagarCuentaCorriente pagarCuentaCorriente = new PagarCuentaCorriente();

            if (dgvCuentaCorriente.SelectedRows.Count > 0)
            {
                indice = dgvCuentaCorriente.SelectedRows[0].Index;

                clienteActual = Program.CuentaCorrientes[indice].Cliente;

                DataGridViewRow row = dgvCuentaCorriente.Rows[indice];

                pagarCuentaCorriente.txtSaldo.Text = row.Cells["Monto"].Value.ToString();

                decimal montoPagar = 0m;
                decimal.TryParse(pagarCuentaCorriente.txtSaldo.Text, out montoPagar);

                if (montoPagar > 0)
                {
                    pagarCuentaCorriente.ShowDialog();

                    RealizarPago(clienteActual, pagarCuentaCorriente.MontoPagar);
                }
                else
                {
                    MessageBox.Show("La cuenta que desea pagar, no tiene saldo pendiente.","Atención");
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un registro", "Atención");
            }

            ObtenerClientesCuenta();
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ObtenerClientesCuenta()
        {
            dgvCuentaCorriente.DataSource = Program.CuentaCorrientes.ToList();

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            dgvCuentaCorriente.Columns["Cliente"].Visible = false;
            dgvCuentaCorriente.Columns["Fecha"].Visible = false;
            dgvCuentaCorriente.Columns["TipoMovimiento"].Visible = false;

            dgvCuentaCorriente.Columns["ClienteStr"].HeaderText = "Cliente";
            dgvCuentaCorriente.Columns["ClienteStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCuentaCorriente.Columns["ClienteStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCuentaCorriente.Columns["Monto"].Visible = true;
            dgvCuentaCorriente.Columns["Monto"].DefaultCellStyle.Format = "C2";
            dgvCuentaCorriente.Columns["Monto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCuentaCorriente.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCuentaCorriente.Columns["FechaStr"].HeaderText = "Fecha";
            dgvCuentaCorriente.Columns["FechaStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCuentaCorriente.Columns["FechaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void RealizarPago(Cliente clienteActual, decimal monto)
        {
            var cuentaCliente = Program.CuentaCorrientes.FirstOrDefault(c => c.Cliente.Equals(clienteActual));

            try
            {
                if (cuentaCliente != null)
                {
                    cuentaCliente.Monto = monto;
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
