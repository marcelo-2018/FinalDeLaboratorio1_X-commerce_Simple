using System;
using System.Drawing;
using System.Windows.Forms;
using SegundoParcial.Clases;

namespace SegundoParcial
{
    public partial class NuevoCliente : Form
    {
        private Cliente _clienteActual;

        public NuevoCliente()
        {
            InitializeComponent();

            _clienteActual = new Cliente();

            Validacion validacion = new Validacion();
        }

        private void btnCargar_Click(object sender, EventArgs e)
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

            _clienteActual = VerificarSiExiste(txtNombre.Text, txtApellido.Text, txtDNI.Text);

            if (_clienteActual == null)
            {
                if (txtDNI.Text.Length == 8)
                {
                    Cliente nuevoCliente = new Cliente();

                    nuevoCliente.Apellido = txtApellido.Text;
                    nuevoCliente.Nombre = txtNombre.Text;
                    nuevoCliente.Dni = txtDNI.Text;

                    Program.Clientes.Add(nuevoCliente);

                    Clases.CuentaCorriente nuevaCuentaCorriente = new Clases.CuentaCorriente();

                    nuevaCuentaCorriente.Cliente = new Cliente();
                    nuevaCuentaCorriente.Cliente.Apellido = nuevoCliente.Apellido;
                    nuevaCuentaCorriente.Cliente.Nombre = nuevoCliente.Nombre;
                    nuevaCuentaCorriente.Fecha = DateTime.Now;
                    nuevaCuentaCorriente.Monto = 0.0m;
                    nuevaCuentaCorriente.TipoMovimiento = TipoMovimiento.Ingreso;

                    Program.CuentaCorrientes.Add(nuevaCuentaCorriente);

                    MessageBox.Show("Los datos se cargaron con exito.");

                    LimpiarControles();
                }
                else
                {
                    MessageBox.Show("El DNI que ingreso no es valido", "Atención",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El cliente que desea ingresar ya exite.", "Atención",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtApellido.Text) && string.IsNullOrEmpty(txtNombre.Text) &&
                string.IsNullOrEmpty(txtDNI.Text))
            {
                this.Close();
            }
            else
            {
                if (MessageBox.Show("Los cambios no se guardaran. ¿Seguro que desea salir?", "Atención",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
        }

        private Cliente VerificarSiExiste(string nombre, string apellido, string dni)
        {
            foreach (var cliente in Program.Clientes)
            {
                if (cliente.Dni.Equals(dni))
                {
                    return cliente;
                }
            }

            return null;
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngresarSoloLetras(e);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngrearSoloNumeros(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.IngresarSoloLetras(e);
        }
    }
}
