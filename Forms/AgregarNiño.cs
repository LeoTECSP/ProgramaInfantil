using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoISW
{
    public partial class AgregarNiño : Form
    {
        public AgregarNiño()
        {
            InitializeComponent();
        }

        private void btnAgregarAlumno_Click(object sender, EventArgs e)
        {

            string nombre = txtNombreAlumno.Text.Trim();
            string primerApellido = txtApellidoPAlumno.Text.Trim();
            string segundoApellido = txtApellidoMAlumno.Text.Trim();

            int cantidadNombres = nombre.Split(' ').Length;

            if (string.IsNullOrEmpty(nombre) || cantidadNombres > 2 || !nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c)) || nombre.Length >30)
            {
                // El campo nombre está nulo, vacío, contiene más de dos nombres o tiene caracteres no válidos
                MessageBox.Show("Por favor ingresa uno o dos nombres válidos.");
                return;
            }


            if (string.IsNullOrWhiteSpace(primerApellido) || !primerApellido.All(char.IsLetter) || primerApellido.Length > 30)
            {
                MessageBox.Show("El apellido paterno solo soporta letras, máximo 30 caractéres");
                return;


            }


            if (string.IsNullOrWhiteSpace(primerApellido) || !primerApellido.All(char.IsLetter) || primerApellido.Length > 30)
            {
                MessageBox.Show("El apellido materno solo soporta letras, máximo 30 caractéres");
                return;
            }


            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                // Abrir la conexión a la base de datos
                connection.Open();


                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "sp_InsertarAlumno";
                // Pasar los valores capturados desde el formulario como parámetros
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@primerApellido", primerApellido);
                command.Parameters.AddWithValue("@segundoApellido", segundoApellido);

                command.CommandType = CommandType.StoredProcedure;

                // Ejecutar el comando INSERT
                int rowsAffected = command.ExecuteNonQuery();

                // Mostrar un mensaje de éxito si se agregó el alumno correctamente
                if (rowsAffected > 0)
                {
                    MessageBox.Show("El alumno se agregó correctamente a la base de datos.");

                    btnVerAlumnos.PerformClick();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el alumno a la base de datos.");
                }
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

        private void btnVerAlumnos_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string query = "SELECT * FROM VListaAlumno ORDER BY ID ASC";

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dtgVerAlumnos.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al ver el alumno a la base de datos: " + ex.Message);
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

        private void txtNombreAlumno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento de tecla presionada
            }
        }

        private void txtApellidoPAlumno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento de tecla presionada
            }
        }

        private void txtApellidoMAlumno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento de tecla presionada
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Obtener los valores del formulario
            string alumnoId = txtIDAlumno.Text.Trim(); // Reemplaza ObtenerIdAlumno() con el código que obtiene el ID del alumno a modificar
            string nombre = txtNombreAlumno.Text.Trim();
            string primerApellido = txtApellidoPAlumno.Text.Trim();
            string segundoApellido = txtApellidoMAlumno.Text.Trim();

            int cantidadNombres = nombre.Split(' ').Length;

            if (string.IsNullOrEmpty(nombre) || cantidadNombres > 2 || !nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c)) || nombre.Length > 30)
            {
                // El campo nombre está nulo, vacío, contiene más de dos nombres o tiene caracteres no válidos
                MessageBox.Show("Por favor ingresa uno o dos nombres válidos.");
                return;
            }


            if (string.IsNullOrWhiteSpace(primerApellido) || !primerApellido.All(char.IsLetter) || primerApellido.Length > 30)
            {
                MessageBox.Show("El apellido paterno solo soporta letras, máximo 30 caractéres");
                return;


            }


            if (string.IsNullOrWhiteSpace(primerApellido) || !primerApellido.All(char.IsLetter) || primerApellido.Length > 30)
            {
                MessageBox.Show("El apellido materno solo soporta letras, máximo 30 caractéres");
                return;
            }

            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión a la base de datos
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "sp_ModificarAlumno";
                    command.Parameters.AddWithValue("@alumnoId", alumnoId);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@primerApellido", primerApellido);
                    command.Parameters.AddWithValue("@segundoApellido", segundoApellido);
                    command.CommandType = CommandType.StoredProcedure;

                    // Ejecutar el comando de modificación
                    int rowsAffected = command.ExecuteNonQuery();

                    // Mostrar un mensaje de éxito si se modificó el alumno correctamente
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("El alumno se modificó correctamente en la base de datos.");
                        btnVerAlumnos.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el alumno en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al modificar el alumno en la base de datos: " + ex.Message);
                }
            }
        }
    }
}
