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
            SELECT DISTINCT p.NombrePack
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


        public int AgregarPedidoCompleto(string tipoMenu, int IdMenu, string nombrePack, int nroCliente, int stock, string estadoProduccion, int cantidadPacks, bool esPersonalizado)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Generar automáticamente el número de pedido
                    int nroPedido = GenerarNumeroPedido();

                    // Obtener el ID de producción según el estado seleccionado
                    int idProduccion = ObtenerIdProduccionPorEstado(estadoProduccion);

                    // Generar automáticamente el número de caja
                    int nroCaja = GenerarNumeroCaja();

                    // Obtener la fecha actual
                    DateTime fechaActual = DateTime.Now;

                    // Sumar 7 días al valor actual para obtener la fecha de vencimiento
                    DateTime fechaVencimiento = fechaActual.AddDays(7);

                    // Luego, inserta fechaVencimiento en la base de datos
                    string insertCajaQuery = "INSERT INTO caja (NroCaja, TiempoVencimiento) VALUES (@NroCaja, @TiempoVencimiento)";
                    MySqlCommand insertCajaCommand = new MySqlCommand(insertCajaQuery, connection);
                    insertCajaCommand.Parameters.AddWithValue("@NroCaja", nroCaja);
                    insertCajaCommand.Parameters.AddWithValue("@TiempoVencimiento", fechaVencimiento);
                    insertCajaCommand.ExecuteNonQuery();

                    // Insertar el número de pedido en la tabla pedido
                    string insertPedidoQuery = "INSERT INTO pedido (NroPedido) VALUES (@NroPedido)";
                    MySqlCommand insertPedidoCommand = new MySqlCommand(insertPedidoQuery, connection);
                    insertPedidoCommand.Parameters.AddWithValue("@NroPedido", nroPedido);
                    insertPedidoCommand.ExecuteNonQuery();

                    if (!esPersonalizado)
                    {
                        // Insertar el pack en la tabla packs incluyendo el stock
                        string insertPackQuery = "INSERT INTO packs (InfoMenu, NombrePack, IdMenu, StockReal, NroCaja, NroPedido, IdProduccion, CantPacks) " +
                                      "VALUES (@InfoMenu, @NombrePack, @IdMenu, @StockReal, @NroCaja, @NroPedido, @IdProduccion, @CantPacks)";
                        MySqlCommand insertPackCommand = new MySqlCommand(insertPackQuery, connection);
                        insertPackCommand.Parameters.AddWithValue("@InfoMenu", tipoMenu);
                        insertPackCommand.Parameters.AddWithValue("@StockReal", stock);
                        insertPackCommand.Parameters.AddWithValue("@NroCaja", nroCaja);
                        insertPackCommand.Parameters.AddWithValue("@NroPedido", nroPedido);
                        insertPackCommand.Parameters.AddWithValue("@IdProduccion", idProduccion);
                        insertPackCommand.Parameters.AddWithValue("@CantPacks", cantidadPacks);
                        insertPackCommand.Parameters.AddWithValue("@NombrePack", nombrePack);
                        insertPackCommand.Parameters.AddWithValue("@IdMenu", IdMenu);
                        insertPackCommand.ExecuteNonQuery();
                        // Insertar en la tabla envasado
                        string insertEnvasadoQuery = "INSERT INTO envasado (NroCaja, InfoMenu, CantidadPacks) " +
                                                     "VALUES (@NroCaja, @InfoMenu, (SELECT CantPacks FROM packs WHERE NroPedido = @NroPedido LIMIT 1))";
                        MySqlCommand insertEnvasadoCommand = new MySqlCommand(insertEnvasadoQuery, connection);
                        insertEnvasadoCommand.Parameters.AddWithValue("@NroCaja", nroCaja);
                        insertEnvasadoCommand.Parameters.AddWithValue("@InfoMenu", tipoMenu);
                        insertEnvasadoCommand.Parameters.AddWithValue("@NroPedido", nroPedido);
                        insertEnvasadoCommand.ExecuteNonQuery();



                        // Actualizar el stock en la tabla Stock restando la cantidad de packs
                        string updateStockQuery = "UPDATE stock SET StockReal = StockReal - 1 " +
                                                   "WHERE IdPack IN (SELECT IdPack FROM packs WHERE NroPedido = @NroPedido)";
                        MySqlCommand updateStockCommand = new MySqlCommand(updateStockQuery, connection);
                        updateStockCommand.Parameters.AddWithValue("@CantPacks", cantidadPacks);
                        updateStockCommand.Parameters.AddWithValue("@NroPedido", nroPedido);
                        updateStockCommand.ExecuteNonQuery();

                        return nroPedido; // Retorna el número de pedido generado
                    }
                    else
                    {
                        // Insertar el pack personalizado en la tabla packs sin incluir el stock
                        string insertPackQuery = "INSERT INTO packs (InfoMenu, NombrePack, IdMenu, NroCaja, NroPedido, IdProduccion, CantPacks, EsPersonalizado) " +
                                                 "VALUES (@InfoMenu, @NombrePack, @IdMenu, @NroCaja, @NroPedido, @IdProduccion, @CantPacks, @EsPersonalizado)";
                        MySqlCommand insertPackCommand = new MySqlCommand(insertPackQuery, connection);
                        insertPackCommand.Parameters.AddWithValue("@InfoMenu", tipoMenu);
                        insertPackCommand.Parameters.AddWithValue("@NroCaja", nroCaja);
                        insertPackCommand.Parameters.AddWithValue("@NroPedido", nroPedido);
                        insertPackCommand.Parameters.AddWithValue("@IdProduccion", idProduccion);
                        insertPackCommand.Parameters.AddWithValue("@CantPacks", cantidadPacks);
                        insertPackCommand.Parameters.AddWithValue("@NombrePack", nombrePack);
                        insertPackCommand.Parameters.AddWithValue("@IdMenu", IdMenu);
                        insertPackCommand.Parameters.AddWithValue("@EsPersonalizado", true); // Es personalizado
                        insertPackCommand.ExecuteNonQuery();
                        // Insertar en la tabla envasado
                        string insertEnvasadoQuery = "INSERT INTO envasado (NroCaja, InfoMenu, CantidadPacks) " +
                                                     "VALUES (@NroCaja, @InfoMenu, (SELECT CantPacks FROM packs WHERE NroPedido = @NroPedido LIMIT 1))";
                        MySqlCommand insertEnvasadoCommand = new MySqlCommand(insertEnvasadoQuery, connection);
                        insertEnvasadoCommand.Parameters.AddWithValue("@NroCaja", nroCaja);
                        insertEnvasadoCommand.Parameters.AddWithValue("@InfoMenu", tipoMenu);
                        insertEnvasadoCommand.Parameters.AddWithValue("@NroPedido", nroPedido);
                        insertEnvasadoCommand.ExecuteNonQuery();

                        return nroPedido; // Retorna el número de pedido generado

                    }

                 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de acceso a datos al agregar el pedido.", ex);
            }
        }

        private int GenerarNumeroPedido()
        {
            Random random = new Random();
            return random.Next(1000, 9999); // Número de pedido aleatorio de 4 dígitos
        }

        private int ObtenerIdProduccionPorEstado(string estadoProduccion)
        {
            int idProduccion = -1;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT IdEstadoProduccion FROM estadosproduccion WHERE EstadoProduccion = @EstadoProduccion";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EstadoProduccion", estadoProduccion);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        idProduccion = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de acceso a datos al obtener el ID de producción.", ex);
            }

            return idProduccion;
        }

        private int GenerarNumeroCaja()
        {
            Random random = new Random();
            return random.Next(1000, 9999); // Número de caja aleatorio de 4 dígitos
        }

        
        public DataTable ObtenerPacksYClientePorNroCliente(int nroCliente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT p.IdPack, p.NombrePack, p.InfoMenu, p.IdMenu, p.StockReal, p.NroCaja, p.NroPedido, p.IdProduccion, p.CantPacks, c.NroCliente
                    FROM packs p
                    INNER JOIN cliente c ON p.NroCliente = c.NroCliente
                    WHERE p.NroCliente = @NroCliente;
                ";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NroCliente", nroCliente);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }


        public DataTable ObtenerTodosLosPacks()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

            string query = @"
            SELECT * FROM packs
            WHERE StockReal IS NOT NULL 
            AND CantPacks IS NOT NULL 
            AND NroPedido IS NOT NULL
           
        ";

                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

    }
}
