using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using RegistroUsuarios.Entities;

namespace Login
{
    public partial class EditDataClientec : Form
    {

        private UserModel userModel;
        public EditDataClientec()
        {
            userModel = new UserModel();
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nuevoApellido = txtSurName.Text;
            string nuevoCI = txtCi.Text;
            string nuevaDireccion = txtAddress.Text;
            string nuevoTelefono = txtPhone.Text;
            string nuevoMail = txtEmail.Text;

            try
            {
                // Obtén el nombre de usuario desde LoginGeneral
                string nombreUsuario = LoginGeneral.NombreUsuarioLogueado;

                bool actualizacionExitosa = userModel.ActualizarDatosCliente(nombreUsuario, nuevoApellido, nuevoCI, nuevaDireccion, nuevoTelefono, nuevoMail);

                if (actualizacionExitosa)
                {
                    MessageBox.Show("Datos actualizados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudieron actualizar los datos. Por favor, verifica la información proporcionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la presentación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

