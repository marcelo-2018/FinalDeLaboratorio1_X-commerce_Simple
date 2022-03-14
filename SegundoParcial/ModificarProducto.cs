using System.Linq;
using System.Windows.Forms;
using SegundoParcial.Clases;

namespace SegundoParcial
{
    public partial class ModificarProducto : Form
    {
        private int indice;

        public ModificarProducto(int indice)
        {
            InitializeComponent();

            this.indice = indice;

            PoblarCombo();

            Validacion validacion = new Validacion();
        }

        private void btnNuevaMarca_Click(object sender, System.EventArgs e)
        {
            NuevaMarca nuevaMarca = new NuevaMarca();
            nuevaMarca.ShowDialog();

            PoblarCombo();
        }

        private void btnNuevoRubro_Click(object sender, System.EventArgs e)
        {
            NuevoRubro nuevoRubro = new NuevoRubro();
            nuevoRubro.ShowDialog();

            PoblarCombo();
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Los cambios no se guardaran. ¿Seguro que desea salir?", "Atención",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

       
        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            LimpiarControles();
        }

        private void PoblarCombo()
        {
            cmbMarca.DataSource = Program.Marcas.OrderBy(x => x.Descripcion).ToList();
            cmbRubro.DataSource = Program.Rubros.OrderBy(x => x.Descripcion).ToList();

            cmbMarca.DisplayMember = "Descripcion";
            cmbMarca.ValueMember = "Descripcion";

            cmbRubro.DisplayMember = "Descripcion";
            cmbRubro.ValueMember = "Descripcion";
        }

        private void LimpiarControles()
        {
            txtCodigo.Clear();
            txtcodigoBarra.Clear();
            txtDescripcion.Clear();
            nudStock.Value = 1;
            nudPrecioCosto.Value = 1.00m;
            nudPrecioPublico.Value = 1.00m;
            chkPermitirStockNegativo.Checked = false;

            if (cmbMarca.Items.Count > 0)
            {
                cmbMarca.SelectedIndex = 0;
            }

            if (cmbRubro.Items.Count > 0)
            {
                cmbRubro.SelectedIndex = 0;
            }
        }

        private void chkPermitirStockNegativo_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkPermitirStockNegativo.Checked == true)
            {
                nudStock.Minimum = -9999999999;
            }
            else
            {
                nudStock.Minimum = 1;
            }
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor complete todos los campos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtcodigoBarra.Text))
            {
                MessageBox.Show("Por favor complete todos los campos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcodigoBarra.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor complete todos los campos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }


            if (MessageBox.Show("¿Esta seguro que desea guardar los cambios?", "Atención",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (indice != -1)
                {
                    Program.Productos[indice].Codigo = int.Parse(txtCodigo.Text); 
                    Program.Productos[indice].CodigoBarra = txtcodigoBarra.Text;
                    Program.Productos[indice].Descripcion = txtDescripcion.Text;
                    Program.Productos[indice].Stock = nudStock.Value;
                    Program.Productos[indice].PrecioCosto = nudPrecioCosto.Value;
                    Program.Productos[indice].PrecioPublico = nudPrecioPublico.Value;
                    Program.Productos[indice].Marca = (Marca)cmbMarca.SelectedItem;
                    Program.Productos[indice].Rubro = (Rubro)cmbRubro.SelectedItem;
                }

                MessageBox.Show("Los datos se guardaron con exito.");

                this.Close();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngrearSoloNumeros(e);
        }

        private void txtcodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngrearSoloNumeros(e);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngresarSoloLetras(e);
        }
    }
}
