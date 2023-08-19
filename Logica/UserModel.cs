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

        public DataTable ObtenerViandasPorMenu(string menuId)
        {
            return datosU.ObtenerViandasPorMenu(menuId);
        }
        public List<string> ObtenerPacksPorMenu(string menuId)
        {
            try
            {
                return datosU.ObtenerPacksPorMenu(menuId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los packs asociados al menú.", ex);
            }
        }


        public List<string> ObtenerViandasPorPack(string packId)
        {
            return datosU.ObtenerViandasPorPack(packId);
        }
    }

}

















