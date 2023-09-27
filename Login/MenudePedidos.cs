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
            cbViandas.SelectedIndex = -1;
            cbViandas.DropDown += (sender, e) => CargarViandasEnComboBox();//utilize un lambda porque puedo dea
            lbViandasPacks.Items.Clear();

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
                DataTable packsTable = userModel.ObtenerPacksPorMenu(idMenu);
                List<string> packs = new List<string>();

                foreach (DataRow row in packsTable.Rows)
                {
                    packs.Add(row["NombrePack"].ToString());
                }

                // Llena el ComboBox cbPacks con los packs disponibles
                cbPacks.DataSource = packs;
                cbPacks.SelectedIndex = -1; // Deja el ComboBox vacío
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
        private void CargarViandasEnListBox(string nombreMenu, string nombrePack)
        {
            List<string> viandas = userModel.ObtenerViandasPorMenuYPack(nombreMenu, nombrePack);

            lbViandasPacks.Items.Clear();
            lbViandasPacks.Items.AddRange(viandas.ToArray());
        }


        private void CargarViandasEnComboBox()
        {
            List<string> nombresViandas = userModel.ObtenerNombresViandas();

            // Llena el ComboBox cbViandas con los nombres de las viandas
            cbViandas.DataSource = nombresViandas;
        }





        private void MenudePedidos_Load(object sender, EventArgs e)
        {

            CargarDatosMenu();

        }

        private void cbTipomenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipomenu.SelectedItem != null)
            {
                // Obtener el ID del menú seleccionado
                string nombreMenu = cbTipomenu.SelectedItem.ToString();
                int idMenu = userModel.ObtenerIdMenuPorNombre(nombreMenu);

                if (idMenu != -1)
                {
                    // Cargar los packs y las viandas asociadas al menú seleccionado
                    CargarPacksConMenus(idMenu);
                    // Deja el ListBox lbViandaspack vacío hasta que se seleccione un pack
                    lbViandasPacks.Items.Clear();
                }
                else
                {
                    // No se encontró el menú seleccionado, limpia los ComboBox de packs y viandas
                    cbPacks.DataSource = null;
                    cbPacks.SelectedIndex = -1;
                    lbViandasPacks.Items.Clear();
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
            if (cbPacks.SelectedItem != null)
            {
                string selectedMenu = cbTipomenu.SelectedItem.ToString();
                string selectedPack = cbPacks.SelectedItem.ToString();
                CargarViandasEnListBox(selectedMenu, selectedPack);
                if (EsPackPersonalizado(selectedPack))
                {
                    // Oculta MenuPrincipal y MenudePedidos
                    this.Hide();
                    MenuPrincipal menuPrincipal = (MenuPrincipal)this.Owner;
                    if (menuPrincipal != null)
                    {
                        menuPrincipal.Hide();
                    }

                    // Abre la ventana PedidoPersonalizado
                    PedidoPersonalizado pedidoPersonalizadoForm = new PedidoPersonalizado();
                    pedidoPersonalizadoForm.FormClosed += (s, args) => {
                        // Muestra nuevamente MenuPrincipal y MenudePedidos al cerrar PedidoPersonalizado
                        this.Show();
                        if (menuPrincipal != null)
                        {
                            menuPrincipal.Show();
                        }
                    };
                    pedidoPersonalizadoForm.Show();
                }
            }
        }

        private bool EsPackPersonalizado(string packNombre)
        {
            // Define una lista de palabras clave que indican packs personalizados
            List<string> palabrasClavePersonalizado = new List<string>
    {
        "Pack P", // Ejemplo: "Pack P Vegetariano"
        "Pack Personalizado", // Ejemplo: "Pack Personalizado Especial"
        // Agrega aquí más palabras clave si es necesario
    };

            // Verifica si el nombre del pack contiene alguna palabra clave de packs personalizados
            foreach (string palabraClave in palabrasClavePersonalizado)
            {
                if (packNombre.Contains(palabraClave))
                {
                    return true; // El pack es personalizado
                }
            }

            return false; // El pack no es personalizado
        }



        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {



        }
    }





}




