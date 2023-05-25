using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoISW.Forms
{
    public partial class MenuEscritura : Form
    {

        private SpeechSynthesizer synth = new SpeechSynthesizer();
        public MenuEscritura()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

     

        private void btnAct2_Click(object sender, EventArgs e)
        {
            Form formulario = new SopaLetras();
            this.Hide();

            if (formulario.ShowDialog() == DialogResult.Retry)
            {
                this.Show();
            }
        }

        private void btnAct1_Click(object sender, EventArgs e)
        {
            Form formulario = new AcertijoPalabra();
            this.Hide();

            if (formulario.ShowDialog()== DialogResult.Retry)
            {
                this.Show();
            }
        }

        private void btnAct4_Click(object sender, EventArgs e)
        {
            Form formulario = new ReconoceInicial();
            this.Hide();

            if (formulario.ShowDialog() == DialogResult.Retry)
            {
                this.Show();
            }
        }

        private void btnAct3_Click(object sender, EventArgs e)
        {
            Form formulario = new EligeObjeto();
            this.Hide();

            if (formulario.ShowDialog() == DialogResult.Retry)
            {
                this.Show();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            VistaPrincipal form1 = new VistaPrincipal();
            this.Hide();

            this.DialogResult = DialogResult.Ignore;
        }

        private void btnAct1_MouseHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Text;
            synth.SpeakAsync(text);
        }

        private void btnAct2_MouseHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Text;
            synth.SpeakAsync(text);
        }

        private void btnAct3_MouseHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Text;
            synth.SpeakAsync(text);
        }

        private void btnAct4_MouseHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Text;
            synth.SpeakAsync(text);
        }

        private void btnRegresar_MouseHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Text;
            synth.SpeakAsync(text);
        }

        private void btnAct1_MouseEnter(object sender, EventArgs e)
        {
            btnAct1.BackColor = Color.LightYellow;

        }

        private void btnAct1_MouseLeave(object sender, EventArgs e)
        {
            btnAct1.BackColor = Color.WhiteSmoke;
        }

        private void btnAct2_MouseEnter(object sender, EventArgs e)
        {
            btnAct2.BackColor = Color.LightYellow;
        }

        private void btnAct2_MouseLeave(object sender, EventArgs e)
        {
            btnAct2.BackColor = Color.WhiteSmoke;
        }

        private void btnAct3_MouseEnter(object sender, EventArgs e)
        {
            btnAct3.BackColor = Color.LightYellow;
        }

        private void btnAct3_MouseLeave(object sender, EventArgs e)
        {
            btnAct3.BackColor = Color.WhiteSmoke;
        }

        private void btnAct4_MouseEnter(object sender, EventArgs e)
        {
            btnAct4.BackColor = Color.LightYellow;
        }

        private void btnAct4_MouseLeave(object sender, EventArgs e)
        {
            btnAct4.BackColor = Color.WhiteSmoke;
        }
    }
}
