using System.Linq;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class ConsultaMarca : Form
    {
        private int indice;

        public ConsultaMarca()
        {
            InitializeComponent();

            indice = 0;

            ObtenerMarca(string.Empty);
        }

        private void ObtenerMarca(string cadenaBuscar)
        {
            dgvMarca.DataSource = Program.Marcas.Where(x =>
                x.Codigo.Contains(cadenaBuscar) || x.Descripcion.ToLower().Contains(cadenaBuscar.ToLower())).ToList();

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            dgvMarca.Columns["Codigo"].Visible = true;
            dgvMarca.Columns["Codigo"].HeaderText = "Código";
            dgvMarca.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvMarca.Columns["Descripcion"].Visible = true;
            dgvMarca.Columns["Descripcion"].HeaderText = "Descripción";
            dgvMarca.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMarca.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvMarca.Columns["EstaEliminado"].Visible = false;
            dgvMarca.Columns["EstaEliminadoStr"].Visible = true;
            dgvMarca.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgvMarca.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMarca.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ObtenerMarca(txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void btnNuevo_Click(object sender, System.EventArgs e)
        {
            NuevaMarca fNuevaMarca = new NuevaMarca();
            fNuevaMarca.ShowDialog();

            ObtenerMarca(string.Empty);
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (dgvMarca.SelectedRows.Count > 0)
            {
                indice = dgvMarca.SelectedRows[0].Index;

                if (indice != -1)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar esta Marca?", "Atencion",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Program.Marcas[indice].EstaEliminado = !Program.Marcas[indice].EstaEliminado;
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un registro.", "Atención");
                }
            }
            else
            {
                MessageBox.Show("No hay registro cargados.", "Atención");
            }

            ObtenerMarca(string.Empty);
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            ObtenerMarca(string.Empty);
        }

        private void btnModificar_Click(object sender, System.EventArgs e)
        {
            if (dgvMarca.SelectedRows.Count > 0)
            {
                indice = dgvMarca.SelectedRows[0].Index;

                if (Program.Marcas[indice].EstaEliminado != true)
                {
                    ModificarMarca modificarMarca = new ModificarMarca(indice);

                    if (indice != -1)
                    {
                        modificarMarca.txtCodigo.Text = Program.Marcas[indice].Codigo;
                        modificarMarca.txtDescripcion.Text = Program.Marcas[indice].Descripcion;
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione un registro.", "Atención");
                    }

                    modificarMarca.ShowDialog();
                }
                else
                {
                    MessageBox.Show("La Marca que desea modificar se encuentra eliminada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay registro cargados.", "Atención");
            }

            ObtenerMarca(string.Empty);
        }
    }
}
