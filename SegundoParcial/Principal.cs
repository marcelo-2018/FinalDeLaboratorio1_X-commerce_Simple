using System;
using System.Windows.Forms;
using SegundoParcial.Clases;

namespace SegundoParcial
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del sistema?", "Atencion",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void puntoDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPuntoVenta frmPuntoVenta = new fPuntoVenta();
            frmPuntoVenta.ShowDialog();
        }

        private void ConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaProducto consultaProducto = new ConsultaProducto();
            consultaProducto.ShowDialog();
        }

        private void NuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoProducto nuevoProducto = new NuevoProducto();
            nuevoProducto.ShowDialog();
        }

        private void ConsultaDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaCliente consultaCliente = new ConsultaCliente();
            consultaCliente.ShowDialog();
        }

        private void NuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoCliente nuevoCliente = new NuevoCliente();
            nuevoCliente.ShowDialog();
        }

        private void CerrarLaSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea cerrar sesion?", "Atencion",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Login flogin = new Login();
                flogin.ShowDialog();
            }
        }

        private void cuentaCorrienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaCuentaCorriente cuentaCorriente = new ConsultaCuentaCorriente();
            cuentaCorriente.ShowDialog();
        }

        private void consultaDeFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaFactura consultaFactura = new ConsultaFactura();
            consultaFactura.ShowDialog();
        }

        private void nuevaMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevaMarca fNuevaMarca = new NuevaMarca();
            fNuevaMarca.ShowDialog();
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaMarca fConsultaMarca = new ConsultaMarca();
            fConsultaMarca.ShowDialog();
        }

        private void consultaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ConsultaRubro fConsultaRubro = new ConsultaRubro();
            fConsultaRubro.ShowDialog();
        }

        private void nuevoRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoRubro fNuevoRubro = new NuevoRubro();
            fNuevoRubro.ShowDialog();
        }
    }
}
