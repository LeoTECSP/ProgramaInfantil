using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoISW.Forms
{
    public partial class AcertijoPalabra : Form
    {
        int correctas = 0;
        int incorrectas = 0;

        public AcertijoPalabra()
        {
            InitializeComponent();
            lblQueso.Click += new EventHandler(OnButtonClick);
            lblCeso.Click += new EventHandler(OnButtonClick);
            lblKeso.Click += new EventHandler(OnButtonClick);
            lblBarco.Click += new EventHandler(OnButtonClick);
            lblVarco.Click += new EventHandler(OnButtonClick);
            lblDarco.Click += new EventHandler(OnButtonClick);
            lblManzana.Click += new EventHandler(OnButtonClick);
            lblMamsana.Click += new EventHandler(OnButtonClick);
            lblMansana.Click += new EventHandler(OnButtonClick);
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

            if (correctas == 3 && incorrectas == 0)
            {
                Thread hilo1 = new Thread(new ThreadStart(Perfecto));
                string mensaje = string.Empty;
                Reiniciar();
                pbFelicitaciones.Visible = true;
                mensaje = string.Format("¡Felicidades!, todas tus respuestas fueron elegidas correctamente");
                //Muestra una ventana de mensaje.
                //Ejecutamos el hilo.
                hilo1.Start();
                MessageBox.Show(mensaje, "¡Felicidades!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                InsertarActividad();



            }
            if (incorrectas >= 1 && correctas == 3)
            {
                Thread hilo1 = new Thread(new ThreadStart(ConErrores));
                string mensaje = string.Empty;
                mensaje = string.Format("Felicidades, terminaste el ejercicio sigue practicando");
                //Ejecutamos el hilo.
                hilo1.Start();
                //Muestra una ventana de mensaje.
                MessageBox.Show(mensaje, "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reiniciar();

                InsertarError();
            }
        }

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
                SqlCommand cmd = new SqlCommand("sp_ActualizarActividad1ES", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Asignar los valores de los parámetros del stored procedure
                cmd.Parameters.AddWithValue("@idRegistro", Variables.idHistorial); // idRegistro es el valor que identifica el registro que quieres actualizar
                cmd.Parameters.AddWithValue("@valor", true); // o false, dependiendo de lo que quieras actualizar

                // Ejecutar el stored procedure y obtener el número de filas afectadas
                int rowsAffected = cmd.ExecuteNonQuery();

                

                // Si se actualizaron filas, mostrar un mensaje de éxito
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Se actualizó la actividad 1ES del registro con éxito.");
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

        /*
        // Abrir la conexión a la base de datos
        connection.Open();


                SqlCommand command = new SqlCommand();
        command.Connection = connection;
                command.CommandText = "sp_InsertarProfesor";

                // Agregar los parámetros del stored procedure
                command.Parameters.AddWithValue("@nombreProfesor", nombre);
                command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                command.Parameters.AddWithValue("@matriculaProfesor", matricula);
                command.Parameters.AddWithValue("@contraseña", contrasena);
                command.Parameters.AddWithValue("@administrador", administrador);

                command.CommandType = CommandType.StoredProcedure;

                // Ejecutar el comando INSERT
                int rowsAffected = command.ExecuteNonQuery();

                // Mostrar un mensaje de éxito si se agregó el alumno correctamente
                if (rowsAffected > 0)
                {
                    MessageBox.Show("El profesor se agregó correctamente a la base de datos.");
                    Reiniciar();

    }
                else
                {
                    MessageBox.Show("No se pudo agregar el alumno a la base de datos.");
                }
*/


        private void Reiniciar()
        {

            pbIncorrecto1.Visible = false;
            pbIncorrecto2.Visible = false;
            pbIncorrecto3.Visible = false;
            pbIncorrecto4.Visible = false;
            pbIncorrecto5.Visible = false;
            pbIncorrecto6.Visible = false;

            pbIncorrecto21.Visible = false;
            pbIncorrecto31.Visible = false;
            pbIncorrecto51.Visible = false;

            pbCorrecto1.Visible = false;
            pbCorrecto2.Visible = false;
            pbCorrecto3.Visible = false;
            pbCorrecto33.Visible = false;
            pbCorrecto11.Visible = false;
            pbCorrecto12.Visible = false;
            pbCorrecto21.Visible = false;
            pbCorrecto22.Visible = false;
            pbCorrecto31.Visible = false;
            


            lblKeso.Enabled = true;
            lblCeso.Enabled = true;
            lblQueso.Enabled = true;
            lblQueso.Visible = true;
          

            lblMamsana.Enabled = true;
            lblMansana.Enabled = true;
            lblManzana.Enabled = true;
            lblManzana.Visible = true;
           

         
            lblBarco.Visible = true;
            lblBarco.Enabled = true;
            lblDarco.Enabled = true;
            lblVarco.Enabled = true;

            correctas = 0;
            incorrectas = 0;
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
            
            if (lblKeso.Text == "Queso")
            {
                RespuestaCorrecta();
                pbCorrecto11.Visible = true;
                lblKeso.Enabled = false;
                lblCeso.Enabled = false;
                lblQueso.Enabled = false;
                correctas++;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto1.Visible = true;
                
                incorrectas++;
            }
            if (lblQueso.Text == "Queso")
            {
                lblQueso.Enabled = true;

                lblKeso.Enabled = false;
            }
            if (lblCeso.Text == "Queso")
            {
                lblCeso.Enabled = true;

                lblKeso.Enabled = false;
            }
        }

        private void lblCeso_Click(object sender, EventArgs e)
        {
            if (lblCeso.Text == "Queso")
            {
                RespuestaCorrecta();
                pbCorrecto12.Visible = true;
                lblKeso.Enabled = false;
                lblCeso.Enabled = false;
                lblQueso.Enabled = false;
                correctas++;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto2.Visible = true;
                
                incorrectas++;
            }
            if (lblQueso.Text == "Queso")
            {
                lblQueso.Enabled = true;

                lblCeso.Enabled = false;
            }
            if (lblKeso.Text == "Queso")
            {
                lblKeso.Enabled = true;

                lblCeso.Enabled = false;
            }
            
        }


        private void lblQueso_Click(object sender, EventArgs e)
        {
            if (lblQueso.Text == "Queso")
            {
                RespuestaCorrecta();
                pbCorrecto1.Visible = true;
                lblKeso.Enabled = false;
                lblCeso.Enabled = false;
                lblQueso.Enabled = false;
                correctas++;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto21.Visible = true;
                incorrectas++;
            }
            if (lblCeso.Text == "Queso")
            {
                lblCeso.Enabled = true;
                
                lblQueso.Enabled = false;
            }
            if (lblKeso.Text == "Queso")
            {
                lblKeso.Enabled = true;
                
                lblQueso.Enabled = false;
            }
        }

        private void lblManzana_Click(object sender, EventArgs e)
        {
            if (lblManzana.Text == "Manzana")
            {
                RespuestaCorrecta();
                pbCorrecto2.Visible = true;
                lblMamsana.Enabled = false;
                lblMansana.Enabled = false;
                lblManzana.Enabled = false;
                correctas++;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto31.Visible = true;
                incorrectas++;
            }
            if (lblMamsana.Text == "Manzana")
            {
                lblMamsana.Enabled = true;

                lblManzana.Enabled = false;
            }
            if (lblMansana.Text == "Manzana")
            {
                lblMansana.Enabled = true;

                lblManzana.Enabled = false;
            }
            
        }

        private void lblMansana_Click(object sender, EventArgs e)
        {
            if (lblMansana.Text == "Manzana")
            {
                RespuestaCorrecta();
                pbCorrecto21.Visible = true;
                lblMamsana.Enabled = false;
                lblMansana.Enabled = false;
                lblManzana.Enabled = false;
                correctas++;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto3.Visible = true;
                lblMansana.Enabled = false;
                incorrectas++;
            }
            if (lblManzana.Text == "Manzana")
            {
                lblManzana.Enabled = true;

                lblMansana.Enabled = false;
            }
            if (lblMamsana.Text == "Manzana")
            {
                lblMamsana.Enabled = true;

                lblMansana.Enabled = false;
            }
            
        }

        private void lblMamsana_Click(object sender, EventArgs e)
        {
            if (lblMamsana.Text == "Manzana")
            {
                RespuestaCorrecta();
                pbCorrecto22.Visible = true;
                lblMamsana.Enabled = false;
                lblMansana.Enabled = false;
                lblManzana.Enabled = false;
                correctas++;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto4.Visible = true;
                lblMamsana.Enabled = false;
                incorrectas++;
            }
            if (lblManzana.Text == "Manzana")
            {
                lblManzana.Enabled = true;

                lblMamsana.Enabled = false;
            }
            if (lblMansana.Text == "Manzana")
            {
                lblMansana.Enabled = true;

                lblMamsana.Enabled = false;
            }
            
        }

        private void lblVarco_Click(object sender, EventArgs e)
        {
            if (lblVarco.Text == "Barco")
            {
                RespuestaCorrecta();
                pbCorrecto31.Visible = true;
                lblVarco.Enabled = false;
                lblBarco.Enabled = false;
                lblDarco.Enabled = false;
                correctas++;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto5.Visible = true;
                lblVarco.Enabled = false;
                incorrectas++;
            }
            if (lblBarco.Text == "Barco")
            {
                lblBarco.Enabled = true;

                lblVarco.Enabled = false;
            }
            if (lblDarco.Text == "Barco")
            {
                lblDarco.Enabled = true;

                lblVarco.Enabled = false;
            }
           
        }

        private void lblBarco_Click(object sender, EventArgs e)
        {
            if (lblBarco.Text == "Barco")
            {
                RespuestaCorrecta();
                pbCorrecto3.Visible = true;
                lblBarco.Enabled = false;
                lblDarco.Enabled = false;
                lblVarco.Enabled = false;
                correctas++;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto51.Visible = true;
                
                incorrectas++;
            }
            if (lblVarco.Text == "Barco")
            {
                lblVarco.Enabled = true;

                lblBarco.Enabled = false;
            }
            if (lblDarco.Text == "Barco")
            {
                lblDarco.Enabled = true;

                lblBarco.Enabled = false;
            }
            
        }

        private void lblDarco_Click(object sender, EventArgs e)
        {
            if (lblDarco.Text == "Barco")
            {
                RespuestaCorrecta();
                pbCorrecto33.Visible = true;
                lblBarco.Enabled = false;
                lblDarco.Enabled = false;
                lblVarco.Enabled = false;
                correctas++;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto6.Visible = true;
                lblDarco.Enabled = false;
                incorrectas++;
            }
            if (lblVarco.Text == "Barco")
            {
                lblVarco.Enabled = true;

                lblDarco.Enabled = false;
            }
            if (lblBarco.Text == "Barco")
            {
                lblBarco.Enabled = true;

                lblDarco.Enabled = false;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PalabraRandomPrimerEjercicio();
            PalabraRandomSegundoEjercicio();
            PalabraRandomTercerEjercicio();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
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
            

            lblMamsana.Enabled = true;
            lblMansana.Enabled = true;
            lblManzana.Enabled = true;
            lblManzana.Visible = true;
            

            
            lblBarco.Visible = true;
            lblBarco.Enabled = true;
            lblDarco.Enabled = true;
            lblVarco.Enabled = true;

            PalabraRandomPrimerEjercicio();
            PalabraRandomSegundoEjercicio();
            PalabraRandomTercerEjercicio();

            correctas = 0;
            incorrectas = 0;

            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        public void PalabraRandomPrimerEjercicio()
        {
            Random random = new Random();
            List<int> numeros = new List<int>();

            while (numeros.Count < 3)
            {
                int numeroAleatorio = random.Next(1, 4);

                if (!numeros.Contains(numeroAleatorio))
                {
                    numeros.Add(numeroAleatorio);
                }
            }

            // Ahora puedes acceder a los tres números aleatorios sin repetición
            int numeroAleatorioQueso1 = numeros[0];
            int numeroAleatorioQueso2 = numeros[1];
            int numeroAleatorioQueso3 = numeros[2];

            Dictionary<int, string> DicQueso = new Dictionary<int, string>();
            DicQueso.Add(1, "Keso");
            DicQueso.Add(2, "Ceso");
            DicQueso.Add(3, "Queso");


            lblKeso.Text = DicQueso[numeroAleatorioQueso1].ToString();
            lblQueso.Text = DicQueso[numeroAleatorioQueso2].ToString();
            lblCeso.Text = DicQueso[numeroAleatorioQueso3].ToString();

        }

        public void PalabraRandomSegundoEjercicio()
        {
            Random random = new Random();
            List<int> numeros = new List<int>();

            while (numeros.Count < 3)
            {
                int numeroAleatorio = random.Next(1, 4);

                if (!numeros.Contains(numeroAleatorio))
                {
                    numeros.Add(numeroAleatorio);
                }
            }

            // Ahora puedes acceder a los tres números aleatorios sin repetición
            int numeroAleatorioManzana1 = numeros[0];
            int numeroAleatorioManzana2 = numeros[1];
            int numeroAleatorioManzana3 =numeros[2];

            Dictionary<int, string> DicManzana = new Dictionary<int, string>();
            DicManzana.Add(1, "Manzana");
            DicManzana.Add(2, "Mansana");
            DicManzana.Add(3, "Mamsana");


            lblManzana.Text = DicManzana[numeroAleatorioManzana1].ToString();
            lblMansana.Text = DicManzana[numeroAleatorioManzana2].ToString();
            lblMamsana.Text = DicManzana[numeroAleatorioManzana3].ToString();
        }

        public void PalabraRandomTercerEjercicio()
        {
            Random random = new Random();
            List<int> numeros = new List<int>();

            while (numeros.Count < 3)
            {
                int numeroAleatorio = random.Next(1, 4);

                if (!numeros.Contains(numeroAleatorio))
                {
                    numeros.Add(numeroAleatorio);
                }
            }

            // Ahora puedes acceder a los tres números aleatorios sin repetición
            int numeroAleatorioBarco1=numeros[0];
            int numeroAleatorioBarco2 = numeros[1];
            int numeroAleatorioBarco3 = numeros[2];

            Dictionary<int, string> DicBarco = new Dictionary<int, string>();
            DicBarco.Add(1, "Varco");
            DicBarco.Add(2, "Barco");
            DicBarco.Add(3, "Darco");


            lblVarco.Text = DicBarco[numeroAleatorioBarco1].ToString();
            lblBarco.Text = DicBarco[numeroAleatorioBarco2].ToString();
            lblDarco.Text = DicBarco[numeroAleatorioBarco3].ToString();
        }
    }
}
