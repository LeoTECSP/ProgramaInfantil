namespace ProyectoISW
{
    partial class HistorialActividades
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCerrarHistorial = new System.Windows.Forms.Button();
            this.btnHFallos = new System.Windows.Forms.Button();
            this.btnHAlfabeto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgHistorial = new System.Windows.Forms.DataGridView();
            this.btnHActividades = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btnCerrarHistorial);
            this.groupBox2.Controls.Add(this.btnHFallos);
            this.groupBox2.Controls.Add(this.btnHAlfabeto);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtgHistorial);
            this.groupBox2.Controls.Add(this.btnHActividades);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1434, 599);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Historial";
            // 
            // btnCerrarHistorial
            // 
            this.btnCerrarHistorial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCerrarHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarHistorial.Location = new System.Drawing.Point(1201, 50);
            this.btnCerrarHistorial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrarHistorial.Name = "btnCerrarHistorial";
            this.btnCerrarHistorial.Size = new System.Drawing.Size(211, 70);
            this.btnCerrarHistorial.TabIndex = 28;
            this.btnCerrarHistorial.Text = "Regresar";
            this.btnCerrarHistorial.UseVisualStyleBackColor = false;
            this.btnCerrarHistorial.Click += new System.EventHandler(this.btnCerrarHistorial_Click);
            // 
            // btnHFallos
            // 
            this.btnHFallos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnHFallos.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHFallos.Location = new System.Drawing.Point(880, 50);
            this.btnHFallos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHFallos.Name = "btnHFallos";
            this.btnHFallos.Size = new System.Drawing.Size(315, 70);
            this.btnHFallos.TabIndex = 27;
            this.btnHFallos.Text = "Fallos";
            this.btnHFallos.UseVisualStyleBackColor = false;
            this.btnHFallos.Click += new System.EventHandler(this.btnHFallos_Click);
            // 
            // btnHAlfabeto
            // 
            this.btnHAlfabeto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnHAlfabeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHAlfabeto.Location = new System.Drawing.Point(233, 50);
            this.btnHAlfabeto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHAlfabeto.Name = "btnHAlfabeto";
            this.btnHAlfabeto.Size = new System.Drawing.Size(321, 70);
            this.btnHAlfabeto.TabIndex = 26;
            this.btnHAlfabeto.Text = "Alfabeto";
            this.btnHAlfabeto.UseVisualStyleBackColor = false;
            this.btnHAlfabeto.Click += new System.EventHandler(this.btnHAlfabeto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 45);
            this.label1.TabIndex = 25;
            this.label1.Text = "Filtrar por:";
            // 
            // dtgHistorial
            // 
            this.dtgHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgHistorial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgHistorial.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dtgHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistorial.Location = new System.Drawing.Point(19, 147);
            this.dtgHistorial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgHistorial.Name = "dtgHistorial";
            this.dtgHistorial.RowHeadersWidth = 51;
            this.dtgHistorial.RowTemplate.Height = 24;
            this.dtgHistorial.Size = new System.Drawing.Size(1393, 409);
            this.dtgHistorial.TabIndex = 20;
            // 
            // btnHActividades
            // 
            this.btnHActividades.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnHActividades.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHActividades.Location = new System.Drawing.Point(560, 50);
            this.btnHActividades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHActividades.Name = "btnHActividades";
            this.btnHActividades.Size = new System.Drawing.Size(315, 70);
            this.btnHActividades.TabIndex = 18;
            this.btnHActividades.Text = "Actividades";
            this.btnHActividades.UseVisualStyleBackColor = false;
            this.btnHActividades.Click += new System.EventHandler(this.btnHActividades_Click);
            // 
            // HistorialActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1474, 581);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HistorialActividades";
            this.Text = "HistorialActividades";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgHistorial;
        private System.Windows.Forms.Button btnHActividades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHFallos;
        private System.Windows.Forms.Button btnHAlfabeto;
        private System.Windows.Forms.Button btnCerrarHistorial;
    }
}