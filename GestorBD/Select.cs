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
    public partial class Select : Form
    {
        String query = "", vacio = "";
        public String server = "", user = "", password = "", bd = "";
        String C = "";
        dbSqlServer conexion = null;

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            DatosDeInicio user = new DatosDeInicio()
            {
                sServidor = server,
                sUsuario = this.user,
                sContrasena = password,
            };

            string sBaseDeDatos = cbBD2.SelectedItem.ToString(); // Obtiene la base de datos seleccionada
            
            conexion = new dbSqlServer(server, this.user, password);
            string sComando = tbComando.Text;

            // Agrega la base de datos al comando SQL
            string comandoConBaseDeDatos = $"USE {sBaseDeDatos}; {sComando}";

            if (!conexion.ConexionAbierta())
                conexion.AbrirConexion();

            DataTable datagrid = conexion.Datagrid(comandoConBaseDeDatos);
            dataGridView1.DataSource = datagrid;

            if (!conexion.EjecutarComando(comandoConBaseDeDatos))
            {
                MessageBox.Show($"Hay un error: {conexion.sLastError}");
            }
            else
            {
                //MessageBox.Show("Comandos ejecutados correctamente...");
            }

        }

        dbSqlServer sql = null;
        Class1 sql1 = null;
        public Select()
        {
            InitializeComponent();
        }

        private void Select_Load(object sender, EventArgs e)
        {
            sql1 = new Class1();
            DataTable BasesDatos = sql1.ConsultaDeBasedeDatos(server, user, password);

            foreach (DataRow bases in BasesDatos.Rows)
            {
                cbBD2.Items.Add(bases[0].ToString());
            }
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
    }
}
