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
    public partial class AccesoPrograma : Form
    {

        public AccesoPrograma()
        {
            InitializeComponent();
            
        }

        private void ReiniciarInformacion()
        {
            txtMatricula.Clear();
            txtContraseña.Clear();
        }
 


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 Variables.matriculaUsuario = txtMatricula.Text;
                 Variables.contraseñaUsuario = txtContraseña.Text;
               

                // Cadena de conexión a la base de datos
                string connectionString = ConfigurationManager.ConnectionStrings["connSTR"].ConnectionString;

                // Consulta SQL para buscar al profesor en la tabla ListaProfesores
                string query = "SELECT administrador FROM VListaProfesores WHERE matricula = @matricula AND contraseña = @contraseña";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@matricula", Variables.matriculaUsuario);
                    command.Parameters.AddWithValue("@contraseña", Variables.contraseñaUsuario);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Variables.esAdministrador = reader.GetBoolean(0);

                        if (Variables.esAdministrador )
                        {
                            MessageBox.Show("Acceso permitido, Administrador ");
                            Variables.esAdministrador = true;
                            this.Hide();
                            Form form1 = new menuAdministrador();


                            form1.Show();
                              
                                ReiniciarInformacion();
                            

                            return;
                        }
                        if (!Variables.esAdministrador)
                        {
                            Variables.esAdministrador = false;
                            // Acceso permitido para el usuario administrador
                            //RegistrarAcceso(matricula);
                            MessageBox.Show("Acceso permitido, Profesor");
                            Form form1 = new menuProfe();
                            this.Hide();



                            form1.Show();
                        
                            ReiniciarInformacion();
                            return;
                        }




                    }


                    else
                    {
                        //// Comprobar si el usuario tiene acceso a los datos de los alumnos en la tabla Historial
                        //bool tieneAcceso = VerificarAcceso(matricula);
                        //if (tieneAcceso)
                        //{
                        //    // Acceso permitido para el usuario no administrador
                        //    RegistrarAcceso(matricula);
                        //    MessageBox.Show("Acceso permitido");
                        //}
                        //else
                        //{
                        //    // Acceso denegado para el usuario no administrador
                        //    MessageBox.Show("Acceso denegado");
                        //}

                        MessageBox.Show("Acceso denegado");
                        ReiniciarInformacion();
                        return;
                    }
                    connection.Close();
                }

            }
            catch (Exception)
            {

                throw;
            }
         
            

        }

        private void AccesoPrograma_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);


        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento de tecla presionada
            }
        }
    }


}



