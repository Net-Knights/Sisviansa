namespace Login
{
    partial class Stock
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
            BtnLimpiar = new Button();
            BtnEliminar = new Button();
            BtnGuardar = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Menus = new DataGridViewTextBoxColumn();
            Canti = new DataGridViewTextBoxColumn();
            TipoMenu = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(BtnLimpiar);
            panel1.Controls.Add(BtnEliminar);
            panel1.Controls.Add(BtnGuardar);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 15;
            // 
            // BtnLimpiar
            // 
            BtnLimpiar.BackColor = Color.DarkTurquoise;
            BtnLimpiar.FlatAppearance.BorderSize = 0;
            BtnLimpiar.FlatStyle = FlatStyle.Flat;
            BtnLimpiar.Image = Properties.Resources._3792033_broom_halloween_magic_witch_109010;
            BtnLimpiar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnLimpiar.Location = new Point(46, 311);
            BtnLimpiar.Name = "BtnLimpiar";
            BtnLimpiar.Size = new Size(149, 31);
            BtnLimpiar.TabIndex = 19;
            BtnLimpiar.Text = "Limpiar";
            BtnLimpiar.UseVisualStyleBackColor = false;
            // 
            // BtnEliminar
            // 
            BtnEliminar.BackColor = Color.Red;
            BtnEliminar.FlatAppearance.BorderSize = 0;
            BtnEliminar.FlatStyle = FlatStyle.Flat;
            BtnEliminar.Image = Properties.Resources.seo_social_web_network_internet_262_icon_icons_com_61518;
            BtnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnEliminar.Location = new Point(46, 363);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(149, 32);
            BtnEliminar.TabIndex = 18;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.UseVisualStyleBackColor = false;
            // 
            // BtnGuardar
            // 
            BtnGuardar.BackColor = Color.Green;
            BtnGuardar.FlatAppearance.BorderSize = 0;
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Image = Properties.Resources.savetheapplication_guardar_2958;
            BtnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnGuardar.Location = new Point(46, 257);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(149, 36);
            BtnGuardar.TabIndex = 17;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(135, 5);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 16;
            label1.Text = "Stock";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Menus, Canti, TipoMenu });
            dataGridView1.Location = new Point(25, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(344, 161);
            dataGridView1.TabIndex = 15;
            // 
            // Menus
            // 
            Menus.HeaderText = "Menu";
            Menus.Name = "Menus";
            // 
            // Canti
            // 
            Canti.HeaderText = "Cantidad";
            Canti.Name = "Canti";
            // 
            // TipoMenu
            // 
            TipoMenu.HeaderText = "TipoMenu";
            TipoMenu.Name = "TipoMenu";
            // 
            // Stock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Stock";
            Text = "Stock";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button BtnLimpiar;
        private Button BtnEliminar;
        private Button BtnGuardar;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Menus;
        private DataGridViewTextBoxColumn Canti;
        private DataGridViewTextBoxColumn TipoMenu;
    }
}