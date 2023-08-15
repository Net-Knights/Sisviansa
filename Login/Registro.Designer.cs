namespace Login
{
    partial class Registro
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
            pictureBox2 = new PictureBox();
            label5 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            pbMostrar = new PictureBox();
            pbOcultar = new PictureBox();
            btnVolver = new Button();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtDireccion = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblDireccion = new Label();
            btnRegistrar = new Button();
            lblCorreoElectronico = new Label();
            lblCI = new Label();
            lblContraseña = new Label();
            lblNombreUsuario = new Label();
            txtContraseña = new TextBox();
            txtCorreoElectronico = new TextBox();
            txtCI = new TextBox();
            txtNombreUsuario = new TextBox();
            lblIngrese = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMostrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbOcultar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logo_1;
            pictureBox2.Location = new Point(174, 518);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(79, 96);
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(88, 588);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 9;
            label5.Text = "Net Knights";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 593);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 8;
            label4.Text = "Developed By:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.login_icon_1769051;
            pictureBox1.Location = new Point(76, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(96, 96);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(256, 617);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Controls.Add(pbMostrar);
            panel2.Controls.Add(pbOcultar);
            panel2.Controls.Add(btnVolver);
            panel2.Controls.Add(txtApellido);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtDireccion);
            panel2.Controls.Add(lblTelefono);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(lblDireccion);
            panel2.Controls.Add(btnRegistrar);
            panel2.Controls.Add(lblCorreoElectronico);
            panel2.Controls.Add(lblCI);
            panel2.Controls.Add(lblContraseña);
            panel2.Controls.Add(lblNombreUsuario);
            panel2.Controls.Add(txtContraseña);
            panel2.Controls.Add(txtCorreoElectronico);
            panel2.Controls.Add(txtCI);
            panel2.Controls.Add(txtNombreUsuario);
            panel2.Controls.Add(lblIngrese);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(256, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(472, 617);
            panel2.TabIndex = 13;
            // 
            // pbMostrar
            // 
            pbMostrar.Image = Properties.Resources._1490793853_user_interface15_82360;
            pbMostrar.Location = new Point(320, 134);
            pbMostrar.Name = "pbMostrar";
            pbMostrar.Size = new Size(25, 25);
            pbMostrar.SizeMode = PictureBoxSizeMode.Zoom;
            pbMostrar.TabIndex = 34;
            pbMostrar.TabStop = false;
            pbMostrar.Click += pbMostrar_Click;
            // 
            // pbOcultar
            // 
            pbOcultar.Image = Properties.Resources._1490793864_user_interface16_82335;
            pbOcultar.Location = new Point(320, 134);
            pbOcultar.Name = "pbOcultar";
            pbOcultar.Size = new Size(25, 25);
            pbOcultar.SizeMode = PictureBoxSizeMode.Zoom;
            pbOcultar.TabIndex = 33;
            pbOcultar.TabStop = false;
            pbOcultar.Click += pbOcultar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.Location = new Point(3, 568);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(114, 37);
            btnVolver.TabIndex = 32;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // txtApellido
            // 
            txtApellido.Cursor = Cursors.IBeam;
            txtApellido.Location = new Point(214, 266);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 31;
            txtApellido.KeyPress += txtApellido_KeyPress;
            // 
            // txtNombre
            // 
            txtNombre.Cursor = Cursors.IBeam;
            txtNombre.Location = new Point(214, 222);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 30;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(41, 128, 185);
            label1.Location = new Point(6, 266);
            label1.Name = "label1";
            label1.Size = new Size(99, 24);
            label1.TabIndex = 29;
            label1.Text = "Apellido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(41, 128, 185);
            label2.Location = new Point(6, 222);
            label2.Name = "label2";
            label2.Size = new Size(100, 24);
            label2.TabIndex = 28;
            label2.Text = "Nombre:";
            // 
            // txtDireccion
            // 
            txtDireccion.Cursor = Cursors.IBeam;
            txtDireccion.Location = new Point(214, 438);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 27;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblTelefono.ForeColor = Color.FromArgb(41, 128, 185);
            lblTelefono.Location = new Point(6, 398);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(104, 24);
            lblTelefono.TabIndex = 26;
            lblTelefono.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Cursor = Cursors.IBeam;
            txtTelefono.Location = new Point(214, 398);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 21;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblDireccion.ForeColor = Color.FromArgb(41, 128, 185);
            lblDireccion.Location = new Point(6, 438);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(112, 24);
            lblDireccion.TabIndex = 20;
            lblDireccion.Text = "Direccion:";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.Location = new Point(346, 568);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(114, 37);
            btnRegistrar.TabIndex = 19;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click_1;
            // 
            // lblCorreoElectronico
            // 
            lblCorreoElectronico.AutoSize = true;
            lblCorreoElectronico.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblCorreoElectronico.ForeColor = Color.FromArgb(41, 128, 185);
            lblCorreoElectronico.Location = new Point(6, 314);
            lblCorreoElectronico.Name = "lblCorreoElectronico";
            lblCorreoElectronico.Size = new Size(207, 24);
            lblCorreoElectronico.TabIndex = 18;
            lblCorreoElectronico.Text = "Correo Electronico:";
            // 
            // lblCI
            // 
            lblCI.AutoSize = true;
            lblCI.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblCI.ForeColor = Color.FromArgb(41, 128, 185);
            lblCI.Location = new Point(6, 358);
            lblCI.Name = "lblCI";
            lblCI.Size = new Size(37, 24);
            lblCI.TabIndex = 17;
            lblCI.Text = "CI:";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblContraseña.ForeColor = Color.FromArgb(41, 128, 185);
            lblContraseña.Location = new Point(6, 129);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(135, 24);
            lblContraseña.TabIndex = 16;
            lblContraseña.Text = "Contraseña:";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblNombreUsuario.ForeColor = Color.FromArgb(41, 128, 185);
            lblNombreUsuario.Location = new Point(6, 89);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(177, 24);
            lblNombreUsuario.TabIndex = 15;
            lblNombreUsuario.Text = "Nombre Usuario:";
            // 
            // txtContraseña
            // 
            txtContraseña.Cursor = Cursors.IBeam;
            txtContraseña.Location = new Point(214, 134);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(100, 23);
            txtContraseña.TabIndex = 14;
            // 
            // txtCorreoElectronico
            // 
            txtCorreoElectronico.Cursor = Cursors.IBeam;
            txtCorreoElectronico.Location = new Point(214, 314);
            txtCorreoElectronico.Name = "txtCorreoElectronico";
            txtCorreoElectronico.Size = new Size(100, 23);
            txtCorreoElectronico.TabIndex = 13;
            // 
            // txtCI
            // 
            txtCI.Cursor = Cursors.IBeam;
            txtCI.Location = new Point(214, 359);
            txtCI.Name = "txtCI";
            txtCI.Size = new Size(100, 23);
            txtCI.TabIndex = 12;
            txtCI.KeyPress += txtCI_KeyPress;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Cursor = Cursors.IBeam;
            txtNombreUsuario.Location = new Point(214, 94);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(100, 23);
            txtNombreUsuario.TabIndex = 11;
            // 
            // lblIngrese
            // 
            lblIngrese.AutoSize = true;
            lblIngrese.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblIngrese.ForeColor = Color.FromArgb(41, 128, 185);
            lblIngrese.Location = new Point(103, 16);
            lblIngrese.Name = "lblIngrese";
            lblIngrese.Size = new Size(182, 24);
            lblIngrese.TabIndex = 10;
            lblIngrese.Text = "Ingrese sus datos";
            // 
            // Registro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(728, 617);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Registro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbMostrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbOcultar).EndInit();
            ResumeLayout(false);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private PictureBox pictureBox2;
        private Label label5;
        private Label label4;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel2;
        private TextBox txtContraseña;
        private TextBox txtCorreoElectronico;
        private TextBox txtCI;
        private TextBox txtNombreUsuario;
        private Label lblIngrese;
        private Label lblNombreUsuario;
        private Label lblCorreoElectronico;
        private Label lblCI;
        private Label lblContraseña;
        private Button btnRegistrar;
        private Label lblDireccion;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private Label label1;
        private Label label2;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Button btnVolver;
        private PictureBox pbMostrar;
        private PictureBox pbOcultar;
    }
}