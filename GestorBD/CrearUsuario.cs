using Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorBD
{
    public partial class CrearUsuario : Form
    {
        public CrearUsuario()
        {
            InitializeComponent();
            // Configura el ComboBox de roles
            cbRoles.Items.AddRange(new string[] { "bulkadmin", "dbcreator", "diskadmin", "processadmin", "securityadmin", "serveradmin", "setupadmin", "sysadmin", "db_owner", "db_datareader", "db_datawriter", "db_ddladmin", "db_securityadmin", "db_accessadmin", "db_backupoperator", "db_denydatareader", "db_denydatawriter" });


        }
        String query = "", vacio = "";
        String server = "", user = "", password = "", bd = "";
        String C = "";

        private void button1_Click(object sender, EventArgs e)
        {
            DatosDeInicio user = new DatosDeInicio()
            {
                sServidor = server,
                sUsuario = this.user,
                sContrasena = password,
            };
            string usuario = tbUsuario.Text;
            string contraseña = tbContraseña.Text;
            string confirmarContraseña = tbConfirmarContraseña.Text;
            string rol = cbRoles.SelectedItem.ToString();
            string baseDeDatos = bd = cbBD.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(baseDeDatos))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }
            if (!ContraseñaCumpleRequisitos(contraseña))
            {
                MessageBox.Show("La contraseña debe contener al menos una mayúscula, una minúscula, un número y un carácter especial.");
                return ;
            }
            if (contraseña != confirmarContraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor, verifica.");
                return;
            }
            else
            {
                dbSqlServer operaciones = new dbSqlServer(user.sServidor, user.sUsuario, user.sContrasena);
                if(operaciones.CrearUsuario(user.sServidor, user.sUsuario, user.sContrasena, baseDeDatos, usuario, contraseña, rol))
                {
                    MessageBox.Show("Usuario no ha podido ser creado con éxito, verifica el nombre de usuario o." + operaciones.sLastError);
                    
                    return;
                }
                else
                {
                    MessageBox.Show("Usuario creado con éxito." );
                }

                 
                
            }
            tbUsuario.Clear();
            tbContraseña.Clear();
            tbConfirmarContraseña.Clear();
            cbBD.Text = string.Empty;
            cbRoles.Text = string.Empty;
            

        }
        private bool ContraseñaCumpleRequisitos(string contraseña)
        {
            // Utiliza una expresión regular para verificar los requisitos de la contraseña
            string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$"; // Al menos 8 caracteres, 1 mayúscula, 1 minúscula, 1 número y 1 carácter especial

            return Regex.IsMatch(contraseña, pattern);
        }
        public class DatosDeInicio
        {
            public String sServidor;
            public String sUsuario;
            public String sContrasena;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Si el CheckBox está marcado, muestra el texto en los TextBox
            if (checkBox1.Checked)
            {
                tbContraseña.PasswordChar = '\0'; // Mostrar texto claro (sin ocultar)
                tbConfirmarContraseña.PasswordChar = '\0';
            }
            else
            {
                tbContraseña.PasswordChar = '*';  // Oculta el texto con asteriscos
                tbConfirmarContraseña.PasswordChar = '*';
            }
        }

        dbSqlServer sql = null;
        Class1 sql1 = null;
        private void CrearUsuario_Load(object sender, EventArgs e)
        {
            sql1 = new Class1();
            DataTable BasesDatos = sql1.ConsultaDeBasedeDatos(server, user, password);

            foreach (DataRow bases in BasesDatos.Rows)
            {
                cbBD.Items.Add(bases[0].ToString());
            }
            string[] ArregloBT = C.Split(',');


            cbBD.Text = ArregloBT[0];
        }
        public void conectarDB(string servidor, string usuario, string contraseña)
        {
            server = servidor;
            user = usuario;
            password = contraseña;
        }
    }
}
