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
using static Conexion.dbSqlServer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestorBD
{
    public partial class Form1 : Form
    {
        String query = "", vacio = "";
        String server = "", user = "", password = "", bd = "";
        dbSqlServer conexion = null;

        dbSqlServer sql = null;
        String C="";
        Class1 sql1 = null;
        public Form1(string server = "", string user = "", string password = "")
        {
            this.server = server;
            this.user = user;
            this.password = password;
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //treeview
            LlenarArbol(server, user, password);
            // Oculta los controles al inicio del formulario
            btnModificar.Visible = false;
            label1.Visible = false;
            tbNombreTabla.Visible = false;
            label2.Visible = false;
            tbBD.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tvBD.Nodes.Clear();
            LlenarArbol(server, user, password);

        }

        private void tvBD_DoubleClick(object sender, EventArgs e)
        {
            
        }
        
        public void tvBD_AfterSelect(object sender, TreeViewEventArgs e)
        {
            cv(e);
        }
        public void cv(TreeViewEventArgs e)
    {
        if (e.Node.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
        {
            C = e.Node.Parent.Text + "," + e.Node.Text;
        }
    }


        public void conectarDB(string servidor, string usuario, string contraseña)
        {
            server = servidor;
            user = usuario;
            password = contraseña;
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            
                string bd = tbBD.Text;
                string nombreTabla = tbNombreTabla.Text;

            DatosDeInicio user = new DatosDeInicio()
            {
                sServidor = server,
                sUsuario = this.user,
                sContrasena = password,
            };
            if (!string.IsNullOrWhiteSpace(tbNombreTabla.Text))
            {
                dbSqlServer operaciones = null;
                operaciones = new dbSqlServer(user.sServidor, user.sUsuario, user.sContrasena);
                if (operaciones.EliminarTabla(ref user, bd, nombreTabla))
                {
                    //MessageBox.Show("Se ha eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show(operaciones.sLastError);
                }

                bd = tbBD.Text;
                query = $"use {bd}; create table ";
                int num = dtgvTabla.Rows.Count, numEj = 0;
                if (tbNombreTabla.Text == "" || tbBD.Text == "")
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
                        query += tbNombreTabla.Text + "( ";
                        CrearQuery(query, num, vacio, numEj);
                    }
                }
            }
            else
            {
                MessageBox.Show("Llena los datos...");
            }
            
            void CrearQuery(String estancia, int primer, String campo, int primer1)
            {
                if (primer1 == primer - 1)
                {
                    estancia += campo + ");";
                    sql = new dbSqlServer(server, this.user, password);
                    if (sql.ConexionAbierta())
                    {
                        if (sql.EjecutarComando(estancia))
                        {
                            MessageBox.Show("Se ha Actualizado con exito...");
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
                            MessageBox.Show("Se ha Actualizado con exito...");
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



            //if (string.IsNullOrWhiteSpace(bd) || string.IsNullOrWhiteSpace(nombreTabla))
            //{
            //    MessageBox.Show("Debes llenar los campos de base de datos y nombre de tabla.", "Advertencia");
            //    return;
            //}

            //int numFilas = dtgvTabla.Rows.Count;

            //if (numFilas <= 1)
            //{
            //    MessageBox.Show("No tienes datos para modificar la tabla.", "Advertencia");
            //    return;
            //}

            //StringBuilder query = new StringBuilder($"USE {bd}; ALTER TABLE {nombreTabla} ");

            //    // Iterar por las filas del DataGridView y construir la consulta de modificación
            //    for (int i = 0; i < numFilas - 1; i++) // Excluir la última fila vacía
            //    {
            //        string nombreColumna = dtgvTabla.Rows[i].Cells[0].Value.ToString();
            //        string tipoDato = dtgvTabla.Rows[i].Cells[1].Value.ToString();
            //        //bool permiteNulos = Convert.ToBoolean(dtgvModificar.Rows[i].Cells[2].Value);
            //        //bool autoIncrement = Convert.ToBoolean(dtgvModificar.Rows[i].Cells[3].Value);
            //        //bool esPK = Convert.ToBoolean(dtgvModificar.Rows[i].Cells[4].Value);

            //        query.Append($"ALTER COLUMN {nombreColumna} {tipoDato}");

            //        //if (!permiteNulos)
            //        //{
            //        //    query.Append(" NOT NULL");
            //        //}

            //        //if (autoIncrement)
            //        //{
            //        //    query.Append(" IDENTITY(1,1)");
            //        //}

            //        //if (esPK)
            //        //{
            //        //    query.Append(" PRIMARY KEY");
            //        //}

            //        if (i < numFilas - 2)
            //        {
            //            query.Append(", ");
            //        }
            //    }

            //    // Ejecutar la consulta de modificación en la base de datos
            //    dbSqlServer sql = new dbSqlServer(server, user, password);
            //    if (sql.ConexionAbierta())
            //    {
            //        if (sql.EjecutarComando(query.ToString()))
            //        {
            //            MessageBox.Show("La tabla se ha modificado con éxito.");
            //        }
            //        else
            //        {
            //            MessageBox.Show(sql.sLastError);
            //        }
            //    }
            //    else
            //    {
            //        sql.AbrirConexion();
            //        if (sql.EjecutarComando(query.ToString()))
            //        {
            //            MessageBox.Show("La tabla se ha modificado con éxito.");
            //        }
            //        else
            //        {
            //            MessageBox.Show(sql.sLastError);
            //        }
            //    }

        }

        private void dtgvTabla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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
                if (dtgvTabla.Rows[b].Cells[6].Value != "")
                {
                    dtgvTabla.Rows[b].Cells[0].Value = dtgvTabla.Rows[b].Cells[6].Value;
                    dtgvTabla.Rows[b].Cells[6].Value = "";
                }
                
            }
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
                if (dtgvTabla.Rows[b].Cells[6].Value != "")
                {
                    dtgvTabla.Rows[b].Cells[0].Value = dtgvTabla.Rows[b].Cells[6].Value;
                    dtgvTabla.Rows[b].Cells[6].Value = "";
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        String[] sCampos = new String[100];
        public Int32 iIndex = 0;
        public Boolean bContador = false;


        public void LlenarArbol(string Servidor, string Usuario, string Contrasena)
        {
            DatosDeInicio user = new DatosDeInicio()
            {
                sServidor = Servidor,
                sUsuario = Usuario,
                sContrasena = Contrasena,
            };

            TreeNode NodoPrincipal = new TreeNode();
            NodoPrincipal.Name = Servidor;
            NodoPrincipal.Text = Servidor;
            NodoPrincipal.ImageIndex = 0;
            NodoPrincipal.SelectedImageIndex = 0;
            tvBD.Nodes.Add(NodoPrincipal);

            dbSqlServer operaciones = null;
            operaciones = new dbSqlServer(user.sServidor, user.sUsuario, user.sContrasena);
            DataTable dtBaseDatos = operaciones.ConsultarBD(ref user);

            foreach (DataRow fila in dtBaseDatos.Rows)
            {
                TreeNode ndBaseDatos = new TreeNode();
                ndBaseDatos.Name = fila[0].ToString();
                ndBaseDatos.Text = fila[0].ToString();
                ndBaseDatos.ImageIndex = 1;
                ndBaseDatos.SelectedImageIndex = 1;
                tvBD.Nodes[NodoPrincipal.Name].Nodes.Add(ndBaseDatos);

                // Agregar un menú contextual al nodo de la base de datos
                ContextMenuStrip contextMenuStripBaseDatos = new ContextMenuStrip();
                ToolStripMenuItem crearTablaMenuItem = new ToolStripMenuItem("Crear Tabla");

                contextMenuStripBaseDatos.Items.Add(crearTablaMenuItem);

                ndBaseDatos.ContextMenuStrip = contextMenuStripBaseDatos;

                crearTablaMenuItem.Click += (s, e) =>
                {
                    CrearTabla c = new CrearTabla("");
                    c.conectarDB(user.sServidor, user.sUsuario, user.sContrasena);
                    // Agregar el formulario "CrearTabla" al panel de contenedor
                    c.TopLevel = false;
                    c.FormBorderStyle = FormBorderStyle.None;
                    c.Dock = DockStyle.Fill;

                    panel1.Controls.Clear(); // Limpia cualquier control existente en el panel
                    panel1.Controls.Add(c);

                    c.Show();
                    btnModificar.Visible = false;
                    label1.Visible = false;
                    tbNombreTabla.Visible = false;
                    label2.Visible = false;
                    tbBD.Visible = false;

                };

                DataTable dtTablas = operaciones.ConsultarTablas(ref user, fila[0].ToString());
                foreach (DataRow row in dtTablas.Rows)
                {
                    TreeNode ndTablas = new TreeNode();
                    ndTablas.Name = row[0].ToString();
                    ndTablas.Text = row[0].ToString();
                    ndTablas.ImageIndex = 2;
                    ndTablas.SelectedImageIndex = 2;

                    tvBD.Nodes[NodoPrincipal.Name].Nodes[ndBaseDatos.Name].Nodes.Add(ndTablas);

                    ContextMenuStrip contextMenuStripServidor = new ContextMenuStrip();
                    ToolStripMenuItem crearBaseDeDatosMenuItem = new ToolStripMenuItem("Crear Base de Datos");
                    ToolStripMenuItem consultarSelect = new ToolStripMenuItem("Consultar Select");
                    ToolStripMenuItem crearUsuario = new ToolStripMenuItem("Crear Usuario");
                    contextMenuStripServidor.Items.Add(crearBaseDeDatosMenuItem);
                    contextMenuStripServidor.Items.Add(consultarSelect);
                    contextMenuStripServidor.Items.Add(crearUsuario);

                    NodoPrincipal.ContextMenuStrip = contextMenuStripServidor;

                    crearBaseDeDatosMenuItem.Click += (s, e) =>
                    {
                        CrearBD crear = new CrearBD();
                        crear.conectarDB(user.sServidor, user.sUsuario, user.sContrasena);
                        // Agregar el formulario "CrearTabla" al panel de contenedor
                        crear.TopLevel = false;
                        crear.FormBorderStyle = FormBorderStyle.None;
                        crear.Dock = DockStyle.Fill;

                        panel1.Controls.Clear(); // Limpia cualquier control existente en el panel
                        panel1.Controls.Add(crear);

                        crear.Show();
                        btnModificar.Visible = false;
                        label1.Visible = false;
                        tbNombreTabla.Visible = false;
                        label2.Visible = false;
                        tbBD.Visible = false;
                    };
                    consultarSelect.Click += (s, e) =>
                    {
                        Select consultar = new Select();
                        consultar.conectarDB(user.sServidor, user.sUsuario, user.sContrasena);
                        // Agregar el formulario "CrearTabla" al panel de contenedor
                        consultar.TopLevel = false;
                       consultar.FormBorderStyle = FormBorderStyle.None;
                       consultar.Dock = DockStyle.Fill;

                        panel1.Controls.Clear(); // Limpia cualquier control existente en el panel
                        panel1.Controls.Add(consultar);

                        consultar.Show();
                        btnModificar.Visible = false;
                        label1.Visible = false;
                        tbNombreTabla.Visible = false;
                        label2.Visible = false;
                        tbBD.Visible = false;
                    };
                    crearUsuario.Click += (s, e) =>
                    {
                        CrearUsuario crearU = new CrearUsuario();
                        crearU.conectarDB(user.sServidor, user.sUsuario, user.sContrasena);
                        // Agregar el formulario "CrearTabla" al panel de contenedor
                        crearU.TopLevel = false;
                        crearU.FormBorderStyle = FormBorderStyle.None;
                        crearU.Dock = DockStyle.Fill;

                        panel1.Controls.Clear(); // Limpia cualquier control existente en el panel
                        panel1.Controls.Add(crearU);

                        crearU.Show();
                        btnModificar.Visible = false;
                        label1.Visible = false;
                        tbNombreTabla.Visible = false;
                        label2.Visible = false;
                        tbBD.Visible = false;
                    };
                    // Agregar un menú contextual al nodo de la tabla
                    ContextMenuStrip contextMenuStripTabla = new ContextMenuStrip();
                    ToolStripMenuItem crearCamposMenuItem = new ToolStripMenuItem("Crear Campos");
                    ToolStripMenuItem verKeysMenuItem = new ToolStripMenuItem("Ver Datos");
                    ToolStripMenuItem Insertinto = new ToolStripMenuItem("Ingresar Datos");

                    contextMenuStripTabla.Items.Add(crearCamposMenuItem);
                    contextMenuStripTabla.Items.Add(verKeysMenuItem);
                    contextMenuStripTabla.Items.Add(Insertinto);

                    ndTablas.ContextMenuStrip = contextMenuStripTabla;

                    crearCamposMenuItem.Click += (s, e) =>
                    {
                        
                        string[] ArregloBT = C.Split(',');

                        //MessageBox.Show("Base Datos: " + ArregloBT[0] +
                        //                '\n' +
                        //                "Tabla: " + ArregloBT[1]);
                        tbBD.Text = ArregloBT[0];
                        tbNombreTabla.Text = ArregloBT[1];
                        

                        dbSqlServer o = null;
                        o = new dbSqlServer(user.sServidor, user.sUsuario, user.sContrasena);
                        //DataTable TCulumnas = operaciones.Columnas(ref user, ArregloBT[0], ArregloBT[1]);
                        DataTable TCulumnas = operaciones.ConsultarCamposTipos(ref user, ArregloBT[0], ArregloBT[1]);
                        panel1.Controls.Clear();
                        dtgvTabla.DataSource = TCulumnas;
                        panel1.Controls.Add(dtgvTabla);

                        // Ajusta el tamaño del DataGridView al tamaño del Panel (si es necesario)
                        dtgvTabla.Dock = DockStyle.Fill;
                        // Hace visibles los controles al presionar el botón}
                        btnModificar.Visible = true;
                        label1.Visible = true;
                        tbNombreTabla.Visible = true;
                        label2.Visible = true;
                        tbBD.Visible = true;


                    };
                    Insertinto.Click += (s, e) =>
                    {

                        
                            string[] ArregloBT = C.Split(',');

                            // Realiza la consulta a la base de datos y almacena los resultados en una variable accesible desde Insertinto
                            DataTable InsertT = operaciones.ConsultarTablasInsert(ref user, ArregloBT[0], ArregloBT[1]);
                             //DataTable InsertTselect = operaciones.ConsultarTablasSelect(ref user, ArregloBT[0], ArregloBT[1]);

                            // Abre el formulario Insertinto y pasa los datos consultados
                            Insert insertintoForm = new Insert(InsertT, ArregloBT[0], ArregloBT[1]);
                        //Insert2 insertintoselect = new Insert2(InsertTselect, ArregloBT[0], ArregloBT[1]);
                        insertintoForm.user = user.sUsuario;
                        insertintoForm.password = user.sContrasena;
                        insertintoForm.server = user.sServidor;
                       
                        
                        // Establece el formulario Insertinto como un control secundario en el panel1
                        insertintoForm.TopLevel = false;
                            insertintoForm.FormBorderStyle = FormBorderStyle.None;
                            insertintoForm.Dock = DockStyle.Fill;
                            panel1.Controls.Clear(); // Limpia cualquier control existente en el panel
                            panel1.Controls.Add(insertintoForm);
                            insertintoForm.Show();
                        





                    };

                    verKeysMenuItem.Click += (s, e) =>
                    { 
                    DataTable dtCampos = operaciones.ConsultarCamposTipos(ref user, fila[0].ToString(), row[0].ToString());

                    for (int numFila = 0; numFila < dtCampos.Rows.Count; numFila++)
                    {
                        sCampos[numFila] = dtCampos.Rows[numFila][0].ToString() + "(" + dtCampos.Rows[numFila][1].ToString() + "," + dtCampos.Rows[numFila][2].ToString() + ")";
                        TreeNode ndCampos = new TreeNode();
                        ndCampos.Name = sCampos[numFila];
                        ndCampos.Text = sCampos[numFila];
                        tvBD.Nodes[NodoPrincipal.Name].Nodes[ndBaseDatos.Name].Nodes[ndTablas.Name].Nodes.Add(ndCampos);
                    }

                    TreeNode ndKeys = new TreeNode();
                    ndKeys.Name = "Keys";
                    ndKeys.Text = "Keys";
                    ndKeys.ImageIndex = 3;
                    ndKeys.SelectedImageIndex = 3;
                    tvBD.Nodes[NodoPrincipal.Name].Nodes[ndBaseDatos.Name].Nodes[ndTablas.Name].Nodes.Add(ndKeys);
                        
                    };
                }
            }
        }

    }
}
