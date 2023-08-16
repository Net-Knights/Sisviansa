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

        }
        private void CargarDatosMenu()
        {
            try
            {
                List<string> tiposMenu = userModel.ObtenerInfoMenu();
                cbTipomenu.DataSource = tiposMenu;
                cbTipomenu.SelectedIndex = -1; // Deja el ComboBox en blanco al principio.
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
            if (cbPacks.SelectedItem != null)
            {
                int idPackSeleccionado = Convert.ToInt32(cbPacks.SelectedValue);
                DataTable menusTable = userModel.ObtenerMenusAsociadosAPack(idPackSeleccionado);
                lbMenusAsociados.DataSource = menusTable;
                lbMenusAsociados.DisplayMember = "Infomenu"; // Asegurarse de cambiar a la columna correcta en tu tabla Menú
            }
        }
    }
}

