using System.Linq;
using System.Windows.Forms;
using SegundoParcial.Clases;

namespace SegundoParcial
{
    public partial class ModificarMarca : Form
    {
        private int indice;
        private Marca _marcaActual;
        private Marca _marcaSinModificacion;

        public ModificarMarca(int indice)
        {
            InitializeComponent();

            this.indice = indice;

            _marcaActual = new Marca();

            _marcaSinModificacion = new Marca();
        }

        private void btnEjecutar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            var codigo = Program.Marcas[indice].Codigo;
            var descripcion = Program.Marcas[indice].Descripcion;


            if (codigo != txtCodigo.Text || descripcion != txtDescripcion.Text)
            {
                if (MessageBox.Show("¿Esta seguro que desea guardar los cambios?", "Atención",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Program.Marcas[indice].Codigo = txtCodigo.Text;
                    Program.Marcas[indice].Descripcion = txtDescripcion.Text;

                    MessageBox.Show("Los datos se guardaron con exito.");

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No se realizo ninguna modificacion.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();

            txtCodigo.Focus();
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
