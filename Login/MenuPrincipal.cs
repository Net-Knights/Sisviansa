using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Login
{
    public partial class MenuPrincipal : Form
    {
        private string tipoUsuario;

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        public MenuPrincipal(string tipoUsuario)
        {
            this.tipoUsuario = tipoUsuario;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int LX, LY;
        private void BtnMax_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            LX = this.Location.X;
            LY = this.Location.Y;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            BtnMax.Visible = false;
            BtnRestaurar.Visible = true;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1027, 535);
            this.Location = new Point(LX, LY);
            BtnRestaurar.Visible = false;
            BtnMax.Visible = true;
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            ventanaPrincipal.Show(this);
            Hide();
        }
        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void BtnPedidos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new MenudePedidos());
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AbmUsuarios());
        }

        private void BtnZonas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormZonas());
        }

        private void BtnTransporte_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormTransoporte());
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new AbmCliente());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormFacturas());
        }
    }
}
