namespace GestorBD
{
    partial class ActualizarContraseñaForm
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
            this.tbContraseñaN = new System.Windows.Forms.TextBox();
            this.btnGuardarContraseñaActualizada = new System.Windows.Forms.Button();
            this.tbConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsuarioo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbServidor = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbContraseñaN
            // 
            this.tbContraseñaN.Location = new System.Drawing.Point(61, 75);
            this.tbContraseñaN.Name = "tbContraseñaN";
            this.tbContraseñaN.Size = new System.Drawing.Size(170, 20);
            this.tbContraseñaN.TabIndex = 0;
            // 
            // btnGuardarContraseñaActualizada
            // 
            this.btnGuardarContraseñaActualizada.Location = new System.Drawing.Point(107, 156);
            this.btnGuardarContraseñaActualizada.Name = "btnGuardarContraseñaActualizada";
            this.btnGuardarContraseñaActualizada.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarContraseñaActualizada.TabIndex = 1;
            this.btnGuardarContraseñaActualizada.Text = "Actualizar";
            this.btnGuardarContraseñaActualizada.UseVisualStyleBackColor = true;
            this.btnGuardarContraseñaActualizada.Click += new System.EventHandler(this.btnGuardarContraseñaActualizada_Click);
            // 
            // tbConfirmarContraseña
            // 
            this.tbConfirmarContraseña.Location = new System.Drawing.Point(61, 130);
            this.tbConfirmarContraseña.Name = "tbConfirmarContraseña";
            this.tbConfirmarContraseña.Size = new System.Drawing.Size(170, 20);
            this.tbConfirmarContraseña.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contraseña Nueva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Confirmar Contraseña";
            // 
            // tbUsuarioo
            // 
            this.tbUsuarioo.Location = new System.Drawing.Point(91, 36);
            this.tbUsuarioo.Name = "tbUsuarioo";
            this.tbUsuarioo.Size = new System.Drawing.Size(100, 20);
            this.tbUsuarioo.TabIndex = 5;
            this.tbUsuarioo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Usuario";
            this.label3.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Servidor BD";
            this.label6.Visible = false;
            // 
            // tbServidor
            // 
            this.tbServidor.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServidor.Location = new System.Drawing.Point(131, 209);
            this.tbServidor.Name = "tbServidor";
            this.tbServidor.Size = new System.Drawing.Size(100, 21);
            this.tbServidor.TabIndex = 28;
            this.tbServidor.Text = "LAPTOP-1A844UJR\\SQLEXPRESS";
            this.tbServidor.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(236, 101);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(41, 17);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "ver";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ActualizarContraseñaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 197);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbServidor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUsuarioo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbConfirmarContraseña);
            this.Controls.Add(this.btnGuardarContraseñaActualizada);
            this.Controls.Add(this.tbContraseñaN);
            this.Name = "ActualizarContraseñaForm";
            this.Text = "ActualizarContraseñaForm";
            this.Load += new System.EventHandler(this.ActualizarContraseñaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbContraseñaN;
        private System.Windows.Forms.Button btnGuardarContraseñaActualizada;
        private System.Windows.Forms.TextBox tbConfirmarContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUsuarioo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbServidor;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}