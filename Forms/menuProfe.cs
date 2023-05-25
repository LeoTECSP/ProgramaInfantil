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
    public partial class menuProfe : Form
    {
        public menuProfe()
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

        private void btnCerrarSesionP_Click(object sender, EventArgs e)
        {


            this.Hide();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccesoPrograma accesoPrograma = new AccesoPrograma();
            accesoPrograma.ShowDialog();
        }

        private void menuProfe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
