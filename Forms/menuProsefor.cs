using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoISW.Forms
{
    public partial class menuProfesor : Form
    {
        public menuProfesor()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnActividad_Click(object sender, EventArgs e)
        {
            Form form = new LogeoNiño();
            form.Show();
            this.Hide();
        }

        private void btnCerrarSesionA_Click(object sender, EventArgs e)
        {
            this.Hide();

            AccesoPrograma accesoPrograma = new AccesoPrograma();
            accesoPrograma.Show();
        }

        private void menuProfesor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
