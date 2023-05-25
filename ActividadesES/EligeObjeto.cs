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
    public partial class EligeObjeto : Form
    {

        int puntaje;
        //Variable para indicar cuantas veces golpeara al topo 
        int numClics = 1;
        private readonly Random random = new Random();
        //Variable para visualizar el numero de veces que golpeo al topo
        //Variable para guardar el numClics
        int numeroAleatorio;


        public class ImagenDescripcion
        {
            public string Descripcion { get; set; }
            public string Imagen { get; set; }
        }

        List<ImagenDescripcion> imagenes = new List<ImagenDescripcion>{
        new ImagenDescripcion { Descripcion = "Niño jugando con un balón", Imagen = "futbolAmericano" },
        new ImagenDescripcion { Descripcion = "Persona montando Bici", Imagen = "ciclismo" },
        new ImagenDescripcion { Descripcion = "Una persona trotando", Imagen = "trotar" },
        new ImagenDescripcion { Descripcion = "Una persona escuchando música", Imagen = "escuchando" },
        new ImagenDescripcion { Descripcion = "Una niña patinando", Imagen = "patinandoNina" },
        new ImagenDescripcion { Descripcion = "Una persona levantando mancuernas", Imagen = "pesa"},
        new ImagenDescripcion { Descripcion = "Una persona saltando cuerda", Imagen = "saltandoCuerda"},
        new ImagenDescripcion { Descripcion = "Persona entrenando en una maquina", Imagen = "maquinaEntrenamiento"},
    };

        public EligeObjeto()
        {
            InitializeComponent();

            // Mostrar a miguelito aleatoriamente y su descripción
            MostrarImagenAleatoria();
        }

        private void MostrarImagenAleatoria()
        {
            Random rnd = new Random();
            int imagenAleatoria = rnd.Next(imagenes.Count);


            // Obtener la imagen y descripción correcta
            string imagenCorrecta = imagenes[imagenAleatoria].Imagen;
            string descripcionCorrecta = imagenes[imagenAleatoria].Descripcion;


            // Mostrar la descripción
            lblDescripcion.Text = descripcionCorrecta;



            // Mostrar las imágenes en PictureBox de manera aleatoria
            PictureBox[] imagenesPictureBox = { pbImagen1, pbImagen2, pbImagen3, pbImagen4, pbImagen5, pbImagen6, pbImagen7, pbImagen8 };

            int imagenCorrectaIndex = rnd.Next(imagenesPictureBox.Length);
            List<int> indicesSeleccionados = new List<int>();


            for (int i = 0; i < imagenesPictureBox.Length; i++)
            {
                if (i == imagenCorrectaIndex)
                {
                    // Asignar la imagen correcta al PictureBox
                    imagenesPictureBox[i].Image = Properties.Resources.ResourceManager.GetObject(imagenCorrecta) as Image;
                    imagenesPictureBox[i].Tag = "correcto";
                }
                else
                {


                    // Generar una nueva imagen aleatoria incorrecta que no es igual a la imagen correcta
                    int imagenIncorrectai = rnd.Next(imagenes.Count);
                    while (indicesSeleccionados.Contains(imagenIncorrectai) || imagenIncorrectai == imagenAleatoria)
                    {
                        imagenIncorrectai = rnd.Next(imagenes.Count);
                    }
                    indicesSeleccionados.Add(imagenIncorrectai);

                    // Asignar la imagen incorrecta al PictureBox
                    string nombreImagen = imagenes[imagenIncorrectai].Imagen.ToString();

                    imagenesPictureBox[i].Image = Properties.Resources.ResourceManager.GetObject(nombreImagen) as Image;
                    imagenesPictureBox[i].Tag = "incorrecto";


                }
            }
        }

        private void pbImagen_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            if (pictureBox.Tag.ToString() == "correcto")
            {
                Thread hilo2 = new Thread(new ThreadStart(Correcto));
                hilo2.Start();

                // Si la imagen es la correcta, mostrar un mensaje
                MessageBox.Show("¡Correcto!");
                MostrarImagenAleatoria();
           
                puntaje++;

                //Muestra la puntuacion del usuario.
                lbScore.Text = "Puntuación: " + puntaje;
                // Ocultar al topo

                //Muestra las veces que el niño debe atrapar o golpear al topo.
                lbClick.Text = "Haz " + numClics + " actividades";

                foreach (PictureBox item in tableLayoutPanel1.Controls)
                {
                    item.BackColor = Color.White;
                }

           

                //Si el usuario ha alcanzado el número de clics dados.
                if (puntaje >= numeroAleatorio)
                {

                    // Mostrar un mensaje de felicitación 
                    //Este se cambia por los globos de congratulation

                    pbAyuda.Visible = false;
                    lblAyuda.Visible = false;
                    pbFelicitaciones.Visible = true;
                    Thread hilo1 = new Thread(new ThreadStart(Perfecto));
                    hilo1.Start();
                    MessageBox.Show("¡Felicidades, has completado la actividad!");

                    InsertarActividad();
                }


            }
            else
            {
                // Si la imagen es incorrecta, cambiar su color a gris como el de Hector
                pictureBox.BackColor = Color.Gray;
                MessageBox.Show("¡Intenta con otra imagen!");
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
                SqlCommand cmd = new SqlCommand("sp_ActualizarActividad3ES", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Asignar los valores de los parámetros del stored procedure
                cmd.Parameters.AddWithValue("@idRegistro", Variables.idHistorial); // idRegistro es el valor que identifica el registro que quieres actualizar
                cmd.Parameters.AddWithValue("@valor", true); // o false, dependiendo de lo que quieras actualizar

                // Ejecutar el stored procedure y obtener el número de filas afectadas
                int rowsAffected = cmd.ExecuteNonQuery();



                // Si se actualizaron filas, mostrar un mensaje de éxito
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Se actualizó la actividad 3ES del registro con éxito.");
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
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("¡Felicidades, has completado la actividad!");
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }


        public void Correcto()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("¡Correcto!");
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void EligeObjeto_Load(object sender, EventArgs e)
        {
            // Generar un número de clics aleatorio 
            numClics = random.Next(1, 6);
            //Se guarda en la variable el numero aleatorio
            numeroAleatorio = numClics;
            //Se genera el diseño de la fuente

            //Muestra la puntuacion del usuario.
            lbScore.Text = "Puntuación: " + puntaje;
            // Ocultar al topo

            //Muestra las veces que el niño debe atrapar o golpear al topo.
            lbClick.Text = "Haz " + numClics + " actividades";
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }
    }
}
