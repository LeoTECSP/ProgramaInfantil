
namespace ProyectoISW
{
    partial class menuAdministrador
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
            this.btnAccederHistorial = new System.Windows.Forms.Button();
            this.btnRegistrarAlumno = new System.Windows.Forms.Button();
            this.btnActividad = new System.Windows.Forms.Button();
            this.btnRegistrarProfesor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccederHistorial
            // 
            this.btnAccederHistorial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAccederHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccederHistorial.Location = new System.Drawing.Point(217, 92);
            this.btnAccederHistorial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAccederHistorial.Name = "btnAccederHistorial";
            this.btnAccederHistorial.Size = new System.Drawing.Size(519, 70);
            this.btnAccederHistorial.TabIndex = 23;
            this.btnAccederHistorial.Text = "Historial de Actividades";
            this.btnAccederHistorial.UseVisualStyleBackColor = false;
            this.btnAccederHistorial.Click += new System.EventHandler(this.btnAccederHistorial_Click);
            // 
            // btnRegistrarAlumno
            // 
            this.btnRegistrarAlumno.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegistrarAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarAlumno.Location = new System.Drawing.Point(512, 203);
            this.btnRegistrarAlumno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrarAlumno.Name = "btnRegistrarAlumno";
            this.btnRegistrarAlumno.Size = new System.Drawing.Size(393, 70);
            this.btnRegistrarAlumno.TabIndex = 24;
            this.btnRegistrarAlumno.Text = "Registrar Alumno";
            this.btnRegistrarAlumno.UseVisualStyleBackColor = false;
            this.btnRegistrarAlumno.Click += new System.EventHandler(this.btnRegistrarAlumno_Click);
            // 
            // btnActividad
            // 
            this.btnActividad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActividad.Location = new System.Drawing.Point(242, 312);
            this.btnActividad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActividad.Name = "btnActividad";
            this.btnActividad.Size = new System.Drawing.Size(449, 70);
            this.btnActividad.TabIndex = 25;
            this.btnActividad.Text = "Generar Actividad";
            this.btnActividad.UseVisualStyleBackColor = false;
            this.btnActividad.Click += new System.EventHandler(this.btnActividad_Click);
            // 
            // btnRegistrarProfesor
            // 
            this.btnRegistrarProfesor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegistrarProfesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarProfesor.Location = new System.Drawing.Point(12, 203);
            this.btnRegistrarProfesor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrarProfesor.Name = "btnRegistrarProfesor";
            this.btnRegistrarProfesor.Size = new System.Drawing.Size(414, 70);
            this.btnRegistrarProfesor.TabIndex = 26;
            this.btnRegistrarProfesor.Text = "Registrar Profesor";
            this.btnRegistrarProfesor.UseVisualStyleBackColor = false;
            this.btnRegistrarProfesor.Click += new System.EventHandler(this.btnRegistrarProfesor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 46);
            this.label1.TabIndex = 28;
            this.label1.Text = "Menu de Opciones";
            // 
            // menuAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 431);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistrarProfesor);
            this.Controls.Add(this.btnActividad);
            this.Controls.Add(this.btnRegistrarAlumno);
            this.Controls.Add(this.btnAccederHistorial);
            this.Name = "menuAdministrador";
            this.Text = "menuAdministrador";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.menuAdministrador_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccederHistorial;
        private System.Windows.Forms.Button btnRegistrarAlumno;
        private System.Windows.Forms.Button btnActividad;
        private System.Windows.Forms.Button btnRegistrarProfesor;
        private System.Windows.Forms.Label label1;
    }
}