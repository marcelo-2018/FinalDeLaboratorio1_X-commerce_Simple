using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SegundoParcial.Clases;

namespace SegundoParcial
{
    public partial class Login : Form
    {
        private static List<Empleado> Empleados = new List<Empleado>();

        private Empleado _empleadoActual;

        public Login()
        {
            InitializeComponent();

            CargaInicialEmpleados();
        }

        private void CargaInicialEmpleados()
        {
            Empleado empleado1 = new Empleado()
            {
                Nombre = "Marcelo",
                Apellido = "Aranda",
                Legajo = "123",
                Dni = "12345678",
                Usuario = "maranda",
                Password = "password",
            };

            Empleados.Add(empleado1);

            Empleado empleado2 = new Empleado()
            {
                Nombre = "Javier",
                Apellido = "Cortes",
                Legajo = "1234",
                Dni = "12345678",
                Usuario = "cjavier",
                Password = "1234",
            };

            Empleados.Add(empleado2);
        }

        private Empleado VerificarLogin(string usuario, string password)
        {
            foreach (var empleado in Empleados)
            {
                if (empleado.Usuario.Equals(usuario) && empleado.Password.Equals(password))
                {
                    return empleado;
                }
            }

            return null;
        }

        private void BtnIngresar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    MessageBox.Show("Por favor ingrese un nombre de usuario", "Atencion");
                    txtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Por favor ingrese una contraseña", "Atencion");
                    txtPassword.Focus();
                    return;
                }

                _empleadoActual = VerificarLogin(txtUsuario.Text, txtPassword.Text);

                if (_empleadoActual != null)
                {
                    Principal fPrincipal = new Principal();                    
                    fPrincipal.ShowDialog();              

                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("El usuario o contraseña es incorrecto", "Atencion");
                    txtUsuario.Clear();
                    txtPassword.Clear();
                    txtUsuario.Focus();
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Atencion", MessageBoxButtons.OK);
            }
            
        }

        private void BtnCancelar_Click(object sender, System.EventArgs e)
        {
            if(MessageBox.Show("¿Desea salir del sistema?", "Atencion",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = "maranda";
            txtPassword.Text = "password";
        }
    }
}
