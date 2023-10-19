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
            // No es necesario cargar los departamentos al inicio, ya que el ComboBox estará en blanco.
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

        // Método para ocultar todos los PictureBox
        private void OcultarPictureBoxs()
        {
            Zona1M.Visible = false;
            Zona2M.Visible = false;
            Zona3M.Visible = false;
            Zona4M.Visible = false;
            Zona5M.Visible = false;
            Zona6M.Visible = false;
            Zona7M.Visible = false;
        }

        // Método para mostrar el PictureBox según la zona seleccionada
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
            }
        }
    }
}


