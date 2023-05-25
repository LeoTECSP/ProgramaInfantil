using System;
using System.Speech.Synthesis;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoISW.Forms
{
    public partial class EligeNumero : Form
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
        

        public EligeNumero()
        {
            InitializeComponent();
            EjerciciosRandom();
        }

        #region Random
        public void EjerciciosRandom()
        {
            List<GroupBox> groupBoxes = new List<GroupBox> { groupBoxHelado, groupBoxEstrella, groupBoxGato, groupBoxTijera, groupBoxDino, groupBoxPez };
            List<int> cellIndices = new List<int>();
            for (int i = 0; i < tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount; i++)
            {
                cellIndices.Add(i);
            }


            Random random = new Random();
            cellIndices = cellIndices.OrderBy(x => random.Next()).ToList();
            int groupBoxIndex = 0;
            foreach (GroupBox groupBox in groupBoxes)
            {
                int cellIndex = cellIndices[groupBoxIndex];
                int row = cellIndex / tableLayoutPanel1.ColumnCount;
                int column = cellIndex % tableLayoutPanel1.ColumnCount;
                tableLayoutPanel1.Controls.Add(groupBox, column, row);
                groupBoxIndex++;
            }
        } 
        #endregion

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
        public void BtnRegresar()
        {
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            string speech = string.Format("Lo siento. Debes terminar el ejercicio");
            speechSynthesizer.Speak(speech);
        }
        #endregion

        #region EventoIce
        private void textBoxIce_KeyPress_1(object sender, KeyPressEventArgs e)
        
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
        private void textBoxGato_KeyPress_1(object sender, KeyPressEventArgs e)
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
        private void textBoxDino_KeyPress_1(object sender, KeyPressEventArgs e)
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
        private void textBoxEstrella_KeyPress_1(object sender, KeyPressEventArgs e)
        
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
        private void textBoxTijera_KeyPress_1(object sender, KeyPressEventArgs e)
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
        private void textBoxPez_KeyPress_1(object sender, KeyPressEventArgs e)
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
            if (textBoxIce.Enabled == false && textBoxGato.Enabled == false && textBoxDino.Enabled == false && textBoxEstrella.Enabled == false && textBoxTijera.Enabled == false && textBoxPez.Text != "")
            {
                EjerciciosRandom();
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
            else
            {
               
            }
            this.DialogResult = DialogResult.Retry;
            this.Close();
            return;
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
                pbFelicidades.Visible = true;
                mensaje = string.Format("¡Felicidades!, todas tus respuestas fueron elegidas correctamente");
                //Muestra una ventana de mensaje.
                //Ejecutamos el hilo.
                hilo1.Start();
                MessageBox.Show(mensaje, "¡Felicidades!", MessageBoxButtons.OK, MessageBoxIcon.None);
                InsertarActividad();

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
                        EjerciciosRandom();
                        InsertarError();
                    }
                }
            }

           
        }


        #endregion

        #region Resultados

        private void InsertarActividad()
        {
            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Abrir la conexión a la base de datos
                connection.Open();

                // Crear un objeto SqlCommand con el nombre del stored procedure y la conexión
                SqlCommand cmd = new SqlCommand("sp_ActualizarActividad2MA", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Asignar los valores de los parámetros del stored procedure
                cmd.Parameters.AddWithValue("@idRegistro", Variables.idHistorial); // idRegistro es el valor que identifica el registro que quieres actualizar
                cmd.Parameters.AddWithValue("@valor", true); // o false, dependiendo de lo que quieras actualizar

                // Ejecutar el stored procedure y obtener el número de filas afectadas
                int rowsAffected = cmd.ExecuteNonQuery();



                // Si se actualizaron filas, mostrar un mensaje de éxito
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Se actualizó la actividad 2MA del registro con éxito.");
                }
                else
                {
                    //MessageBox.Show("No se encontró ningún registro con el id especificado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar el registro: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                connection.Close();
            }
        }

        private void InsertarError()
        {

            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Abrir la conexión a la base de datos
                connection.Open();

                // Llamar al Stored Procedure para sumar 1 al campo erroresTotales del registro con idRegistro especificado
                SqlCommand cmd = new SqlCommand("sp_ErroresActividades", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idRegistro", Variables.idHistorial); // idRegistro es el valor que identifica el registro que quieres actualizar
                SqlParameter resultParam = cmd.Parameters.Add("@result", SqlDbType.Int);
                resultParam.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                // Obtener el valor de retorno del stored procedure
                int result = Convert.ToInt32(resultParam.Value);

                // Verificar si hubo un error en el stored procedure
                if (result == -1)
                {
                    //MessageBox.Show("Ocurrió un error al actualizar el registro.");
                }
                else
                {
                    // Mostrar un mensaje de éxito
                    //MessageBox.Show("Se actualizó el campo erroresTotales del registro con éxito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar el registro: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                connection.Close();
            }
        }


        #endregion
    }
}
