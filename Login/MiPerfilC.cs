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



        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtNrocliente.Text, out int nroCliente))
                {
                    List<string> datosCliente = userModel.ObtenerDatosClientePorNroCliente(nroCliente);

                    if (datosCliente.Count > 0)
                    {
                        lAutorizacion.Text = datosCliente[0];
                        lEmail.Text = datosCliente[1];
                        lTelefono.Text = datosCliente[2];
                        lDireccion.Text = datosCliente[3];
                        lCi.Text = datosCliente[4];
                        lNombre.Text = datosCliente[5];
                        lApellido.Text = datosCliente[6];

                        // Mostrar los labels
                        lAutorizacion.Visible = true;
                        lEmail.Visible = true;
                        lTelefono.Visible = true;
                        lDireccion.Visible = true;
                        lCi.Visible = true;
                        lNombre.Visible = true;
                        lApellido.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos para ese número de cliente.", "Datos no encontrados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Número de cliente no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            EditDataClientec editForm = new EditDataClientec();
            editForm.Show();
        }
    }
}

