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

        public List<string> ObtenerEstadosProduccion()
        {
            List<string> estadosProduccion = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT NombreEstados FROM estadosproduccion;";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estadosProduccion.Add(reader.GetString("NombreEstados"));
                    }
                }
            }

            return estadosProduccion;
        }


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
                INNER JOIN menupack mp ON p.IdPacks = mp.IdPack
                WHERE mp.IdMenu = @IdMenu;
            ";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdMenu", idMenu);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public DataTable ObtenerViandasPorMenu(int idMenu)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                SELECT v.Nombre_Vianda
                FROM vianda v
                INNER JOIN menuvianda mv ON v.IdVianda = mv.IdVianda
                WHERE mv.IdMenu = @IdMenu;
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

                string query = "SELECT IdPacks FROM packs WHERE NombrePack = @NombrePack;";
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


        // Método para obtener las viandas asociadas a un pack por su ID
        public List<string> ObtenerViandasDePack(int idPack)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                SELECT v.Nombre_Vianda
                FROM packvianda pv
                INNER JOIN vianda v ON pv.IdVianda = v.IdVianda
                WHERE pv.IdPacks = @IdPack;
        ";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdPack", idPack);

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


        //Stock
        public int ObtenerStockReal(int idMenu)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT StockReal FROM stock WHERE IdMenu = @IdMenu";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdMenu", idMenu);


                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                return -1; // Valor de error si no se encuentra el stock
            }
        }


        public int ObtenerStockMinimo(int idMenu)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT StockMinimo FROM stock WHERE IdMenu = @IdMenu";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdMenu", idMenu);


                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                return -1; // Valor de error si no se encuentra el stock mínimo
            }
        }



        //Tabla integra
        public void AgregarIntegra(int idMenu, string nombrePack, string infoMenu, int nroCliente, int cantidadViandas, string estado, int stock)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar un registro en la tabla "pedido" para obtener NroPedido generado automáticamente
                        string insertPedidoQuery = "INSERT INTO pedido DEFAULT VALUES";
                        using (MySqlCommand command = new MySqlCommand(insertPedidoQuery, connection, transaction))
                        {
                            command.ExecuteNonQuery();
                        }

                        // Obtener el NroPedido generado automáticamente
                        string obtenerNroPedidoQuery = "SELECT LAST_INSERT_ID()";
                        int nroPedido;
                        using (MySqlCommand command = new MySqlCommand(obtenerNroPedidoQuery, connection, transaction))
                        {
                            nroPedido = Convert.ToInt32(command.ExecuteScalar());
                        }

                        // Insertar un registro en la tabla "caja" para obtener NroCaja generado automáticamente
                        string insertCajaQuery = "INSERT INTO caja DEFAULT VALUES";
                        using (MySqlCommand command = new MySqlCommand(insertCajaQuery, connection, transaction))
                        {
                            command.ExecuteNonQuery();
                        }
                        // Obtener el IdMenu correspondiente al valor seleccionado en el ComboBox cbTipomenu
                        string obtenerIdMenuQuery = "SELECT IdMenu FROM menu WHERE InfoMenu = @InfoMenu";

                        using (MySqlCommand command = new MySqlCommand(obtenerIdMenuQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@InfoMenu", infoMenu);
                            idMenu = Convert.ToInt32(command.ExecuteScalar());
                        }
                        // Obtener el NroCaja generado automáticamente
                        string obtenerNroCajaQuery = "SELECT LAST_INSERT_ID()";
                        int nroCaja;
                        using (MySqlCommand command = new MySqlCommand(obtenerNroCajaQuery, connection, transaction))
                        {
                            nroCaja = Convert.ToInt32(command.ExecuteScalar());
                        }

                        // Insertar el registro en la tabla "envasado" con los valores ingresados
                        string insertEnvasadoQuery = "INSERT INTO envasado (Cantidad_Viandas, NroCaja, InfoMenu, NombrePack) " +
                                                     "VALUES (@CantidadViandas, @NroCaja, @InfoMenu, @NombrePack)";
                        using (MySqlCommand command = new MySqlCommand(insertEnvasadoQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@CantidadViandas", cantidadViandas);
                            command.Parameters.AddWithValue("@NroCaja", nroCaja);
                            command.Parameters.AddWithValue("@InfoMenu", infoMenu);
                            command.Parameters.AddWithValue("@NombrePack", nombrePack);
                            command.ExecuteNonQuery();
                        }

                        // Insertar el registro en la tabla "integra" con los valores obtenidos e ingresados
                        string insertIntegraQuery = "INSERT INTO integra (IdMenu, NombrePack, InfoMenu, NroPedido, NroCaja, NroCliente, CantidadViandas, Estado, Stock) " +
                                                    "VALUES (@IdMenu, @NombrePack, @InfoMenu, @NroPedido, @NroCaja, @NroCliente, " +
                                                    "(SELECT Cantidad_Viandas FROM envasado WHERE NroCaja = @NroCaja AND InfoMenu = @InfoMenu AND NombrePack = @NombrePack), " +
                                                    "@Estado, @Stock)";
                        using (MySqlCommand command = new MySqlCommand(insertIntegraQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@IdMenu", idMenu);
                            command.Parameters.AddWithValue("@NombrePack", nombrePack);
                            command.Parameters.AddWithValue("@InfoMenu", infoMenu);
                            command.Parameters.AddWithValue("@NroPedido", nroPedido);
                            command.Parameters.AddWithValue("@NroCaja", nroCaja);
                            command.Parameters.AddWithValue("@NroCliente", nroCliente);
                            command.Parameters.AddWithValue("@Estado", estado);
                            command.Parameters.AddWithValue("@Stock", stock);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al agregar en la tabla integra: " + ex.Message);
                    }
                }
            }
        }




        public DataTable ObtenerDatosIntegra()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string obtenerDatosIntegraQuery = "SELECT * FROM integra";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(obtenerDatosIntegraQuery, connection))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public DataTable BuscarPedidosPorCliente(int nroCliente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM integra WHERE NroCliente = @NroCliente";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NroCliente", nroCliente);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }


        public void EliminarDatosPedido(int nroPedido)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    conexion.Open();

                    // Consulta para eliminar datos en la tabla Integra
                    string consultaIntegra = "DELETE FROM integra WHERE NroPedido = @NroPedido";
                    using (MySqlCommand comandoIntegra = new MySqlCommand(consultaIntegra, conexion))
                    {
                        comandoIntegra.Parameters.AddWithValue("@NroPedido", nroPedido);
                        comandoIntegra.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar los datos de Integra.", ex);
            }
        }

    }
}
