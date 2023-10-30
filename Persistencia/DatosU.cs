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
    public class DatosU 
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BdConection"].ConnectionString;





      
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
        WHERE ru.Roles IS NOT NULL
            AND c.NroCliente NOT IN (SELECT NroCliente FROM Empresa WHERE NroCliente IS NOT NULL);
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
            try
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
                co.Ci AS 'Ci',
                co.Nombre AS 'Nombre',
                co.Apellido AS 'Apellido',
                e.RUT AS 'Rut',
                e.NombreEmpresa AS 'NombreEmpresa'
            FROM Cliente c
            LEFT JOIN Comun co ON c.NroCliente = co.NroCliente
            LEFT JOIN Empresa e ON c.NroCliente = e.NroCliente
            WHERE c.NroCliente = @NroCliente;";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NroCliente", nroCliente);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes registrar el error o lanzar una excepción personalizada.
                throw new Exception("Error en la capa de datos al buscar cliente por NroCliente: " + ex.Message);
            }
        }

        public void EliminarCliente(int nroCliente, string tipoCliente)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string deleteQuery = "";

                    if (tipoCliente == "Comun")
                    {
                        // Eliminar datos del Cliente Común
                        deleteQuery = "DELETE FROM Comun WHERE NroCliente = @NroCliente";
                    }
                    else if (tipoCliente == "Empresa")
                    {
                        // Eliminar datos del Cliente Empresa
                        deleteQuery = "DELETE FROM Empresa WHERE NroCliente = @NroCliente";
                    }

                    // Ejecutar la consulta de eliminación en la tabla correspondiente
                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@NroCliente", nroCliente);
                    deleteCommand.ExecuteNonQuery();

                    // Luego, eliminar el registro principal de la tabla Cliente
                    string deleteClienteQuery = "DELETE FROM Cliente WHERE NroCliente = @NroCliente";
                    MySqlCommand deleteClienteCommand = new MySqlCommand(deleteClienteQuery, connection);
                    deleteClienteCommand.Parameters.AddWithValue("@NroCliente", nroCliente);
                    deleteClienteCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la capa de datos al eliminar el cliente: " + ex.Message, ex);
                }
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

        
       


    }
    }




















