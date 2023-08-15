using Persistencia;
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
    public partial class AbmUsuarios : Form
    {
        private DatosU datosU;
        private UserModel userModel;
        public AbmUsuarios()
        {
            InitializeComponent();
            datosU = new DatosU();
            userModel = new UserModel();
        }



        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string usuario = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;
            string rol = cbRoles.SelectedItem?.ToString();// para verificar si no es nuloantes de llamar al metodo tostring

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(rol))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            datosU.GuardarUsuario(usuario, contraseña, rol);
            MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos y actualizar el DataGridView
            LimpiarCampos();
            CargarUsuarios();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                string usuario = dgvUsuarios.SelectedRows[0].Cells["Usuario"].Value.ToString();

                try
                {
                    userModel.EliminarUsuario(usuario);
                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los campos y actualizar el DataGridView
                    LimpiarCampos();
                    CargarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AbmUsuarios_Load(object sender, EventArgs e)
        {
            List<string> roles = datosU.ObtenerRoles();
            cbRoles.DataSource = roles;
            CargarUsuarios();
        }

        private void LimpiarCampos()
        {
            txtNombreUsuario.Text = "";
            txtContraseña.Text = "";
            cbRoles.SelectedIndex = -1; // Limpiar selección del ComboBox
        }


        private void CargarUsuarios()
        {
            DataTable usuarios = datosU.ObtenerUsuarios();
            dgvUsuarios.DataSource = usuarios;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string rol = txtBuscarRol.Text;
            DataTable usuariosFiltrados = datosU.ObtenerUsuariosPorRol(rol);

            dgvUsuarios.DataSource = usuariosFiltrados;
        }
    }
}
