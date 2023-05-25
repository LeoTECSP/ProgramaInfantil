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
    public partial class HistorialActividades : Form
    {
        public HistorialActividades()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarHistorial_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void btnHAlfabeto_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;
        
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string query = "SELECT* FROM VHistorialAlumnos ORDER BY Alumno ASC";

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dtgHistorial.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al ver el historial en  la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                connection.Close();
            }

        }

        private void btnHActividades_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string query = "SELECT * FROM VHistorialAlumnos ORDER BY [Actividades Realizadas] DESC";

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dtgHistorial.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al ver el historial en  la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                connection.Close();
            }

        }

        private void btnHFallos_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string query = "SELECT * FROM VHistorialAlumnos ORDER BY Errores DESC";

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dtgHistorial.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al ver el historial en  la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                connection.Close();
            }
        }
    }
}
