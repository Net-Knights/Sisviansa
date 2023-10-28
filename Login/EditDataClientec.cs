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
                bool exito = userModel.ActualizarDatosCliente(nuevoApellido, nuevoCI, nuevaDireccion, nuevoTelefono, nuevoMail);

                if (exito)
                {
                    MessageBox.Show("Los datos se actualizaron con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudieron actualizar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

