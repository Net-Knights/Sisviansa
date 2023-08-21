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
                DataTable packsTable = datosU.ObtenerPacksPorMenu(idMenu);
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
                DataTable viandasTable = datosU.ObtenerViandasPorMenu(idMenu);
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

        }
        private void CargarViandasDePack(int idPack)
        {
            lbViandasPacks.Items.Clear(); // Limpia el ListBox

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
                string nombrePack = cbPacks.SelectedItem.ToString();
                int idPack = userModel.ObtenerIdPackPorNombre(nombrePack);

                if (idPack != -1)
                {
                    // Cargar las viandas asociadas al pack seleccionado
                    CargarViandasDePack(idPack);
                }
                else
                {
                    // No se encontró el pack seleccionado, limpia el ListBox
                    lbViandasPacks.Items.Clear();
                }
            }
        }

   
    
    
    
    
    }



        

    }




