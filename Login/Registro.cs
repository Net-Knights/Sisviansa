using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Logica;
using MySql.Data.MySqlClient;
using Persistencia;
using RegistroUsuarios.Entities;



namespace Login
{
    public partial class Registro : Form
    {

        private UserModel userModel;
        private DatosU datosU;
        private ToolTip toolTip; // Variable para el control ToolTip

        public Registro()
        {
            InitializeComponent();
            userModel = new UserModel();
            datosU = new DatosU();
            txtContraseña.PasswordChar = '*';
            toolTip = new ToolTip();

        }





        private void btnRegistrar_Click_1(object sender, EventArgs e)

        {
            try
            {
                string mail = txtCorreoElectronico.Text;
                string telefono = txtTelefono.Text;
                string direccion = txtDireccion.Text;
                string ci = txtCI.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string usuario = txtNombreUsuario.Text;
                string contraseña = txtContraseña.Text;

                string resultadoValidacion = userModel.ValidarCampos(mail, telefono, direccion, ci, nombre, apellido, usuario, contraseña);

                if (!string.IsNullOrEmpty(resultadoValidacion))
                {
                    MessageBox.Show(resultadoValidacion, "Validación de Campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                datosU.RegistrarCliente(mail, telefono, direccion, ci, nombre, apellido, usuario, contraseña);

                MessageBox.Show("Registro exitoso.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
                LimpiarCampos();
            }
        }



        private void LimpiarCampos()
        {
            txtNombreUsuario.Text = "";
            txtContraseña.Text = "";
            txtCorreoElectronico.Text = "";
            txtCI.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";

        }










        private void btnVolver_Click(object sender, EventArgs e)
        {
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            ventanaPrincipal.Show(this);
            Hide();
        }

        private void pbMostrar_Click(object sender, EventArgs e)
        {
            pbOcultar.BringToFront();
            txtContraseña.PasswordChar = '\0';


        }

        private void pbOcultar_Click(object sender, EventArgs e)
        {
            pbMostrar.BringToFront();
            txtContraseña.PasswordChar = '*';
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar que solo se ingresen letras y que no se exceda de un cierto tamaño (opcional)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) || txtNombre.Text.Length >= 50)
            {
                e.Handled = true;
                toolTip.Show("El nombre solo puede contener letras y debe tener un máximo de 50 caracteres.", txtNombre);
            }
            else
            {
                toolTip.Hide(txtNombre);
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar que solo se ingresen letras y que no se exceda de un cierto tamaño (opcional)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) || txtApellido.Text.Length >= 50)
            {
                e.Handled = true;
                toolTip.Show("El apellido solo puede contener letras y debe tener un máximo de 50 caracteres.", txtApellido);
            }
            else
            {
                toolTip.Hide(txtApellido);
            }
        }

        private void txtCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar que solo se ingresen números y que no se exceda de 7 dígitos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || txtCI.Text.Length >= 8)
            {
                e.Handled = true;
                toolTip.Show("La CI solo puede contener números y debe tener un máximo de 7 dígitos.", txtCI);
            }
            else
            {
                toolTip.Hide(txtCI);
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar que solo se ingresen números y que no se exceda de 9 dígitos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || txtTelefono.Text.Length >= 9)
            {
                e.Handled = true;
                toolTip.Show("El teléfono solo puede contener números y debe tener un máximo de 9 dígitos.", txtTelefono);
            }
            else
            {
                toolTip.Hide(txtTelefono);
            }
        }
    }
}






