using ProyectoISW.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;


namespace ProyectoISW
{
    public partial class VistaPrincipal : Form
    {
        private SpeechSynthesizer synth = new SpeechSynthesizer();

        public VistaPrincipal()
        {
            InitializeComponent();
        }
        public void SetNombreAlumno(string nombre)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           



            
        }

        private void btnMenuES_Click(object sender, EventArgs e)
        {
            Form formulario = new MenuEscritura();
            this.Hide();
            if (formulario.ShowDialog()== DialogResult.Ignore)
            {
                this.Show();
            }
            
        }

        private void btnMenuMA_Click(object sender, EventArgs e)
        {
            Form formulario = new MenuMatematicas();
            this.Hide();

            if (formulario.ShowDialog() == DialogResult.Ignore)
            {
                this.Show();
            }
        }

        private void VistaPrincipal_Load(object sender, EventArgs e)
        {
            lblAlumno.Text += Variables.nombreAlumno;
           


        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (Variables.esAdministrador == true)
            {
                AccesoPrograma accesoPrograma = new AccesoPrograma();

                accesoPrograma.Show();
                this.Hide();


                
               



    
            }
            if (Variables.esAdministrador == false)
            {
                //menuProfesor menuProfesor = new menuProfesor();
   AccesoPrograma accesoPrograma = new AccesoPrograma();

                accesoPrograma.Show();
                this.Hide();
            }
        }

        private void btnMenuES_MouseHover(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            string text = button.Text;
            synth.SpeakAsync(text);
        }

        private void btnMenuMA_MouseHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Text;
            synth.SpeakAsync(text);
        }

        private void btnAcceder_MouseHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Text;
            synth.SpeakAsync(text);
        }

        private void btnMenuES_MouseEnter(object sender, EventArgs e)
        {
            btnMenuES.BackColor = Color.LightYellow;
        }

        private void btnMenuES_MouseLeave(object sender, EventArgs e)
        {
            btnMenuES.BackColor = Color.WhiteSmoke;
        }

        private void btnMenuMA_MouseEnter(object sender, EventArgs e)
        {
            btnMenuMA.BackColor = Color.LightYellow;
        }

        private void btnMenuMA_MouseLeave(object sender, EventArgs e)
        {
            btnMenuMA.BackColor = Color.WhiteSmoke;
        }

        private void VistaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
