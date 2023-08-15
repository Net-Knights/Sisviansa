namespace Login
{
    partial class FormularioClienteComun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioClienteComun));
            BarraTitulo = new Panel();
            btn_maximizar = new PictureBox();
            btn_restaurar = new PictureBox();
            label1 = new Label();
            btn_minimizar = new PictureBox();
            btn_close = new PictureBox();
            BtnRestaurar = new PictureBox();
            BtnMin = new PictureBox();
            BtnMax = new PictureBox();
            BtnClose = new PictureBox();
            panel1 = new Panel();
            button7 = new Button();
            btn_Perfil = new Button();
            button2 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            panelContenedor = new Panel();
            BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_restaurar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_close).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BtnRestaurar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BtnMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BtnMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BtnClose).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BarraTitulo
            // 
            BarraTitulo.BackColor = Color.FromArgb(49, 66, 82);
            BarraTitulo.Controls.Add(btn_maximizar);
            BarraTitulo.Controls.Add(btn_restaurar);
            BarraTitulo.Controls.Add(label1);
            BarraTitulo.Controls.Add(btn_minimizar);
            BarraTitulo.Controls.Add(btn_close);
            BarraTitulo.Controls.Add(BtnRestaurar);
            BarraTitulo.Controls.Add(BtnMin);
            BarraTitulo.Controls.Add(BtnMax);
            BarraTitulo.Controls.Add(BtnClose);
            BarraTitulo.Dock = DockStyle.Top;
            BarraTitulo.Location = new Point(0, 0);
            BarraTitulo.Name = "BarraTitulo";
            BarraTitulo.Size = new Size(1027, 33);
            BarraTitulo.TabIndex = 1;
            BarraTitulo.MouseDown += BarraTitulo_MouseDown;
            // 
            // btn_maximizar
            // 
            btn_maximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_maximizar.Image = Properties.Resources.window_maximize_icon_1812281;
            btn_maximizar.Location = new Point(945, 0);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(44, 33);
            btn_maximizar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_maximizar.TabIndex = 3;
            btn_maximizar.TabStop = false;
            btn_maximizar.Click += btn_maximizar_Click;
            // 
            // btn_restaurar
            // 
            btn_restaurar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_restaurar.Image = Properties.Resources.window_restore_icon_144027;
            btn_restaurar.Location = new Point(945, 0);
            btn_restaurar.Name = "btn_restaurar";
            btn_restaurar.Size = new Size(44, 33);
            btn_restaurar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_restaurar.TabIndex = 6;
            btn_restaurar.TabStop = false;
            btn_restaurar.Visible = false;
            btn_restaurar.Click += btn_restaurar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Ink Free", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(336, 7);
            label1.Name = "label1";
            label1.Size = new Size(111, 23);
            label1.TabIndex = 4;
            label1.Text = "Menu Cliente";
            // 
            // btn_minimizar
            // 
            btn_minimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_minimizar.Image = Properties.Resources._1904666_calculate_close_delete_hide_minimize_minus_remove_122516;
            btn_minimizar.Location = new Point(904, 0);
            btn_minimizar.Name = "btn_minimizar";
            btn_minimizar.Size = new Size(44, 32);
            btn_minimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_minimizar.TabIndex = 5;
            btn_minimizar.TabStop = false;
            btn_minimizar.Click += btn_minimizar_Click;
            // 
            // btn_close
            // 
            btn_close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_close.Image = Properties.Resources._1492790846_9cancel_84247;
            btn_close.InitialImage = (Image)resources.GetObject("btn_close.InitialImage");
            btn_close.Location = new Point(986, 0);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(41, 33);
            btn_close.SizeMode = PictureBoxSizeMode.Zoom;
            btn_close.TabIndex = 4;
            btn_close.TabStop = false;
            btn_close.Click += Closebtn_Click;
            // 
            // BtnRestaurar
            // 
            BtnRestaurar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnRestaurar.Image = Properties.Resources.window_restore_icon_144027;
            BtnRestaurar.Location = new Point(1601, -1);
            BtnRestaurar.Name = "BtnRestaurar";
            BtnRestaurar.Size = new Size(44, 33);
            BtnRestaurar.SizeMode = PictureBoxSizeMode.Zoom;
            BtnRestaurar.TabIndex = 3;
            BtnRestaurar.TabStop = false;
            BtnRestaurar.Visible = false;
            // 
            // BtnMin
            // 
            BtnMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnMin.Image = Properties.Resources._1904666_calculate_close_delete_hide_minimize_minus_remove_122516;
            BtnMin.Location = new Point(1560, 0);
            BtnMin.Name = "BtnMin";
            BtnMin.Size = new Size(44, 32);
            BtnMin.SizeMode = PictureBoxSizeMode.Zoom;
            BtnMin.TabIndex = 2;
            BtnMin.TabStop = false;
            // 
            // BtnMax
            // 
            BtnMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnMax.Image = Properties.Resources.window_maximize_icon_1812281;
            BtnMax.Location = new Point(1601, 0);
            BtnMax.Name = "BtnMax";
            BtnMax.Size = new Size(44, 33);
            BtnMax.SizeMode = PictureBoxSizeMode.Zoom;
            BtnMax.TabIndex = 1;
            BtnMax.TabStop = false;
            // 
            // BtnClose
            // 
            BtnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnClose.Image = Properties.Resources._1492790846_9cancel_84247;
            BtnClose.InitialImage = (Image)resources.GetObject("BtnClose.InitialImage");
            BtnClose.Location = new Point(1642, 0);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(41, 33);
            BtnClose.SizeMode = PictureBoxSizeMode.Zoom;
            BtnClose.TabIndex = 0;
            BtnClose.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(btn_Perfil);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(169, 502);
            panel1.TabIndex = 2;
            // 
            // button7
            // 
            button7.Cursor = Cursors.Hand;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Image = Properties.Resources.log_out_icon_icons_com_50106;
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(3, 465);
            button7.Name = "button7";
            button7.Size = new Size(157, 34);
            button7.TabIndex = 18;
            button7.Text = "Cerrar Sesion";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // btn_Perfil
            // 
            btn_Perfil.Cursor = Cursors.Hand;
            btn_Perfil.FlatAppearance.BorderSize = 0;
            btn_Perfil.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btn_Perfil.FlatStyle = FlatStyle.Flat;
            btn_Perfil.Image = Properties.Resources.Why_Us_80_icon_icons_com_57240;
            btn_Perfil.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Perfil.Location = new Point(3, 62);
            btn_Perfil.Name = "btn_Perfil";
            btn_Perfil.Size = new Size(157, 23);
            btn_Perfil.TabIndex = 17;
            btn_Perfil.Text = "Mi perfil";
            btn_Perfil.UseVisualStyleBackColor = true;
            btn_Perfil.Click += btn_Perfil_Click;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = Properties.Resources._1486394965_12_bills_80559;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 159);
            button2.Name = "button2";
            button2.Size = new Size(169, 23);
            button2.TabIndex = 16;
            button2.Text = "Historial de pedidos";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.Menus;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 103);
            button1.Name = "button1";
            button1.Size = new Size(166, 28);
            button1.TabIndex = 15;
            button1.Text = "Hacer pedido";
            button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_1;
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(163, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(169, 33);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(858, 502);
            panelContenedor.TabIndex = 3;
            // 
            // FormularioClienteComun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1027, 535);
            Controls.Add(panelContenedor);
            Controls.Add(panel1);
            Controls.Add(BarraTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormularioClienteComun";
            Text = "FormularioClienteComun";
            BarraTitulo.ResumeLayout(false);
            BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_restaurar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_close).EndInit();
            ((System.ComponentModel.ISupportInitialize)BtnRestaurar).EndInit();
            ((System.ComponentModel.ISupportInitialize)BtnMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)BtnMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)BtnClose).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel BarraTitulo;
        private Label label1;
        private PictureBox BtnRestaurar;
        private PictureBox BtnMin;
        private PictureBox BtnMax;
        private PictureBox BtnClose;
        private Panel panel1;
        private Button button7;
        private Button btn_Perfil;
        private Button button2;
        private Button button1;
        private PictureBox pictureBox1;
        private PictureBox btn_restaurar;
        private PictureBox btn_minimizar;
        private PictureBox btn_close;
        private PictureBox btn_maximizar;
        private Panel panelContenedor;
    }
}