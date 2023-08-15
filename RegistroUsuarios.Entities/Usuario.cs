using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsuarios.Entities
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string CorreoElectronico { get; set; }

       
    }

    public class ClienteComun : Usuario
    {
        public string Direccion { get; set; }
        public string CI { get; set; }
        public string Telefono { get; set; }

       
    }

    public class ClienteEmpresa : Usuario
    {
        public string NombreEmpresa { get; set; }
        public string RUT { get; set; }
        public string DireccionEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }

       
    }

    

    public class LoginGeneral
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
    }
}