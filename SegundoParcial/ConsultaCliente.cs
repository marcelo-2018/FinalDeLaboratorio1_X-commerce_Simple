using System;
using System.Linq;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class ConsultaCliente : Form
    {
        private int indice;

        public ConsultaCliente()
        {
            InitializeComponent();

            indice = 0;

            ObtenerCliente(string.Empty);
        }

        private void ObtenerCliente(string cadenaBuscar)
        {
            dgvCliente.DataSource = Program.Clientes.Where(x => x.Nombre.ToLower().Contains(cadenaBuscar.ToLower())
                                                                || x.Apellido.ToLower().Contains(cadenaBuscar.ToLower())
                                                                || x.Dni.Contains(cadenaBuscar)).ToList();

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            dgvCliente.Columns["Apellido"].Visible = false;
            dgvCliente.Columns["Nombre"].Visible = false;
            
            dgvCliente.Columns["ApyNom"].Visible = true;
            dgvCliente.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgvCliente.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCliente.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCliente.Columns["Dni"].Visible = true;
            dgvCliente.Columns["Dni"].HeaderText = "DNI";
            dgvCliente.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCliente.Columns["Dni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCliente.Columns["EstaEliminado"].Visible = false;

            dgvCliente.Columns["EstaEliminadoStr"].Visible = true;
            dgvCliente.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgvCliente.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCliente.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnNuevo_Click(object sender, System.EventArgs e)
        {
            NuevoCliente nuevoCliente = new NuevoCliente();
            nuevoCliente.ShowDialog();

            ObtenerCliente(string.Empty);
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                indice = dgvCliente.SelectedRows[0].Index;

                    if (indice != -1)
                    {
                        if (MessageBox.Show("¿Esta seguro que desea eliminar este cliente?", "Atencion",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Program.Clientes[indice].EstaEliminado = !Program.Clientes[indice].EstaEliminado;
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

            ObtenerCliente(string.Empty);
        }

        private void btnModificar_Click(object sender, System.EventArgs e)
        {
            if(dgvCliente.SelectedRows.Count > 0)
            {
                indice = dgvCliente.SelectedRows[0].Index;

                if (Program.Clientes[indice].EstaEliminado != true)
                {
                    ModificarCliente modificarCliente = new ModificarCliente(indice);

                    if (indice != -1)
                    {
                        modificarCliente.txtApellido.Text = Program.Clientes[indice].Apellido;
                        modificarCliente.txtNombre.Text = Program.Clientes[indice].Nombre;
                        modificarCliente.txtDNI.Text = Program.Clientes[indice].Dni;
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione un registro.", "Atención");
                    }

                    modificarCliente.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El cliente que desea modificar se encuentra eliminado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay registro cargados.", "Atención");
            }

            ObtenerCliente(string.Empty);
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            ObtenerCliente(String.Empty);
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
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
    }
}
