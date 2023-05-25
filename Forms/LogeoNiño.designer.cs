namespace ProyectoISW
{
    partial class LogeoNiño
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnCrearSesion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbListaAlumnos = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnRegresar);
            this.groupBox1.Controls.Add(this.btnCrearSesion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbListaAlumnos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(779, 444);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(219, 349);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(401, 57);
            this.btnRegresar.TabIndex = 2;
            this.btnRegresar.Text = "Regresar al acceso";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnCrearSesion
            // 
            this.btnCrearSesion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCrearSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearSesion.Location = new System.Drawing.Point(251, 232);
            this.btnCrearSesion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrearSesion.Name = "btnCrearSesion";
            this.btnCrearSesion.Size = new System.Drawing.Size(321, 70);
            this.btnCrearSesion.TabIndex = 1;
            this.btnCrearSesion.Text = "Inicio sesion";
            this.btnCrearSesion.UseVisualStyleBackColor = false;
            this.btnCrearSesion.Click += new System.EventHandler(this.btnCrearSesion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(270, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del niño (a):";
            // 
            // cbListaAlumnos
            // 
            this.cbListaAlumnos.FormattingEnabled = true;
            this.cbListaAlumnos.Location = new System.Drawing.Point(132, 164);
            this.cbListaAlumnos.Margin = new System.Windows.Forms.Padding(4);
            this.cbListaAlumnos.Name = "cbListaAlumnos";
            this.cbListaAlumnos.Size = new System.Drawing.Size(548, 37);
            this.cbListaAlumnos.TabIndex = 0;
            this.cbListaAlumnos.SelectedIndexChanged += new System.EventHandler(this.cbListaAlumnos_SelectedIndexChanged);
            // 
            // LogeoNiño
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 474);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LogeoNiño";
            this.Text = "LogeoNiño";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogeoNiño_FormClosed);
            this.Load += new System.EventHandler(this.LogeoNiño_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbListaAlumnos;
        private System.Windows.Forms.Button btnCrearSesion;
        private System.Windows.Forms.Button btnRegresar;
    }
}