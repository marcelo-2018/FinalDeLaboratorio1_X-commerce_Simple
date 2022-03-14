using System;
using System.Linq;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class ConsultaFactura : Form
    {
        public ConsultaFactura()
        {
            InitializeComponent();

            ObtenerCliente(String.Empty);
        }

        private void ObtenerCliente(string cadenaBuscar)
        {
            dgvFactura.DataSource = Program.Facturas.Where(x => x.ClienteStr.ToLower().Contains(cadenaBuscar.ToLower())
            || x.Numero.ToString().Contains(cadenaBuscar)).ToList();

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            dgvFactura.Columns["Numero"].Visible = true;
            dgvFactura.Columns["Numero"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvFactura.Columns["Fecha"].Visible = false;
            dgvFactura.Columns["Cliente"].Visible = false;
            dgvFactura.Columns["SubTotal"].Visible = false;
            dgvFactura.Columns["Descuento"].Visible = false;
            dgvFactura.Columns["Total"].Visible = false;
            dgvFactura.Columns["TotalFacturar"].Visible = true;
            //dgvFactura.Columns["Items"].Visible = false;

            dgvFactura.Columns["FechaStr"].Visible = true;
            dgvFactura.Columns["FechaStr"].HeaderText = "Fecha";
            dgvFactura.Columns["FechaStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactura.Columns["FechaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvFactura.Columns["ClienteStr"].Visible = true;
            dgvFactura.Columns["ClienteStr"].HeaderText = "Apellido y Nombre";
            dgvFactura.Columns["ClienteStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFactura.Columns["ClienteStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvFactura.Columns["TotalFacturar"].Visible = true;
            dgvFactura.Columns["TotalFacturar"].HeaderText = "Total";
            dgvFactura.Columns["TotalFacturar"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactura.Columns["TotalFacturar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFactura.Columns["TotalFacturar"].DefaultCellStyle.Format = "C2";
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ObtenerCliente(txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
