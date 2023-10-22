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


        public DataTable ObtenerDatosCliente(int nroCliente)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT c.Autorizacion, c.Mail, c.Telefono, c.Direccion, co.CI, co.Nombre, co.Apellido " +
                                   "FROM cliente c " +
                                   "INNER JOIN comun co ON c.NroCliente = co.NroCliente " +
                                   "WHERE c.NroCliente = @nroCliente";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nroCliente", nroCliente);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de la excepción de MySQL
                Console.WriteLine("Error de MySQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                Console.WriteLine("Error: " + ex.Message);
            }

            return dataTable;
        }
    }
}





