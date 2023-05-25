using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoISW
{
    public partial class LogeoNiño : Form
    {
        public LogeoNiño()
        {
            InitializeComponent();

           
        }

        public static class VariablesGlobales
        {
            public static string Variable1 = "Valor1";
            public static int Variable2 = 123;
            public static bool Variable3 = true;
            public static double Variable4 = 3.1416;
            public static DateTime Variable5 = DateTime.Now;
        }


        private void LogeoNiño_Load(object sender, EventArgs e)
        {
            // Establecer la conexión a la base de datos

            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            
            // Crear un comando SQL para recuperar los nombres de los alumnos de la tabla ListaAlumnos
            SqlCommand cmd = new SqlCommand(@"SELECT CONCAT(nombre, ' ', primerApellido, ' ', segundoApellido) FROM ListaAlumnos", connection);

            // Ejecutar el comando y obtener un lector de datos
            SqlDataReader reader = cmd.ExecuteReader();

            // Recorrer los resultados y agregar cada nombre de alumno al ComboBox
            while (reader.Read())
            {
                string nombreAlumno = reader.GetString(0);
                cbListaAlumnos.Items.Add(nombreAlumno);
            }

            // Cerrar el lector de datos y la conexión a la base de datos
            reader.Close();
            connection.Close();
        }

        private void cbListaAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }


        private void btnCrearSesion_Click(object sender, EventArgs e)
        {
            


            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
           
            try
            {
                if (cbListaAlumnos.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona a un alumno");
                    return;

                }
                 

                Variables.nombreAlumno = cbListaAlumnos.SelectedItem.ToString();

                


                connection.Open();



                SqlCommand cmd = new SqlCommand("SELECT idAlumno FROM ListaAlumnos WHERE CONCAT(nombre, ' ', primerApellido, ' ', segundoApellido) = @nombre", connection);
                cmd.Parameters.AddWithValue("@nombre", Variables.nombreAlumno);

                int idAlumno = (int)cmd.ExecuteScalar(); // obtener el idAlumno correspondiente

                
                // Guardar el idAlumno obtenido en una variable
                // Por ejemplo, si tienes una variable llamada idAlumnoSesion en tu formulario, puedes hacer lo siguiente:
                Variables.idAlumno = idAlumno;


                // Obtener la fecha actual
                DateTime fechaActual = DateTime.Now;

                // Insertar un nuevo registro en Historial con los valores de la sesión
                string query = "INSERT INTO Historial (idAlumno, matriculaProfesor, fecha) VALUES (@idAlumno, @matriculaProfesor, @fecha); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd2 = new SqlCommand(query, connection);
                cmd2.Parameters.AddWithValue("@idAlumno", Variables.idAlumno); // idAlumno es el valor que obtuviste en el ListBox
                cmd2.Parameters.AddWithValue("@matriculaProfesor", Variables.matriculaUsuario); // matriculaProfesor es el valor que obtuviste en el formulario
                cmd2.Parameters.AddWithValue("@fecha", fechaActual);

                int idRegistro = Convert.ToInt32(cmd2.ExecuteScalar());

                Variables.idHistorial = idRegistro;

                VistaPrincipal form1 = new VistaPrincipal();

                form1.Show();
                this.Hide();


               
            }



            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar el alumno a la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                connection.Close();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {





            this.Hide();
            AccesoPrograma accesoPrograma = new AccesoPrograma();
            accesoPrograma.ShowDialog();
        }

        private void LogeoNiño_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
