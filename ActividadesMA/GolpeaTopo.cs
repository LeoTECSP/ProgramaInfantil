using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Speech.Synthesis;
using System.Threading;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoISW.Forms
{
    public partial class GolpeaTopo : Form
    {
        private readonly Random random = new Random();
        //Variable para visualizar el numero de veces que golpeo al topo
        private int puntaje;
        //Variable para indicar cuantas veces golpeara al topo 
        int numClics =1;
        //Variable para guardar el numClics
        int numeroAleatorio;

        public GolpeaTopo()
        {
            InitializeComponent();
            // Ocultar al topo
            pbTopo1.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            //Matriz de agujeros.
            PictureBox[] agujeros = { pbAgujero1, pbAgujero2, pbAgujero3, pbAgujero4, pbAgujero5,
            pbAgujero6, pbAgujero7, pbAgujero8, pbAgujero9, pbAgujero10, pbAgujero11,
            pbAgujero12, pbAgujero13, pbAgujero14, pbAgujero15, pbAgujero16 };
            //Mover al topo a un agujero aleatorio
            PictureBox agujeroAleatorio = agujeros[random.Next(agujeros.Length)];
            //Locacion del topo en los agujeros.
            pbTopo1.Location = new Point(agujeroAleatorio.Location.X + 15, agujeroAleatorio.Location.Y - 20);
            //Mostrar al topo
            pbTopo1.Visible = true;
        }
        private void pbTopo1_Click(object sender, EventArgs e)
        {
            //Posicionar todos los picturebox de agujeros por detras del topo
            PictureBox pic = (PictureBox)sender;
            pic.Image = Properties.Resources.topo;
            pic.BringToFront();
            //Incrementa la puntuación del usuario
            puntaje++;
            //Muestra la puntuacion del usuario.
            lbScore.Text = "Puntuación: " + puntaje;
            // Ocultar al topo
            pbTopo1.Visible = false;
            //Muestra las veces que el niño debe atrapar o golpear al topo.
            lbClick.Text = "Golpea : " + numClics + " veces al topo";


            //Reproduce sonido al golpear al topo
            SoundPlayer reproductor = new SoundPlayer(Properties.Resources.Golpeo);
            reproductor.Play();


            //Si el usuario ha alcanzado el número de clics dados.
            if (puntaje >= numeroAleatorio)
            {
                //Detener el timer
                timer1.Stop();
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
                SqlCommand cmd = new SqlCommand("sp_ActualizarActividad4MA", connection);
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

      
        public void Perfecto()
        {
            //Agregamos lo que queremos que diga Cortana.
            string speech = string.Format("¡Felicidades, has completado la actividad!");
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            //Hacemos que hable Cortana.
            speechSynthesizer.Speak(speech);
        }

        private void martillo()
        {
            //Obtener la imagen del martillo para el cursor.
            Bitmap martillo = new Bitmap(Properties.Resources.martillo, new Size(90, 90));
            //Tipo de dato para el cursor.
            IntPtr iconito = martillo.GetHicon();
            //crear el cursor personalizado.
            Icon icono = Icon.FromHandle(iconito);
            //crear un objeto cursor con las especificaciones dadas.
            Cursor cursor = new Cursor(iconito);
            //mostrra solamente el cursor martillo en el panel del juego
            panel1.Cursor = new Cursor(iconito);
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            //mandar a llamar el metodo martillo para que solo se active cuando comienza el juego.
            martillo();
            // Generar un número de clics aleatorio 
            numClics = random.Next(1, 6);
            //Se guarda en la variable el numero aleatorio
            numeroAleatorio = numClics;
            //Se genera el diseño de la fuente
            

            //Muestra al usuario las veces que debe golpear al topo.
            lbClick.Text = "Golpea: " + Convert.ToString(numClics) + " veces al topo";
            using (Font font = new Font("Arial", 22.2f))
            {
                lbClick.Font = font;
            }
            //Inicializar el puntaje en cero
            puntaje = 0;
            //mostrar mensaje de puntuacion antes de que incremente.


            lbScore.Text = "Puntuación: 0";
            using (Font font = new Font("Arial", 22.2f))
            {
                lbScore.Font = font;
            }
            timer1.Start();
            
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            // Detener el timer
            timer1.Stop();
            // Reiniciar el puntaje y el número de clics
            puntaje = 0;
            numClics = 0;
            //mostrar mensajes xd
            lbScore.Text = "Puntuación: 0";
            lbClick.Text = "Atrapa : " + Convert.ToString(numClics) + " veces al topo";
            // Ocultar al topo
            pbTopo1.Visible = false;
        }

        private void pbFelicitaciones_Click(object sender, EventArgs e)
        {

        }

        private void GolpeaTopo_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }
    }
}