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
    public partial class ReconoceInicial : Form
    {
        int correctas = 0;
        int Respuestas = 0;
        //string[] bancoImagenes = { "gbB", "gbI", "gbE", "gbN", "gbH", "gbE2", "gbC", "gbH2", "gbO" };
        

        public ReconoceInicial()
        {
            InitializeComponent();
            OcultarLabel();
            //List<string> Gbox = new List<string>();
            //foreach (string imagen in bancoImagenes)
            //{
            //    Gbox.Add(imagen);
            //}
            //Random random = new Random();

            //foreach (GroupBox groupBox in tableImagenes.Controls)
            //{
            //    int index = random.Next(Gbox.Count);
            //    string image = Gbox[index];
            //    groupBox.Tag = image;
            //    tableImagenes.Controls.Add(groupBox);
            //    Gbox.RemoveAt(index);
            //}

            List<GroupBox> groupBoxes = new List<GroupBox> { gbB, gbI, gbE, gbN, gbH, gbE2, gbC, gbH2, gbO, gbP };
            List<int> cellIndices = new List<int>();
            for (int i = 0; i < tableImagenes.RowCount * tableImagenes.ColumnCount; i++)
            {
                    cellIndices.Add(i);
                
            }
            Random random = new Random();
            cellIndices = cellIndices.OrderBy(x => random.Next()).ToList();
            int groupBoxIndex = 0;
            foreach (GroupBox groupBox in groupBoxes)
            {
                int cellIndex = cellIndices[groupBoxIndex];
               
                int row = cellIndex / tableImagenes.ColumnCount;
                int column = cellIndex % tableImagenes.ColumnCount;
                tableImagenes.Controls.Add(groupBox, column, row);
                groupBoxIndex++;
            }

        }
        private void OcultarLabel()
        {
            lblB.Visible = false;
            lblI.Visible = false;
            lblE.Visible = false;
            lblN.Visible = false;
            lblH.Visible = false;
            lblE2.Visible = false;
            lblC.Visible = false;
            lblH2.Visible = false;
            lblO.Visible = false;
            lblP.Visible = false;
        }
        private void RespuestaIncorrecta()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("Lo siento, esta letra es incorrecta");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void RespuestaCorrecta()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("Felicidades, esta letra esta correcta");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);

        }

        private void Reiniciar()
        {

            pbIncorrecto1.Visible = false;
            pbIncorrecto2.Visible = false;
            pbIncorrecto3.Visible = false;
            pbIncorrecto4.Visible = false;
            pbIncorrecto5.Visible = false;
            pbIncorrecto6.Visible = false;
            pbIncorrecto7.Visible = false;
            pbIncorrecto8.Visible = false;
            pbIncorrecto9.Visible = false;
            pbIncorrecto10.Visible = false;

            pbCorrecto1.Visible = false;
            pbCorrecto2.Visible = false;
            pbCorrecto3.Visible = false;
            pbCorrecto4.Visible = false;
            pbCorrecto5.Visible = false;
            pbCorrecto6.Visible = false;
            pbCorrecto7.Visible = false;
            pbCorrecto8.Visible = false;
            pbCorrecto9.Visible = false;
            pbCorrecto10.Visible = false;

            txtB.TextChanged -= txtB_TextChanged_1;
            txtI.TextChanged -= txtI_TextChanged_1;
            txtE.TextChanged -= txtE_TextChanged_1;
            txtN.TextChanged -= txtN_TextChanged_1;
            txtH.TextChanged -= txtH_TextChanged_1;
            txtE2.TextChanged -= txtE2_TextChanged_1;
            txtC.TextChanged -= txtC_TextChanged_1;
            txtH2.TextChanged -= txtH2_TextChanged_1;
            txtO.TextChanged -= txtO_TextChanged_1;
            txtP.TextChanged -= txtP_TextChanged;


            txtB.Clear();
            txtB.Enabled = true;
            txtI.Clear();
            txtI.Enabled = true;
            txtE.Clear();
            txtE.Enabled = true;
            txtN.Clear();
            txtN.Enabled = true;

            txtH.Clear();
            txtH.Enabled = true;
            txtE2.Clear();
            txtE2.Enabled = true;
            txtC.Clear();
            txtC.Enabled = true;
            txtH2.Clear();
            txtH2.Enabled = true;
            txtO.Clear();
            txtO.Enabled = true;

            txtP.Clear();
            txtP.Enabled = true;




            txtB.TextChanged += txtB_TextChanged_1;
            txtI.TextChanged += txtI_TextChanged_1;
            txtE.TextChanged += txtE_TextChanged_1;
            txtN.TextChanged += txtN_TextChanged_1;
            txtH.TextChanged += txtH_TextChanged_1;
            txtE2.TextChanged += txtE2_TextChanged_1;
            txtC.TextChanged += txtC_TextChanged_1;
            txtH2.TextChanged += txtH2_TextChanged_1;
            txtO.TextChanged += txtO_TextChanged_1;
            txtP.TextChanged += txtP_TextChanged;


            OcultarLabel();

            correctas = 0;
            Respuestas = 0;
        }





        private void btnRevisar_Click(object sender, EventArgs e)
        {
            if (correctas == 10 && Respuestas == 10)
            {
                Thread hilo1 = new Thread(new ThreadStart(Perfecto));
                hilo1.Start();
                pbFelicitaciones.Visible = true;
                string speech = string.Format("¡Felicidades!, todas tus respuestas fueron elegidas correctamente");
                MessageBox.Show(speech, "¡Felicidades!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InsertarActividad();

                return;
            }
            if (Respuestas == 10)
            {
                Thread hilo1 = new Thread(new ThreadStart(ConErrores));
                hilo1.Start();
                string speech = string.Format("Felicidades!, terminaste el ejercicio, sigue practicando");
                InsertarError();

                //Muestra una ventana de mensaje.
                MessageBox.Show(speech, "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reiniciar();
                return;
            }
            else
            {
                string speech = string.Format("¡Faltan ejercicios que contestar!");
                //Instanciamos la clase speechSynthesizer.
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                //Hacemos que hable Cortana.
                speechSynthesizer.Speak(speech);
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
                SqlCommand cmd = new SqlCommand("sp_ActualizarActividad4ES", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Asignar los valores de los parámetros del stored procedure
                cmd.Parameters.AddWithValue("@idRegistro", Variables.idHistorial); // idRegistro es el valor que identifica el registro que quieres actualizar
                cmd.Parameters.AddWithValue("@valor", true); // o false, dependiendo de lo que quieras actualizar

                // Ejecutar el stored procedure y obtener el número de filas afectadas
                int rowsAffected = cmd.ExecuteNonQuery();



                // Si se actualizaron filas, mostrar un mensaje de éxito
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Se actualizó la actividad 4ES del registro con éxito.");
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

        private void soloLetras()
        {
            string speech = string.Format("¡Lo siento!, Solo se permiten letras");
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(speech);
        }
        private void pictureBox1_MouseHover_1(object sender, EventArgs e)
        {
            string speech = string.Format("¡Ballena");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void pictureBox2_MouseHover_1(object sender, EventArgs e)
        {
            string speech = string.Format("¡Iguana");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void pictureBox3_MouseHover_1(object sender, EventArgs e)
        {
            string speech = string.Format("¡Elefante");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void pictureBox4_MouseHover_1(object sender, EventArgs e)
        {
            string speech = string.Format("¡Nutria");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void pictureBox5_MouseHover_1 (object sender, EventArgs e)
        {
            string speech = string.Format("¡Hipopótamo");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void pictureBox6_MouseHover_1(object sender, EventArgs e)
        {
            string speech = string.Format("¡Escorpión");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void pictureBox7_MouseHover_1(object sender, EventArgs e)
        {
            string speech = string.Format("¡Caballo");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void pictureBox9_MouseHover_1(object sender, EventArgs e)
        {
            string speech = string.Format("¡Hormiga");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void pictureBox8_MouseHover_1(object sender, EventArgs e)
        {
            string speech = string.Format("¡OSO");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            string speech = string.Format("¡PERRO");
            //Instanciamos la clase speechSynthesizer.
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }
        private void txtB_TextChanged_1(object sender, EventArgs e)
        {
            if (txtB.Text == "b" || txtB.Text == "B")
            {
                RespuestaCorrecta();
                pbCorrecto1.Visible = true;
                correctas++;
                Respuestas++;
                txtB.Enabled = false;
                lblB.Visible = true;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto1.Visible = true;
                Respuestas++;
                txtB.Enabled = false;
            }
        }

        private void txtB_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                soloLetras();
                e.Handled = true;
                return;
            }
        }

        private void txtI_TextChanged_1(object sender, EventArgs e)
        {
            if (txtI.Text == "i" || txtI.Text == "I")
            {
                RespuestaCorrecta();
                pbCorrecto2.Visible = true;
                correctas++;
                Respuestas++;
                txtI.Enabled = false;
                lblI.Visible = true;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto2.Visible = true;
                Respuestas++;
                txtI.Enabled = false;
            }
        }

        private void txtI_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                soloLetras();
                e.Handled = true;
                return;
            }
        }

        private void txtE_TextChanged_1(object sender, EventArgs e)
        {
            if (txtE.Text == "e" || txtE.Text == "E")
            {
                RespuestaCorrecta();
                pbCorrecto3.Visible = true;
                correctas++;
                Respuestas++;
                txtE.Enabled = false;
                lblE.Visible = true;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto3.Visible = true;
                Respuestas++;
                txtE.Enabled = false;
            }
        }

        private void txtE_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                soloLetras();
                e.Handled = true;
                return;
            }
        }

        private void txtN_TextChanged_1(object sender, EventArgs e)
        {
            if (txtN.Text == "n" || txtN.Text == "N")
            {
                RespuestaCorrecta();
                pbCorrecto4.Visible = true;
                correctas++;
                Respuestas++;
                txtN.Enabled = false;
                lblN.Visible = true;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto4.Visible = true;
                Respuestas++;
                txtN.Enabled = false;
            }
        }

        private void txtN_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                soloLetras();
                e.Handled = true;
                return;
            }
        }

        private void txtH_TextChanged_1(object sender, EventArgs e)
        {
            if (txtH.Text == "h" || txtH.Text == "H")
            {
                RespuestaCorrecta();
                pbCorrecto5.Visible = true;
                correctas++;
                Respuestas++;
                txtH.Enabled = false;
                lblH.Visible = true;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto5.Visible = true;
                Respuestas++;
                txtH.Enabled = false;
            }
        }

        private void txtH_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                soloLetras();
                e.Handled = true;
                return;
            }
        }

        private void txtE2_TextChanged_1(object sender, EventArgs e)
        {
            if (txtE2.Text == "e" || txtE2.Text == "E")
            {
                RespuestaCorrecta();
                pbCorrecto6.Visible = true;
                correctas++;
                Respuestas++;
                txtE2.Enabled = false;
                lblE2.Visible = true;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto6.Visible = true;
                Respuestas++;
                txtE2.Enabled = false;
            }
        }

        private void txtE2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                soloLetras();
                e.Handled = true;
                return;
            }
        }

        private void txtC_TextChanged_1(object sender, EventArgs e)
        {
            if (txtC.Text == "c" || txtC.Text == "C")
            {
                RespuestaCorrecta();
                pbCorrecto7.Visible = true;
                correctas++;
                Respuestas++;
                txtC.Enabled = false;
                lblC.Visible = true;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto7.Visible = true;
                Respuestas++;
                txtC.Enabled = false;
            }
        }

        private void txtC_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                soloLetras();
                e.Handled = true;
                return;
            }
        }

        private void txtH2_TextChanged_1(object sender, EventArgs e)
        {
            if (txtH2.Text == "h" || txtH2.Text == "H")
            {
                RespuestaCorrecta();
                pbCorrecto8.Visible = true;
                correctas++;
                Respuestas++;
                txtH2.Enabled = false;
                lblH2.Visible = true;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto8.Visible = true;
                Respuestas++;
                txtH2.Enabled = false;
            }
        }

        private void txtH2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                soloLetras();
                e.Handled = true;
                return;
            }
        }

        private void txtO_TextChanged_1(object sender, EventArgs e)
        {
            if (txtO.Text == "o" || txtO.Text == "O")
            {
                RespuestaCorrecta();
                pbCorrecto9.Visible = true;
                correctas++;
                Respuestas++;
                txtO.Enabled = false;
                lblO.Visible = true;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto9.Visible = true;
                Respuestas++;
                txtO.Enabled = false;
            }
        }

        private void txtO_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                soloLetras();
                e.Handled = true;
                return;
            }
        }
        private void txtP_TextChanged(object sender, EventArgs e)
        {
            if (txtP.Text == "p" || txtP.Text == "P")
            {
                RespuestaCorrecta();
                pbCorrecto10.Visible = true;
                correctas++;
                Respuestas++;
                txtP.Enabled = false;
                lblP.Visible = true;
            }
            else
            {
                RespuestaIncorrecta();
                pbIncorrecto10.Visible = true;
                Respuestas++;
                txtP.Enabled = false;
            }
        }

        private void txtP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                soloLetras();
                e.Handled = true;
                return;
            }
        }

        private void gbH2_Enter(object sender, EventArgs e)
        {

        }

        private void ReconoceInicial_Load(object sender, EventArgs e)
        {

            CheckForIllegalCrossThreadCalls = true;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }
    }
}
