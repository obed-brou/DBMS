using Conexion;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace GestorBD
{
    public partial class Insert : Form
    {
        public Insert()
        {
            InitializeComponent();
        }
        private DataTable dataTable = new DataTable();
        String query = "", vacio = "";
        public String server = "", user = "", password = "", bd = "";
        String C = "";
        dbSqlServer sql = null;
        Class1 sql1 = null;

       
        private string baseDatos;

        public class DatosDeInicio
        {
            public String sServidor;
            public String sUsuario;
            public String sContrasena;
        }
        private void dtgInsert_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertarDatos(baseDatos, nombreTabla, dtgInsert);
            llenarGrid(server, user, password);
        }
        public void InsertarDatos(string baseDatos, string nombreTabla, DataGridView dataGridView)
        {
            List<string> nombresCampos = new List<string>();
            List<bool> esIdentidad = new List<bool>();

            foreach (DataGridViewColumn columna in dataGridView.Columns)
            {
                nombresCampos.Add(columna.HeaderText);
                esIdentidad.Add(columna.DataPropertyName == "IDENTITY_COLUMN_NAME");
            }
            string campos = string.Join(", ", nombresCampos);
            string valores = "";


            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                List<string> valoresFila = new List<string>();

                for (int i = 0; i < fila.Cells.Count; i++)
                {
                    DataGridViewCell celda = fila.Cells[i];

                    if (celda.Value != null)
                    {
                        if (celda.ValueType == typeof(string) || celda.ValueType == typeof(int))
                        {
                            valoresFila.Add("'" + celda.Value.ToString() + "'");
                        }
                        else
                        {
                            valoresFila.Add(celda.Value.ToString());
                        }
                    }
                    else
                    {
                        valoresFila.Add("NULL");
                    }

                }
                bool contieneValor = valoresFila.Any(valor => valor != "NULL" && !esIdentidad[valoresFila.IndexOf(valor)]);

                if (contieneValor)
                {
                    valores += "(" + string.Join(", ", valoresFila) + "), ";
                }
            }

            if (!string.IsNullOrEmpty(valores))
            {
                valores = valores.TrimEnd(new char[] { ' ', ',' }); // Elimina la coma y el espacio final

                DatosDeInicio user = new DatosDeInicio()
                {
                    sServidor = server,
                    sUsuario = this.user,
                    sContrasena = password,
                };
                // Ahora puedes usar los valores capturados para realizar la inserción en la base de datos.
                // Aquí debes llamar a tu método de inserción en la base de datos.
                // Supongamos que tienes una instancia de la clase dbSqlServer llamada 'operaciones' para realizar la inserción:
                dbSqlServer operaciones = new dbSqlServer(user.sServidor, user.sUsuario, user.sContrasena);
                operaciones.InsertarEnTabla(baseDatos, nombreTabla, campos, valores);
            }
            else
            {
                MessageBox.Show("No hay datos para insertar.");
            }
        }
        public void ActualizarDatos(string baseDatos, string nombreTabla, DataGridView dataGridView)
        {
            List<string> nombresCampos = new List<string>();

            foreach (DataGridViewColumn columna in dataGridView.Columns)
            {
                nombresCampos.Add(columna.HeaderText);
            }

            string campos = string.Join(", ", nombresCampos);
            string valores = "";
            string campo1 = tbColumna.Text;
            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                List<string> valoresFila = new List<string>();

                for (int i = 0; i < fila.Cells.Count; i++)
                {
                    DataGridViewCell celda = fila.Cells[i];

                    if (celda.Value != null)
                    {
                        if (celda.ValueType == typeof(string) || celda.ValueType == typeof(int))
                        {
                            valoresFila.Add($"[{nombresCampos[i]}] = '" + celda.Value.ToString() + "'");
                        }
                        else
                        {
                            valoresFila.Add($"[{nombresCampos[i]}] = {celda.Value.ToString()}");
                        }
                    }
                }

                bool contieneValor = valoresFila.Any();

                if (contieneValor)
                {
                    valores += string.Join(", ", valoresFila) + $" WHERE [{campo1}] = " + fila.Cells[campo1].Value.ToString() + ";";
                }
            }

            if (!string.IsNullOrEmpty(valores))
            {
                DatosDeInicio user = new DatosDeInicio()
                {
                    sServidor = server,
                    sUsuario = this.user,
                    sContrasena = password,
                };
                // Ahora puedes usar los valores capturados para realizar la actualización en la base de datos.
                // Aquí debes llamar a tu método de actualización en la base de datos.
                // Supongamos que tienes una instancia de la clase dbSqlServer llamada 'operaciones' para realizar la actualización:
                dbSqlServer operaciones = new dbSqlServer(user.sServidor, user.sUsuario, user.sContrasena);
                operaciones.ActualizarEnTabla(baseDatos, nombreTabla, valores);
            }
            else
            {
                MessageBox.Show("No hay datos para actualizar.");
            }
        }



        private string nombreTabla;
        private void Insert_Load(object sender, EventArgs e)
        {

            //string[] ArregloBT = C.Split(',');
            //MessageBox.Show("Base Datos: " + ArregloBT[0] +
            //                '\n' +
            //                "Tabla: " + ArregloBT[1]);
            llenarGrid(server, user, password);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            llenarGrid(server, user, password);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar();
            llenarGrid(server, user, password);
        }
        private void Eliminar()
        {
            DatosDeInicio user = new DatosDeInicio()
            {
                sServidor = server,
                sUsuario = this.user,
                sContrasena = password,
            };
            string ID = tbID.Text;
            string columna = tbColumna.Text;
            // Ahora puedes usar los valores capturados para realizar la inserción en la base de datos.
            // Aquí debes llamar a tu método de inserción en la base de datos.
            // Supongamos que tienes una instancia de la clase dbSqlServer llamada 'operaciones' para realizar la inserción:
            dbSqlServer operaciones = new dbSqlServer(user.sServidor, user.sUsuario, user.sContrasena);
            operaciones.EliminarFilaEnTabla(baseDatos, nombreTabla, columna, ID);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ActualizarDatos(baseDatos, nombreTabla, dtgInsert);
            llenarGrid(server, user, password);
        }

        private void dtgvSelect_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataTable.Columns.Add("Columna1"); // Reemplaza con los nombres de tus columnas
            dataTable.Columns.Add("Columna2");
            dataTable.Columns.Add("Columna3");
            dataTable.Columns.Add("Columna4");
            dataTable.Columns.Add("Columna5");
            dataTable.Columns.Add("Columna6");
            dataTable.Columns.Add("Columna7");
            dataTable.Columns.Add("Columna8");
            dataTable.Columns.Add("Columna9");
            dataTable.Columns.Add("Columna10");
            dataTable.Columns.Add("Columna11");
            dataTable.Columns.Add("Columna12");
            dataTable.Columns.Add("Columna13");
            dataTable.Columns.Add("Columna14");

            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtgvSelect.Rows[e.RowIndex];
                DataRow newRow = dataTable.NewRow(); // Supongo que tienes un dataTable para dtgInsert

                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    newRow[i] = selectedRow.Cells[i].Value;
                }
                //dtgvSelect.CellDoubleClick += dtgvSelect_CellDoubleClick;
                dataTable.Rows.Add(newRow);


                DataTable transposedTable = TransposeDataTable(dataTable);

                // Configura el DataGridView para mostrar los datos transpuestos

                dtgInsert.DataSource = transposedTable;

            }
        }
        private string nombreColumnaEditada = null; // Variable para almacenar el nombre de la columna editada
        private void dtgvSelect_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DatosDeInicio user = new DatosDeInicio()
            {
                sServidor = server,
                sUsuario = this.user,
                sContrasena = password,
            };
            DataGridViewCell celdaSeleccionada = dtgvSelect.Rows[e.RowIndex].Cells[e.ColumnIndex];

            object valorCeldaNuevo = celdaSeleccionada.Value;
            string basededatos = tbBD.Text;
            string nombretabla = tbTabla.Text;
            string nombreColumna2 = nombreColumnaEditada;

           dbSqlServer operaciones = new dbSqlServer(user.sServidor, user.sUsuario, user.sContrasena);
            bool exito = GuardaCelda(nombretabla, basededatos, dtgvSelect, dtgvSelect.Columns[0].Name, valorCeldaNuevo, nombreColumna2, user);
            }
        public bool GuardaCelda(string nombretabla, string basededatos, DataGridView dataGridView1, string nombreColumna, object valorCeldaNuevo, string nombreColumnaSelecionada, DatosDeInicio user)
        {
            try
            {
                string connectionString = dbSqlServer.GetConnectionString(user.sServidor, user.sUsuario, user.sContrasena);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Verifica si ya existe una fila con el mismo identificador único (ID)

                    int filaID = ObtenerIDFilaSeleccionada(dataGridView1, dataGridView1.CurrentRow.Index);
                    // Realizar una actualización en lugar de una inserción
                    string query = $"USE {baseDatos}; UPDATE {nombretabla} SET {nombreColumnaSelecionada} = '{valorCeldaNuevo}' WHERE {nombreColumnaEditada} = {filaID}";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                      
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Actualización exitosa
                            //MessageBox.Show("Celda actualizada correctamente.");
                        }
                        else
                        {
                            // No se encontraron registros para actualizar
                            MessageBox.Show("No se encontraron registros para actualizar.");
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar/inserir la celda: " + ex.Message);
                return false; // Debería devolver false en caso de error
            }
        }
       public int ObtenerIDFilaSeleccionada(DataGridView dataGridView, int filaSeleccionada)
{
    // Asegúrate de que el índice de fila seleccionada sea válido
    if (filaSeleccionada >= 0 && filaSeleccionada < dataGridView.Rows.Count)
    {
        // Supongamos que la columna de ID se encuentra en el índice 0, ajusta esto según tu estructura
        int idColumnIndex = 0;

        if (dataGridView.Rows[filaSeleccionada].Cells[idColumnIndex].Value != null)
        {
            if (int.TryParse(dataGridView.Rows[filaSeleccionada].Cells[idColumnIndex].Value.ToString(), out int id))
            {
                return id;
            }
        }
    }

    // Si no se pudo obtener el ID o el índice de fila seleccionada no es válido, devuelve un valor por defecto
    return -1;
}

        public void dtgvSelect_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                nombreColumnaEditada = dtgvSelect.Columns[e.ColumnIndex].Name;
            }
            else
            {
                nombreColumnaEditada = null; // Reinicia el nombre de la columna editada
            }
        }

        public void llenarGrid(string Servidor, string Usuario, string Contrasena)
        {
            
            //string[] ArregloBT = C.Split(',');
            //tbBD.Text = ArregloBT[0];
            //tbTabla.Text = ArregloBT[1];

            DatosDeInicio user = new DatosDeInicio()
            {
                sServidor = server,
                sUsuario = this.user,
                sContrasena = password,
            };

            dbSqlServer operaciones = new dbSqlServer(user.sServidor, user.sUsuario, user.sContrasena);
            DataTable InsertTselect = operaciones.ConsultarTablasSelect(user.sServidor, user.sUsuario, user.sContrasena, baseDatos, nombreTabla);
            dtgvSelect.DataSource = InsertTselect;
            string nombrePrimeraColumna = operaciones.ObtenerNombrePrimeraColumna(user.sServidor, user.sUsuario, user.sContrasena, baseDatos, nombreTabla);
            tbColumna.Text = nombrePrimeraColumna;




            tbBD.Text = baseDatos;
            tbTabla.Text = nombreTabla;
        }
        public Insert(DataTable dataTable, string baseDatos, string nombreTabla)
        {
            InitializeComponent();

            this.baseDatos = baseDatos;
            this.nombreTabla = nombreTabla;

            // Transponer la tabla
            DataTable transposedTable = TransposeDataTable(dataTable);

            // Configura el DataGridView para mostrar los datos transpuestos
            dtgInsert.DataSource = transposedTable;
            
            // También puedes configurar otras propiedades del DataGridView según sea necesario
        }

        // Método para transponer una tabla
        private DataTable TransposeDataTable(DataTable inputTable)
        {
            DataTable transposedTable = new DataTable();

            // Agregar columnas al DataTable transpuesto
            foreach (DataRow row in inputTable.Rows)
            {
                DataColumn newColumn = new DataColumn(row[0].ToString());
                transposedTable.Columns.Add(newColumn);
            }

            // Agregar filas al DataTable transpuesto
            for (int i = 1; i < inputTable.Columns.Count; i++)
            {
                DataRow newRow = transposedTable.NewRow();

                foreach (DataRow row in inputTable.Rows)
                {
                    newRow[row[0].ToString()] = row[i];
                }

                transposedTable.Rows.Add(newRow);
            }

            return transposedTable;
        }



        public void conectarDB(string servidor, string usuario, string contraseña)
        {
            server = servidor;
            user = usuario;
            password = contraseña;
        }
    }
}
