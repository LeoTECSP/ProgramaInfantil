using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoISW.Forms
{
    public partial class Suma : Form
    {
        int correctas = 0;
        int Respuestas = 0;
        public Suma()
        {
            InitializeComponent();
            Aleatorizar();
            
        }

        private void Aleatorizar()
        {
            List<GroupBox> groupBoxes = new List<GroupBox> { gbPelota4, gbVaca4, gbSol5, gbTortuga6, gbAvion8, gbGalleta7 };
            List<int> cellIndices = new List<int>();
            for (int i = 0; i < tablaImagenes.RowCount * tablaImagenes.ColumnCount; i++)
            {
                cellIndices.Add(i);

            }
            Random random = new Random();
            cellIndices = cellIndices.OrderBy(x => random.Next()).ToList();
            int groupBoxIndex = 0;
            foreach (GroupBox groupBox in groupBoxes)
            {
                int cellIndex = cellIndices[groupBoxIndex];

                int row = cellIndex / tablaImagenes.ColumnCount;
                int column = cellIndex % tablaImagenes.ColumnCount;
                tablaImagenes.Controls.Add(groupBox, column, row);
                groupBoxIndex++;
            }

        }
        private void RespuestaIncorrecta()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("Lo siento, esta suma es incorrecta");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }



        private void RespuestaCorrecta()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("Felicidades, esta suma esta correcta");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);

        }
        public void Perfecto()
        {
            string speech = string.Format("¡Felicidades!, todas tus respuestas fueron elegidas correctamente");
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
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
        private void txt1R4_TextChanged(object sender, EventArgs e)
        {
            if (txt1R4.Text == "4")
            {
                RespuestaCorrecta();
                pbCorrecto1.Visible = true;
                correctas++;
                Respuestas++;
                txt1R4.Enabled = false;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto1.Visible = true;
                Respuestas++;
                txt1R4.Enabled = false;
            }
        }

        private void txt2R4_TextChanged(object sender, EventArgs e)
        {
            if (txt2R4.Text == "4")
            {
                RespuestaCorrecta();
                pbCorrecto2.Visible = true;
                correctas++;
                Respuestas++;
                txt2R4.Enabled = false;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto2.Visible = true;
                Respuestas++;
                txt2R4.Enabled = false;
            }
        }

        private void txt3R5_TextChanged(object sender, EventArgs e)
        {
            if (txt3R5.Text == "5")
            {
                RespuestaCorrecta();
                pbCorrecto3.Visible = true;
                correctas++;
                Respuestas++;
                txt3R5.Enabled = false;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto3.Visible = true;
                Respuestas++;
                txt3R5.Enabled = false;
            }
        }

        private void txt4R6_TextChanged(object sender, EventArgs e)
        {
            if (txt4R6.Text == "6")
            {
                RespuestaCorrecta();
                pbCorrecto4.Visible = true;
                correctas++;
                Respuestas++;
                txt4R6.Enabled = false;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto4.Visible = true;
                Respuestas++;
                txt4R6.Enabled = false;
            }
        }

        private void txt5R8_TextChanged(object sender, EventArgs e)
        {
            if (txt5R8.Text == "8")
            {
                RespuestaCorrecta();
                pbCorrecto5.Visible = true;
                correctas++;
                Respuestas++;
                txt5R8.Enabled = false;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto5.Visible = true;
                Respuestas++;
                txt5R8.Enabled = false;
            }
        }

        private void txt6R7_TextChanged(object sender, EventArgs e)
        {
            if (txt6R7.Text == "7")
            {
                RespuestaCorrecta();
                pbCorrecto6.Visible = true;
                correctas++;
                Respuestas++;
                txt6R7.Enabled = false;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto6.Visible = true;
                Respuestas++;
                txt6R7.Enabled = false;
            }
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
            pbCorrecto4.Visible = false;
            pbCorrecto5.Visible = false;
            pbCorrecto6.Visible = false;

            txt1R4.TextChanged -= txt1R4_TextChanged;
            txt2R4.TextChanged -= txt2R4_TextChanged;
            txt3R5.TextChanged -= txt3R5_TextChanged;
            txt4R6.TextChanged -= txt4R6_TextChanged;
            txt5R8.TextChanged -= txt5R8_TextChanged;
            txt6R7.TextChanged -= txt6R7_TextChanged;


            txt1R4.Clear();
            txt1R4.Enabled = true;
            txt2R4.Clear();
            txt2R4.Enabled = true;
            txt3R5.Clear();
            txt3R5.Enabled = true;
            txt4R6.Clear();
            txt4R6.Enabled = true;
            txt5R8.Clear();
            txt5R8.Enabled = true;
            txt6R7.Clear();
            txt6R7.Enabled = true;


            Aleatorizar();

            txt1R4.TextChanged += txt1R4_TextChanged;
            txt2R4.TextChanged += txt2R4_TextChanged;
            txt3R5.TextChanged += txt3R5_TextChanged;
            txt4R6.TextChanged += txt4R6_TextChanged;
            txt5R8.TextChanged += txt5R8_TextChanged;
            txt6R7.TextChanged += txt6R7_TextChanged;


            correctas = 0;
            Respuestas = 0;

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
                SqlCommand cmd = new SqlCommand("sp_ActualizarActividad1MA", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Asignar los valores de los parámetros del stored procedure
                cmd.Parameters.AddWithValue("@idRegistro", Variables.idHistorial); // idRegistro es el valor que identifica el registro que quieres actualizar
                cmd.Parameters.AddWithValue("@valor", true); // o false, dependiendo de lo que quieras actualizar

                // Ejecutar el stored procedure y obtener el número de filas afectadas
                int rowsAffected = cmd.ExecuteNonQuery();



                // Si se actualizaron filas, mostrar un mensaje de éxito
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Se actualizó la actividad 1ES del registro con éxito.");
                }
                else
                {
                    MessageBox.Show("No se encontró ningún registro con el id especificado.");
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
        private void btnRevisar_Click(object sender, EventArgs e)
        {
            

            if (correctas == 6 && Respuestas == 6)
            {
                Thread hilo1 = new Thread(new ThreadStart(Perfecto));
                hilo1.Start();
                pbFelicitaciones.Visible = true;
                string speech = string.Format("¡Felicidades!, todas tus respuestas fueron elegidas correctamente");

                pbIncorrecto1.Visible = false;
                pbIncorrecto2.Visible = false;
                pbIncorrecto3.Visible = false;
                pbIncorrecto4.Visible = false;
                pbIncorrecto5.Visible = false;
                pbIncorrecto6.Visible = false;

                pbCorrecto1.Visible = false;
                pbCorrecto2.Visible = false;
                pbCorrecto3.Visible = false;
                pbCorrecto4.Visible = false;
                pbCorrecto5.Visible = false;
                pbCorrecto6.Visible = false;
                pbFelicitaciones.Visible = true;
                //Muestra una ventana de mensaje.
                MessageBox.Show(speech, "¡Felicidades!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InsertarActividad();
                return;
            }
            if (Respuestas == 6)
            {
                Thread hilo1 = new Thread(new ThreadStart(ConErrores));
                hilo1.Start();
                string speech = string.Format("Felicidades!, terminaste el ejercicio, sigue practicando");
                //Muestra una ventana de mensaje.
                MessageBox.Show(speech, "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reiniciar();
                InsertarError();
                return;
            }
            else
            {
                string speech = string.Format("¡Faltan sumas que contestar!");
                //Instanciamos la clase speechSynthesizer.
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                //Hacemos que hable Cortana.
                speechSynthesizer.Speak(speech);
            }
        }
        private void SoloNumeros()
        {
            string speech = string.Format("¡Lo siento!, Solo se permiten numeros");
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(speech);
        }
        private void txt1R4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <=255))
            {
                SoloNumeros();
                e.Handled= true;
                return;
            }
        }

        private void txt2R4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                SoloNumeros();
                e.Handled = true;
                return;
            }
        }

        private void txt3R5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                SoloNumeros();
                e.Handled = true;
                return;
            }
        }

        private void txt4R6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                SoloNumeros();
                e.Handled = true;
                return;
            }
        }

        private void txt5R8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                SoloNumeros();
                e.Handled = true;
                return;
            }
        }

        private void txt6R7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                SoloNumeros();
                e.Handled = true;
                return;
            }
        }

        private void gbTortuga6_Enter(object sender, EventArgs e)
        {

        }

        private void tablaImagenes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void pbFelicitaciones_Click(object sender, EventArgs e)
        {

        }
    }
}
