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
        private bool cbTipomenuLoaded = false;
        private bool cbEstadoProduccionLoeaded = false;
        private DatosU datosU;
        private DatosP datosP;
        public MenudePedidos()
        {
            InitializeComponent();
            userModel = new UserModel();
            datosU = new DatosU();

            CargarDatosMenu();



        }
        private void CargarDatosMenu()
        {
            try
            {
                List<string> tiposMenu = userModel.ObtenerInfoMenu();
                if (tiposMenu != null)
                {
                    cbTipomenu.DataSource = tiposMenu;
                    cbTipomenu.SelectedIndex = -1;
                    cbTipomenuLoaded = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información del menú: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarPacksConMenus(int idMenu)
        {
            try
            {
                DataTable packsTable = datosP.ObtenerPacksPorMenu(idMenu);
                List<string> packs = new List<string>();

                foreach (DataRow row in packsTable.Rows)
                {
                    packs.Add(row["NombrePack"].ToString());
                }

                cbPacks.DataSource = packs;
                cbPacks.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los packs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarViandasConMenus(int idMenu)
        {
            try
            {
                DataTable viandasTable = datosP.ObtenerViandasPorMenu(idMenu);
                List<string> viandas = new List<string>();

                foreach (DataRow row in viandasTable.Rows)
                {
                    viandas.Add(row["Nombre_Vianda"].ToString());
                }

                cbViandas.DataSource = viandas;
                cbViandas.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las viandas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenudePedidos_Load(object sender, EventArgs e)
        {
            CargarDatosMenu();
            CargarComboBoxEstadosProduccion();
            CargarDatosIntegra();


        }
        private void CargarViandasDePack(int idPack)
        {
            lbViandasPacks.Items.Clear();

            try
            {
                // Llama a la capa lógica para obtener las viandas asociadas al pack
                List<string> viandas = userModel.ObtenerViandasDePack(idPack);

                // Agrega las viandas al ListBox
                lbViandasPacks.Items.AddRange(viandas.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las viandas del pack: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbTipomenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipomenuLoaded && cbTipomenu.SelectedItem != null)
            {
                // Obtener el ID del menú seleccionado
                string nombreMenu = cbTipomenu.SelectedItem.ToString();
                int idMenu = userModel.ObtenerIdMenuPorNombre(nombreMenu);

                if (idMenu != -1)
                {
                    // Cargar los packs y las viandas asociadas al menú seleccionado
                    CargarPacksConMenus(idMenu);
                    CargarViandasConMenus(idMenu);
                }
                else
                {
                    // No se encontró el menú seleccionado, limpia los ComboBox de packs y viandas
                    cbPacks.DataSource = null;
                    cbViandas.DataSource = null;
                }
            }
        }

        private void CargarComboBoxEstadosProduccion()
        {
            try
            {
                List<string> estadosProduccion = userModel.ObtenerEstadosProduccion();
                if (estadosProduccion != null)
                {
                    cbEstadoProduccion.DataSource = estadosProduccion;
                    cbEstadoProduccion.SelectedIndex = -1;
                    cbEstadoProduccionLoeaded = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información de los estados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }
        private void cbViandas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void btnVerificarStock_Click(object sender, EventArgs e)
        {
            // Obtener el Id del menú seleccionado
            string nombreMenu = cbTipomenu.SelectedItem.ToString();
            int idMenu = userModel.ObtenerIdMenuPorNombre(nombreMenu);

            // Consultar el stock real en la base de datos
            int stockReal = userModel.ObtenerStockReal(idMenu);

            // Mostrar el stock real en el TextBox
            txtStock.Text = stockReal.ToString();

            // Verificar si el stock real es menor o igual al stock mínimo
            int stockMinimo = userModel.ObtenerStockMinimo(idMenu);
            if (stockReal <= stockMinimo)
            {
                MessageBox.Show("No hay stock.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores seleccionados y/o ingresados en el formulario
                string nombrePack = cbPacks.SelectedItem.ToString();
                string infoMenu = cbTipomenu.SelectedItem.ToString();
                int nroCliente = int.Parse(txtNroclienteb.Text);
                int cantidadViandas = (int)numCantidadViandas.Value;
                string estado = cbEstadoProduccion.SelectedItem.ToString();

                // Obtener el IdMenu correspondiente al valor seleccionado en el ComboBox cbTipomenu
                int idMenu = userModel.ObtenerIdMenuPorNombre(infoMenu);

                // Obtener el valor del stock del TextBox txtStock
                int stock = int.Parse(txtStock.Text);

                // Llamar al método en la capa de lógica para agregar la información a la base de datos
                userModel.AgregarIntegra(idMenu, nombrePack, infoMenu, nroCliente, cantidadViandas, estado, stock);

                // Mostrar un mensaje de éxito
                MessageBox.Show("Pedido agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar el formulario o realizar otras acciones necesarias después de agregar
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException is MySql.Data.MySqlClient.MySqlException)
                {
                    var mysqlEx = (MySql.Data.MySqlClient.MySqlException)ex.InnerException;

                    if (mysqlEx.Number == 1062) // Número de error para clave duplicada
                    {
                        MessageBox.Show("Ya existe un pedido con la misma cantidad de viandas. Puede actualizar el pedido existente si es necesario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error al agregar el pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void LimpiarFormulario()
        {
            // Agrega aquí el código para limpiar los campos del formulario si es necesario
            // Por ejemplo:
            cbTipomenu.SelectedIndex = -1;
            cbPacks.SelectedIndex = -1;
            txtNroclienteb.Clear();
            numCantidadViandas.Value = 0;
            cbEstadoProduccion.SelectedIndex = -1;
        }

        private void cbTipomenu_DropDown(object sender, EventArgs e)
        {
            if (!cbTipomenuLoaded)
            {
                CargarDatosMenu();
            }
        }

        private void cbPacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPacks.SelectedItem != null)
            {
                string nombrePack = cbPacks.SelectedItem.ToString();
                int idPack = userModel.ObtenerIdPackPorNombre(nombrePack);

                if (idPack != -1)
                {
                    // Cargar las viandas asociadas al pack seleccionado
                    CargarViandasDePack(idPack);
                }
                else
                {

                    lbViandasPacks.Items.Clear();
                }
            }
        }


        private void CargarDatosIntegra()
        {
            try
            {
                // Llamar al método de la capa lógica para obtener los datos de integra
                DataTable dataTable = userModel.ObtenerDatosIntegra();

                // Asignar los datos al DataGridView dgvPedidos
                dgvPedidos.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de integra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            int nroCliente;
            if (int.TryParse(txtNrclienteBuscar.Text, out nroCliente))
            {
                try
                {
                    DataTable dataTable = datosP.BuscarPedidosPorCliente(nroCliente);
                    dgvPedidos.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar pedidos: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número de cliente válido.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            

            if (dgvPedidos.SelectedRows.Count > 0)
            {
                // Obtener el NroPedido seleccionado en el DataGridView
                int nroPedidoSeleccionado = Convert.ToInt32(dgvPedidos.SelectedRows[0].Cells["NroPedido"].Value);

                // Llamar al método de la capa lógica para eliminar los datos en las tablas
                UserModel userModel = new UserModel();
                userModel.EliminarDatosPedido(nroPedidoSeleccionado);

                // Recargar los datos en el DataGridView después de la eliminación
                CargarDatosIntegra();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }





}




