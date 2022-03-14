using System.Linq;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class ConsultaProducto : Form
    {
        private int indice;

        public ConsultaProducto()
        {
            InitializeComponent();

            indice = 0;

            ObtenerProducto(string.Empty);
        }

        private void ObtenerProducto(string cadenabuscar)
        {
            dgvProducto.DataSource = Program.Productos.Where(x =>
                x.Descripcion.ToLower().Contains(cadenabuscar.ToLower())
                || x.Codigo.ToString().Contains(cadenabuscar) || x.CodigoBarra.Contains(cadenabuscar)).ToList();

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            dgvProducto.Columns["Codigo"].HeaderText = "Código";
            dgvProducto.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            

            dgvProducto.Columns["CodigoBarra"].HeaderText = "Código de Barras";
            dgvProducto.Columns["CodigoBarra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducto.Columns["PrecioCosto"].Visible = false;

            dgvProducto.Columns["PrecioPublico"].HeaderText = "Precio publico";
            dgvProducto.Columns["PrecioPublico"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducto.Columns["PrecioPublico"].DefaultCellStyle.Format = "C2";

            dgvProducto.Columns["Stock"].HeaderText = "Stock";
            dgvProducto.Columns["Stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducto.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducto.Columns["Descripcion"].HeaderText = "Descripción";
            dgvProducto.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducto.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvProducto.Columns["Marca"].Visible = false;
            dgvProducto.Columns["Rubro"].Visible = false;
            dgvProducto.Columns["RubroStr"].Visible = false;
            dgvProducto.Columns["MarcaStr"].Visible = false;
            dgvProducto.Columns["MarcaStr"].HeaderText = "Marca";
            dgvProducto.Columns["RubroStr"].HeaderText = "Rubro";

            dgvProducto.Columns["EstaEliminado"].Visible = false;
            dgvProducto.Columns["EstaEliminadoStr"].Visible = true;
            dgvProducto.Columns["EstaEliminadoStr"].HeaderText = "Eliminado";
            dgvProducto.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnNuevo_Click(object sender, System.EventArgs e)
        {
            NuevoProducto nuevoProducto = new NuevoProducto();
            nuevoProducto.ShowDialog();

            ObtenerProducto(string.Empty);
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ObtenerProducto(txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count > 0)
            {
                indice = dgvProducto.SelectedRows[0].Index;

                if (indice != -1)
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar este producto?", "Atencion",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Program.Productos[indice].EstaEliminado = !Program.Productos[indice].EstaEliminado;
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

            ObtenerProducto(string.Empty);
        }

        private void btnModificar_Click(object sender, System.EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count > 0)
            {
                indice = dgvProducto.SelectedRows[0].Index;

                if (Program.Productos[indice].EstaEliminado != true)
                {
                    ModificarProducto fModificarProducto = new ModificarProducto(indice);

                    if (indice != -1)
                    {
                        fModificarProducto.txtCodigo.Text = Program.Productos[indice].Codigo.ToString();
                        fModificarProducto.txtcodigoBarra.Text = Program.Productos[indice].CodigoBarra;
                        fModificarProducto.txtDescripcion.Text = Program.Productos[indice].Descripcion;
                        fModificarProducto.nudStock.Value = Program.Productos[indice].Stock;
                        fModificarProducto.nudPrecioCosto.Value = Program.Productos[indice].PrecioCosto;
                        fModificarProducto.nudPrecioPublico.Value = Program.Productos[indice].PrecioPublico;
                        fModificarProducto.cmbMarca.SelectedItem = Program.Productos[indice].Marca;
                        fModificarProducto.cmbRubro.SelectedItem = Program.Productos[indice].Rubro;
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione un registro.", "Atención");
                    }

                    fModificarProducto.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El producto que desea modificar se encuentra eliminado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay registro cargados.", "Atención");
            }

            ObtenerProducto(string.Empty);
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            ObtenerProducto(string.Empty);
        }
    }
}
