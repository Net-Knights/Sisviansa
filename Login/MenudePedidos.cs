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
    public partial class MenudePedidos : Form
    {
        private UserModel userModel;
        private DatosU datosU;
        public MenudePedidos()
        {
            InitializeComponent();
            userModel = new UserModel();
            datosU = new DatosU();  
            CargarEstadosProduccion();
        }

        private void MenudePedidos_Load(object sender, EventArgs e)
        {
            List<string> menus = userModel.ObtenerMenus();
            cbTipomenu.DataSource = menus;
        }

        private void cbTipomenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string menuSeleccionado = cbTipomenu.SelectedItem.ToString();
            List<string> viandas = userModel.ObtenerViandasPorMenu(menuSeleccionado);
            cbViandas.DataSource = viandas;

            ActualizarStock();
        }

        private void cbViandas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarStock();
        }

        private void CargarEstadosProduccion()
        {
            List<string> estadosProduccion = datosU.ObtenerEstadosProduccion();

            // Asignar la lista al ComboBox y seleccionar el índice 0
            cbEstadoProduccion.DataSource = estadosProduccion;
            cbEstadoProduccion.SelectedIndex = 0;
        }
        private void ActualizarStock()
        {
            if (cbTipomenu.SelectedItem == null || cbViandas.SelectedItem == null)
            {
                return;
            }

            string menuSeleccionado = cbTipomenu.SelectedItem.ToString();
            string viandaSeleccionada = cbViandas.SelectedItem.ToString();

            int stockDisponible = userModel.ObtenerStockDisponible(menuSeleccionado, viandaSeleccionada);
            int stockMinimo = userModel.ObtenerStockMinimo(menuSeleccionado, viandaSeleccionada);

            txtStock.Text = stockDisponible.ToString();

            if (stockDisponible < stockMinimo)
            {
                lblMensajeStock.Text = "Stock insuficiente";
                lblMensajeStock.ForeColor = Color.Red;
                btnAgregar.Enabled = false;
            }
            else
            {
                lblMensajeStock.Text = "Stock suficiente";
                lblMensajeStock.ForeColor = Color.Green;
                btnAgregar.Enabled = true;
            }
        }

        private void btnVerificarStock_Click(object sender, EventArgs e)
        {
            try
            {
                string menuSeleccionado = cbTipomenu.SelectedItem?.ToString();
                string viandaSeleccionada = cbViandas.SelectedItem?.ToString();

                bool stockSuficiente = userModel.VerificarSeleccionViandaMenu(menuSeleccionado, viandaSeleccionada);

                if (stockSuficiente)
                {
                    MessageBox.Show("Stock suficiente para realizar el pedido.", "Verificación de Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Stock insuficiente para realizar el pedido.", "Verificación de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string menuSeleccionado = cbTipomenu.SelectedItem.ToString();
            string viandaSeleccionada = cbViandas.SelectedItem.ToString();
            int cantidadViandas = Convert.ToInt32(numCantidadViandas.Value);
            int nroCliente = Convert.ToInt32(txtNroclienteb.Text); // Obtener el número de cliente

            int nroPedido = userModel.GenerarNumeroPedido();
            int nroCaja = userModel.GenerarNumeroCaja();
            string estadoProduccion = cbEstadoProduccion.SelectedItem.ToString();
            int stockReal = userModel.ObtenerStockDisponible(menuSeleccionado, viandaSeleccionada);

            userModel.ActualizarStock(menuSeleccionado, viandaSeleccionada, cantidadViandas);
            userModel.AgregarPedidoIntegra(viandaSeleccionada, menuSeleccionado, nroPedido, estadoProduccion, stockReal, cantidadViandas, nroCaja);

            // Agregar el pedido al DataGridView
            dgvPedidos.Rows.Add(nroPedido, viandaSeleccionada, menuSeleccionado, estadoProduccion, stockReal, cantidadViandas, nroCaja, nroCliente);

            MessageBox.Show("Pedido agregado exitosamente.", "Agregar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

