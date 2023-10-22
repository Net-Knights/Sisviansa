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

    public partial class FormZonas : Form
    {
        private UserModel userModel = new UserModel();
        private bool departamentosCargados = false;

        public FormZonas()
        {
            InitializeComponent();

            // Evento cuando se carga el formulario
            this.Load += FormZonas_Load;

            // Eventos de ComboBox
            cbDepar.SelectedIndexChanged += cbDepar_SelectedIndexChanged;
            cbDepar.DropDown += cbDepar_DropDown;
            cbZona.SelectedIndexChanged += cbZona_SelectedIndexChanged;

            // Limpia los ComboBox al inicio
            cbDepar.Items.Clear();
            cbZona.Items.Clear();
        }

        private void FormZonas_Load(object sender, EventArgs e)
        {

        }

        private void CargarDepartamentos()
        {
            if (!departamentosCargados)
            {
                // Rellenar el ComboBox de Departamentos
                var departamentos = userModel.ObtenerDepartamentos();
                cbDepar.DataSource = departamentos;

                // Asociar los identificadores de departamentos en segundo plano
                cbDepar.DisplayMember = "NombreDepartamento";
                departamentosCargados = true;
            }
        }

        private void cbDepar_DropDown(object sender, EventArgs e)
        {
            // Al desplegar el ComboBox, cargar los departamentos si no se han cargado previamente
            if (!departamentosCargados)
            {
                CargarDepartamentos();
            }
        }

        private void cbDepar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el ID del departamento seleccionado
            int idDepartamento = userModel.ObtenerIdDepartamentoPorNombre(cbDepar.SelectedItem.ToString());

            // Rellenar el ComboBox de Zonas en base al ID del departamento
            var zonaIds = userModel.ObtenerIdsZonasPorDepartamento(idDepartamento);
            cbZona.DataSource = zonaIds;

            // Ocultar todos los PictureBox
            OcultarPictureBoxs();
        }

        private void cbZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar el PictureBox correspondiente a la zona seleccionada
            string zonaSeleccionada = cbZona.SelectedItem.ToString();
            MostrarPictureBox(zonaSeleccionada);
        }


        private void OcultarPictureBoxs()
        {
            Zona1M.Visible = false;
            Zona2M.Visible = false;
            Zona3M.Visible = false;
            Zona4M.Visible = false;
            Zona5M.Visible = false;
            Zona6M.Visible = false;
            Zona7M.Visible = false;
            Zona8Tac.Visible = false;
            Zona9Tac.Visible = false;
            Zona10A.Visible = false;
            Zona11A.Visible = false;
            Zona12TyT.Visible = false;
            Zona13TyT.Visible = false;
            Zona14C.Visible = false;
            Zona15C.Visible = false;
            Zona16Mal.Visible = false;
            Zona17Mal.Visible = false;
            Zona18Cerr.Visible = false;
            Zona19Cerr.Visible = false;
            Zona20Col.Visible = false;
            Zona21Col.Visible = false;
            Zona22D.Visible = false;
            Zona23D.Visible = false;
            Zona24Fl.Visible = false;
            Zona25Fl.Visible = false;
            Zona26Florida.Visible = false;
            Zona27Florida.Visible = false;
            Zona28Lav.Visible = false;
            Zona29Lav.Visible = false;
            Zona30P.Visible = false;
            Zona31P.Visible = false;
            Zona32Rio.Visible = false;
            Zona33Rio.Visible = false;
            Zona34Riv.Visible = false;
            Zona35Riv.Visible = false;
            Zona36Roch.Visible = false;
            Zona37Roch.Visible = false;
            Zona38Sal.Visible = false;
            Zona39Sal.Visible = false;
            Zona40SanJ.Visible = false;
            Zona41SanJ.Visible = false;
            Zona42Sori.Visible = false;
            Zona43Sori.Visible = false;
        }


        private void MostrarPictureBox(string zonaSeleccionada)
        {
            OcultarPictureBoxs();

            switch (zonaSeleccionada)
            {
                case "1":
                    Zona1M.Visible = true;
                    break;
                case "2":
                    Zona2M.Visible = true;
                    break;
                case "3":
                    Zona3M.Visible = true;
                    break;
                case "4":
                    Zona4M.Visible = true;
                    break;
                case "5":
                    Zona5M.Visible = true;
                    break;
                case "6":
                    Zona6M.Visible = true;
                    break;
                case "7":
                    Zona7M.Visible = true;
                    break;
                case "8":
                    Zona8Tac.Visible = true;
                    break;
                case "9":
                    Zona9Tac.Visible = true;
                    break;
                case "10":
                    Zona10A.Visible = true;
                    break;
                case "11":
                    Zona11A.Visible = true;
                    break;
                case "12":
                    Zona12TyT.Visible = true;
                    break;
                case "13":
                    Zona13TyT.Visible = true;
                    break;
                case "14":
                    Zona14C.Visible = true;
                    break;
                case "15":
                    Zona15C.Visible = true;
                    break;
                case "16":
                    Zona16Mal.Visible = true;
                    break;
                case "17":
                    Zona17Mal.Visible = true;
                    break;
                case "18":
                    Zona18Cerr.Visible = true;
                    break;
                case "19":
                    Zona19Cerr.Visible = true;
                    break;
                case "20":
                    Zona20Col.Visible = true;
                    break;
                case "21":
                    Zona21Col.Visible = true;
                    break;
                case "22":
                    Zona22D.Visible = true;
                    break;
                case "23":
                    Zona23D.Visible = true;
                    break;
                case "24":
                    Zona24Fl.Visible = true;
                    break;
                case "25":
                    Zona25Fl.Visible = true;
                    break;
                case "26":
                    Zona26Florida.Visible = true;
                    break;
                case "27":
                    Zona27Florida.Visible = true;
                    break;
                case "28":
                    Zona28Lav.Visible = true;
                    break;
                case "29":
                    Zona29Lav.Visible = true;
                    break;
                case "30":
                    Zona30P.Visible = true;
                    break;
                case "31":
                    Zona31P.Visible = true;
                    break;
                case "32":
                    Zona32Rio.Visible = true;
                    break;
                case "33":
                    Zona33Rio.Visible = true;
                    break;
                case "34":
                    Zona34Riv.Visible = true;
                    break;
                case "35":
                    Zona35Riv.Visible = true;
                    break;
                case "36":
                    Zona36Roch.Visible = true;
                    break;
                case "37":
                    Zona37Roch.Visible = true;
                    break;
                case "38":
                    Zona38Sal.Visible = true;
                    break;
                case "39":
                    Zona39Sal.Visible = true;
                    break;
                case "40":
                    Zona40SanJ.Visible = true;
                    break;
                case "41":
                    Zona41SanJ.Visible = true;
                    break;
                case "42":
                    Zona42Sori.Visible = true;
                    break;
                case "43":
                    Zona43Sori.Visible = true;
                    break;

            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            // Verificar que se han seleccionado departamento, zona y que el número de cliente existe
            if (cbDepar.SelectedItem != null && cbZona.SelectedItem != null && !string.IsNullOrEmpty(txtNroCliente.Text))
            {
                string numeroCliente = txtNroCliente.Text;

                // Comprobar si el número de cliente existe en la base de datos
                if (userModel.ExisteNumeroCliente(numeroCliente))
                {
                    int idZona = Convert.ToInt32(cbZona.SelectedItem);
                    int idDepartamento = userModel.ObtenerIdDepartamentoPorNombre(cbDepar.SelectedItem.ToString());
                    int idCliente = userModel.ObtenerIdClientePorNumero(numeroCliente);

                    // Guardar datos en la tabla 'vive'
                    if (userModel.GuardarVive(idZona, idDepartamento, idCliente))
                    {
                        MessageBox.Show("Datos guardados correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar datos.");
                    }
                }
                else
                {
                    MessageBox.Show("El número de cliente no existe en la base de datos.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un departamento, una zona y proporcionar un número de cliente.");
            }
        }
    }
}


