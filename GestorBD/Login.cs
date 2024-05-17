using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conexion;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace GestorBD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        dbSqlServer conexion = null;

        private void btnConectar_Click(object sender, EventArgs e)
        {
            conexion = new dbSqlServer(tbServidor.Text, tbUsuario.Text, tbPassword.Text);

            if (conexion.AbrirConexion())
            {
                string User = tbUsuario.Text;
                string servidor = tbServidor.Text;
                string username = tbUsuario.Text;
                string newPassword = tbPassword.Text;

                dbSqlServer operaciones = new dbSqlServer(tbServidor.Text, tbUsuario.Text, tbPassword.Text);
                Form1 c = new Form1(tbServidor.Text, tbUsuario.Text, tbPassword.Text);
                this.Hide();
                c.ShowDialog();
                this.Show();
                conexion.CerrarConexion();
            }
            else
            {
                if (conexion.sLastError =="Login failed for user '" + tbUsuario.Text + "'.  Reason: The password of the account must be changed.")
                {
                    ActualizarContraseñaForm actform = new ActualizarContraseñaForm(tbServidor.Text, tbUsuario.Text, tbPassword.Text);
                    actform.Show();
                }
                else
                {
                    // Otro tipo de error, muestra un mensaje
                    MessageBox.Show("Error al conectar: " + conexion.sLastError);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private bool EsUsuarioNuevo(string nombreUsuario)
        {
            // En un entorno real, consulta la base de datos para verificar si el usuario es nuevo.
            // Aquí utilizamos un archivo plano como ejemplo.
            // Puedes cambiar esta implementación según tu estructura de datos.
            string path = "usuarios.txt";

            if (File.Exists(path))
            {
                string[] usuarios = File.ReadAllLines(path);
                return !usuarios.Contains(nombreUsuario);
            }

            return true; // Si no se encontró el archivo, asumimos que es un usuario nuevo.
        }
        private void MarcarUsuarioComoActualizado(string nombreUsuario)
        {
            // En un entorno real, actualiza la base de datos para marcar al usuario como actualizado.
            // Aquí utilizamos un archivo plano como ejemplo.
            // Puedes cambiar esta implementación según tu estructura de datos.
            string path = "usuarios.txt";

            // Agregamos el nombre de usuario al archivo para indicar que ya ha actualizado su contraseña.
            File.AppendAllText(path, nombreUsuario + Environment.NewLine);
        }

        private void checkBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                tbPassword.PasswordChar = '\0'; // Mostrar texto claro (sin ocultar)

            }
            else
            {
                tbPassword.PasswordChar = '*';  // Oculta el texto con asteriscos

            }
        }
    }
}
