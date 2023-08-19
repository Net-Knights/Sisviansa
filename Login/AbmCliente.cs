using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Persistencia;

namespace Login
{
    public partial class AbmCliente : Form
    {
        private UserModel userModel;
        private DatosU datosU;
        private DataTable dataTableClientes;

        public AbmCliente()
        {
            InitializeComponent();
            userModel = new UserModel();
            datosU = new DatosU();
            dataTableClientes = new DataTable();

            // Configuración inicial del ComboBox y DataGridView
            cbTipoCliente.Items.AddRange(new string[] { "Comun", "Empresa" });
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            OcultarCampos();

            CargarDatosClientesComunes();

        }
        private void OcultarCampos()
        {
            // Ocultar campos correspondientes a cliente común
            lblNombre.Visible = false;
            lblApellido.Visible = false;
            lblCorreoElectronico.Visible = false;
            lblTelefono.Visible = false;
            lblCi.Visible = false;
            lblDireccion.Visible = false;

            txtNombre.Visible = false;
            txtApellido.Visible = false;
            txtCorreoElectronico.Visible = false;
            txtTelefono.Visible = false;
            txtCI.Visible = false;
            txtDireccion.Visible = false;

            // Ocultar campos correspondientes a cliente empresa
            lblRUT.Visible = false;
            lblNombreEmpresa.Visible = false;
            lblDireccionEmpresa.Visible = false;

            txtRUT.Visible = false;
            txtNombreEmpresa.Visible = false;
            txtDireccionEmpresa.Visible = false;
        }

        private void MostrarCampos(string tipoCliente)
        {
            OcultarCampos();

            if (tipoCliente == "Comun")
            {
                lblNombre.Visible = true;
                lblApellido.Visible = true;
                lblCorreoElectronico.Visible = true;
                lblTelefono.Visible = true;
                lblCi.Visible = true;
                lblDireccion.Visible = true;

                txtNombre.Visible = true;
                txtApellido.Visible = true;
                txtCorreoElectronico.Visible = true;
                txtTelefono.Visible = true;
                txtCI.Visible = true;
                txtDireccion.Visible = true;
            }
            else if (tipoCliente == "Empresa")
            {
                lblRUT.Visible = true;
                lblNombreEmpresa.Visible = true;
                lblDireccionEmpresa.Visible = true;
                lblCorreoElectronico.Visible = true;
                lblTelefono.Visible = true;

                txtRUT.Visible = true;
                txtNombreEmpresa.Visible = true;
                txtDireccionEmpresa.Visible = true;
                txtCorreoElectronico.Visible = true;
                txtTelefono.Visible = true;
            }
        }
        private void CargarDatosClientesComunes()
        {
            DataTable clientesComunes = datosU.ObtenerDatosClientesComunes();

            // Filtrar los resultados para mostrar solo los clientes con el rol de "Común"
            var filteredRows = clientesComunes.AsEnumerable().Where(row => string.Equals(row.Field<string>("Rol"), "Comun", StringComparison.OrdinalIgnoreCase));

            // Crear un nuevo DataTable con las columnas deseadas
            DataTable dataTableClientes = new DataTable();
            dataTableClientes.Columns.Add("NroCliente", typeof(int));
            dataTableClientes.Columns.Add("Autorizacion", typeof(string));
            dataTableClientes.Columns.Add("Mail", typeof(string));
            dataTableClientes.Columns.Add("Telefono", typeof(string));
            dataTableClientes.Columns.Add("Direccion", typeof(string));
            dataTableClientes.Columns.Add("Ci", typeof(string));
            dataTableClientes.Columns.Add("Nombre", typeof(string));
            dataTableClientes.Columns.Add("Apellido", typeof(string));
            dataTableClientes.Columns.Add("Rol", typeof(string)); // Agregar columna para el rol

            // Agregar los datos filtrados al DataTable
            foreach (DataRow row in filteredRows)
            {
                dataTableClientes.Rows.Add(row["NroCliente"], row["Autorizacion"], row["Mail"], row["Telefono"], row["Direccion"], row["Ci"], row["Nombre"], row["Apellido"], row["Rol"]);
            }

            // Asignar el DataTable al DataGridView de clientes
            dgvClientes.DataSource = dataTableClientes;
        }

        // Método para cargar los datos de clientes empresa en dgvEmpresa
        private void CargarDatosClientesEmpresa()
        {
            DataTable clientesEmpresa = datosU.ObtenerDatosClientesEmpresa();
            dgvEmpresa.DataSource = clientesEmpresa;
        }


