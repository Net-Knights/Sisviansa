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

namespace Persistencia
{
    public class DatosU 
    {
        private string connectionString = "Server=localhost;Database=sisviansa;Uid=root;Pwd=auditoredash3;";

        
       

      
        // estos es para cliente comun
        public void RegistrarCliente(string mail, string telefono, string direccion, string ci, string nombre, string apellido, string usuario, string contraseña)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Registrar cliente
                        string query = "INSERT INTO cliente (Mail, Telefono, Direccion) VALUES (@Mail, @Telefono, @Direccion)";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Mail", mail);
                            command.Parameters.AddWithValue("@Telefono", telefono);
                            command.Parameters.AddWithValue("@Direccion", direccion);
                            command.ExecuteNonQuery();
                        }

                        // Obtener el NroCliente generado automáticamente
                        int nroCliente;
                        query = "SELECT LAST_INSERT_ID()";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            nroCliente = Convert.ToInt32(command.ExecuteScalar());
                        }

                        // Código para determinar el rol del cliente (ejemplo: común)
                        string rol = "Comun";
                        // Aquí puedes agregar la lógica para determinar el rol según algún criterio, como verificar si es empresa o administrador

                        // Registrar información común con el mismo NroCliente en la tabla "comun"
                        query = "INSERT INTO comun (NroCliente, Ci, Nombre, Apellido) VALUES (@NroCliente, @Ci, @Nombre, @Apellido)";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@NroCliente", nroCliente);
                            command.Parameters.AddWithValue("@Ci", ci);
                            command.Parameters.AddWithValue("@Nombre", nombre);
                            command.Parameters.AddWithValue("@Apellido", apellido);
                            command.ExecuteNonQuery();
                        }

                        // Registrar usuario y contraseña con el rol asignado en la tabla "login"
                        query = "INSERT INTO login (Usuario, Contraseña, Rol) VALUES (@Usuario, @Contraseña, @Rol)";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Usuario", usuario);
                            command.Parameters.AddWithValue("@Contraseña", contraseña);
                            command.Parameters.AddWithValue("@Rol", rol);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al registrar: " + ex.Message);
                    }
                }
            }
        }


        //login general
        public LoginGeneral IniciarSesion(string usuario, string contraseña)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Usuario, Rol FROM login WHERE Usuario = @Usuario AND Contraseña = @Contraseña;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Contraseña", contraseña);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nombreUsuario = reader.GetString("Usuario");
                        string rol = reader.GetString("Rol");
                        return new LoginGeneral { NombreUsuario = nombreUsuario, Rol = rol };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        //Abm clientes
        // Método para obtener los datos de clientes comunes
        public DataTable ObtenerDatosClientesComunes()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
SELECT 
    c.NroCliente,
    c.Autorizacion,
    c.Mail AS 'Mail',
    c.Telefono AS 'Telefono',
    c.Direccion AS 'Direccion',
    co.Ci AS 'Ci',
    co.Nombre AS 'Nombre',
    co.Apellido AS 'Apellido',
    ru.Roles AS 'Rol'
