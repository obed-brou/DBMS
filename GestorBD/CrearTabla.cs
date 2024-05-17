using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conexion;

namespace GestorBD
{
    public partial class CrearTabla : Form
    {
        string Cadenatabla="";
        public CrearTabla(String cadena)
        {
            InitializeComponent();
        Cadenatabla = cadena;
        }
        String query = "", vacio = "";
        String server = "", user = "", password = "", bd = "";
        String C = "";
        dbSqlServer sql = null;
        Class1 sql1 = null;

        private void CrearTabla_Load(object sender, EventArgs e)
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

        private void btnCrear_Click(object sender, EventArgs e)
        {
            bd = cbBD.Text;
            query = $"use {bd}; create table ";
            int num = dtgvTabla.Rows.Count, numEj = 0;
            if (tbNombreT.Text == "" || cbBD.Text == "")
            {
                MessageBox.Show("No haz llenado los campos ", "Advertencia");
            }
            else
            {
                if (num == 1)
                {
                    MessageBox.Show("No tienes datos");
                }
                else
                {
                    query += tbNombreT.Text + "( ";
                    CrearQuery(query, num, vacio, numEj);
                }
            }
            void CrearQuery(String estancia, int primer, String campo, int primer1)
            {
                if (primer1 == primer - 1)
                {
                    estancia += campo + ");";
                    sql = new dbSqlServer(server, user, password);
                    if (sql.ConexionAbierta())
                    {
                        if (sql.EjecutarComando(estancia))
                        {
                            MessageBox.Show("Se ha realizado con exito...");
                        }
                        else
                        {
                            MessageBox.Show(sql.sLastError);
                        }
                    }
                    else
                    {
                        sql.AbrirConexion();
                        if (sql.EjecutarComando(estancia))
                        {
                            MessageBox.Show("Se ha realizado con exito...");
                        }
                        else
                        {
                            MessageBox.Show(sql.sLastError);
                        }
                    }
                }
                else
                {
                    campo += (dtgvTabla.Rows[primer1].Cells[0].Value + " ");
                    campo += (dtgvTabla.Rows[primer1].Cells[1].Value + " ");
                    campo += (dtgvTabla.Rows[primer1].Cells[2].Value + " ");
                    campo += (dtgvTabla.Rows[primer1].Cells[3].Value + " ");
                    campo += (dtgvTabla.Rows[primer1].Cells[4].Value + " ");
                    if (primer1 == primer - 2)
                    {
                        campo += (dtgvTabla.Rows[primer1].Cells[5].Value + " ");
                    }
                    else
                    {
                        campo += (dtgvTabla.Rows[primer1].Cells[5].Value + ", ");
                    }

                    CrearQuery(estancia, primer, campo, primer1 + 1);
                }
            }
        }
        public string GenerarConsultaKeys(DataGridView dataGridView)
        {
            dataGridView = dtgvTabla;
            StringBuilder consulta = new StringBuilder("ALTER TABLE nombre_de_tabla ADD PRIMARY KEY (");

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                {
                    string columna = row.Cells[1].Value.ToString(); // Nombre de la columna
                    consulta.Append(columna);
                    consulta.Append(", ");
                }
            }

            if (consulta.ToString().EndsWith(", "))
            {
                consulta.Remove(consulta.Length - 2, 2); // Eliminar la última coma y espacio
            }

            consulta.Append(");");

            return consulta.ToString();
        }
        

        private void dtgvTabla_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            int a = 0;
            a = dtgvTabla.RowCount - 1;
            for (int b = 0; b < a; b++)
            {
                if (dtgvTabla.Rows[b].Cells[2].Value != "")
                {
                    dtgvTabla.Rows[b].Cells[1].Value = dtgvTabla.Rows[b].Cells[2].Value;
                    dtgvTabla.Rows[b].Cells[2].Value = "";
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class DatosDeInicio
        {
            public String sServidor;
            public String sUsuario;
            public String sContrasena;
        }
        public void conectarDB(string servidor, string usuario, string contraseña)
        {
            server = servidor;
            user = usuario;
            password = contraseña;
        }
        private void dtgvTabla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dtgvTabla.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    if (dtgvTabla.Rows[e.RowIndex].Cells[1].Value.ToString() == "varchar" || dtgvTabla.Rows[e.RowIndex].Cells[1].Value.ToString() == "nvarchar" || dtgvTabla.Rows[e.RowIndex].Cells[1].Value.ToString() == "nchar" || dtgvTabla.Rows[e.RowIndex].Cells[1].Value.ToString() == "binary" || dtgvTabla.Rows[e.RowIndex].Cells[1].Value.ToString() == "char" || dtgvTabla.Rows[e.RowIndex].Cells[1].Value.ToString() == "varbinary" || dtgvTabla.Rows[e.RowIndex].Cells[1].Value.ToString() == "")
                    {
                        dtgvTabla[2, e.RowIndex].ReadOnly = false;
                    }
                    else
                    {
                        dtgvTabla[2, e.RowIndex].ReadOnly = true;
                    }
                }

            }
        }

        private void dtgvTabla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
