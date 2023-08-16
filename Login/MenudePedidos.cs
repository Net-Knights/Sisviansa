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
        private DatosU datosU;
        public MenudePedidos()
        {
            InitializeComponent();
            userModel = new UserModel();
            datosU = new DatosU();
            CargarEstadosProduccion();
            CargarDatosMenu();
            //CargarPacksConMenus();

        }
        private void CargarDatosMenu()
        {
            try
            {
                List<string> tiposMenu = userModel.ObtenerInfoMenu();
                cbTipomenu.DataSource = tiposMenu;
                cbTipomenu.SelectedIndex = -1; // Deja el ComboBox en blanco al principio.
                cbTipomenuLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información del menú: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarViandasPorMenu(string menu)
        {
            try
            {
                DataTable viandasTable = userModel.ObtenerViandasPorMenu(menu);
                cbViandas.DataSource = viandasTable;
                cbViandas.DisplayMember = "Nombre_Vianda";
                cbViandas.ValueMember = "IdVianda";
                cbTipomenu.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las viandas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenudePedidos_Load(object sender, EventArgs e)
        {
            CargarDatosMenu();

        }

        private void cbTipomenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipomenu.SelectedItem != null)
            {
                string menuSeleccionado = cbTipomenu.SelectedItem.ToString();
                CargarViandasPorMenu(menuSeleccionado);

                // Ahora también cargamos los packs asociados al menú seleccionado
                CargarPacksAsociadosAMenu(menuSeleccionado);
            }
            else
            {
                cbPacks.DataSource = null;
            }
        }

        private void cbViandas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarEstadosProduccion()
        {

        }
        private void ActualizarStock()
        {

        }

        private void btnVerificarStock_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

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
            
        }

        

        private void CargarPacksAsociadosAMenu(string menuSeleccionado)
        {
            try
            {
                int idMenuSeleccionado = datosU.ObtenerIdMenuPorNombre(menuSeleccionado);
                DataTable packsTable = datosU.ObtenerPacksAsociadosAMenu(idMenuSeleccionado);

                cbPacks.DisplayMember = "NombrePack";
                cbPacks.ValueMember = "IdPack";
                cbPacks.DataSource = packsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los packs asociados al menú: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

