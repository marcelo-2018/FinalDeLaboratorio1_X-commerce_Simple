using System.Windows.Forms;
using SegundoParcial.Clases;

namespace SegundoParcial
{
    public partial class ModificarRubro : Form
    {
        private int indice;
        private Rubro _rubroActual;

        public ModificarRubro(int indice)
        {
            InitializeComponent();

            this.indice = indice;

            _rubroActual = new Rubro();
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

            var codigo = Program.Rubros[indice].Codigo;
            var descripcion = Program.Rubros[indice].Descripcion;

            if (codigo != txtCodigo.Text || descripcion != txtDescripcion.Text)
            {
                if (MessageBox.Show("¿Esta seguro que desea guardar los cambios?", "Atención",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Program.Rubros[indice].Codigo = txtCodigo.Text;
                    Program.Rubros[indice].Descripcion = txtDescripcion.Text;

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

        private Rubro VerificarSiExiste(string codigo, string descripcion)
        {
            foreach (var rubro in Program.Rubros)
            {
                if (!rubro.Codigo.Equals(codigo) && !rubro.Descripcion.Equals(descripcion))
                {
                    return rubro;
                }
            }

            return null;
        }
    }
}