        private void AbmCliente_Load(object sender, EventArgs e)
        {
            // Cargar todos los datos de las tablas Cliente, Comun, Empresa y login en el DataGridView
            CargarDatosClientesComunes();
            CargarDatosClientesEmpresa();

            // Ajustar el diseño del DataGridView, si es necesario
            // Ejemplo:
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpresa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNroCliente.Text, out int nroCliente))
            {
                // Buscar cliente por NroCliente y mostrar resultados en el DataGridView
                DataTable clienteEncontrado = datosU.BuscarClientePorNroCliente(nroCliente);

                if (clienteEncontrado.Rows.Count > 0)
                {
                   
                    dgvClientes.DataSource = clienteEncontrado;
                }
                else
                {
                    // Si no se encontraron resultados, mostrar un mensaje al usuario
                    MessageBox.Show("No se encontraron resultados para el NroCliente especificado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvClientes.DataSource = null; 
                }
            }
            else
            {
                MessageBox.Show("Ingrese un NroCliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvClientes.DataSource = null; 
            }
        }

        private void cbTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoCliente = cbTipoCliente.SelectedItem.ToString();
            MostrarCampos(tipoCliente);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (cbTipoCliente.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de cliente.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipoCliente = cbTipoCliente.SelectedItem.ToString();
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string correoElectronico = txtCorreoElectronico.Text;
            string telefono = txtTelefono.Text;
            string ci = txtCI.Text;
            string direccion = txtDireccion.Text;
            string rut = txtRUT.Text;
            string nombreEmpresa = txtNombreEmpresa.Text;
            string direccionEmpresa = txtDireccionEmpresa.Text;

            if (rut.Length > 9)
            {
                MessageBox.Show("El RUT de la empresa no puede tener más de 9 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamar al método de la capa de datosU para guardar el cliente
            datosU.GuardarCliente(tipoCliente, nombre, apellido, correoElectronico, telefono, ci, tipoCliente == "Empresa" ? direccionEmpresa : direccion, rut, nombreEmpresa, tipoCliente == "Empresa" ? direccionEmpresa : ""); // Si es Empresa, la dirección de la empresa se guarda en la columna Direccion

            MessageBox.Show("Registro exitoso.");
            CargarDatosClientesComunes();
            CargarDatosClientesEmpresa();

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int nroCliente = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["NroCliente"].Value);
                if (MessageBox.Show("¿Está seguro de que desea eliminar el cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    datosU.EliminarCliente(nroCliente);
                    MessageBox.Show("Cliente eliminado correctamente.");
                    CargarDatosClientesComunes();
                }
            }

            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rbSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSi.Checked)
            {
                ActualizarAutorizacionEnDataGridView(dgvClientes, "Si");
            }
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNo.Checked)
            {
                ActualizarAutorizacionEnDataGridView(dgvClientes, "No");
            }
        }

        private void BtnActualizarAutorizacion_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarAutorizacionEnBaseDeDatos();
                MessageBox.Show("Autorización actualizada correctamente.");
                CargarDatosClientesComunes();
                CargarDatosClientesEmpresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la autorización: " + ex.Message);
            }
        }

        private void rbSiEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSiEmpresa.Checked)
            {
                ActualizarAutorizacionEnDataGridView(dgvEmpresa, "Si");
            }
        }

        private void rbNoEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoEmpresa.Checked)
            {
                ActualizarAutorizacionEnDataGridView(dgvEmpresa, "No");
            }
        }

        private void ActualizarAutorizacionEnDataGridView(DataGridView dgv, string autorizacion)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                row.Cells["Autorizacion"].Value = autorizacion;
            }
        }

        private void ActualizarAutorizacionEnBaseDeDatos()
        {
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                int nroCliente = Convert.ToInt32(row.Cells["NroCliente"].Value);
                string autorizacion = Convert.ToString(row.Cells["Autorizacion"].Value);
                datosU.ActualizarAutorizacionEnBaseDeDatos(nroCliente, autorizacion);
            }

            foreach (DataGridViewRow row in dgvEmpresa.Rows)
            {
                int nroCliente = Convert.ToInt32(row.Cells["NroCliente"].Value);
                string autorizacion = Convert.ToString(row.Cells["Autorizacion"].Value);
                datosU.ActualizarAutorizacionEnBaseDeDatos(nroCliente, autorizacion);
            }
        }
    }
}


