using SegundoParcial.Clases;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class ModificarCliente : Form
    {
        private int indice;
        private Cliente _clienteActual;
        private Cliente _clienteSinModificacion;

        public ModificarCliente(int indice)
        {
            InitializeComponent();

            this.indice = indice;

            _clienteActual = new Cliente();

            _clienteSinModificacion = new Cliente();

            Validacion validacion = new Validacion();
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDNI.Text))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus();
                return;
            }

            var apellido = Program.Clientes[indice].Apellido;
            var nombre = Program.Clientes[indice].Nombre;
            var dni = Program.Clientes[indice].Dni;

            if (txtDNI.Text.Length == 8)
            {
                if (apellido != txtApellido.Text || nombre != txtNombre.Text || dni != txtDNI.Text)
                {
                    if (MessageBox.Show("¿Esta seguro que desea guardar los cambios?", "Atención",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Program.Clientes[indice].Apellido = txtApellido.Text;
                        Program.Clientes[indice].Nombre = txtNombre.Text;
                        Program.Clientes[indice].Dni = txtDNI.Text;

                        MessageBox.Show("Los datos se guardaron con exito");

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No se realizo ningun cambio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("El DNI que ingreso no es valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDNI.Clear();
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Los cambios no se guardaran. ¿Seguro que desea salir?", "Atención",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngresarSoloLetras(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngresarSoloLetras(e);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngrearSoloNumeros(e);
        }
    }
}
