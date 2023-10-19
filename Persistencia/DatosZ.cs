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
    public class DatosZ
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BdConection"].ConnectionString;




        public List<string> ObtenerDepartamentos()
        {
            List<string> departamentos = new List<string>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT NombreDepartamento FROM Departamento";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departamentos.Add(reader.GetString("NombreDepartamento"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener departamentos desde la capa de datos.", ex);
            }

            return departamentos;
        }

        public int ObtenerIdDepartamentoPorNombre(string nombreDepartamento)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT IdDpto FROM Departamento WHERE NombreDepartamento = @NombreDepartamento";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@NombreDepartamento", nombreDepartamento);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return -1; // Indicar que no se encontró el departamento
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el ID del departamento por nombre desde la capa de datos.", ex);
            }
        }

        public List<int> ObtenerIdsZonasPorDepartamento(int idDpto)
        {
            List<int> zonaIds = new List<int>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT IdZonas FROM Zonas WHERE IdDpto = @IdDpto";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@IdDpto", idDpto);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            zonaIds.Add(reader.GetInt32("IdZonas"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener IDs de zonas por departamento desde la capa de datos.", ex);
            }

            return zonaIds;
        }
    }
}
