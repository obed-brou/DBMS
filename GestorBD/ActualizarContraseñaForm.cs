using Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorBD
{
    public partial class ActualizarContraseñaForm : Form
    {
        public ActualizarContraseñaForm(string server = "", string user = "", string password = "")
        {
            this.server = server;
            this.user = user;
            this.password = password;
            InitializeComponent();
        }
        String query = "", vacio = "";
        String server = "", user = "", password = "", bd = "";

        private void btnGuardarContraseñaActualizada_Click(object sender, EventArgs e)
        {
            DatosDeInicio user = new DatosDeInicio()
            {
                sServidor = server,
                sUsuario = this.user,
                sContrasena = password,
            };
            string nombreUsuario = tbUsuarioo.Text;
            string contraseña = tbContraseñaN.Text;
            string confirmarContraseña = tbConfirmarContraseña.Text;
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(confirmarContraseña))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }
            if (!ContraseñaCumpleRequisitos(contraseña))
            {
                MessageBox.Show("La contraseña debe contener al menos una mayúscula, una minúscula, un número y un carácter especial.");
                return;
            }
            if (contraseña != confirmarContraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, verifica.");
                return;
            }
            dbSqlServer operaciones = new dbSqlServer(user.sServidor, user.sUsuario, user.sContrasena);
            if(operaciones.ActualizarContraseña(user.sServidor, nombreUsuario, contraseña))
            {
                Form1 c = new Form1(user.sServidor, tbUsuarioo.Text, tbContraseñaN.Text);
                            this.Close();
                            c.ShowDialog();
                            
            }
            
            
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Si el CheckBox está marcado, muestra el texto en los TextBox
            if (checkBox1.Checked)
            {
                tbContraseñaN.PasswordChar = '\0'; // Mostrar texto claro (sin ocultar)
                tbConfirmarContraseña.PasswordChar = '\0';
            }
            else
            {
                tbContraseñaN.PasswordChar = '*';  // Oculta el texto con asteriscos
                tbConfirmarContraseña.PasswordChar = '*';
            }
        }

        private bool ContraseñaCumpleRequisitos(string contraseña)
        {
            // Utiliza una expresión regular para verificar los requisitos de la contraseña
            string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$"; // Al menos 8 caracteres, 1 mayúscula, 1 minúscula, 1 número y 1 carácter especial

            return Regex.IsMatch(contraseña, pattern);
        }
        String C = "";

        public class DatosDeInicio
        {
            public String sServidor;
            public String sUsuario;
            public String sContrasena;
        }
        private void ActualizarContraseñaForm_Load(object sender, EventArgs e)
        {
            DatosDeInicio user = new DatosDeInicio()
            {
                sServidor = server,
                sUsuario = this.user,
                sContrasena = password,
            };
            tbUsuarioo.Text = user.sUsuario;
        }
    }
}
