using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoISW.Forms
{
    public partial class Memorama : Form
    {
        //Imagenes disponibles
        string[] bancoImagenes = {"conejo_img", "perro_img","gato_img","vaca_img"};

        //

        public Memorama()
        {
            InitializeComponent();

            //Se agregan las imagenes a una lista (2 veces cada una)

            List<string> cartas = new List<string>();
            foreach (string imagen in bancoImagenes)
            {
                cartas.Add(imagen);
                cartas.Add(imagen);


            }

            Random random = new Random();


            foreach (PictureBox pictureBox in tableLayoutPanel1.Controls)
            {
                int index = random.Next(cartas.Count);
                string image = cartas[index];
                pictureBox.Tag = image;
                cartas.RemoveAt(index);

                pictureBox.Image = Properties.Resources.atras_img; // Imagen de dorso de la carta
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Click += PictureBox_Click; // Evento de clic para voltear la carta
            }

        }

        //Variables que guardarán la selección de el par de cartas
        PictureBox primeraCarta = null;
        PictureBox segundaCarta = null;
        int TotalPares = 0;

        void PictureBox_Click(object sender, EventArgs e)
        {
            //Se recoge que picturebox fue presionado de la tabla

            PictureBox pictureBox = sender as PictureBox;

            //Si es nulo se regresa 
            if (pictureBox == null) return;

            //Checa si la primera carta es nulo, es decir, que no tiene imagen aún puesta
            if (primeraCarta == null)
            {
                //Voltear primera carta
                primeraCarta = pictureBox;
                 //Agarra la imagen usando la direccion de recursos  
                primeraCarta.Image = Properties.Resources.ResourceManager.GetObject(primeraCarta.Tag.ToString()) as Image;
            }

            //Checa si la segunda carta es nula y que además no seala misma que la primera carta (es decir, la misma posicion)
            else if (segundaCarta == null && pictureBox != primeraCarta)
            {
                // Voltear segunda carta
                segundaCarta = pictureBox;
                //Agarra la imagen usando la direccion de recursos 
                segundaCarta.Image = Properties.Resources.ResourceManager.GetObject(segundaCarta.Tag.ToString()) as Image;

                // Comprobar si las cartas son iguales, en caso de serlo se dejan así
                if (primeraCarta.Tag.ToString() == segundaCarta.Tag.ToString())
                {
                    primeraCarta.Enabled = false;
                    segundaCarta.Enabled = false;
                    primeraCarta = null;
                    segundaCarta = null;

                    // Verificar si se han emparejado todas las cartas
                    TotalPares++;

                    //Se divide a la mitad el total de controles que existentes (en este caso son 8)
                    //Por lo que se verifica si las 4 parejas es igual a los 4 espacios
                    if (TotalPares == tableLayoutPanel1.Controls.Count / 2)
                    {
                        pbFelicitaciones.Visible = true;
                        Thread hilo1 = new Thread(new ThreadStart(Perfecto));
                        hilo1.Start();
                        MessageBox.Show("¡Felicidades, has completado el memorama!");
                        InsertarActividad();

                    }

                }

                // En caso de no ser iguales, se voltean
                else
                {
                  

                    temporizador.Interval = 1000; // Intervalo de 1 segundo
                    temporizador.Start(); // Esperar un segundo antes de voltear las cartas

                }
            }
        }

       

        private void temporizador_Tick(object sender, EventArgs e)
        {
            // Voltear las cartas de nuevo porque no fueron iguales
            primeraCarta.Image = Properties.Resources.atras_img;
            segundaCarta.Image = Properties.Resources.atras_img;

       

            primeraCarta = null;
            segundaCarta = null;
         
            temporizador.Stop();
        }


        public void Perfecto()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("¡Felicidades, has completado el memorama!");
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
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
                SqlCommand cmd = new SqlCommand("sp_ActualizarActividad3MA", connection);
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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }
    }
}
