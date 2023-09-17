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
            datosP = new DatosP();

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

        private void cbTipomenu_DropDown(object sender, EventArgs e)
        {
            if (!cbTipomenuLoaded)
            {
                CargarDatosMenu();
            }
        }









        private void MenudePedidos_Load(object sender, EventArgs e)
        {

            CargarDatosMenu();

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




        private void btnVerificarStock_Click(object sender, EventArgs e)
        {
          
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           

        }
        private void LimpiarFormulario()
        {
            // Agrega aquí el código para limpiar los campos del formulario si es necesario
            // Por ejemplo:
            cbTipomenu.SelectedIndex = -1;
        }

       

        private void cbPacks_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


      

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            

           
        }
    }





}




