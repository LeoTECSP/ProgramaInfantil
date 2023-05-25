using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;
namespace ProyectoISW.Forms
{
    public partial class EligeNumeroTEMP : Form
    {
        #region Variables
        int valorIce = 0;
        int valorGato = 0;
        int valorDino = 0;
        int valorEstrella = 0;
        int valorTijera = 0;
        int valorPez = 0;
        int resCorrectas = 0;
        int resIncorrectas = 0; 
        #endregion

        public EligeNumeroTEMP()
        {
            InitializeComponent();
            
        }

       
        #region MetodoSpeak
        public void SpeakCorrecto()//metodo 
        {
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();//instanciamos la clase de la libreria speak 
            string speech = string.Format("Muy bien.La respuesta es correcta");
            speechSynthesizer.Speak(speech);
        }
        public void SpeakIncorrecto()
        {
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            string speech = string.Format("Lo siento. esta respuesta es incorrecta");
            speechSynthesizer.Speak(speech);
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
        public void Practica()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("No te preocupes, sigue intentando");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }
        #endregion

        #region EventoIce
        private void textBoxIce_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar >= 00 && e.KeyChar <= 07 || e.KeyChar >= 09 && e.KeyChar <= 12 || e.KeyChar >= 14 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)//restricción del teclado 
            {//Se abre espacio.   

                //Devuelve un true si el evento está controlado; en caso contrario,false.
                e.Handled = true;
                //Devuelve el valor.
                return;
            }

            if (e.KeyChar == 13)
            {
                timer1.Enabled = true;

                if (textBoxIce.Text == "")
                {
                    try
                    {
                        valorIce = Convert.ToInt16(textBoxIce.Text.ToString());
                        if (valorIce == 3)
                        {

                            pictureBox2.Visible = true;//muestara la imagen de correcto
                            textBoxIce.Enabled = false;//bloquea la acción una vez realizada ya no puedes volver a usarlo
                            SpeakCorrecto(); //mandamos llama el metodo deonde contiene lo que se va decir a voz
                            resCorrectas++;
                        }
                        else
                        {
                            pictureBox3.Visible = true;//mustra la imagen de incorrecto
                            textBoxIce.Enabled = false;
                            SpeakIncorrecto();
                            resIncorrectas++;
                        }

                    }
                    catch (Exception ex)
                    {
                        string mensaje = string.Format("Escribe los números");
                        // Código que maneja la excepción
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    valorIce = Convert.ToInt16(textBoxIce.Text.ToString());
                    if (valorIce == 3)
                    {

                        pictureBox2.Visible = true;//muestara la imagen de correcto
                        textBoxIce.Enabled = false;//bloquea la acción una vez realizada ya no puedes volver a usarlo
                        SpeakCorrecto(); //mandamos llama el metodo deonde contiene lo que se va decir a voz
                        resCorrectas++;
                    }
                    else
                    {
                        pictureBox3.Visible = true;//mustra la imagen de incorrecto
                        textBoxIce.Enabled = false;
                        SpeakIncorrecto();
                        resIncorrectas++;
                    }
                }
            }
        }

        #endregion

        #region EventoGato
        private void textBoxGato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 00 && e.KeyChar <= 07 || e.KeyChar >= 09 && e.KeyChar <= 12 || e.KeyChar >= 14 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {//Se abre espacio.   

                //Devuelve un true si el evento está controlado; en caso contrario,false.
                e.Handled = true;
                //Devuelve el valor.
                return;
            }

            if (e.KeyChar == 13)
            {
                timer1.Enabled = true;

                if (textBoxGato.Text == "")
                {
                    try
                    {
                        //una variable string que se tuvo que convertir a int para obtener el valor del textbox
                        valorGato = Convert.ToInt16(textBoxGato.Text.ToString());
                        if (valorGato == 6)
                        {
                            pictureBox5.Visible = true;
                            textBoxGato.Enabled = false;
                            SpeakCorrecto();
                            resCorrectas++;
                        }
                        else
                        {
                            pictureBox6.Visible = true;
                            textBoxGato.Enabled = false;
                            SpeakIncorrecto();
                            resIncorrectas++;
                        }
                    }
                    catch (Exception ex)
                    {
                        string mensaje = string.Format("Escribe los números");
                        // Código que maneja la excepción
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //una variable string que se tuvo que convertir a int para obtener el valor del textbox
                    valorGato = Convert.ToInt16(textBoxGato.Text.ToString());
                    if (valorGato == 6)
                    {
                        pictureBox5.Visible = true;
                        textBoxGato.Enabled = false;
                        SpeakCorrecto();
                        resCorrectas++;
                    }
                    else
                    {
                        pictureBox6.Visible = true;
                        textBoxGato.Enabled = false;
                        SpeakIncorrecto();
                        resIncorrectas++;
                    }
                }
            }
        }
        #endregion

