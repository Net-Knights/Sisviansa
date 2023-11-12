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
            dgvClientes.DataSource = clientesComunes;
        }

        // Método para cargar los datos de clientes empresa en dgvEmpresa
        private void CargarDatosClientesEmpresa()
        {
            DataTable clientesEmpresa = datosU.ObtenerDatosClientesEmpresa();
            dgvEmpresa.DataSource = clientesEmpresa;
        }


        private void AbmCliente_Load(object sender, EventArgs e)
        {
            CargarDatosClientesComunes();
            CargarDatosClientesEmpresa();

            // Ajustar el diseño de los DataGridView, si es necesario
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpresa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            dgvClientes.DataSource = null; // Borrar los datos existentes en dgvClientes
            dgvEmpresa.DataSource = null; // Borrar los datos existentes en dgvEmpresa

            if (int.TryParse(txtNroCliente.Text, out int nroCliente))
            {
                DataTable clienteEncontrado = datosU.BuscarClientePorNroCliente(nroCliente);

                if (clienteEncontrado.Rows.Count > 0)
                {
                    if (clienteEncontrado.Columns.Contains("Nombre") && clienteEncontrado.Rows[0]["Nombre"] != DBNull.Value)
                    {
                        dgvClientes.DataSource = clienteEncontrado;

                        // Ocultar las columnas innecesarias en el dgvClientes
                        dgvClientes.Columns["Rut"].Visible = false;
                        dgvClientes.Columns["NombreEmpresa"].Visible = false;
                    }
                    else if (clienteEncontrado.Columns.Contains("NombreEmpresa") && clienteEncontrado.Rows[0]["NombreEmpresa"] != DBNull.Value)
                    {
                        dgvEmpresa.DataSource = clienteEncontrado;

                        // Ocultar las columnas innecesarias en el dgvEmpresa
                        dgvEmpresa.Columns["Ci"].Visible = false;
                        dgvEmpresa.Columns["Nombre"].Visible = false;
                        dgvEmpresa.Columns["Apellido"].Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados para el NroCliente especificado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un NroCliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoCliente = cbTipoCliente.SelectedItem.ToString();
            MostrarCampos(tipoCliente);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
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

                // Validar el RUT
                if (rut.Length > 9)
                {
                    MessageBox.Show("El RUT de la empresa no puede tener más de 9 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar la CI
                if (ci.Length > 8)
                {
                    MessageBox.Show("La CI no puede tener más de 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar el teléfono
                if (telefono.Length > 9)
                {
                    MessageBox.Show("El teléfono no puede tener más de 9 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                             

                // Llamar al método de la capa de datosU para guardar el cliente
                datosU.GuardarCliente(tipoCliente, nombre, apellido, correoElectronico, telefono, ci, tipoCliente == "Empresa" ? direccionEmpresa : direccion, rut, nombreEmpresa, tipoCliente == "Empresa" ? direccionEmpresa : ""); // Si es Empresa, la dirección de la empresa se guarda en la columna Direccion

                MessageBox.Show("Registro exitoso.");
                CargarDatosClientesComunes();
                CargarDatosClientesEmpresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count > 0)
                {
                    int nroCliente = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["NroCliente"].Value);
                    string tipoCliente = dgvClientes.SelectedRows[0].Cells["Rol"].Value.ToString();

                    if (MessageBox.Show("¿Está seguro de que desea eliminar el cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        userModel.EliminarCliente(nroCliente, tipoCliente);
                        MessageBox.Show("Cliente eliminado correctamente.");
                        CargarDatosClientesComunes();
                    }
                }
                else if (dgvEmpresa.SelectedRows.Count > 0)
                {
                    int nroCliente = Convert.ToInt32(dgvEmpresa.SelectedRows[0].Cells["NroCliente"].Value);
                    string tipoCliente = "Empresa";

                    if (MessageBox.Show("¿Está seguro de que desea eliminar el cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        userModel.EliminarCliente(nroCliente, tipoCliente);
                        MessageBox.Show("Cliente eliminado correctamente.");
                        CargarDatosClientesEmpresa();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


