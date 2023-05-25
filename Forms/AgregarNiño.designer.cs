namespace ProyectoISW
{
    partial class AgregarNiño
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtIDAlumno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.dtgVerAlumnos = new System.Windows.Forms.DataGridView();
            this.txtApellidoMAlumno = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAgregarAlumno = new System.Windows.Forms.Button();
            this.txtApellidoPAlumno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombreAlumno = new System.Windows.Forms.TextBox();
            this.btnVerAlumnos = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVerAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.btnModificar);
            this.groupBox3.Controls.Add(this.btnVerAlumnos);
            this.groupBox3.Controls.Add(this.txtIDAlumno);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnRegresar);
            this.groupBox3.Controls.Add(this.dtgVerAlumnos);
            this.groupBox3.Controls.Add(this.txtApellidoMAlumno);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btnAgregarAlumno);
            this.groupBox3.Controls.Add(this.txtApellidoPAlumno);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtNombreAlumno);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(1077, 655);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Agregar Niños";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnModificar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(433, 554);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(296, 65);
            this.btnModificar.TabIndex = 36;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtIDAlumno
            // 
            this.txtIDAlumno.BackColor = System.Drawing.Color.White;
            this.txtIDAlumno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDAlumno.Location = new System.Drawing.Point(9, 485);
            this.txtIDAlumno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDAlumno.Name = "txtIDAlumno";
            this.txtIDAlumno.Size = new System.Drawing.Size(295, 34);
            this.txtIDAlumno.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 68);
            this.label1.TabIndex = 34;
            this.label1.Text = "Id (Solo para \r\nmodificar alumno)";
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegresar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(755, 24);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(296, 65);
            this.btnRegresar.TabIndex = 39;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // dtgVerAlumnos
            // 
            this.dtgVerAlumnos.AllowUserToAddRows = false;
            this.dtgVerAlumnos.AllowUserToDeleteRows = false;
            this.dtgVerAlumnos.AllowUserToResizeColumns = false;
            this.dtgVerAlumnos.AllowUserToResizeRows = false;
            this.dtgVerAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgVerAlumnos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgVerAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVerAlumnos.Location = new System.Drawing.Point(327, 106);
            this.dtgVerAlumnos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgVerAlumnos.Name = "dtgVerAlumnos";
            this.dtgVerAlumnos.ReadOnly = true;
            this.dtgVerAlumnos.RowHeadersWidth = 51;
            this.dtgVerAlumnos.RowTemplate.Height = 24;
            this.dtgVerAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVerAlumnos.Size = new System.Drawing.Size(724, 433);
            this.dtgVerAlumnos.TabIndex = 32;
            // 
            // txtApellidoMAlumno
            // 
            this.txtApellidoMAlumno.BackColor = System.Drawing.Color.White;
            this.txtApellidoMAlumno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoMAlumno.Location = new System.Drawing.Point(9, 329);
            this.txtApellidoMAlumno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtApellidoMAlumno.Name = "txtApellidoMAlumno";
            this.txtApellidoMAlumno.Size = new System.Drawing.Size(295, 34);
            this.txtApellidoMAlumno.TabIndex = 27;
            this.txtApellidoMAlumno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoMAlumno_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 277);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(264, 34);
            this.label8.TabIndex = 26;
            this.label8.Text = "Apellido Materno";
            // 
            // btnAgregarAlumno
            // 
            this.btnAgregarAlumno.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregarAlumno.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAlumno.Location = new System.Drawing.Point(131, 554);
            this.btnAgregarAlumno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarAlumno.Name = "btnAgregarAlumno";
            this.btnAgregarAlumno.Size = new System.Drawing.Size(296, 65);
            this.btnAgregarAlumno.TabIndex = 29;
            this.btnAgregarAlumno.Text = "Agregar ";
            this.btnAgregarAlumno.UseVisualStyleBackColor = false;
            this.btnAgregarAlumno.Click += new System.EventHandler(this.btnAgregarAlumno_Click);
            // 
            // txtApellidoPAlumno
            // 
            this.txtApellidoPAlumno.BackColor = System.Drawing.Color.White;
            this.txtApellidoPAlumno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoPAlumno.Location = new System.Drawing.Point(13, 204);
            this.txtApellidoPAlumno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtApellidoPAlumno.Name = "txtApellidoPAlumno";
            this.txtApellidoPAlumno.Size = new System.Drawing.Size(295, 34);
            this.txtApellidoPAlumno.TabIndex = 24;
            this.txtApellidoPAlumno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoPAlumno_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 34);
            this.label7.TabIndex = 23;
            this.label7.Text = "Apellido Paterno";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 34);
            this.label6.TabIndex = 22;
            this.label6.Text = "Nombre(s)";
            // 
            // txtNombreAlumno
            // 
            this.txtNombreAlumno.BackColor = System.Drawing.Color.White;
            this.txtNombreAlumno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreAlumno.Location = new System.Drawing.Point(13, 100);
            this.txtNombreAlumno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreAlumno.Name = "txtNombreAlumno";
            this.txtNombreAlumno.Size = new System.Drawing.Size(295, 34);
            this.txtNombreAlumno.TabIndex = 19;
            this.txtNombreAlumno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreAlumno_KeyPress);
            // 
            // btnVerAlumnos
            // 
            this.btnVerAlumnos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVerAlumnos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerAlumnos.Location = new System.Drawing.Point(735, 554);
            this.btnVerAlumnos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerAlumnos.Name = "btnVerAlumnos";
            this.btnVerAlumnos.Size = new System.Drawing.Size(296, 65);
            this.btnVerAlumnos.TabIndex = 37;
            this.btnVerAlumnos.Text = "Ver Lista";
            this.btnVerAlumnos.UseVisualStyleBackColor = false;
            this.btnVerAlumnos.Click += new System.EventHandler(this.btnVerAlumnos_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 34);
            this.label5.TabIndex = 17;
            // 
            // AgregarNiño
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1095, 680);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AgregarNiño";
            this.Text = "AgregarNiño";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVerAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgVerAlumnos;
        private System.Windows.Forms.TextBox txtApellidoMAlumno;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAgregarAlumno;
        private System.Windows.Forms.TextBox txtApellidoPAlumno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombreAlumno;
        private System.Windows.Forms.Button btnVerAlumnos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtIDAlumno;
        private System.Windows.Forms.Label label1;
    }
}