        #region EveDino
        private void textBoxDino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 00 && e.KeyChar <= 07 || e.KeyChar >= 09 && e.KeyChar <= 12 || e.KeyChar >= 14 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {//Se abre espacio.   

                //Devuelve un true si el evento está controlado; en caso contrario,false.
                e.Handled = true;
                //Devuelve el valor.
                return;
            }

            if (e.KeyChar == 13)
            {
                timer1.Enabled = true;
                if (textBoxDino.Text == "")
                {
                    try
                    {
                        //una variable string que se tuvo que convertir a int para obtener el valor del textbox
                        valorDino = Convert.ToInt16(textBoxDino.Text.ToString());
                        if (valorDino == 4)
                        {
                            pictureBox8.Visible = true;
                            textBoxDino.Enabled = false;
                            SpeakCorrecto();
                            resCorrectas++;
                        }
                        else
                        {
                            pictureBox9.Visible = true;
                            textBoxDino.Enabled = false;
                            SpeakIncorrecto();
                            resIncorrectas++;
                        }
                    }
                    catch (Exception)
                    {
                        string mensaje = string.Format("Escribe los números");
                        // Código que maneja la excepción
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //una variable string que se tuvo que convertir a int para obtener el valor del textbox
                    valorDino = Convert.ToInt16(textBoxDino.Text.ToString());
                    if (e.KeyChar == 13)
                    {
                        timer1.Enabled = true;
                        if (valorDino == 4)
                        {
                            pictureBox8.Visible = true;
                            textBoxDino.Enabled = false;
                            SpeakCorrecto();
                            resCorrectas++;
                        }
                        else
                        {
                            pictureBox9.Visible = true;
                            textBoxDino.Enabled = false;
                            SpeakIncorrecto();
                            resIncorrectas++;
                        }
                    }
                }
            }
        }
        #endregion

        #region EventoEstrella
        private void textBoxEstrella_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 00 && e.KeyChar <= 07 || e.KeyChar >= 09 && e.KeyChar <= 12 || e.KeyChar >= 14 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {//Se abre espacio.   

                //Devuelve un true si el evento está controlado; en caso contrario,false.
                e.Handled = true;
                //Devuelve el valor.
                return;
            }
            
            if (e.KeyChar == 13)
            {
                timer1.Enabled = true;

                if (textBoxEstrella.Text == "")
                {
                    try
                    {
                        //una variable string que se tuvo que convertir a int para obtener el valor del textbox
                        valorEstrella = Convert.ToInt16(textBoxEstrella.Text.ToString());
                        if (valorEstrella == 9)
                        {
                            pictureBox13.Visible = true;
                            textBoxEstrella.Enabled = false;
                            SpeakCorrecto();
                            resCorrectas++;
                        }
                        else
                        {
                            pictureBox14.Visible = true;
                            textBoxEstrella.Enabled = false;
                            SpeakIncorrecto();
                            resIncorrectas++;
                        }
                    }
                    catch (Exception ex)
                    {

                        string mensaje = string.Format("Escribe los números");
                        // Código que maneja la excepción
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //una variable string que se tuvo que convertir a int para obtener el valor del textbox
                    valorEstrella = Convert.ToInt16(textBoxEstrella.Text.ToString());
                    if (e.KeyChar == 13)
                    {
                        timer1.Enabled = true;
                        if (valorEstrella == 9)
                        {
                            pictureBox13.Visible = true;
                            textBoxEstrella.Enabled = false;
                            SpeakCorrecto();
                            resCorrectas++;
                        }
                        else
                        {
                            pictureBox14.Visible = true;
                            textBoxEstrella.Enabled = false;
                            SpeakIncorrecto();
                            resIncorrectas++;
                        }
                    }
                }
            }
            
        }
        #endregion

        #region EvenTijera
        private void textBoxTijera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 00 && e.KeyChar <= 07 || e.KeyChar >= 09 && e.KeyChar <= 12 || e.KeyChar >= 14 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {//Se abre espacio.   

                //Devuelve un true si el evento está controlado; en caso contrario,false.
                e.Handled = true;
                //Devuelve el valor.
                return;
            }
            
            if (e.KeyChar == 13)
            {
                timer1.Enabled = true;
                if (textBoxTijera.Text == "")
                {
                    try
                    {
                        //una variable string que se tuvo que convertir a int para obtener el valor del textbox
                        valorTijera = Convert.ToInt16(textBoxTijera.Text.ToString());
                        if (valorTijera == 7)
                        {
                            pictureBox15.Visible = true;
                            textBoxTijera.Enabled = false;
                            SpeakCorrecto();
                            resCorrectas++;
                        }
                        else
                        {
                            pictureBox16.Visible = true;
                            textBoxTijera.Enabled = false;
                            SpeakIncorrecto();
                            resIncorrectas++;
                        }
                    }
                    catch (Exception ex)
                    {
                        string mensaje = string.Format("Escribe los números");
                        // Código que maneja la excepción
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //una variable string que se tuvo que convertir a int para obtener el valor del textbox
                    valorTijera = Convert.ToInt16(textBoxTijera.Text.ToString());
                    if (e.KeyChar == 13)
                    {
                        timer1.Enabled = true;
                        if (valorTijera == 7)
                        {
                            pictureBox15.Visible = true;
                            textBoxTijera.Enabled = false;
                            SpeakCorrecto();
                            resCorrectas++;
                        }
                        else
                        {
                            pictureBox16.Visible = true;
                            textBoxTijera.Enabled = false;
                            SpeakIncorrecto();
                            resIncorrectas++;
                        }
                    }
                }
            }
            
        }
        #endregion

