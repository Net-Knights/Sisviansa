using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Persistencia;
using RegistroUsuarios.Entities;
//using Persistencia;


namespace Login
{
    public partial class VentanaPrincipal : Form
    {
        private UserModel userModel;
        private DatosU datosU;
        private DatosP datosP;
        private DatosL datosL;
        private string token;


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            Application.Run(ventanaPrincipal);
        }


        public VentanaPrincipal()
        {
            InitializeComponent();
            datosU = new DatosU();
            datosP = new DatosP();
            datosL = new DatosL();
            txtPassword.PasswordChar = '*';
            userModel = new UserModel();

        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsername.Text;
                string contraseña = txtPassword.Text;

                // Validar que los campos no estén vacíos
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor, ingrese el usuario y la contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validar el formato del nombre de usuario y la contraseña usando UserModel
                if (!userModel.ValidarNombreUsuario(usuario))
                {
                    MessageBox.Show("El nombre de usuario solo debe contener letras y números.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!userModel.ValidarContraseña(contraseña))
                {
                    MessageBox.Show("La contraseña no puede incluir caracteres especiales.", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                LoginGeneral usuarioLogueado = datosL.IniciarSesion(usuario, contraseña);

                if (usuarioLogueado != null)
                {
                    LoginGeneral.NombreUsuarioLogueado = usuarioLogueado.NombreUsuario;
                    LoginGeneral.RolLogueado = usuarioLogueado.Rol;
                    string mensaje = $"Bienvenido {usuarioLogueado.NombreUsuario} ({usuarioLogueado.Rol}).";
                    MessageBox.Show(mensaje, "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrir formulario correspondiente según el rol del usuario
                    switch (usuarioLogueado.Rol.ToLower())
                    {
                        case "administrador":
                        case "gerencia":
                            MenuPrincipal menuPrincipal = new MenuPrincipal();
                            menuPrincipal.Show();
                            this.Hide();
                            break;

                        case "comun":
                            FormularioClienteComun formularioClienteComun = new FormularioClienteComun();
                            formularioClienteComun.Show();
                            this.Hide();
                            break;
                       
                        case "jefecocina":

                            break;
                        case "atencionalpublico":
                        break;
                        // Agregar más casos para otros roles si es necesario
                        default:
                            // Si el rol no coincide con ningún caso, mostrar un mensaje de error
                            MessageBox.Show("Rol no reconocido. No se pudo abrir el formulario correspondiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos. Por favor, verifique sus credenciales.", "Inicio de Sesión Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }



        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Registrarse_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show(this);
            Hide();
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pbMostrar_Click(object sender, EventArgs e)
        {
            pbOcultar.BringToFront();
            txtPassword.PasswordChar = '\0';
        }

        private void pbOcultar_Click(object sender, EventArgs e)
        {
            pbMostrar.BringToFront();
           txtPassword.PasswordChar = '*';
        }
    }
}

