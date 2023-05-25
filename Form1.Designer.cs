
namespace ProyectoISW
{
    partial class VistaPrincipal
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenuES = new System.Windows.Forms.Button();
            this.btnMenuMA = new System.Windows.Forms.Button();
            this.btnAcceder = new System.Windows.Forms.Button();
            this.lblAlumno = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(667, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actividades de Aprendizaje";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnMenuES
            // 
            this.btnMenuES.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMenuES.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuES.Location = new System.Drawing.Point(18, 246);
            this.btnMenuES.Name = "btnMenuES";
            this.btnMenuES.Size = new System.Drawing.Size(322, 125);
            this.btnMenuES.TabIndex = 1;
            this.btnMenuES.Text = "Español";
            this.btnMenuES.UseVisualStyleBackColor = false;
            this.btnMenuES.Click += new System.EventHandler(this.btnMenuES_Click);
            this.btnMenuES.MouseEnter += new System.EventHandler(this.btnMenuES_MouseEnter);
            this.btnMenuES.MouseLeave += new System.EventHandler(this.btnMenuES_MouseLeave);
            this.btnMenuES.MouseHover += new System.EventHandler(this.btnMenuES_MouseHover);
            // 
            // btnMenuMA
            // 
            this.btnMenuMA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMenuMA.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuMA.Location = new System.Drawing.Point(670, 246);
            this.btnMenuMA.Name = "btnMenuMA";
            this.btnMenuMA.Size = new System.Drawing.Size(322, 125);
            this.btnMenuMA.TabIndex = 3;
            this.btnMenuMA.Text = "Matemáticas";
            this.btnMenuMA.UseVisualStyleBackColor = false;
            this.btnMenuMA.Click += new System.EventHandler(this.btnMenuMA_Click);
            this.btnMenuMA.MouseEnter += new System.EventHandler(this.btnMenuMA_MouseEnter);
            this.btnMenuMA.MouseLeave += new System.EventHandler(this.btnMenuMA_MouseLeave);
            this.btnMenuMA.MouseHover += new System.EventHandler(this.btnMenuMA_MouseHover);
            // 
            // btnAcceder
            // 
            this.btnAcceder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAcceder.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceder.Location = new System.Drawing.Point(795, 483);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(255, 58);
            this.btnAcceder.TabIndex = 5;
            this.btnAcceder.Text = "Acceso";
            this.btnAcceder.UseVisualStyleBackColor = false;
            this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
            this.btnAcceder.MouseHover += new System.EventHandler(this.btnAcceder_MouseHover);
            // 
            // lblAlumno
            // 
            this.lblAlumno.AutoSize = true;
            this.lblAlumno.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumno.Location = new System.Drawing.Point(12, 490);
            this.lblAlumno.Name = "lblAlumno";
            this.lblAlumno.Size = new System.Drawing.Size(143, 34);
            this.lblAlumno.TabIndex = 6;
            this.lblAlumno.Text = "Alumno: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProyectoISW.Properties.Resources.ninosmenuprincipal;
            this.pictureBox1.Location = new System.Drawing.Point(378, 196);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 217);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // VistaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1062, 553);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAlumno);
            this.Controls.Add(this.btnAcceder);
            this.Controls.Add(this.btnMenuMA);
            this.Controls.Add(this.btnMenuES);
            this.Controls.Add(this.label1);
            this.Name = "VistaPrincipal";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VistaPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.VistaPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMenuES;
        private System.Windows.Forms.Button btnMenuMA;
        private System.Windows.Forms.Button btnAcceder;
        private System.Windows.Forms.Label lblAlumno;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