        #region EvenPez
        private void textBoxPez_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 00 && e.KeyChar <= 07 || e.KeyChar >= 09 && e.KeyChar <= 12 || e.KeyChar >= 14 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {//Se abre espacio.   

                //Devuelve un true si el evento está controlado; en caso contrario,false.
                e.Handled = true;
                //Devuelve el valor.
                return;
            }

            if (e.KeyChar == 13)
            {
                timer1.Enabled = true;
                if (textBoxPez.Text == "")
                {
                    try
                    {
                        //una variable string que se tuvo que convertir a int para obtener el valor del textbox
                        valorPez = Convert.ToInt16(textBoxPez.Text.ToString());
                        if (valorPez == 10)
                        {
                            pictureBox17.Visible = true;
                            textBoxPez.Enabled = false;
                            SpeakCorrecto();
                            resCorrectas++;
                        }
                        else
                        {
                            pictureBox18.Visible = true;
                            textBoxPez.Enabled = false;
                            SpeakIncorrecto();
                            resIncorrectas++;
                        }
                    }
                    catch (Exception ex)
                    {
                        string mensaje = string.Format("Escribe los números");
                        // Código que maneja la excepción
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //una variable string que se tuvo que convertir a int para obtener el valor del textbox
                    valorPez = Convert.ToInt16(textBoxPez.Text.ToString());

                    if (e.KeyChar == 13)
                    {
                        timer1.Enabled = true;
                        if (valorPez == 10)
                        {
                            pictureBox17.Visible = true;
                            textBoxPez.Enabled = false;
                            SpeakCorrecto();
                            resCorrectas++;
                        }
                        else
                        {
                            pictureBox18.Visible = true;
                            textBoxPez.Enabled = false;
                            SpeakIncorrecto();
                            resIncorrectas++;
                        }
                    }
                }
            }
        }
        #endregion

        
        private void Reiniciar()
        {
            textBoxIce.Text = "";//se manda una cadena vacia para limpiar el textbox
            textBoxGato.Text = "";
            textBoxDino.Text = "";
            textBoxEstrella.Text = "";
            textBoxTijera.Text = "";
            textBoxPez.Text = "";
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            textBoxIce.Enabled = true;
            textBoxGato.Enabled = true;
            textBoxDino.Enabled = true;
            textBoxEstrella.Enabled = true;
            textBoxTijera.Enabled = true;
            textBoxPez.Enabled = true;
            valorIce = 0;
            valorGato = 0;
            valorDino = 0;
            valorEstrella = 0;
            valorTijera = 0;
            valorPez = 0;
            resCorrectas = 0;
            resIncorrectas = 0;
        }

        #region BtnRegresar
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        #endregion



        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (valorIce == 3 && valorGato == 6 && valorDino == 4 && valorEstrella == 9 && valorTijera == 7 && valorPez == 10)
            {
                timer1.Enabled = false;
                Thread hilo1 = new Thread(new ThreadStart(Perfecto));
                string mensaje = string.Empty;
                mensaje = string.Format("¡Felicidades!, todas las respuestas estaban bien :)");
                //Muestra una ventana de mensaje.
                //Ejecutamos el hilo.

                pbFelicidades.Visible = true;
                hilo1.Start();
                MessageBox.Show(mensaje, "¡Felicidades!", MessageBoxButtons.OK, MessageBoxIcon.None);

            }

            if (textBoxIce.Text != null && textBoxGato.Text != null && textBoxDino.Text != null && textBoxEstrella.Text != null && textBoxTijera.Text != null && textBoxPez.Text != null)
            {
                if (valorIce >= 1 && valorGato >= 1 && valorDino >= 1 && valorEstrella >= 1 && valorTijera >= 1 && valorPez >= 1)
                {
                    if (valorIce != 3 || valorGato != 6 || valorDino != 4 || valorEstrella != 9 || valorTijera != 7 || valorPez != 10)
                    {
                        timer1.Enabled = false;
                        Thread hilo1 = new Thread(new ThreadStart(Practica));
                        string mensaje = string.Empty;
                        mensaje = string.Format("Terminaste el ejercicio, sigue practicando");
                        //Ejecutamos el hilo.
                        hilo1.Start();
                        //Muestra una ventana de mensaje.
                        MessageBox.Show(mensaje, "Sigue practicando", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Reiniciar();


                    }
                }
            }

        } 
        #endregion


    }
}