FROM Cliente c
LEFT JOIN Comun co ON c.NroCliente = co.NroCliente
LEFT JOIN roles_usuarios ru ON ru.Roles = 'Comun'
WHERE ru.Roles IS NOT NULL;
";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
        public DataTable BuscarClientePorNroCliente(int nroCliente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT 
                c.NroCliente,
                c.Autorizacion,
                c.Mail AS 'MailCliente',
                c.Telefono AS 'TelefonoCliente',
                c.Direccion AS 'DireccionCliente',
                co.Ci AS 'CiComun',
                co.Nombre AS 'NombreComun',
                co.Apellido AS 'ApellidoComun',
                e.RUT AS 'RutEmpresa',
                e.NombreEmpresa AS 'NombreEmpresa',
                ru.Roles AS 'Rol'
            FROM Cliente c
            LEFT JOIN Comun co ON c.NroCliente = co.NroCliente
            LEFT JOIN Empresa e ON c.NroCliente = e.NroCliente
            LEFT JOIN roles_usuario ru ON c.NroCliente = ru.NroCliente
            WHERE c.NroCliente = @NroCliente;";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NroCliente", nroCliente);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public void EliminarCliente(int nroCliente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Cliente WHERE NroCliente = @NroCliente";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NroCliente", nroCliente);

                command.ExecuteNonQuery();
            }
        }

        
        public DataTable ObtenerDatosClientesEmpresa()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
        SELECT 
            e.NroCliente,
            e.RUT AS 'RUT',
            e.NombreEmpresa AS 'NombreEmpresa',
            c.Direccion AS 'DireccionEmpresa',
            c.Telefono AS 'Telefono',
            c.Autorizacion AS 'Autorizacion',
            ru.Roles AS 'Rol'
        FROM Empresa e
        LEFT JOIN Cliente c ON e.NroCliente = c.NroCliente
        LEFT JOIN roles_usuarios ru ON ru.Roles = 'Empresa'
        ;";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        
     public void GuardarCliente(string tipoCliente, string nombre, string apellido, string correoElectronico, string telefono, string ci, string direccion, string rut, string nombreEmpresa, string direccionEmpresa)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string queryCliente = "INSERT INTO Cliente (Mail, Telefono, Direccion) VALUES (@Mail, @Telefono, @Direccion) " +
                                    "ON DUPLICATE KEY UPDATE Mail = @Mail, Telefono = @Telefono, Direccion = @Direccion;";
                MySqlCommand commandCliente = new MySqlCommand(queryCliente, connection);
                commandCliente.Parameters.AddWithValue("@Mail", correoElectronico);
                commandCliente.Parameters.AddWithValue("@Telefono", telefono);
                commandCliente.Parameters.AddWithValue("@Direccion", tipoCliente == "Empresa" ? direccionEmpresa : direccion); // Dirección de Empresa si es Empresa, sino Dirección normal
                commandCliente.ExecuteNonQuery();

                // Insertar o actualizar en las tablas correspondientes según el tipo de cliente
                if (tipoCliente == "Comun")
                {
                    string queryComun = "INSERT INTO Comun (NroCliente, CI, Nombre, Apellido) VALUES ((SELECT NroCliente FROM Cliente WHERE Mail = @Mail), @CI, @Nombre, @Apellido) " +
                                        "ON DUPLICATE KEY UPDATE CI = @CI, Nombre = @Nombre, Apellido = @Apellido;";
                    MySqlCommand commandComun = new MySqlCommand(queryComun, connection);
                    commandComun.Parameters.AddWithValue("@Mail", correoElectronico);
                    commandComun.Parameters.AddWithValue("@CI", ci);
                    commandComun.Parameters.AddWithValue("@Nombre", nombre);
                    commandComun.Parameters.AddWithValue("@Apellido", apellido);
                    commandComun.ExecuteNonQuery();
                }
                else if (tipoCliente == "Empresa")
                {
                    string queryEmpresa = "INSERT INTO Empresa (NroCliente, RUT, NombreEmpresa) VALUES ((SELECT NroCliente FROM Cliente WHERE Mail = @Mail LIMIT 1), @RUT, @NombreEmpresa) " +
                                        "ON DUPLICATE KEY UPDATE RUT = @RUT, NombreEmpresa = @NombreEmpresa;";
                    MySqlCommand commandEmpresa = new MySqlCommand(queryEmpresa, connection);
                    commandEmpresa.Parameters.AddWithValue("@Mail", correoElectronico);
                    commandEmpresa.Parameters.AddWithValue("@RUT", rut);
                    commandEmpresa.Parameters.AddWithValue("@NombreEmpresa", nombreEmpresa);
                    commandEmpresa.ExecuteNonQuery();
                }
            }




        }
        public void ActualizarAutorizacionEnBaseDeDatos(int nroCliente, string autorizacion)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                UPDATE Cliente
                SET Autorizacion = @Autorizacion
                WHERE NroCliente = @NroCliente";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NroCliente", nroCliente);
                command.Parameters.AddWithValue("@Autorizacion", autorizacion);

                command.ExecuteNonQuery();
            }
        }


        //Abm usuarios
       public List<string> ObtenerRoles()
        {
            List<string> roles = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Roles FROM roles_usuarios;";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString("Roles"));
                    }
                }
            }

            return roles;
        }


        public void GuardarUsuario(string usuario, string contraseña, string rol)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO login (Usuario, Contraseña, Rol) VALUES (@Usuario, @Contraseña, @Rol);";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Contraseña", contraseña);
                command.Parameters.AddWithValue("@Rol", rol);

                command.ExecuteNonQuery();
            }
        }




        public DataTable ObtenerUsuarios()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Usuario, Contraseña, Rol FROM login;";
                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable usuariosTable = new DataTable();
                adapter.Fill(usuariosTable);

                return usuariosTable;
            }
        }



        public DataTable ObtenerUsuariosPorRol(string rol)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Usuario, Contraseña, Rol FROM login WHERE Rol = @Rol;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Rol", rol);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable usuariosTable = new DataTable();
                adapter.Fill(usuariosTable);

                return usuariosTable;
            }
        }


        public void EliminarUsuario(string usuario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM login WHERE Usuario = @Usuario;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", usuario);

                command.ExecuteNonQuery();
            }
        }




        //Pedidos

        public List<string> ObtenerMenus()
        {
            List<string> menus = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT InfoMenu FROM Menu;";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        menus.Add(reader.GetString("InfoMenu"));
                    }
                }
            }

            return menus;
        }

        public List<string> ObtenerViandasPorMenu(string menu)
        {
            List<string> viandas = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Nombre_Vianda FROM Vianda;";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        viandas.Add(reader.GetString("Nombre_Vianda"));
                    }
                }
            }

            return viandas;
        }

        public int ObtenerStockDisponible(string menu, string vianda)
        {
            int stockReal = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT s.StockReal
            FROM Integra i
            JOIN Stock s ON i.IdVianda = s.IdVianda
            WHERE i.Infomenu = @Menu AND i.Nombre_Vianda = @Vianda;
        ";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Menu", menu);
                command.Parameters.AddWithValue("@Vianda", vianda);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    stockReal = Convert.ToInt32(result);
                }
            }

            return stockReal;
        }

        public int ObtenerStockMinimo(string menu, string vianda)
        {
            int stockMinimo = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
    SELECT s.StockMinimo
    FROM Integra i
    JOIN Stock s ON i.IdVianda = s.IdVianda
    WHERE i.Infomenu = @Menu AND i.Nombre_Vianda = @Vianda;
";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Menu", menu);
                command.Parameters.AddWithValue("@Vianda", vianda);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    stockMinimo = Convert.ToInt32(result);
                }
            }

            return stockMinimo;
        }

        public int GenerarNumeroPedido()
        {
            int nroPedido = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MAX(NroPedido) FROM Pedido;";
                MySqlCommand command = new MySqlCommand(query, connection);

                object result = command.ExecuteScalar();
                if (result != null && !Convert.IsDBNull(result))
                {
                    nroPedido = Convert.ToInt32(result) + 1;
                }
                else
                {
                    nroPedido = 1;
                }
            }

            return nroPedido;
        }

        public int GenerarNumeroCaja()
        {
            int nroCaja = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MAX(NroCaja) FROM Envasado;";
                MySqlCommand command = new MySqlCommand(query, connection);

                object result = command.ExecuteScalar();
                if (result != null && !Convert.IsDBNull(result))
                {
                    nroCaja = Convert.ToInt32(result) + 1;
                }
                else
                {
                    nroCaja = 1;
                }
            }

            return nroCaja;
        }

        public void ActualizarStock(string menu, string vianda, int cantidadViandas)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Stock SET StockReal = StockReal - @CantidadViandas WHERE IdVianda IN (SELECT IdVianda FROM Integra WHERE Infomenu = @Menu AND Nombre_Vianda = @Vianda);";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CantidadViandas", cantidadViandas);
                command.Parameters.AddWithValue("@Menu", menu);
                command.Parameters.AddWithValue("@Vianda", vianda);

                command.ExecuteNonQuery();
            }
        }

        public void AgregarPedidoIntegra(string vianda, string menu, int nroPedido, string estadoProduccion, int stockReal, int cantidadViandas, int nroCaja)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Obtener el último IdVianda generado en la tabla Vianda
                int idVianda;
                using (MySqlCommand getIdCommand = new MySqlCommand("SELECT LAST_INSERT_ID();", connection))
                {
                    idVianda = Convert.ToInt32(getIdCommand.ExecuteScalar());
                }

                string query = @"
            INSERT INTO Integra (IdVianda, Nombre_Vianda, InfoMenu, NroPedido, EstadosProduccion, Stock, CantidadViandas, NroCaja)
            VALUES (@IdVianda, @Vianda, @Menu, @NroPedido, @EstadoProduccion, @Stock, @CantidadViandas, @NroCaja);
        ";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdVianda", idVianda);
                command.Parameters.AddWithValue("@Vianda", vianda);
                command.Parameters.AddWithValue("@Menu", menu);
                command.Parameters.AddWithValue("@NroPedido", nroPedido);
                command.Parameters.AddWithValue("@EstadoProduccion", estadoProduccion);
                command.Parameters.AddWithValue("@Stock", stockReal);
                command.Parameters.AddWithValue("@CantidadViandas", cantidadViandas);
                command.Parameters.AddWithValue("@NroCaja", nroCaja);

                command.ExecuteNonQuery();
            }




        }

        public List<string> ObtenerEstadosProduccion()
        {
            List<string> estadosProduccion = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Estados_Produccion FROM estadosproduccion;";
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estadosProduccion.Add(reader.GetString("Estados_Produccion"));
                    }
                }
            }

            return estadosProduccion;
        }

    }






}