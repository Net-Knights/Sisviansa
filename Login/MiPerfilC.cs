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
using Persistencia;
using RegistroUsuarios.Entities;

namespace Login
{
    public partial class MiPerfilC : Form
    {

        private UserModel userModel = new UserModel();
        private int nroCliente; // Declare la variable nroCliente aquí

        public MiPerfilC()
        {
            InitializeComponent();
            this.Load += MiPerfilC_Load;


        }




        private void MiPerfilC_Load(object sender, EventArgs e)
        {
            try
            {
                // Obtén el nombre de usuario desde LoginGeneral
                string nombreUsuario = LoginGeneral.NombreUsuarioLogueado;

                List<string> datos = userModel.ObtenerDatosClientePorUsuario(nombreUsuario);

                if (datos.Count > 0)
                {
                    // Mostrar los datos en los labels correspondientes
                    lNroCliente.Text = datos[0];
                    lAutorizacion.Text = datos[1];
                    lEmail.Text = datos[2];
                    lTelefono.Text = datos[3];
                    lDireccion.Text = datos[4];
                    lCi.Text = datos[5];
                    lNombre.Text = datos[6];
                    lApellido.Text = datos[7];
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el usuario especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la presentación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            EditDataClientec editForm = new EditDataClientec();
            editForm.Show();
        }
    }
}

