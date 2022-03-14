using System;
using System.Linq;
using System.Windows.Forms;
using SegundoParcial.Clases;

namespace SegundoParcial
{
    public partial class Facturar : Form
    {
        private int indice;
        private decimal _total;

        public bool confirmar { get; set; }

        public Facturar(decimal total)
        {
            InitializeComponent();

            indice = 0;

            _total = total;

            ObtenerClientes(string.Empty);
        }

        private void ObtenerClientes(string cadenaBuscar)
        {
            dgvFacturar.DataSource = Program.Clientes.Where(x => x.EstaEliminado != true 
                                                                 && x.Apellido.ToLower().Contains(cadenaBuscar.ToLower()) 
                                                                 || x.Nombre.ToLower().Contains(cadenaBuscar.ToLower())
                                                                 || x.Dni.Contains(cadenaBuscar)).ToList();

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            dgvFacturar.Columns["Nombre"].Visible = false;
            dgvFacturar.Columns["Apellido"].Visible = false;

            dgvFacturar.Columns["ApyNom"].Visible = true;
            dgvFacturar.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgvFacturar.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvFacturar.Columns["Dni"].Visible = true;
            dgvFacturar.Columns["Dni"].HeaderText = "DNI";
            dgvFacturar.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFacturar.Columns["Dni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvFacturar.Columns["EstaEliminado"].Visible = false;

            dgvFacturar.Columns["EstaEliminadoStr"].Visible = false;
        }

        private void btnConfirmar_Click(object sender, System.EventArgs e)
        {
            var clienteActual = new Cliente();

            if (dgvFacturar.SelectedRows.Count > 0)
            {
                indice = dgvFacturar.SelectedRows[0].Index;

                if (indice != -1)
                {
                    Program.CuentaCorrientes[indice].Monto += _total;
                    NuevaFactura(indice);
                }

                MessageBox.Show("Los datos se cargaron con exito.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);

                confirmar = true;

                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un registro","Atención",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void NuevaFactura(int indice)
        {
            //var cuenta = Program.CuentaCorrientes.FirstOrDefault(x => x.Cliente.Equals(clienteActual));

                Factura nuevaFactura = new Factura();

                fPuntoVenta puntoVenta = new fPuntoVenta();

                nuevaFactura.Cliente = new Cliente();
                nuevaFactura.Cliente.Apellido = Program.Clientes[indice].Apellido;
                nuevaFactura.Cliente.Nombre = Program.Clientes[indice].Nombre;
                nuevaFactura.Fecha = DateTime.Now;
                nuevaFactura.Numero = int.Parse(puntoVenta.txtNumeroFactura.Text);
                nuevaFactura.TotalFacturar = _total;

                Program.Facturas.Add(nuevaFactura);
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            confirmar = false;

            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ObtenerClientes(txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }
    }
}
