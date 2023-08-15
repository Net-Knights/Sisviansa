namespace Login
{
    partial class VentanaPrincipal
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            Btn_Login = new Button();
            panel1 = new Panel();
            label6 = new Label();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            panel5 = new Panel();
            Closebtn = new Button();
            panel2 = new Panel();
            pbMostrar = new PictureBox();
            pbOcultar = new PictureBox();
            Btn_Registrarse = new Button();
            label1 = new Label();
            label7 = new Label();
            panel4 = new Panel();
            pictureBox4 = new PictureBox();
            panel3 = new Panel();
            pictureBox3 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMostrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbOcultar).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Cursor = Cursors.IBeam;
            txtUsername.Location = new Point(33, 10);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(405, 16);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.Location = new Point(33, 10);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(405, 16);
            txtPassword.TabIndex = 3;
            // 
            // Btn_Login
            // 
            Btn_Login.BackColor = Color.FromArgb(41, 128, 185);
            Btn_Login.Cursor = Cursors.Hand;
            Btn_Login.FlatStyle = FlatStyle.Flat;
            Btn_Login.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_Login.ForeColor = Color.White;
            Btn_Login.Location = new Point(72, 253);
            Btn_Login.Name = "Btn_Login";
            Btn_Login.Size = new Size(263, 33);
            Btn_Login.TabIndex = 4;
            Btn_Login.Text = "Ingresar";
            Btn_Login.UseVisualStyleBackColor = false;
            Btn_Login.Click += btn_Login_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(257, 530);
            panel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(57, 192);
            label6.Name = "label6";
            label6.Size = new Size(147, 24);
            label6.TabIndex = 5;
            label6.Text = "De SISVIANSA";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logo_1;
            pictureBox2.Location = new Point(178, 431);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(79, 96);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(85, 492);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 3;
            label5.Text = "Net Knights";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 497);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 2;
            label4.Text = "Developed By:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 168);
            label3.Name = "label3";
            label3.Size = new Size(229, 24);
            label3.TabIndex = 1;
            label3.Text = "Bienvendio al sistema";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.account_login_log_in_icon_250759;
            pictureBox1.Location = new Point(85, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(96, 96);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(Closebtn);
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(493, 36);
            panel5.TabIndex = 12;
            panel5.MouseDown += panel5_MouseDown;
            // 
            // Closebtn
            // 
            Closebtn.Cursor = Cursors.Hand;
            Closebtn.FlatAppearance.BorderSize = 0;
            Closebtn.FlatStyle = FlatStyle.Flat;
            Closebtn.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Closebtn.ForeColor = Color.FromArgb(41, 128, 185);
            Closebtn.Location = new Point(453, 0);
            Closebtn.Name = "Closebtn";
            Closebtn.Size = new Size(40, 36);
            Closebtn.TabIndex = 5;
            Closebtn.Text = "X";
            Closebtn.UseVisualStyleBackColor = true;
            Closebtn.Click += Closebtn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(pbMostrar);
            panel2.Controls.Add(pbOcultar);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(Btn_Registrarse);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(Btn_Login);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(257, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(493, 530);
            panel2.TabIndex = 5;
            // 
            // pbMostrar
            // 
            pbMostrar.Image = Properties.Resources._1490793853_user_interface15_82360;
            pbMostrar.Location = new Point(447, 176);
            pbMostrar.Name = "pbMostrar";
            pbMostrar.Size = new Size(28, 32);
            pbMostrar.SizeMode = PictureBoxSizeMode.Zoom;
            pbMostrar.TabIndex = 14;
            pbMostrar.TabStop = false;
            pbMostrar.Click += pbMostrar_Click;
            // 
            // pbOcultar
            // 
            pbOcultar.Image = Properties.Resources._1490793864_user_interface16_82335;
            pbOcultar.Location = new Point(447, 176);
            pbOcultar.Name = "pbOcultar";
            pbOcultar.Size = new Size(28, 32);
            pbOcultar.SizeMode = PictureBoxSizeMode.Zoom;
            pbOcultar.TabIndex = 13;
            pbOcultar.TabStop = false;
            pbOcultar.Click += pbOcultar_Click;
            // 
            // Btn_Registrarse
            // 
            Btn_Registrarse.BackColor = Color.FromArgb(41, 128, 185);
            Btn_Registrarse.Cursor = Cursors.Hand;
            Btn_Registrarse.FlatAppearance.BorderColor = Color.FromArgb(41, 128, 185);
            Btn_Registrarse.FlatAppearance.BorderSize = 0;
            Btn_Registrarse.FlatStyle = FlatStyle.Flat;
            Btn_Registrarse.ForeColor = Color.White;
            Btn_Registrarse.Location = new Point(164, 335);
            Btn_Registrarse.Name = "Btn_Registrarse";
            Btn_Registrarse.Size = new Size(85, 23);
            Btn_Registrarse.TabIndex = 10;
            Btn_Registrarse.Text = "Registrarse";
            Btn_Registrarse.UseVisualStyleBackColor = false;
            Btn_Registrarse.Click += Btn_Registrarse_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(143, 298);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 9;
            label1.Text = "Aun no tienes cuenta?";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(41, 128, 185);
            label7.Location = new Point(123, 88);
            label7.Name = "label7";
            label7.Size = new Size(212, 24);
            label7.TabIndex = 8;
            label7.Text = "Ingrese a su cuenta";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(txtPassword);
            panel4.Location = new Point(3, 176);
            panel4.Name = "panel4";
            panel4.Size = new Size(444, 32);
            panel4.TabIndex = 7;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.internet_locked_padlock_password_secure_security_unlock_icon_1270831;
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 31);
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(txtUsername);
            panel3.Location = new Point(0, 139);
            panel3.Name = "panel3";
            panel3.Size = new Size(447, 34);
            panel3.TabIndex = 6;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.customer_person_people_man_user_client_1629;
            pictureBox3.Location = new Point(3, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 31);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // VentanaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 530);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VentanaPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VentanaPrincipal";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbMostrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbOcultar).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button Btn_Login;
        private Panel panel1;
        private Panel panel2;
        private Label label5;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button Closebtn;
        private Label label6;
        private Label label7;
        private Panel panel4;
        private Panel panel3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private Label label1;
        private Button Btn_Registrarse;
        private Panel panel5;
        private PictureBox pbMostrar;
        private PictureBox pbOcultar;
    }
}