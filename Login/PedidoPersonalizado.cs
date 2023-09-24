using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class PedidoPersonalizado : Form
    {
        private UserModel userModel = new UserModel();


        public PedidoPersonalizado()
        {
            InitializeComponent();
            CargarViandasDisponibles();
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void CargarViandasDisponibles()
        {
            List<string> viandas = userModel.ObtenerNombresViandas();

            // Llena el ListBox lbViandas con las viandas disponibles
            lbViandas.DataSource = viandas;
        }






        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show(this);
            Hide();
        }

        private void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            if (lbViandas.SelectedItem != null)
            {
                string viandaSeleccionada = lbViandas.SelectedItem.ToString();

                // Agrega la vianda seleccionada al carrito
                lbCarrito.Items.Add(viandaSeleccionada);
            }
        }

        private void btnQuitarDelCarrito_Click(object sender, EventArgs e)
        {
            if (lbCarrito.SelectedItem != null)
            {
                // Remueve la vianda seleccionada del carrito
                lbCarrito.Items.Remove(lbCarrito.SelectedItem);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
