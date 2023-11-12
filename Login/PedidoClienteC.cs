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
    public partial class PedidoClienteC : Form
    {
        private UserModel userModel;
        private bool cbTipomenuLoaded = false;
        private bool cbEstadoProduccionLoeaded = false;
        private DatosU datosU;
        private DatosP datosP;
        private List<string> viandasSeleccionadas = new List<string>(); // Variable para mantener las viandas seleccionadas


        public PedidoClienteC()
        {




            InitializeComponent();
        }
     

        private void CargarDatosMenu()
        {

        }
        private void CargarPacksConMenus(int idMenu)
        {

        }

        private void cbTipomenu_DropDown(object sender, EventArgs e)
        {

        }
        private void CargarViandasEnListBox(string nombreMenu, string nombrePack)
        {

        }


        private void CargarViandasEnComboBox()
        {

        }

        private void PedidoClienteC_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Este formulario está en mantenimiento.");
        }

        private void CargarViandasSeleccionadas()
        {

        }

        private void cbTipomenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }


        private void CargarTodosLosPacksEnDataGridView()
        {

        }

        private void cbPacks_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        //private bool EsPackPersonalizado(string packNombre)
        //{

        //}


    }
}
