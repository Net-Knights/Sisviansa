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


        public List<string> ObtenerDatosClientePorNroCliente(int nroCliente)
        {
            try
            {
                List<string> datosCliente = new List<string>();
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

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Agregar los valores a la lista en el orden deseado
                                datosCliente.Add(reader.GetString("Autorizacion"));
                                datosCliente.Add(reader.GetString("Mail"));
                                datosCliente.Add(reader.GetString("Telefono"));
                                datosCliente.Add(reader.GetString("Direccion"));
                                datosCliente.Add(reader.GetString("CI"));
                                datosCliente.Add(reader.GetString("Nombre"));
                                datosCliente.Add(reader.GetString("Apellido"));
                            }
                        }
                    }
                }
                return datosCliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos del cliente: " + ex.Message);
            }
        }
    }
}





