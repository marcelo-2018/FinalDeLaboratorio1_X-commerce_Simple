using SegundoParcial.Clases;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class NuevoProducto : Form
    {
        private Producto _productoActual;

        public NuevoProducto()
        {
            InitializeComponent();

            PoblarCombo();

            Validacion validacion = new Validacion();

            _productoActual = new Producto();
        }

        private void btnNuevaMarca_Click(object sender, System.EventArgs e)
        {
            NuevaMarca nuevaMarca = new NuevaMarca();
            nuevaMarca.ShowDialog();

            PoblarCombo();
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

        private void btnNuevoRubro_Click(object sender, System.EventArgs e)
        {
            NuevoRubro nuevoRubro = new NuevoRubro();
            nuevoRubro.ShowDialog();

            PoblarCombo();
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            LimpiarControles();
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

            if(cmbMarca.Items.Count > 0 )
            {
                cmbMarca.SelectedIndex = 0;
            }

            if(cmbRubro.Items.Count > 0 )
            {
                cmbRubro.SelectedIndex = 0;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCodigo.Text))
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

            _productoActual = VerificarSiExiste(txtCodigo.Text, txtcodigoBarra.Text);

            if (_productoActual == null)
            {
                Producto nuevoProducto = new Producto();

                nuevoProducto.Codigo = int.Parse(txtCodigo.Text);
                nuevoProducto.CodigoBarra = txtcodigoBarra.Text;
                nuevoProducto.Descripcion = txtDescripcion.Text;
                nuevoProducto.PrecioCosto = nudPrecioCosto.Value;
                nuevoProducto.PrecioPublico = nudPrecioPublico.Value;
                nuevoProducto.Stock = nudStock.Value;
                nuevoProducto.EstaEliminado = false;
                nuevoProducto.Marca = (Marca)cmbMarca.SelectedItem;
                nuevoProducto.Rubro = (Rubro)cmbRubro.SelectedItem;

                Program.Productos.Add(nuevoProducto);

                MessageBox.Show("Los datos se cargaron con exito.","Atención");

                LimpiarControles();
            }
            else
            {
                MessageBox.Show("El producto que desea ingresar ya existe.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chkPermitirStockNegativo_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPermitirStockNegativo.Checked == true)
            {
                nudStock.Minimum = -9999999999;
            }
            else
            {
                nudStock.Minimum = 1;
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

        private Producto VerificarSiExiste(string codigo, string codigoBarra)
        {
            foreach (var producto in Program.Productos)
            {
                if (producto.Codigo.ToString().Equals(codigo) || producto.CodigoBarra.Equals(codigoBarra))
                {
                    return producto;
                }
            }

            return null;
        }
    }
}
