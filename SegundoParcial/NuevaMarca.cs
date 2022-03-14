namespace SegundoParcial
{
    using SegundoParcial.Clases;
    using System;
    using System.Windows.Forms;

    public partial class NuevaMarca : Form
    {
        private Marca _marcaActual;

        public NuevaMarca()
        {
            InitializeComponent();

            _marcaActual = new Marca();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();

            txtCodigo.Focus();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            _marcaActual = VerificarSiExiste(txtCodigo.Text, txtDescripcion.Text);

            if (_marcaActual == null)
            {
                Marca nuevaMarca = new Marca();

                nuevaMarca.Codigo = txtCodigo.Text;
                nuevaMarca.Descripcion = txtDescripcion.Text;

                Program.Marcas.Add(nuevaMarca);

                MessageBox.Show("Los datos se cargaron con exito.");

                LimpiarControles();
            }
            else
            {
                MessageBox.Show("La marca que desea ingresar ya exite.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngrearSoloNumeros(e);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngresarSoloLetras(e);
        }

        private Marca VerificarSiExiste(string codigo, string descripcion)
        {
            foreach (var marca in Program.Marcas)
            {
                if (marca.Codigo.Equals(codigo) || marca.Descripcion.ToLower().Equals(descripcion.ToLower()))
                {
                    return marca;
                }
            }

            return null;
        }
    }
}
