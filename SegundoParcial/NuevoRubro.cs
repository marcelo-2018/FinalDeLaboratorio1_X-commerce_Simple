namespace SegundoParcial
{
    using SegundoParcial.Clases;
    using System;
    using System.Windows.Forms;

    public partial class NuevoRubro : Form
    {
        private Rubro _rubroActual;

        public NuevoRubro()
        {
            InitializeComponent();

            _rubroActual = new Rubro();

            Validacion validacion = new Validacion();
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
                txtCodigo.Focus();
                return;
            }

            _rubroActual = VerificarSiExiste(txtCodigo.Text, txtDescripcion.Text);

            if (_rubroActual == null)
            {
                Rubro nuevoRubro = new Rubro();

                nuevoRubro.Codigo = txtCodigo.Text;
                nuevoRubro.Descripcion = txtDescripcion.Text;

                Program.Rubros.Add(nuevoRubro);

                MessageBox.Show("Los datos se cargaron con exito.");

                LimpiarControles();
            }
            else
            {
                MessageBox.Show("El rubro que desea ingresar ya exite.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Rubro VerificarSiExiste(string codigo, string descripcion)
        {
            foreach (var rubro in Program.Rubros)
            {
                if (rubro.Codigo.Equals(codigo) || rubro.Descripcion.ToLower().Equals(descripcion.ToLower()))
                {
                    return rubro;
                }
            }

            return null;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngrearSoloNumeros(e);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngresarSoloLetras(e);
        }
    }
}
