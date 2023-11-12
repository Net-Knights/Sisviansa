using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using Persistencia;
using RegistroUsuarios.Entities;
using System.Text.RegularExpressions;
using Persistencia;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
namespace Logica
{
    
    public class UserModel
    {
        private DatosU datosU;
        private DatosP datosP;
        private DatosL datosL;
        private DatosZ datosZ;
        private DatosClienteC datosClienteC = new DatosClienteC();

        public UserModel()
        {
            datosU = new DatosU();
            datosP = new DatosP();
            datosP = new DatosP();
            datosZ = new DatosZ();
        }
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }
        public string ValidarCampos(string mail, string telefono, string direccion, string ci, string nombre, string apellido, string usuario, string contraseña)
        {
            if (string.IsNullOrEmpty(mail) ||
                string.IsNullOrEmpty(telefono) ||
                string.IsNullOrEmpty(direccion) ||
                string.IsNullOrEmpty(ci) ||
                string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(usuario) ||
                string.IsNullOrEmpty(contraseña))
            {
                return "Todos los campos son obligatorios. Por favor, ingrese todos los datos.";
            }

            if (!IsValidEmail(mail))
            {
                return "El email ingresado no es válido. Por favor, ingrese un email válido.";
            }

            return ""; // Si no hay errores, retorna una cadena vacía
        }
        public void GuardarUsuario(string usuario, string contraseña, string rol)
        {
            try
            {
                datosU.GuardarUsuario(usuario, contraseña, rol);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                throw new Exception("Error al guardar el usuario.", ex);
            }
        }
        public bool ValidarNombreUsuario(string usuario)
        {
            try
            {
                // Utiliza expresiones regulares para verificar si el nombre de usuario contiene solo letras y números
                if (!Regex.IsMatch(usuario, "^[a-zA-Z0-9]+$"))
                {
                    throw new Exception("El nombre de usuario solo debe contener letras y números.");
                }

                return true; // La validación fue exitosa
            }
            catch (Exception ex)
            {
                // Puedes registrar el error si lo necesitas
                // Logging.LogError(ex);
                return false; // La validación falló
            }
        }

        public bool ValidarContraseña(string contraseña)
        {
            try
            {
                // Utiliza expresiones regulares para verificar si la contraseña no incluye caracteres especiales
                if (!Regex.IsMatch(contraseña, "^[a-zA-Z0-9]+$"))
                {
                    throw new Exception("La contraseña no puede incluir caracteres especiales.");
                }

                return true; // La validación fue exitosa
            }
            catch (Exception ex)
            {
                // Puedes registrar el error si lo necesitas
                // Logging.LogError(ex);
                return false; // La validación falló
            }
        }


      

        public bool ValidarCI(string ci)
        {
            try
            {
                return Regex.IsMatch(ci, @"^\d{1,8}$");
            }
            catch (Exception ex)
            {
                
                return false; // La validación falló
            }
        }

        public bool ValidarRUT(string rut)
        {
            try
            {
                return Regex.IsMatch(rut, @"^\d{1,11}$");
            }
            catch (Exception ex)
            {
                
                return false; // La validación falló
            }
        }

        public bool ValidarTelefono(string telefono)
        {
            try
            {
                return Regex.IsMatch(telefono, @"^\d{1,9}$");
            }
            catch (Exception ex)
            {
                
                return false; // La validación falló
            }
        }


        public void EliminarUsuario(string usuario)
        {
            try
            {
                datosU.EliminarUsuario(usuario);
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                throw new Exception("Error al eliminar el usuario.", ex);
            }
        }

