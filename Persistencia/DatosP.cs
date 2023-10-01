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
    public class DatosP
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BdConection"].ConnectionString;



        public List<string> ObtenerInfoMenu()
        {


            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT infomenu FROM menu;";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    List<string> infoMenu = new List<string>();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            infoMenu.Add(reader.GetString("infomenu"));
                        }
                    }

                    return infoMenu;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la información del menú desde la capa de datos.", ex);
            }
        }

        public int ObtenerIdMenuPorNombre(string nombreMenu)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT IdMenu FROM Menu WHERE InfoMenu = @NombreMenu;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NombreMenu", nombreMenu);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return -1; // Valor de error si no se encuentra el menú
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el Id del menú desde la capa de datos.", ex);
            }
        }

        public DataTable ObtenerPacksPorMenu(int idMenu)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT p.NombrePack
            FROM packs p
            WHERE p.IdMenu = @IdMenu;
        ";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdMenu", idMenu);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public int ObtenerIdPackPorNombre(string nombrePack)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT IdPack FROM packs WHERE NombrePack = @NombrePack;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombrePack", nombrePack);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                return -1; // Valor de error si no se encuentra el pack
            }
        }

        public List<string> ObtenerNombresViandas()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Nombre_Vianda FROM vianda;";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    List<string> nombresViandas = new List<string>();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nombresViandas.Add(reader.GetString("Nombre_Vianda"));
                        }
                    }

                    return nombresViandas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los nombres de las viandas desde la capa de datos.", ex);
            }
        }


        public List<string> ObtenerViandasPorMenuYPack(string nombreMenu, string nombrePack)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT v.Nombre_Vianda
                        FROM packvianda pv
                        JOIN vianda v ON pv.IdVianda = v.IdVianda
                        JOIN packs p ON pv.IdPack = p.IdPack
                        JOIN menu m ON p.IdMenu = m.IdMenu
                        WHERE m.InfoMenu = @NombreMenu AND p.NombrePack = @NombrePack;
                    ";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NombreMenu", nombreMenu);
                    command.Parameters.AddWithValue("@NombrePack", nombrePack);

                    List<string> viandas = new List<string>();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            viandas.Add(reader.GetString("Nombre_Vianda"));
                        }
                    }

                    return viandas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las viandas asociadas al pack desde la capa de datos.", ex);
            }
        }


        public int ObtenerStockMinimoPorPack(string nombreMenu, string nombrePack)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT s.StockMinimo
                FROM stock s
                INNER JOIN packs p ON s.IdPack = p.IdPack
                INNER JOIN menu m ON p.IdMenu = m.IdMenu
                WHERE m.InfoMenu = @NombreMenu AND p.NombrePack = @NombrePack;
            ";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NombreMenu", nombreMenu);
                    command.Parameters.AddWithValue("@NombrePack", nombrePack);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return -1; // Valor de error si no se encuentra el stock mínimo
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el stock mínimo desde la capa de datos.", ex);
            }
        }

        public int ObtenerStockMaximoPorPack(string nombreMenu, string nombrePack)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT s.StockMaximo
                FROM stock s
                INNER JOIN packs p ON s.IdPack = p.IdPack
                INNER JOIN menu m ON p.IdMenu = m.IdMenu
                WHERE m.InfoMenu = @NombreMenu AND p.NombrePack = @NombrePack;
            ";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NombreMenu", nombreMenu);
                    command.Parameters.AddWithValue("@NombrePack", nombrePack);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return -1; // Valor de error si no se encuentra el stock máximo
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el stock máximo desde la capa de datos.", ex);
            }
        }

        public int ObtenerStockRealPorPack(string nombreMenu, string nombrePack)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT s.StockReal
                FROM stock s
                INNER JOIN packs p ON s.IdPack = p.IdPack
                INNER JOIN menu m ON p.IdMenu = m.IdMenu
                WHERE m.InfoMenu = @NombreMenu AND p.NombrePack = @NombrePack;
            ";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NombreMenu", nombreMenu);
                    command.Parameters.AddWithValue("@NombrePack", nombrePack);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return -1; // Valor de error si no se encuentra el stock real
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el stock real desde la capa de datos.", ex);
            }
        }


        public List<string> ObtenerEstadosProduccion()
        {
            List<string> estadosProduccion = new List<string>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT EstadoProduccion FROM estadosproduccion";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreEstado = reader["EstadoProduccion"].ToString();
                            estadosProduccion.Add(nombreEstado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de acceso a datos al obtener los estados de producción.", ex);
            }

            return estadosProduccion;
        }







    }
}
