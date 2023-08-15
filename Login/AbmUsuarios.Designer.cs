namespace Login
{
    partial class AbmUsuarios
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
            panel1 = new Panel();
            cbRoles = new ComboBox();
            BtnEliminar = new Button();
            BtnGuardar = new Button();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtContraseña = new TextBox();
            txtNombreUsuario = new TextBox();
            label1 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtBuscarRol = new TextBox();
            BtnBuscar = new Button();
            dgvUsuarios = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cbRoles);
            panel1.Controls.Add(BtnEliminar);
            panel1.Controls.Add(BtnGuardar);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtContraseña);
            panel1.Controls.Add(txtNombreUsuario);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(223, 491);
            panel1.TabIndex = 0;
            // 
            // cbRoles
            // 
            cbRoles.FormattingEnabled = true;
            cbRoles.Location = new Point(3, 164);
            cbRoles.Name = "cbRoles";
            cbRoles.Size = new Size(121, 23);
            cbRoles.TabIndex = 12;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnEliminar.BackColor = Color.Red;
            BtnEliminar.FlatAppearance.BorderSize = 0;
            BtnEliminar.FlatStyle = FlatStyle.Flat;
            BtnEliminar.Image = Properties.Resources.seo_social_web_network_internet_262_icon_icons_com_61518;
            BtnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnEliminar.Location = new Point(12, 451);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(149, 28);
            BtnEliminar.TabIndex = 10;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // BtnGuardar
            // 
            BtnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnGuardar.BackColor = Color.Green;
            BtnGuardar.FlatAppearance.BorderSize = 0;
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Image = Properties.Resources.savetheapplication_guardar_2958;
            BtnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnGuardar.Location = new Point(12, 418);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(149, 27);
            BtnGuardar.TabIndex = 9;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.UseVisualStyleBackColor = false;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 132);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 8;
            label5.Text = "Rol:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 76);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 6;
            label3.Text = "Contraseña:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 32);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 5;
            label2.Text = "Nombre Usuario:";
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(3, 94);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(193, 23);
            txtContraseña.TabIndex = 3;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(3, 50);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(193, 23);
            txtNombreUsuario.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 0;
            label1.Text = "Detalle del Usuario";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(229, 27);
            label6.Name = "label6";
            label6.Size = new Size(95, 15);
            label6.TabIndex = 2;
            label6.Text = "Lista de Usuarios";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(458, 24);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 3;
            label7.Text = "Buscar:";
            // 
            // txtBuscarRol
            // 
            txtBuscarRol.Location = new Point(509, 19);
            txtBuscarRol.Name = "txtBuscarRol";
            txtBuscarRol.Size = new Size(128, 23);
            txtBuscarRol.TabIndex = 4;
            // 
            // BtnBuscar
            // 
            BtnBuscar.FlatAppearance.BorderSize = 0;
            BtnBuscar.FlatStyle = FlatStyle.Flat;
            BtnBuscar.Image = Properties.Resources.seo_social_web_network_internet_340_icon_icons_com_61497;
            BtnBuscar.Location = new Point(643, 17);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(35, 29);
            BtnBuscar.TabIndex = 5;
            BtnBuscar.UseVisualStyleBackColor = true;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(258, 69);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowTemplate.Height = 25;
            dgvUsuarios.Size = new Size(392, 314);
            dgvUsuarios.TabIndex = 6;
            // 
            // AbmUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 491);
            Controls.Add(dgvUsuarios);
            Controls.Add(BtnBuscar);
            Controls.Add(txtBuscarRol);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AbmUsuarios";
            Text = "AbmUsuarios";
            Load += AbmUsuarios_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private TextBox txtContraseña;
        private TextBox txtNombreUsuario;
        private Label label1;
        private Button BtnEliminar;
        private Button BtnGuardar;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtBuscarRol;
        private Button BtnBuscar;
        private ComboBox cbRoles;
        private DataGridView dgvUsuarios;
    }
}