        public void EliminarCliente(int nroCliente, string tipoCliente)
        {
            try
            {
                datosU.EliminarCliente(nroCliente, tipoCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de lógica al eliminar el cliente: " + ex.Message, ex);
            }
        }

        public DataTable BuscarClientePorNroCliente(int nroCliente)
        {
            try
            {
                // Llamar a la capa de datos para buscar el cliente por NroCliente
                return datosU.BuscarClientePorNroCliente(nroCliente);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes registrar el error o lanzar una excepción personalizada.
                throw new Exception("Error en la capa de lógica al buscar cliente por NroCliente: " + ex.Message);
            }
        }










        //logica para los pedidos

        public List<string> ObtenerInfoMenu()
        {
            try
            {
                return datosP.ObtenerInfoMenu();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la información del menú.", ex);
            }
        }



        public int ObtenerIdMenuPorNombre(string nombreMenu)
        {
            try
            {
                return datosP.ObtenerIdMenuPorNombre(nombreMenu);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el Id del menú desde la capa de datos.", ex);
            }
        }



        // Sobrecarga del método para obtener el ID del pack solo por nombre (sin ID del menú)
        public int ObtenerIdPackPorNombre(string nombrePack)
        {
            try
            {

                int idMenu = -1;
                return datosP.ObtenerIdPackPorNombre(nombrePack);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el ID del pack desde la capa de datos.", ex);
            }
        }


        public List<string> ObtenerNombresViandas()
        {
            DatosP datosP = new DatosP();
            return datosP.ObtenerNombresViandas();
        }

        public List<string> ObtenerViandasPorMenuYPack(string nombreMenu, string nombrePack)
        {
            return datosP.ObtenerViandasPorMenuYPack(nombreMenu, nombrePack);
        }
        public DataTable ObtenerPacksPorMenu(int idMenu)
        {
            return datosP.ObtenerPacksPorMenu(idMenu);
        }




        public int ObtenerStockMinimoPorPack(string nombreMenu, string nombrePack)
        {
            try
            {
                return datosP.ObtenerStockMinimoPorPack(nombreMenu, nombrePack);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el stock mínimo por pack desde la capa de lógica.", ex);
            }
        }

        public int ObtenerStockMaximoPorPack(string nombreMenu, string nombrePack)
        {
            try
            {
                return datosP.ObtenerStockMaximoPorPack(nombreMenu, nombrePack);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el stock máximo por pack desde la capa de lógica.", ex);
            }
        }

        public int ObtenerStockRealPorPack(string nombreMenu, string nombrePack)
        {
            try
            {
                return datosP.ObtenerStockRealPorPack(nombreMenu, nombrePack);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el stock real por pack desde la capa de lógica.", ex);
            }
        }


        public List<string> ObtenerEstadosProduccion()
        {
            try
            {
                return datosP.ObtenerEstadosProduccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de lógica al obtener los estados de producción.", ex);
            }
        }

        public int AgregarPedidoCompleto(string tipoMenu, int IdMenu, string nombrePack, int nroCliente, int stock, string estadoProduccion, int cantidadPacks, bool esPersonalizado)
        {
            // Validación: Verificar si el número de cliente es positivo
            if (nroCliente <= 0)
            {
                throw new ArgumentException("El número de cliente debe ser un valor positivo.");
            }

            // Validación: Verificar si la cantidad de packs es positiva
            if (cantidadPacks <= 0)
            {
                throw new ArgumentException("La cantidad de packs debe ser un valor positivo.");
            }

            // Llama a la capa de datos para agregar el pedido
            return datosP.AgregarPedidoCompleto(tipoMenu, IdMenu, nombrePack, nroCliente, stock, estadoProduccion, cantidadPacks, esPersonalizado);
        }




        public DataTable ObtenerPacksYClientePorNroCliente(int nroCliente)
        {
            try
            {
                return datosP.ObtenerPacksYClientePorNroCliente(nroCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa logica para obtener los packs", ex);
            }
             
            
        }



        public DataTable ObtenerTodosLosPacks()
        {
            try
            {
                // Llama a la capa de acceso a datos para obtener todos los packs
                return datosP.ObtenerTodosLosPacks();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de lógica al obtener todos los packs.", ex);
            }
        }


        //Logica de zonas

        public List<string> ObtenerDepartamentos()
        {
            try
            {
                return datosZ.ObtenerDepartamentos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de lógica al obtener departamentos.", ex);
            }
        }

        public List<int> ObtenerIdsZonasPorDepartamento(int idDpto)
        {
            try
            {
                return datosZ.ObtenerIdsZonasPorDepartamento(idDpto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los IDs de zonas por departamento desde la capa de lógica.", ex);
            }
        }

        public int ObtenerIdDepartamentoPorNombre(string nombreDepartamento)
        {
            try
            {
                return datosZ.ObtenerIdDepartamentoPorNombre(nombreDepartamento);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de lógica al obtener el ID del departamento por nombre.", ex);
            }
        }

        public bool ExisteNumeroCliente(string numeroCliente)
        {
            try
            {
                return datosZ.ExisteNumeroCliente(numeroCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de lógica al verificar si el número de cliente existe.", ex);
            }
        }

        public bool ExisteClienteConNumero(int idCliente)
        {
            try
            {
                // Llamada al método de la capa de datos para verificar si ya existe un cliente con el mismo número
                return datosZ.ExisteClienteConNumero(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar si ya existe un cliente con el mismo número.", ex);
            }
        }


        public int ObtenerIdClientePorNumero(string numeroCliente)
        {
            try
            {
                return datosZ.ObtenerIdClientePorNumero(numeroCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de lógica al obtener el ID del cliente por número.", ex);
            }
        }

        public bool GuardarVive(int idZona, int idDepartamento, int idCliente)
        {
            try
            {
                return datosZ.GuardarVive(idZona, idDepartamento, idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de lógica al guardar datos en la tabla 'vive'.", ex);
            }
        }

        //logica cliente comun


        public List<string> ObtenerDatosClientePorUsuario(string usuario)
        {
            try
            {
                return datosClienteC.ObtenerDatosClientePorUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica: " + ex.Message);
            }
        }

        public bool ActualizarDatosCliente(string nombreUsuario, string nuevoApellido, string nuevoCI, string nuevaDireccion, string nuevoTelefono, string nuevoMail)
        {
            try
            {
                return datosClienteC.ActualizarDatosCliente(nombreUsuario, nuevoApellido, nuevoCI, nuevaDireccion, nuevoTelefono, nuevoMail);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica: " + ex.Message);
            }
        }






    }

    }



















