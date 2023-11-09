namespace Login
{
    partial class PedidoClienteC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidoClienteC));
            panelcontenedor = new Panel();
            panel1 = new Panel();
            dgvPedidos = new DataGridView();
            groupBox2 = new GroupBox();
            BtnBuscar = new Button();
            label5 = new Label();
            txtNrclienteBuscar = new TextBox();
            label8 = new Label();
            label1 = new Label();
            lbViandasPacks = new ListBox();
            btnEliminarP = new Button();
            btnAgregar = new Button();
            groupBox3 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            cbPacks = new ComboBox();
            lblMensajeStock = new Label();
            numericUpDown1 = new NumericUpDown();
            label7 = new Label();
            cbViandas = new ComboBox();
            label4 = new Label();
            txtNroclienteb = new TextBox();
            cbTipomenu = new ComboBox();
            label6 = new Label();
            panelcontenedor.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // panelcontenedor
            // 
            panelcontenedor.Controls.Add(panel1);
            panelcontenedor.Dock = DockStyle.Fill;
            panelcontenedor.Location = new Point(0, 0);
            panelcontenedor.Name = "panelcontenedor";
            panelcontenedor.Size = new Size(800, 450);
            panelcontenedor.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dgvPedidos);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lbViandasPacks);
            panel1.Controls.Add(btnEliminarP);
            panel1.Controls.Add(btnAgregar);
            panel1.Controls.Add(groupBox3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // dgvPedidos
            // 
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(518, 20);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.RowTemplate.Height = 25;
            dgvPedidos.Size = new Size(279, 365);
            dgvPedidos.TabIndex = 69;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnBuscar);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtNrclienteBuscar);
            groupBox2.Location = new Point(3, 237);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(144, 75);
            groupBox2.TabIndex = 68;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informacion del cliente";
            // 
            // BtnBuscar
            // 
            BtnBuscar.FlatAppearance.BorderSize = 0;
            BtnBuscar.FlatStyle = FlatStyle.Flat;
            BtnBuscar.Image = Properties.Resources.seo_social_web_network_internet_340_icon_icons_com_61497;
            BtnBuscar.Location = new Point(51, 36);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(35, 23);
            BtnBuscar.TabIndex = 28;
            BtnBuscar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 18);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 28;
            label5.Text = "Nro Cliente:";
            // 
            // txtNrclienteBuscar
            // 
            txtNrclienteBuscar.Location = new Point(6, 37);
            txtNrclienteBuscar.Name = "txtNrclienteBuscar";
            txtNrclienteBuscar.Size = new Size(39, 23);
            txtNrclienteBuscar.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(0, 197);
            label8.Name = "label8";
            label8.Size = new Size(171, 28);
            label8.TabIndex = 67;
            label8.Text = "Consultar pedidos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(292, 2);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 66;
            label1.Text = "Contenido del pack:";
            // 
            // lbViandasPacks
            // 
            lbViandasPacks.FormattingEnabled = true;
            lbViandasPacks.ItemHeight = 15;
            lbViandasPacks.Location = new Point(292, 20);
            lbViandasPacks.Name = "lbViandasPacks";
            lbViandasPacks.Size = new Size(220, 424);
            lbViandasPacks.TabIndex = 65;
            // 
            // btnEliminarP
            // 
            btnEliminarP.FlatStyle = FlatStyle.Flat;
            btnEliminarP.Image = (Image)resources.GetObject("btnEliminarP.Image");
            btnEliminarP.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminarP.Location = new Point(568, 402);
            btnEliminarP.Name = "btnEliminarP";
            btnEliminarP.Size = new Size(111, 45);
            btnEliminarP.TabIndex = 64;
            btnEliminarP.Text = "       Eliminar";
            btnEliminarP.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Image = Properties.Resources.shopping_cart_add_button_icon_icons_com_56132;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(685, 402);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(115, 45);
            btnAgregar.TabIndex = 63;
            btnAgregar.Text = "       Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            //btnAgregar.Click += btnAgregar_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(cbPacks);
            groupBox3.Controls.Add(lblMensajeStock);
            groupBox3.Controls.Add(numericUpDown1);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(cbViandas);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(txtNroclienteb);
            groupBox3.Controls.Add(cbTipomenu);
            groupBox3.Controls.Add(label6);
            groupBox3.Location = new Point(2, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(284, 182);
            groupBox3.TabIndex = 62;
            groupBox3.TabStop = false;
            groupBox3.Text = "Agregar un nuevo pedido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 75);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 54;
            label2.Text = "Packs:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 119);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 54;
            label3.Text = "Cantidad de Packs";
            // 
            // cbPacks
            // 
            cbPacks.FormattingEnabled = true;
            cbPacks.Location = new Point(-2, 93);
            cbPacks.Name = "cbPacks";
            cbPacks.Size = new Size(121, 23);
            cbPacks.TabIndex = 53;
            cbPacks.SelectedIndexChanged += cbPacks_SelectedIndexChanged;
            // 
            // lblMensajeStock
            // 
            lblMensajeStock.AutoSize = true;
            lblMensajeStock.Location = new Point(563, 8);
            lblMensajeStock.Name = "lblMensajeStock";
            lblMensajeStock.Size = new Size(0, 15);
            lblMensajeStock.TabIndex = 52;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(1, 153);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(45, 23);
            numericUpDown1.TabIndex = 53;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(152, 19);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 50;
            label7.Text = "Viandas:";
            // 
            // cbViandas
            // 
            cbViandas.FormattingEnabled = true;
            cbViandas.Location = new Point(152, 37);
            cbViandas.Name = "cbViandas";
            cbViandas.Size = new Size(121, 23);
            cbViandas.TabIndex = 49;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(152, 75);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 48;
            label4.Text = "Nro Cliente:";
            // 
            // txtNroclienteb
            // 
            txtNroclienteb.Location = new Point(164, 93);
            txtNroclienteb.Name = "txtNroclienteb";
            txtNroclienteb.Size = new Size(31, 23);
            txtNroclienteb.TabIndex = 47;
            // 
            // cbTipomenu
            // 
            cbTipomenu.FormattingEnabled = true;
            cbTipomenu.Location = new Point(0, 37);
            cbTipomenu.Name = "cbTipomenu";
            cbTipomenu.Size = new Size(121, 23);
            cbTipomenu.TabIndex = 46;
            cbTipomenu.DropDown += cbTipomenu_DropDown;
            cbTipomenu.SelectedIndexChanged += cbTipomenu_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 19);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 40;
            label6.Text = "Tipo de menu:";
            // 
            // PedidoClienteC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelcontenedor);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PedidoClienteC";
            Text = "PedidoClienteC";
            Load += PedidoClienteC_Load;
            panelcontenedor.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelcontenedor;
        private Panel panel1;
        private GroupBox groupBox3;
        private Label label2;
        private Label label3;
        private ComboBox cbPacks;
        private Label lblMensajeStock;
        private NumericUpDown numericUpDown1;
        private Label label7;
        private ComboBox cbViandas;
        private Label label4;
        private TextBox txtNroclienteb;
        private ComboBox cbTipomenu;
        private Label label6;
        private Button btnEliminarP;
        private Button btnAgregar;
        private Label label1;
        private ListBox lbViandasPacks;
        private GroupBox groupBox2;
        private Button BtnBuscar;
        private Label label5;
        private TextBox txtNrclienteBuscar;
        private Label label8;
        private DataGridView dgvPedidos;
    }
}