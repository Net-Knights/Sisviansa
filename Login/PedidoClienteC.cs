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
            userModel = new UserModel();
            datosU = new DatosU();
            datosP = new DatosP();

            CargarDatosMenu();
            cbViandas.SelectedIndex = -1;
            cbViandas.DropDown += (sender, e) => CargarViandasEnComboBox();//utilize un lambda porque puedo dea
            lbViandasPacks.Items.Clear();

            InitializeComponent();
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

        private void PedidoClienteC_Load(object sender, EventArgs e)
        {
            CargarDatosMenu();

            CargarViandasSeleccionadas();

            // Cargar la tabla "packs" en el DataGridView al cargar el formulario
            CargarTodosLosPacksEnDataGridView();
        }

        private void CargarViandasSeleccionadas()
        {
            try
            {
                string filePath = @"C:\Users\sergi\source\repos\Net-Knights\Sisviansa\viandas_seleccionadas.txt";

                if (File.Exists(filePath))
                {
                    // Leer las viandas seleccionadas desde el archivo
                    List<string> viandasSeleccionadas = new List<string>();
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            viandasSeleccionadas.Add(line);
                        }
                    }

                    // Mostrar las viandas en el ListBox correspondiente (lbViandasPacks)
                    lbViandasPacks.Items.AddRange(viandasSeleccionadas.ToArray());
                }
                else
                {
                    // Agregar una vianda predeterminada si el archivo no existe
                    lbViandasPacks.Items.Add("Vianda Predeterminada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las viandas seleccionadas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        //private void btnAgregar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Captura los datos ingresados por el usuario
        //        string tipoMenu = cbTipomenu.SelectedItem.ToString();
        //        string nombrePack = cbPacks.SelectedItem.ToString();
        //        int nroCliente = int.Parse(txtNroclienteb.Text);
        //        int stock = 0; // Inicializamos stock en 0
              

        //        // Determina si el pack es personalizado
        //        bool esPersonalizado = EsPackPersonalizado(nombrePack);

              

        //        // Llama al método ObtenerIdMenuPorNombre para obtener IdMenu
        //        int IdMenu = userModel.ObtenerIdMenuPorNombre(tipoMenu);

        //        if (IdMenu == -1)
        //        {
        //            // Maneja el caso en que no se encontró un IdMenu válido.
        //            MessageBox.Show("No se encontró un menú válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        else
        //        {
                

        //            if (nroPedido > 0)
        //            {
        //                // Mostrar mensaje de éxito
        //                MessageBox.Show($"Pedido agregado con éxito. Número de pedido: {nroPedido}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                // Actualizar el DataGridView con los nuevos datos de la tabla "packs"
        //                CargarTodosLosPacksEnDataGridView();
        //            }
        //            else
        //            {
        //                // Mostrar mensaje de error
        //                MessageBox.Show("Error al agregar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al agregar el pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private void CargarTodosLosPacksEnDataGridView()
        {
            try
            {
                DataTable packsTable = userModel.ObtenerTodosLosPacks();
                dgvPedidos.DataSource = packsTable;
                dgvPedidos.Columns["IdPack"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la tabla packs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    // Oculta MenudePedidos
                    this.Hide();

                    PedidoPersonalizado pedidoPersonalizadoForm = new PedidoPersonalizado(viandasSeleccionadas);
                    pedidoPersonalizadoForm.Owner = this; // Establece la ventana principal como propietaria
                    pedidoPersonalizadoForm.FormClosed += (s, args) =>
                    {
                        // Muestra nuevamente MenudePedidos al cerrar PedidoPersonalizado
                        this.Show();

                        // Recupera las viandas seleccionadas desde la ventana PedidoPersonalizado
                        viandasSeleccionadas = pedidoPersonalizadoForm.GetViandasSeleccionadas();

                        // Actualiza el ListBox lbViandasPacks con las viandas seleccionadas
                        lbViandasPacks.Items.Clear();
                        lbViandasPacks.Items.AddRange(viandasSeleccionadas.ToArray());
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


    }
}
