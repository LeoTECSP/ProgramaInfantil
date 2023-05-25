using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoISW
{
    public partial class AgregarProfesor : Form
    {
        public AgregarProfesor()
        {
            InitializeComponent();


        }

        private void Reiniciar()
        {
            txtNombre.Clear();
            txtApellidoP.Clear();
            txtApellidoM.Clear();
            txtMatricula.Clear();
            txtContrasena.Clear();

            cbAdministrador.Checked = false;

        }

        private void btnAgregarMaestro_Click(object sender, EventArgs e)
        {

            string nombre = txtNombre.Text;
            string apellidoPaterno = txtApellidoP.Text;
            string apellidoMaterno = txtApellidoM.Text;
            string matricula = txtMatricula.Text;
            string contrasena = txtContrasena.Text;
            bool administrador = cbAdministrador.Checked;

            int cantidadNombres = nombre.Split(' ').Length;

            if (string.IsNullOrEmpty(nombre) || cantidadNombres > 2 || !nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c)) || nombre.Length >30 )
            {
                // El campo nombre está nulo, vacío, contiene más de dos nombres o tiene caracteres no válidos
                MessageBox.Show("Por favor ingresa uno o dos nombres válidos.");
                return;
            }

            if (string.IsNullOrWhiteSpace(apellidoPaterno) || !apellidoPaterno.All(char.IsLetter) || apellidoPaterno.Length >30)
            {
                MessageBox.Show("El apellido paterno solo soporta letras, máximo 30 caractéres");
                return;


            }



            if (string.IsNullOrWhiteSpace(apellidoMaterno) || !apellidoMaterno.All(char.IsLetter) || apellidoMaterno.Length > 30)
            {
                MessageBox.Show("El apellido materno solo soporta letras, máximo 30 caractéres");
                return;
            }


            if (string.IsNullOrEmpty(contrasena) || contrasena.Length > 10)
            {
                MessageBox.Show("Ingrese una contraseña válida, máximo 10 caracteres de numeros o letras.");
                return;
            }


            if (string.IsNullOrEmpty(matricula) || !matricula.All(char.IsDigit) || matricula.Length != 6)
            {
                // El campo matricula está nulo, vacío, contiene caracteres no numéricos o no tiene 6 caracteres de longitud
                MessageBox.Show("Por favor ingresa una matrícula válida de 6 dígitos.");
                return;
            }


            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);



            try
            {
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
                    MessageBox.Show("No se pudo agregar el profesor a la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar el profesor a la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                connection.Close();
            }

        }


        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string query = "SELECT * FROM VListaProfesores ORDER BY ID ASC";

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dtgVerProfesor.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar el profesor a la base de datos: " + ex.Message);
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento de tecla presionada
            }
        }

        private void txtApellidoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento de tecla presionada
            }
        }

        private void txtApellidoM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento de tecla presionada
            }
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento de tecla presionada
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellidoPaterno = txtApellidoP.Text;
            string apellidoMaterno = txtApellidoM.Text;
            string matricula = txtMatricula.Text;
            string contrasena = txtContrasena.Text;
            bool administrador = cbAdministrador.Checked;

            int cantidadNombres = nombre.Split(' ').Length;
           
            if (string.IsNullOrEmpty(nombre) || cantidadNombres > 2 || !nombre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsPunctuation(c)) || nombre.Length > 30)
            {
                // El campo nombre está nulo, vacío, contiene más de dos nombres o tiene caracteres no válidos
                MessageBox.Show("Por favor ingresa uno o dos nombres válidos.");
                return;
            }

            if (string.IsNullOrWhiteSpace(apellidoPaterno) || !apellidoPaterno.All(char.IsLetter) || apellidoPaterno.Length > 30)
            {
                MessageBox.Show("El apellido paterno solo soporta letras, máximo 30 caractéres");
                return;


            }



            if (string.IsNullOrWhiteSpace(apellidoMaterno) || !apellidoMaterno.All(char.IsLetter) || apellidoMaterno.Length > 30)
            {
                MessageBox.Show("El apellido materno solo soporta letras, máximo 30 caractéres");
                return;
            }


            if (string.IsNullOrEmpty(contrasena) || contrasena.Length > 10)
            {
                MessageBox.Show("Ingrese una contraseña válida, máximo 10 caracteres de numeros o letras.");
                return;
            }


            if (string.IsNullOrEmpty(matricula) || !matricula.All(char.IsDigit) || matricula.Length != 6)
            {
                // El campo matricula está nulo, vacío, contiene caracteres no numéricos o no tiene 6 caracteres de longitud
                MessageBox.Show("Por favor ingresa una matrícula válida de 6 dígitos.");
                return;
            }



            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);



            try
            {
                // Abrir la conexión a la base de datos
                connection.Open();


                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "sp_ModificarProfesor";

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
                    MessageBox.Show("El profesor se modificó correctamente a la base de datos.");
                    btnVerHistorial.PerformClick();
                    Reiniciar();

                }
                else
                {
                    MessageBox.Show("No se pudo agregar el profesor a la base de datos.");
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
    }
}
