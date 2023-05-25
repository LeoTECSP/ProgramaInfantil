using System;
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
    public partial class SopaLetras : Form
    {

   

        public SopaLetras()
        {
            InitializeComponent();
            
        }

        public void Perfecto()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("¡La palabra está correcta, felicidades!");
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        public void ConErrores()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("Lo siento, la palabra no está bien escrita, intentalo de nuevo");
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }


        private void AlPresionarBoton(object sender, EventArgs e)
        {


            if (lbCajaUno.Text == "P" && lbCajaDos.Text == "E" && lbCajaTres.Text == "R" && lbCajaCuatro.Text == "A")
            {
                Thread hilo1 = new Thread(new ThreadStart(Perfecto));
                hilo1.Start();
                pictureBox2.Visible = true;
                MessageBox.Show("¡La palabra está correcta, felicidades!");
                ResetearForm();
                InsertarActividad();
            
                
       
            }
            else if (lbCajaUno.Text != "" && lbCajaDos.Text != "" && lbCajaTres.Text != "" && lbCajaCuatro.Text != "")
            {
                Thread hilo1 = new Thread(new ThreadStart(ConErrores));
                hilo1.Start();
                MessageBox.Show("Lo siento, la palabra no está bien escrita, intentalo de nuevo");

                ResetearForm();
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
                SqlCommand cmd = new SqlCommand("sp_ActualizarActividad2ES", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Asignar los valores de los parámetros del stored procedure
                cmd.Parameters.AddWithValue("@idRegistro", Variables.idHistorial); // idRegistro es el valor que identifica el registro que quieres actualizar
                cmd.Parameters.AddWithValue("@valor", true); // o false, dependiendo de lo que quieras actualizar

                // Ejecutar el stored procedure y obtener el número de filas afectadas
                int rowsAffected = cmd.ExecuteNonQuery();



                // Si se actualizaron filas, mostrar un mensaje de éxito
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Se actualizó la actividad 2ES del registro con éxito.");
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

        private void SopaLetras_Load(object sender, EventArgs e)
        {

            Inicio();
        }
        int index = 0;

        private void Inicio()
        {
            lb1.Click += new EventHandler(AlPresionarBoton);
            lb2.Click += new EventHandler(AlPresionarBoton);
            lb3.Click += new EventHandler(AlPresionarBoton);
            lb4.Click += new EventHandler(AlPresionarBoton);
            //Une todos los subprocesos al principal.
            CheckForIllegalCrossThreadCalls = true;




            string letras = "PERA";
            Random rnd = new Random();
            List<char> seleccion = new List<char>();

            // Generar cuatro letras aleatorias sin repetirse
            while (seleccion.Count < 4)
            {
                int indice = rnd.Next(letras.Length);
                char letra = letras[indice];
                if (!seleccion.Contains(letra))
                {
                    seleccion.Add(letra);

                    // Checar si no se hizo por accidente la palabra
                    if (seleccion.Count == 4 && seleccion.SequenceEqual("PERA"))
                    {
                        seleccion.Clear();
                    }
                }
            }

            // Colocar las letras dentro de cada label

            lb1.Text = seleccion[0].ToString();
            lb2.Text = seleccion[1].ToString();
            lb3.Text = seleccion[2].ToString();
            lb4.Text = seleccion[3].ToString();


        }

        private void ResetearForm()
        {

            lb1.Text = "";
            lb2.Text = "";
            lb3.Text = "";
            lb4.Text = "";

            lbCajaUno.Text = "";
            lbCajaDos.Text = "";
            lbCajaTres.Text = "";
            lbCajaCuatro.Text = "";

            lb1.Enabled = true;
            lb2.Enabled = true;
            lb3.Enabled = true;
            lb4.Enabled = true;

            index = 0;

            Inicio();
        }

      
        private void lb1_Click(object sender, EventArgs e)
        {

            // Obtener el label presionado
            Label label = (Label)sender;

            // Obtener el texto del label
            string texto = label.Text;



            switch (index)
            {
                case 0:
                    lbCajaUno.Text = texto;
                    break;
                case 1:
                    lbCajaDos.Text = texto;
                    break;
                case 2:
                    lbCajaTres.Text = texto;
                    break;
                case 3:
                    lbCajaCuatro.Text = texto;
                    break;
            }

            // Incrementar el índice
            index = (index + 1) % 4; // Esto asegura que el índice esté en el rango 0-3
            lb1.Enabled = false;

        }

        private void lb2_Click(object sender, EventArgs e)
        {

            // Obtener el label presionado
            Label label = (Label)sender;

            // Obtener el texto del label
            string texto = label.Text;



            switch (index)
            {
                case 0:
                    lbCajaUno.Text = texto;
                    break;
                case 1:
                    lbCajaDos.Text = texto;
                    break;
                case 2:
                    lbCajaTres.Text = texto;
                    break;
                case 3:
                    lbCajaCuatro.Text = texto;
                    break;
            }

            // Incrementar el índice
            index = (index + 1) % 4; // Esto asegura que el índice esté en el rango 0-3
            lb2.Enabled = false;


        }

        private void lb3_Click(object sender, EventArgs e)
        {

            // Obtener el label presionado
            Label label = (Label)sender;

            // Obtener el texto del label
            string texto = label.Text;



            switch (index)
            {
                case 0:
                    lbCajaUno.Text = texto;
                    break;
                case 1:
                    lbCajaDos.Text = texto;
                    break;
                case 2:
                    lbCajaTres.Text = texto;
                    break;
                case 3:
                    lbCajaCuatro.Text = texto;
                    break;
            }

            // Incrementar el índice
            index = (index + 1) % 4; // Esto asegura que el índice esté en el rango 0-3
            lb3.Enabled = false;
        }

        private void lb4_Click(object sender, EventArgs e)
        {

            // Obtener el label presionado
            Label label = (Label)sender;

            // Obtener el texto del label
            string texto = label.Text;



            switch (index)
            {
                case 0:
                    lbCajaUno.Text = texto;
                    break;
                case 1:
                    lbCajaDos.Text = texto;
                    break;
                case 2:
                    lbCajaTres.Text = texto;
                    break;
                case 3:
                    lbCajaCuatro.Text = texto;
                    break;
            }

            // Incrementar el índice
            index = (index + 1) % 4; // Esto asegura que el índice esté en el rango 0-3

            lb4.Enabled = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }
    }
}
