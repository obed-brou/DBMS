namespace GestorBD
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tvBD = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvTabla = new System.Windows.Forms.DataGridView();
            this.Campo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDato = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Nulos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AutoLine = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbBD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNombreTabla = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // tvBD
            // 
            this.tvBD.Location = new System.Drawing.Point(12, 12);
            this.tvBD.Name = "tvBD";
            this.tvBD.Size = new System.Drawing.Size(175, 385);
            this.tvBD.TabIndex = 6;
            this.tvBD.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvBD_AfterSelect);
            this.tvBD.DoubleClick += new System.EventHandler(this.tvBD_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Location = new System.Drawing.Point(193, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 386);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dtgvTabla
            // 
            this.dtgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Campo,
            this.cantidad,
            this.TipoDato,
            this.Nulos,
            this.AutoLine,
            this.PK});
            this.dtgvTabla.Location = new System.Drawing.Point(907, 34);
            this.dtgvTabla.Name = "dtgvTabla";
            this.dtgvTabla.Size = new System.Drawing.Size(601, 237);
            this.dtgvTabla.TabIndex = 15;
            this.dtgvTabla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTabla_CellEndEdit_1);
            // 
            // Campo
            // 
            this.Campo.HeaderText = "Campo";
            this.Campo.Name = "Campo";
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Tipo de Dato";
            this.cantidad.Name = "cantidad";
            // 
            // TipoDato
            // 
            this.TipoDato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.TipoDato.HeaderText = "";
            this.TipoDato.Items.AddRange(new object[] {
            "int",
            "bigint",
            "binary",
            "bit",
            "varchar",
            "char",
            "date",
            "datetime",
            "datetime",
            "decimal",
            "float",
            "geography",
            "geometry",
            "image",
            "money",
            "nchar",
            "ntext",
            "numeric",
            "nvarchar",
            "real",
            "smalldatetime",
            "smallint",
            "smallmoney",
            "time",
            "tinyint",
            "timestamp",
            "xml"});
            this.TipoDato.Name = "TipoDato";
            this.TipoDato.Width = 39;
            // 
            // Nulos
            // 
            this.Nulos.FalseValue = "not null";
            this.Nulos.HeaderText = "Nulos";
            this.Nulos.Name = "Nulos";
            this.Nulos.TrueValue = "null";
            this.Nulos.Width = 50;
            // 
            // AutoLine
            // 
            this.AutoLine.FalseValue = " ";
            this.AutoLine.HeaderText = "AutoLine";
            this.AutoLine.Name = "AutoLine";
            this.AutoLine.TrueValue = "identity";
            this.AutoLine.Width = 50;
            // 
            // PK
            // 
            this.PK.FalseValue = " ";
            this.PK.HeaderText = "PK";
            this.PK.Name = "PK";
            this.PK.TrueValue = "primary key";
            this.PK.Width = 50;
            // 
            // tbBD
            // 
            this.tbBD.Location = new System.Drawing.Point(585, 403);
            this.tbBD.Name = "tbBD";
            this.tbBD.Size = new System.Drawing.Size(100, 20);
            this.tbBD.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Base de datos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre Tabla";
            // 
            // tbNombreTabla
            // 
            this.tbNombreTabla.Location = new System.Drawing.Point(372, 404);
            this.tbNombreTabla.Name = "tbNombreTabla";
            this.tbNombreTabla.Size = new System.Drawing.Size(100, 20);
            this.tbNombreTabla.TabIndex = 3;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(193, 403);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // button1
            // 
            this.button1.ImageKey = "(ninguno)";
            this.button1.Location = new System.Drawing.Point(56, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Refrescar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(749, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Cerrar Sesion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 438);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtgvTabla);
            this.Controls.Add(this.tbBD);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvBD);
            this.Controls.Add(this.tbNombreTabla);
            this.Controls.Add(this.btnModificar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Grand Gestor basedatos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvBD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNombreTabla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBD;
        private System.Windows.Forms.DataGridView dtgvTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewComboBoxColumn TipoDato;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Nulos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AutoLine;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PK;
        private System.Windows.Forms.Button button2;
    }
}

