using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoISW
{
    public partial class menuAdministrador : Form
    {
        public menuAdministrador()
        {
            InitializeComponent();
        }

        private void btnActividad_Click(object sender, EventArgs e)
        {
            Form form1 = new LogeoNiño();
            this.Hide();
            if (form1.ShowDialog() == DialogResult.Retry)
            {
                this.Show();
            }
        }

        private void btnRegistrarAlumno_Click(object sender, EventArgs e)
        {
            Form form1 = new AgregarNiño();
          


            if (form1.ShowDialog() == DialogResult.Retry)
            {
                this.Show();

            }
        }

        private void btnCerrarSesionA_Click(object sender, EventArgs e)
        {


            this.Hide();
            AccesoPrograma accesoPrograma = new AccesoPrograma();
            accesoPrograma.Show();

        }

        private void btnRegistrarProfesor_Click(object sender, EventArgs e)
        {
            Form form1 = new AgregarProfesor();
            if (form1.ShowDialog() == DialogResult.Retry)
            {
                this.Show();

            }
        }

        private void btnAccederHistorial_Click(object sender, EventArgs e)
        {
            Form form1 = new HistorialActividades();
            if (form1.ShowDialog() == DialogResult.Retry)
            {
                this.Show();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void menuAdministrador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
