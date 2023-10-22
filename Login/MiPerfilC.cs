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


        public void SetNroCliente(int nroCliente)
        {
            this.nroCliente = nroCliente;
        }

        private void MiPerfilC_Load(object sender, EventArgs e)
        {
          

            DataTable datosCliente = userModel.ObtenerDatosCliente(nroCliente);

            if (datosCliente.Rows.Count > 0)
            {
                DataRow row = datosCliente.Rows[0];
                
                lAutorizacion.Text = row["Autorizacion"].ToString();
                lEmail.Text = row["Mail"].ToString();
                lTelefono.Text = row["Telefono"].ToString();
                lDireccion.Text = row["Direccion"].ToString();
                lCi.Text = row["CI"].ToString();
                lNombre.Text = row["Nombre"].ToString();
                lApellido.Text = row["Apellido"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el cliente especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Cerrar el formulario si no se encuentran datos para el cliente
            }
        }




    }
}

