namespace GestorBD
{
    partial class Insert
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
            this.dtgInsert = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tbBD = new System.Windows.Forms.TextBox();
            this.tbTabla = new System.Windows.Forms.TextBox();
            this.dtgvSelect = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tbColumna = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgInsert
            // 
            this.dtgInsert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInsert.Location = new System.Drawing.Point(12, 229);
            this.dtgInsert.Name = "dtgInsert";
            this.dtgInsert.Size = new System.Drawing.Size(640, 78);
            this.dtgInsert.TabIndex = 0;
            this.dtgInsert.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgInsert_RowLeave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(503, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbBD
            // 
            this.tbBD.Location = new System.Drawing.Point(102, 316);
            this.tbBD.Name = "tbBD";
            this.tbBD.ReadOnly = true;
            this.tbBD.Size = new System.Drawing.Size(100, 20);
            this.tbBD.TabIndex = 2;
            // 
            // tbTabla
            // 
            this.tbTabla.Location = new System.Drawing.Point(277, 316);
            this.tbTabla.Name = "tbTabla";
            this.tbTabla.ReadOnly = true;
            this.tbTabla.Size = new System.Drawing.Size(100, 20);
            this.tbTabla.TabIndex = 3;
            // 
            // dtgvSelect
            // 
            this.dtgvSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvSelect.Location = new System.Drawing.Point(12, 12);
            this.dtgvSelect.Name = "dtgvSelect";
            this.dtgvSelect.Size = new System.Drawing.Size(640, 200);
            this.dtgvSelect.TabIndex = 4;
            this.dtgvSelect.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dtgvSelect_CellBeginEdit);
            this.dtgvSelect.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvSelect_CellDoubleClick);
            this.dtgvSelect.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvSelect_CellEndEdit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Base de Datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tabla";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 314);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Refrescar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(43, 351);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(100, 20);
            this.tbID.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ID";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(160, 349);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(250, 349);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbColumna
            // 
            this.tbColumna.Location = new System.Drawing.Point(340, 351);
            this.tbColumna.Name = "tbColumna";
            this.tbColumna.Size = new System.Drawing.Size(100, 20);
            this.tbColumna.TabIndex = 12;
            // 
            // Insert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbColumna);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgvSelect);
            this.Controls.Add(this.tbTabla);
            this.Controls.Add(this.tbBD);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgInsert);
            this.Name = "Insert";
            this.Text = "Insert";
            this.Load += new System.EventHandler(this.Insert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgInsert;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dtgvSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbBD;
        private System.Windows.Forms.TextBox tbTabla;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbColumna;
    }
}