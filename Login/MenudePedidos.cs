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

        //private void CargarViandasPorMenu(string menu)
        //{
        //    try
        //    {
        //        DataTable viandasTable = userModel.ObtenerViandasPorMenu(menu);
        //        cbViandas.DataSource = viandasTable;
        //        cbViandas.SelectedIndex = -1;
        //        cbViandas.DisplayMember = "Nombre_Vianda";
        //        cbViandas.ValueMember = "IdVianda";

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cargar las viandas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void MenudePedidos_Load(object sender, EventArgs e)
        {
            CargarDatosMenu();

        }

        private void cbTipomenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipomenu.SelectedItem != null)
            {
                string menuSeleccionado = cbTipomenu.SelectedItem.ToString();
                CargarPacksPorMenu(menuSeleccionado);
                CargarViandasPorMenu(menuSeleccionado); // Cargar viandas asociadas al menú
            }
            else
            {
                cbPacks.DataSource = null;
                cbViandas.DataSource = null;
            }
        }
        private void CargarPacksPorMenu(string menuSeleccionado)
        {
            try
            {
                // Obtener la lista de packs asociados al menú seleccionado desde la capa lógica
                List<string> packs = userModel.ObtenerPacksPorMenu(menuSeleccionado);

                // Configurar el ComboBox cbPacks con la lista de packs
                cbPacks.DataSource = packs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los packs asociados al menú: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarViandasPorMenu(string menuId)
        {
            try
            {
                DataTable viandasTable = userModel.ObtenerViandasPorMenu(menuId);
                cbViandas.DataSource = viandasTable;
                cbViandas.DisplayMember = "Nombre_Vianda"; // La columna que se mostrará en el ComboBox
                cbViandas.ValueMember = "IdVianda";        // El valor asociado a la selección
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las viandas asociadas al menú: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbViandas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CargarViandasPorPack(string packId)
        {
            List<string> viandas = userModel.ObtenerViandasPorPack(packId);
            lbViandasPacks.DataSource = viandas;
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
            if (cbPacks.SelectedItem != null)
            {
                string packSeleccionado = cbPacks.SelectedItem.ToString();
                CargarViandasPorPack(packSeleccionado); // Cargar viandas asociadas al pack
            }
            else
            {
                lbViandasPacks.DataSource = null;
            }
        }

    }



        

    }




