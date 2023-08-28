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
namespace Logica
{
    
    public class UserModel
    {
        private DatosU datosU;

        public UserModel()
        {
            datosU = new DatosU();
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



        public List<string> ObtenerInfoMenu()
        {
            try
            {
                return datosU.ObtenerInfoMenu();
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
                return datosU.ObtenerIdMenuPorNombre(nombreMenu);
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
                return datosU.ObtenerIdPackPorNombre(nombrePack);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el ID del pack desde la capa de datos.", ex);
            }
        }

        // Método para obtener las viandas asociadas a un pack por su ID
        public List<string> ObtenerViandasDePack(int idPack)
        {
            try
            {
                return datosU.ObtenerViandasDePack(idPack);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las viandas del pack desde la capa de datos.", ex);
            }
        }


        public int ObtenerStockReal(int idMenu)
        {
            try
            {
                return datosU.ObtenerStockReal(idMenu);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el stock real desde la capa de datos.", ex);
            }
        }

        // Método para obtener el stock mínimo desde la capa de datos
        public int ObtenerStockMinimo(int idMenu)
        {
            try
            {
                return datosU.ObtenerStockMinimo(idMenu);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el stock mínimo desde la capa de datos.", ex);
            }
        }

        public List<string> ObtenerEstadosProduccion()
        {
            try
            {
                return datosU.ObtenerEstadosProduccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los estados de producción desde la capa de datos.", ex);
            }
        }


        public void AgregarIntegra(int idMenu, string nombrePack, string infoMenu, int nroCliente, int cantidadViandas, string estado, int stock)
        {
            try
            {
                int stockReal = datosU.ObtenerStockReal(idMenu);
                int stockMinimo = datosU.ObtenerStockMinimo(idMenu);

                // Llamar al método correspondiente en la capa de acceso a datos
                datosU.AgregarIntegra(idMenu, nombrePack, infoMenu, nroCliente, cantidadViandas, estado, stock);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa lógica al agregar en la tabla integra: " + ex.Message);
            }
        }

        public DataTable ObtenerDatosIntegra()
        {
            try
            {
                // Llamar al método correspondiente en la capa de acceso a datos
                return datosU.ObtenerDatosIntegra();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa lógica al obtener los datos de integra: " + ex.Message);
            }
        }

    }

}

















