using Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorBD
{
    public partial class CrearBD : Form
    {
        public CrearBD()
        {
            InitializeComponent();
        }
        String query = "", vacio = "";
        String server = "", user = "", password = "", bd = "";

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar si el TextBox tiene datos
            if (!string.IsNullOrWhiteSpace(tbNombreBD.Text))
            {
                string bd = tbNombreBD.Text;

                // Crear una instancia del cuadro de diálogo SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                // Configurar propiedades del cuadro de diálogo
                saveFileDialog.Filter = "Archivos de base de datos (*.mdf)|*.mdf";
                saveFileDialog.Title = "Guardar base de datos";
                saveFileDialog.FileName = bd; // Puedes establecer un nombre predeterminado si lo deseas.

                // Mostrar el cuadro de diálogo y verificar si el usuario hizo clic en "Guardar"
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta seleccionada por el usuario
                    string rutaGuardada = saveFileDialog.FileName;

                    DatosDeInicio user = new DatosDeInicio()
                    {
                        sServidor = server,
                        sUsuario = this.user,
                        sContrasena = password,
                    };

                    dbSqlServer operaciones = new dbSqlServer(user.sServidor, user.sUsuario, user.sContrasena);

                    // Utiliza la variable "rutaGuardada" para realizar las operaciones de guardado
                    if (operaciones.CrearBD(user.sServidor, user.sUsuario, user.sContrasena, bd, rutaGuardada))
                    {
                        MessageBox.Show("Se ha Creado Correctamente.");
                    }
                    else
                    {
                        MessageBox.Show(operaciones.sLastError);
                    }
                }
                else
                {
                    MessageBox.Show("Operación de guardado cancelada.");
                }
            }
            else
            {
                MessageBox.Show("Ingresa los datos");
            }
        }
        void CrearQuery(String nombreBaseDatos)
        {

            // Crear la sentencia SQL para crear la base de datos
            string sentenciaSql = $"CREATE DATABASE {bd};";

            sql = new dbSqlServer(server, user, password);

            if (sql.ConexionAbierta())
            {
                if (sql.EjecutarComando(sentenciaSql))
                {
                    MessageBox.Show("Se ha creado la base de datos con éxito...");
                }
                else
                {
                    MessageBox.Show(sql.sLastError);
                }
            }
            else
            {
                sql.AbrirConexion();
                if (sql.EjecutarComando(sentenciaSql))
                {
                    MessageBox.Show("Se ha creado la base de datos con éxito...");
                }
                else
                {
                    MessageBox.Show(sql.sLastError);
                }
            }
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CrearBD_Load(object sender, EventArgs e)
        {

        }

        public void conectarDB(string servidor, string usuario, string contraseña)
        {
            server = servidor;
            user = usuario;
            password = contraseña;
        }
        public class DatosDeInicio
        {
            public String sServidor;
            public String sUsuario;
            public String sContrasena;
        }

        dbSqlServer sql = null;
        Class1 sql1 = null;
    }
}
