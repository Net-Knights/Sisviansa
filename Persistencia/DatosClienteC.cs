using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using RegistroUsuarios.Entities;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Data.Common;
using System.Configuration;

namespace Persistencia
{
   public class DatosClienteC
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BdConection"].ConnectionString;


        public List<string> ObtenerDatosClientePorUsuario(string usuario)
        {
            List<string> datos = new List<string>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT c.NroCliente, c.Autorizacion, c.Mail, c.Telefono, c.Direccion, co.CI, co.Nombre, co.Apellido " +
                                   "FROM cliente c " +
                                   "INNER JOIN comun co ON c.NroCliente = co.NroCliente " +
                                   "INNER JOIN login l ON l.Usuario = co.Nombre " +
                                   "WHERE l.Usuario = @Usuario";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                datos.Add(reader["NroCliente"].ToString());
                                datos.Add(reader["Autorizacion"].ToString());
                                datos.Add(reader["Mail"].ToString());
                                datos.Add(reader["Telefono"].ToString());
                                datos.Add(reader["Direccion"].ToString());
                                datos.Add(reader["CI"].ToString());
                                datos.Add(reader["Nombre"].ToString());
                                datos.Add(reader["Apellido"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos del cliente: " + ex.Message);
            }

            return datos;
        }


        public bool ActualizarDatosCliente(string nombreUsuario, string nuevoApellido, string nuevoCI, string nuevaDireccion, string nuevoTelefono, string nuevoMail)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string queryComun = "UPDATE comun SET Apellido = @NuevoApellido, CI = @NuevoCI WHERE Nombre = @NombreUsuario";
                    string queryCliente = "UPDATE cliente SET Mail = @NuevoMail, Telefono = @NuevoTelefono, Direccion = @NuevaDireccion WHERE NroCliente = (SELECT c.NroCliente FROM comun c WHERE c.Nombre = @NombreUsuario)";

                    using (MySqlCommand command = new MySqlCommand(queryComun, connection))
                    {
                        command.Parameters.AddWithValue("@NuevoApellido", nuevoApellido);
                        command.Parameters.AddWithValue("@NuevoCI", nuevoCI);
                        command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                        int rowsAffectedComun = command.ExecuteNonQuery();

                        using (MySqlCommand commandCliente = new MySqlCommand(queryCliente, connection))
                        {
                            commandCliente.Parameters.AddWithValue("@NuevoMail", nuevoMail);
                            commandCliente.Parameters.AddWithValue("@NuevoTelefono", nuevoTelefono);
                            commandCliente.Parameters.AddWithValue("@NuevaDireccion", nuevaDireccion);
                            commandCliente.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                            int rowsAffectedCliente = commandCliente.ExecuteNonQuery();

                            return rowsAffectedComun > 0 && rowsAffectedCliente > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar los datos del cliente: " + ex.Message);
            }
        }




    }
}





