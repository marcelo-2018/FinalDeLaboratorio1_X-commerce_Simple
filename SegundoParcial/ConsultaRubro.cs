using System;
using System.Linq;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class ConsultaRubro : Form
    {
        private int indice;

        public ConsultaRubro()
        {
            InitializeComponent();

            indice = 0;

            ObtenerRubro(string.Empty);
        }

        private void ObtenerRubro(string cadenaBuscar)
        {
            dgvRubro.DataSource = Program.Rubros.Where(x =>
                x.Codigo.Contains(cadenaBuscar) || x.Descripcion.ToLower().Contains(cadenaBuscar.ToLower())).ToList();

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            dgvRubro.Columns["Codigo"].Visible = true;
            dgvRubro.Columns["Codigo"].HeaderText = "Código";
            dgvRubro.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvRubro.Columns["Descripcion"].Visible = true;
            dgvRubro.Columns["Descripcion"].HeaderText = "Descripción";
            dgvRubro.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRubro.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvRubro.Columns["EstaEliminado"].Visible = false;
            dgvRubro.Columns["EstaEliminadoStr"].Visible = true;
            dgvRubro.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgvRubro.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRubro.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            ObtenerRubro(String.Empty);
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            NuevoRubro fNuevaRubro = new NuevoRubro();
            fNuevaRubro.ShowDialog();

            ObtenerRubro(string.Empty);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRubro.SelectedRows.Count > 0)
            {
                indice = dgvRubro.SelectedRows[0].Index;

                if (indice != -1)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar esta Rubro?", "Atencion",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Program.Rubros[indice].EstaEliminado = !Program.Rubros[indice].EstaEliminado;
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

            ObtenerRubro(string.Empty);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvRubro.SelectedRows.Count > 0)
            {
                indice = dgvRubro.SelectedRows[0].Index;

                if (Program.Rubros[indice].EstaEliminado != true)
                {
                    ModificarRubro modificarRubro = new ModificarRubro(indice);

                    if (indice != -1)
                    {
                        modificarRubro.txtCodigo.Text = Program.Rubros[indice].Codigo;
                        modificarRubro.txtDescripcion.Text = Program.Rubros[indice].Descripcion;
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione un registro.", "Atención");
                    }

                    modificarRubro.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El Rubro que desea modificar se encuentra eliminada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay registros cargados.", "Atención");
            }

            ObtenerRubro(string.Empty);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ObtenerRubro(txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }
    }
}
