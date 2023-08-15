namespace Login
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            BarraTitulo = new Panel();
            label1 = new Label();
            BtnRestaurar = new PictureBox();
            BtnMin = new PictureBox();
            BtnMax = new PictureBox();
            BtnClose = new PictureBox();
            MenuVertical = new Panel();
            panel4 = new Panel();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            panel8 = new Panel();
            BtnUsuarios = new Button();
            panel7 = new Panel();
            button7 = new Button();
            panel6 = new Panel();
            BtnClientes = new Button();
            panel3 = new Panel();
            BtnTransporte = new Button();
            panel2 = new Panel();
            BtnZonas = new Button();
            panel1 = new Panel();
            BtnPedidos = new Button();
            panelContenedor = new Panel();
            BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BtnRestaurar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BtnMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BtnMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BtnClose).BeginInit();
            MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BarraTitulo
            // 
            BarraTitulo.BackColor = Color.FromArgb(49, 66, 82);
            BarraTitulo.Controls.Add(label1);
            BarraTitulo.Controls.Add(BtnRestaurar);
            BarraTitulo.Controls.Add(BtnMin);
            BarraTitulo.Controls.Add(BtnMax);
            BarraTitulo.Controls.Add(BtnClose);
            BarraTitulo.Dock = DockStyle.Top;
            BarraTitulo.Location = new Point(0, 0);
            BarraTitulo.Name = "BarraTitulo";
            BarraTitulo.Size = new Size(1027, 33);
            BarraTitulo.TabIndex = 0;
            BarraTitulo.MouseDown += BarraTitulo_MouseDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Ink Free", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(336, 7);
            label1.Name = "label1";
            label1.Size = new Size(124, 23);
            label1.TabIndex = 4;
            label1.Text = "Menu Principal";
            // 
            // BtnRestaurar
            // 
            BtnRestaurar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnRestaurar.Image = Properties.Resources.window_restore_icon_144027;
            BtnRestaurar.Location = new Point(942, 0);
            BtnRestaurar.Name = "BtnRestaurar";
            BtnRestaurar.Size = new Size(44, 33);
            BtnRestaurar.SizeMode = PictureBoxSizeMode.Zoom;
            BtnRestaurar.TabIndex = 3;
            BtnRestaurar.TabStop = false;
            BtnRestaurar.Visible = false;
            BtnRestaurar.Click += BtnRestaurar_Click;
            // 
            // BtnMin
            // 
            BtnMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnMin.Image = Properties.Resources._1904666_calculate_close_delete_hide_minimize_minus_remove_122516;
            BtnMin.Location = new Point(901, 0);
            BtnMin.Name = "BtnMin";
            BtnMin.Size = new Size(44, 32);
            BtnMin.SizeMode = PictureBoxSizeMode.Zoom;
            BtnMin.TabIndex = 2;
            BtnMin.TabStop = false;
            BtnMin.Click += BtnMin_Click;
            // 
            // BtnMax
            // 
            BtnMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnMax.Image = Properties.Resources.window_maximize_icon_1812281;
            BtnMax.Location = new Point(942, 0);
            BtnMax.Name = "BtnMax";
            BtnMax.Size = new Size(44, 33);
            BtnMax.SizeMode = PictureBoxSizeMode.Zoom;
            BtnMax.TabIndex = 1;
            BtnMax.TabStop = false;
            BtnMax.Click += BtnMax_Click;
            // 
            // BtnClose
            // 
            BtnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnClose.Image = Properties.Resources._1492790846_9cancel_84247;
            BtnClose.InitialImage = (Image)resources.GetObject("BtnClose.InitialImage");
            BtnClose.Location = new Point(983, 0);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(41, 33);
            BtnClose.SizeMode = PictureBoxSizeMode.Zoom;
            BtnClose.TabIndex = 0;
            BtnClose.TabStop = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // MenuVertical
            // 
            MenuVertical.BackColor = Color.FromArgb(41, 128, 185);
            MenuVertical.Controls.Add(panel4);
            MenuVertical.Controls.Add(button1);
            MenuVertical.Controls.Add(pictureBox1);
            MenuVertical.Controls.Add(panel8);
            MenuVertical.Controls.Add(BtnUsuarios);
            MenuVertical.Controls.Add(panel7);
            MenuVertical.Controls.Add(button7);
            MenuVertical.Controls.Add(panel6);
            MenuVertical.Controls.Add(BtnClientes);
            MenuVertical.Controls.Add(panel3);
            MenuVertical.Controls.Add(BtnTransporte);
            MenuVertical.Controls.Add(panel2);
            MenuVertical.Controls.Add(BtnZonas);
            MenuVertical.Controls.Add(panel1);
            MenuVertical.Controls.Add(BtnPedidos);
            MenuVertical.Dock = DockStyle.Left;
            MenuVertical.Location = new Point(0, 33);
            MenuVertical.Name = "MenuVertical";
            MenuVertical.Size = new Size(169, 502);
            MenuVertical.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(49, 66, 82);
            panel4.Location = new Point(3, 315);
            panel4.Name = "panel4";
            panel4.Size = new Size(10, 32);
            panel4.TabIndex = 18;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources._1486394965_12_bills_80559;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(12, 315);
            button1.Name = "button1";
            button1.Size = new Size(157, 32);
            button1.TabIndex = 17;
            button1.Text = "Facturacion";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_1;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(166, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(49, 66, 82);
            panel8.Location = new Point(3, 157);
            panel8.Name = "panel8";
            panel8.Size = new Size(10, 34);
            panel8.TabIndex = 16;
            // 
            // BtnUsuarios
            // 
            BtnUsuarios.Cursor = Cursors.Hand;
            BtnUsuarios.FlatAppearance.BorderSize = 0;
            BtnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            BtnUsuarios.FlatStyle = FlatStyle.Flat;
            BtnUsuarios.Image = Properties.Resources.Why_Us_80_icon_icons1;
            BtnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            BtnUsuarios.Location = new Point(12, 110);
            BtnUsuarios.Name = "BtnUsuarios";
            BtnUsuarios.Size = new Size(157, 30);
            BtnUsuarios.TabIndex = 15;
            BtnUsuarios.Text = "Usuarios";
            BtnUsuarios.UseVisualStyleBackColor = true;
            BtnUsuarios.Click += BtnUsuarios_Click;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel7.BackColor = Color.FromArgb(49, 66, 82);
            panel7.Location = new Point(3, 468);
            panel7.Name = "panel7";
            panel7.Size = new Size(10, 31);
            panel7.TabIndex = 14;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button7.Cursor = Cursors.Hand;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Image = Properties.Resources.log_out_icon_234084;
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(9, 468);
            button7.Name = "button7";
            button7.Size = new Size(139, 31);
            button7.TabIndex = 13;
            button7.Text = "Cerrar Sesion";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(49, 66, 82);
            panel6.Location = new Point(3, 268);
            panel6.Name = "panel6";
            panel6.Size = new Size(10, 32);
            panel6.TabIndex = 12;
            // 
            // BtnClientes
            // 
            BtnClientes.Cursor = Cursors.Hand;
            BtnClientes.FlatAppearance.BorderSize = 0;
            BtnClientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            BtnClientes.FlatStyle = FlatStyle.Flat;
            BtnClientes.Image = Properties.Resources._3741756_bussiness_ecommerce_marketplace_onlinestore_store_user_108907;
            BtnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            BtnClientes.Location = new Point(12, 268);
            BtnClientes.Name = "BtnClientes";
            BtnClientes.Size = new Size(157, 32);
            BtnClientes.TabIndex = 11;
            BtnClientes.Text = "Clientes";
            BtnClientes.UseVisualStyleBackColor = true;
            BtnClientes.Click += BtnClientes_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(49, 66, 82);
            panel3.Location = new Point(3, 210);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 39);
            panel3.TabIndex = 6;
            // 
            // BtnTransporte
            // 
            BtnTransporte.Cursor = Cursors.Hand;
            BtnTransporte.FlatAppearance.BorderSize = 0;
            BtnTransporte.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            BtnTransporte.FlatStyle = FlatStyle.Flat;
            BtnTransporte.Image = Properties.Resources.Truck_Yellow_icon_icons1;
            BtnTransporte.ImageAlign = ContentAlignment.MiddleLeft;
            BtnTransporte.Location = new Point(12, 210);
            BtnTransporte.Name = "BtnTransporte";
            BtnTransporte.Size = new Size(157, 39);
            BtnTransporte.TabIndex = 5;
            BtnTransporte.Text = "Transporte";
            BtnTransporte.UseVisualStyleBackColor = true;
            BtnTransporte.Click += BtnTransporte_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(49, 66, 82);
            panel2.Location = new Point(3, 110);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 30);
            panel2.TabIndex = 4;
            // 
            // BtnZonas
            // 
            BtnZonas.Cursor = Cursors.Hand;
            BtnZonas.FlatAppearance.BorderSize = 0;
            BtnZonas.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            BtnZonas.FlatStyle = FlatStyle.Flat;
            BtnZonas.Image = Properties.Resources._1496676725_rounded_high_ultra_colour02_maps_846271;
            BtnZonas.ImageAlign = ContentAlignment.MiddleLeft;
            BtnZonas.Location = new Point(12, 157);
            BtnZonas.Name = "BtnZonas";
            BtnZonas.Size = new Size(157, 33);
            BtnZonas.TabIndex = 3;
            BtnZonas.Text = "Zonas";
            BtnZonas.UseVisualStyleBackColor = true;
            BtnZonas.Click += BtnZonas_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(49, 66, 82);
            panel1.Location = new Point(3, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 32);
            panel1.TabIndex = 2;
            // 
            // BtnPedidos
            // 
            BtnPedidos.Cursor = Cursors.Hand;
            BtnPedidos.FlatAppearance.BorderSize = 0;
            BtnPedidos.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            BtnPedidos.FlatStyle = FlatStyle.Flat;
            BtnPedidos.Image = Properties.Resources.Menus;
            BtnPedidos.ImageAlign = ContentAlignment.MiddleLeft;
            BtnPedidos.Location = new Point(12, 57);
            BtnPedidos.Name = "BtnPedidos";
            BtnPedidos.Size = new Size(157, 32);
            BtnPedidos.TabIndex = 1;
            BtnPedidos.Text = "Pedidos";
            BtnPedidos.UseVisualStyleBackColor = true;
            BtnPedidos.Click += BtnPedidos_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(224, 224, 224);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(169, 33);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(858, 502);
            panelContenedor.TabIndex = 2;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1027, 535);
            Controls.Add(panelContenedor);
            Controls.Add(MenuVertical);
            Controls.Add(BarraTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuPrincipal";
            BarraTitulo.ResumeLayout(false);
            BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BtnRestaurar).EndInit();
            ((System.ComponentModel.ISupportInitialize)BtnMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)BtnMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)BtnClose).EndInit();
            MenuVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel BarraTitulo;
        private Panel MenuVertical;
        private Panel panelContenedor;
        private PictureBox BtnMin;
        private PictureBox BtnMax;
        private PictureBox BtnClose;
        private PictureBox BtnRestaurar;
        private PictureBox pictureBox1;
        private Button BtnPedidos;
        private Panel panel1;
        private Panel panel7;
        private Button button7;
        private Panel panel6;
        private Button BtnClientes;
        private Panel panel3;
        private Button BtnTransporte;
        private Panel panel2;
        private Button BtnZonas;
        private Label label1;
        private Button BtnUsuarios;
        private Panel panel8;
        private Panel panel4;
        private Button button1;
    }
}