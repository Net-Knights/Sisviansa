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
using System.IO;

namespace Login
{
    public partial class PedidoPersonalizado : Form
    {
        private UserModel userModel = new UserModel();
        private List<string> viandasSeleccionadas = new List<string>();

        public PedidoPersonalizado(List<string> viandasSeleccionadas)
        {
            InitializeComponent();
            this.viandasSeleccionadas = viandasSeleccionadas; // Inicializa la lista con los datos pasados
            CargarViandasDisponibles();
        }
        public void SetViandasSeleccionadas(List<string> viandasSeleccionadas)
        {
            this.viandasSeleccionadas = viandasSeleccionadas;
        }
        public List<string> GetViandasSeleccionadas()
        {
            return viandasSeleccionadas;
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
            this.Close();
        }

        private void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            // Agregar vianda al carrito
            string viandaSeleccionada = lbViandas.SelectedItem as string;
            if (!string.IsNullOrEmpty(viandaSeleccionada) && !viandasSeleccionadas.Contains(viandaSeleccionada))
            {
                viandasSeleccionadas.Add(viandaSeleccionada);
                lbCarrito.Items.Add(viandaSeleccionada);
            }
        }

        private void btnQuitarDelCarrito_Click(object sender, EventArgs e)
        {
            // Eliminar vianda del carrito
            string viandaSeleccionada = lbCarrito.SelectedItem as string;
            if (!string.IsNullOrEmpty(viandaSeleccionada))
            {
                viandasSeleccionadas.Remove(viandaSeleccionada);
                lbCarrito.Items.Remove(viandaSeleccionada);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PedidoPersonalizado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Visible = true; // Restaura la visibilidad de MenudePedidos
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Ruta completa del archivo
            string filePath = @"C:\Users\sergi\source\repos\Net-Knights\Sisviansa\viandas_seleccionadas.txt";

            // Guardar las viandas seleccionadas en un archivo
            try
            {
                // Crear un archivo de texto o sobrescribir si ya existe
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string vianda in viandasSeleccionadas)
                    {
                        writer.WriteLine(vianda);
                    }
                }

                MessageBox.Show("Viandas seleccionadas guardadas con éxito.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar las viandas seleccionadas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
    }

