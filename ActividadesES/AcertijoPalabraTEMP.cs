using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;

namespace ProyectoISW
{
    public partial class AcertijoPalabraTEMP : Form
    {
        int correctas = 0;
        int incorrectas = 0;
        
        public AcertijoPalabraTEMP()
        {
            InitializeComponent();
            lblQueso.Click += new EventHandler(OnButtonClick);
            lblBarco.Click += new EventHandler(OnButtonClick);
            lblManzana.Click += new EventHandler(OnButtonClick);
            //Une todos los subprocesos al principal.
            CheckForIllegalCrossThreadCalls = true;

        }

        public void Perfecto()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("¡Felicidades!, todas tus respuestas fueron elegidas correctamente");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        public void ConErrores()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("¡Felicidades!, terminaste el ejercicio sigue practicando");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }
        /// <summary>
        /// Este evento nos permite revisar todos los clicks que hagamos en el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonClick(object sender, EventArgs e)
        {
            /*
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            */
            if (correctas == 3 && incorrectas == 0)
            {
                Thread hilo1 = new Thread(new ThreadStart(Perfecto));
                string mensaje = string.Empty;
                mensaje = string.Format("¡Felicidades!, todas tus respuestas fueron elegidas correctamente");
                //Muestra una ventana de mensaje.
                //Ejecutamos el hilo.
                pbFelicitaciones.Visible = true;
                hilo1.Start();
                MessageBox.Show(mensaje, "¡Felicidades!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (incorrectas >= 1 && correctas == 3)
            {
                Thread hilo1 = new Thread(new ThreadStart(ConErrores));
                string mensaje = string.Empty;
                mensaje = string.Format("Felicidades!, terminaste el ejercicio, sigue practicando");
                //Ejecutamos el hilo.

                hilo1.Start();
                //Muestra una ventana de mensaje.
                MessageBox.Show(mensaje, "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reiniciar();
            }
        }

        /// <summary>
        /// Este método sirve para decir que la respuesta es incorrecta.
        /// </summary>
        private void RespuestaIncorrecta()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("Lo siento, esta palabra es incorrecta");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void RespuestaCorrecta()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("Felicidades, esta palabra esta correcta");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
            
        }
        private void lblKeso_Click(object sender, EventArgs e)
        {
            RespuestaIncorrecta();
            pbIncorrecto1.Visible = true;
            lblKeso.Enabled = false;
            incorrectas++;
        }

        private void lblCeso_Click(object sender, EventArgs e)
        {
            RespuestaIncorrecta();
            pbIncorrecto2.Visible = true;
            lblCeso.Enabled = false;
            incorrectas++;
        }

        
        private void lblQueso_Click(object sender, EventArgs e)
        {
            RespuestaCorrecta();
            pbCorrecto1.Visible = true;
            lblKeso.Enabled = false;
            lblCeso.Enabled = false;
            lblQueso.Enabled = false;
            lblQueso.Visible = false;
            pbQueso.Visible = true;
            correctas++;
        }

        private void lblManzana_Click(object sender, EventArgs e)
        {
            RespuestaCorrecta();
            pbCorrecto2.Visible = true;
            lblMamsana.Enabled = false;
            lblMansana.Enabled = false;
            lblManzana.Enabled = false;
            lblManzana.Visible = false;
            pbManzana.Visible = true;
            correctas++;
        }

        private void lblMansana_Click(object sender, EventArgs e)
        {
            RespuestaIncorrecta();
            pbIncorrecto3.Visible = true;
            lblMansana.Enabled = false;
            incorrectas++;
        }

        private void lblMamsana_Click(object sender, EventArgs e)
        {
            RespuestaIncorrecta();
            pbIncorrecto4.Visible = true;
            lblMamsana.Enabled = false;
            incorrectas++;
        }

        private void lblVarco_Click(object sender, EventArgs e)
        {
            RespuestaIncorrecta();
            pbIncorrecto5.Visible = true;
            lblVarco.Enabled = false;
            incorrectas++;
        }

        private void lblBarco_Click(object sender, EventArgs e)
        {
            RespuestaCorrecta();
            pbCorrecto3.Visible = true;
            pbBarco.Visible = true;
            lblBarco.Visible = false;
            lblBarco.Enabled = false;
            lblDarco.Enabled = false;
            lblVarco.Enabled = false;
            correctas++;
        }

        private void lblDarco_Click(object sender, EventArgs e)
        {
            RespuestaIncorrecta();
            pbIncorrecto6.Visible = true;
            lblDarco.Enabled = false;
            incorrectas++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Reiniciar()
        {

            pbIncorrecto1.Visible = false;
            pbIncorrecto2.Visible = false;
            pbIncorrecto3.Visible = false;
            pbIncorrecto4.Visible = false;
            pbIncorrecto5.Visible = false;
            pbIncorrecto6.Visible = false;
            pbCorrecto1.Visible = false;
            pbCorrecto2.Visible = false;
            pbCorrecto3.Visible = false;

            lblKeso.Enabled = true;
            lblCeso.Enabled = true;
            lblQueso.Enabled = true;
            lblQueso.Visible = true;
            pbQueso.Visible = false;

            lblMamsana.Enabled = true;
            lblMansana.Enabled = true;
            lblManzana.Enabled = true;
            lblManzana.Visible = true;
            pbManzana.Visible = false;

            pbBarco.Visible = false;
            lblBarco.Visible = true;
            lblBarco.Enabled = true;
            lblDarco.Enabled = true;
            lblVarco.Enabled = true;

            correctas = 0;
            incorrectas = 0;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
