using System;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class PagarCuentaCorriente : Form
    {
        private decimal saldoDisponible;

        public decimal MontoPagar
        {
            get { return saldoDisponible; }
        }

        public PagarCuentaCorriente()
        {
            InitializeComponent();

            saldoDisponible = 0m;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cancelar la operación?", "Atención",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            decimal montoPagar = nudMontoPagar.Value;

            decimal.TryParse(txtSaldo.Text, out saldoDisponible);

            if (montoPagar > 0)
            {
                if (montoPagar <= saldoDisponible)
                {
                    saldoDisponible -= montoPagar;

                    MessageBox.Show("El pago se realizó con éxito.");
                }
                else
                {
                    MessageBox.Show("El monto ingresado es mayor al saldo disponible.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    nudMontoPagar.Value = 0.00m;
                    nudMontoPagar.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un monto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.Close();
        }
    }
}
