namespace GestorBD
{
    partial class CrearTabla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgvTabla = new System.Windows.Forms.DataGridView();
            this.Campo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDato = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Nulos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AutoLine = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbBD = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNombreT = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTabla)).BeginInit();
            this.SuspendLayout();
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
            this.dtgvTabla.Location = new System.Drawing.Point(12, 76);
            this.dtgvTabla.Name = "dtgvTabla";
            this.dtgvTabla.Size = new System.Drawing.Size(585, 237);
            this.dtgvTabla.TabIndex = 13;
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
            // 
            // AutoLine
            // 
            this.AutoLine.FalseValue = " ";
            this.AutoLine.HeaderText = "AutoLine";
            this.AutoLine.Name = "AutoLine";
            this.AutoLine.TrueValue = "identity";
            // 
            // PK
            // 
            this.PK.FalseValue = " ";
            this.PK.HeaderText = "PK";
            this.PK.Name = "PK";
            this.PK.TrueValue = "primary key";
            // 
            // cbBD
            // 
            this.cbBD.FormattingEnabled = true;
            this.cbBD.Location = new System.Drawing.Point(93, 14);
            this.cbBD.Name = "cbBD";
            this.cbBD.Size = new System.Drawing.Size(121, 21);
            this.cbBD.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre Tabla";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Base de datos:";
            // 
            // tbNombreT
            // 
            this.tbNombreT.Location = new System.Drawing.Point(93, 41);
            this.tbNombreT.Name = "tbNombreT";
            this.tbNombreT.Size = new System.Drawing.Size(100, 20);
            this.tbNombreT.TabIndex = 9;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(199, 41);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 8;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(518, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 14;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // CrearTabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 325);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dtgvTabla);
            this.Controls.Add(this.cbBD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNombreT);
            this.Controls.Add(this.btnCrear);
            this.Name = "CrearTabla";
            this.Text = "CrearTabla";
            this.Load += new System.EventHandler(this.CrearTabla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvTabla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewComboBoxColumn TipoDato;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Nulos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AutoLine;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PK;
        private System.Windows.Forms.ComboBox cbBD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNombreT;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnCerrar;
    }
}