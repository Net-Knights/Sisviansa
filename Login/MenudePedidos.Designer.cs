namespace Login
{
    partial class MenudePedidos
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
            button1 = new Button();
            panel1 = new Panel();
            label6 = new Label();
            lbViandasPacks = new ListBox();
            label8 = new Label();
            dgvPedidos = new DataGridView();
            numCantidadViandas = new NumericUpDown();
            label13 = new Label();
            btnAgregar = new Button();
            groupBox3 = new GroupBox();
            label5 = new Label();
            cbEstadoProduccion = new ComboBox();
            label1 = new Label();
            cbPacks = new ComboBox();
            lblMensajeStock = new Label();
            btnVerificarStock = new Button();
            label7 = new Label();
            cbViandas = new ComboBox();
            label3 = new Label();
            txtNroclienteb = new TextBox();
            cbTipomenu = new ComboBox();
            label11 = new Label();
            txtStock = new TextBox();
            label9 = new Label();
            groupBox2 = new GroupBox();
            BtnBuscar = new Button();
            label4 = new Label();
            textBox5 = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidadViandas).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(712, 445);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 22;
            button1.Text = "Stock";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(lbViandasPacks);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(dgvPedidos);
            panel1.Controls.Add(numCantidadViandas);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(btnAgregar);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 510);
            panel1.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(518, 172);
            label6.Name = "label6";
            label6.Size = new Size(113, 15);
            label6.TabIndex = 56;
            label6.Text = "Contenido del pack:";
            // 
            // lbViandasPacks
            // 
            lbViandasPacks.FormattingEnabled = true;
            lbViandasPacks.ItemHeight = 15;
            lbViandasPacks.Location = new Point(498, 196);
            lbViandasPacks.Name = "lbViandasPacks";
            lbViandasPacks.Size = new Size(220, 289);
            lbViandasPacks.TabIndex = 55;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(553, 96);
            label8.Name = "label8";
            label8.Size = new Size(114, 15);
            label8.TabIndex = 54;
            label8.Text = "Cantidad de viandas";
            // 
            // dgvPedidos
            // 
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(3, 204);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.RowTemplate.Height = 25;
            dgvPedidos.Size = new Size(469, 281);
            dgvPedidos.TabIndex = 39;
            // 
            // numCantidadViandas
            // 
            numCantidadViandas.Location = new Point(622, 114);
            numCantidadViandas.Name = "numCantidadViandas";
            numCantidadViandas.Size = new Size(45, 23);
            numCantidadViandas.TabIndex = 53;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(3, 0);
            label13.Name = "label13";
            label13.Size = new Size(177, 19);
            label13.TabIndex = 38;
            label13.Text = "Agregar un pedido a la lista";
            // 
            // btnAgregar
            // 
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Image = Properties.Resources.shopping_cart_add_button_icon_icons_com_56132;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(683, 96);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(115, 63);
            btnAgregar.TabIndex = 37;
            btnAgregar.Text = "       Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(cbEstadoProduccion);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(cbPacks);
            groupBox3.Controls.Add(lblMensajeStock);
            groupBox3.Controls.Add(btnVerificarStock);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(cbViandas);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(txtNroclienteb);
            groupBox3.Controls.Add(cbTipomenu);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(txtStock);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(3, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(795, 71);
            groupBox3.TabIndex = 36;
            groupBox3.TabStop = false;
            groupBox3.Text = "Agregar un nuevo pedido";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(563, 18);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 29;
            label5.Text = "Estado";
            // 
            // cbEstadoProduccion
            // 
            cbEstadoProduccion.FormattingEnabled = true;
            cbEstadoProduccion.Location = new Point(563, 37);
            cbEstadoProduccion.Name = "cbEstadoProduccion";
            cbEstadoProduccion.Size = new Size(82, 23);
            cbEstadoProduccion.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(136, 19);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 54;
            label1.Text = "Packs:";
            // 
            // cbPacks
            // 
            cbPacks.FormattingEnabled = true;
            cbPacks.Location = new Point(136, 37);
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
            // btnVerificarStock
            // 
            btnVerificarStock.Location = new Point(730, 36);
            btnVerificarStock.Name = "btnVerificarStock";
            btnVerificarStock.Size = new Size(59, 23);
            btnVerificarStock.TabIndex = 51;
            btnVerificarStock.Text = "Verificar";
            btnVerificarStock.UseVisualStyleBackColor = true;
            btnVerificarStock.Click += btnVerificarStock_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(338, 19);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 50;
            label7.Text = "Viandas:";
            // 
            // cbViandas
            // 
            cbViandas.FormattingEnabled = true;
            cbViandas.Location = new Point(338, 36);
            cbViandas.Name = "cbViandas";
            cbViandas.Size = new Size(121, 23);
            cbViandas.TabIndex = 49;
            cbViandas.SelectedIndexChanged += cbViandas_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(465, 18);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 48;
            label3.Text = "Nro Cliente:";
            // 
            // txtNroclienteb
            // 
            txtNroclienteb.Location = new Point(483, 37);
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
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(709, 18);
            label11.Name = "label11";
            label11.Size = new Size(39, 15);
            label11.TabIndex = 44;
            label11.Text = "Stock:";
            // 
            // txtStock
            // 
            txtStock.BackColor = Color.Silver;
            txtStock.Location = new Point(672, 36);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(52, 23);
            txtStock.TabIndex = 43;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 19);
            label9.Name = "label9";
            label9.Size = new Size(83, 15);
            label9.TabIndex = 40;
            label9.Text = "Tipo de menu:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnBuscar);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Location = new Point(3, 127);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(191, 75);
            groupBox2.TabIndex = 30;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 19);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 28;
            label4.Text = "Nro Cliente:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 37);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(39, 23);
            textBox5.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(0, 96);
            label2.Name = "label2";
            label2.Size = new Size(171, 28);
            label2.TabIndex = 24;
            label2.Text = "Consultar pedidos";
            // 
            // MenudePedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 510);
            Controls.Add(panel1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenudePedidos";
            Text = "MenudePedidos";
            Load += MenudePedidos_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidadViandas).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Panel panel1;
        private Label label2;
        private Button BtnBuscar;
        private TextBox textBox5;
        private GroupBox groupBox2;
        private ComboBox cbEstadoProduccion;
        private Label label5;
        private Label label4;
        private GroupBox groupBox3;
        private Label label9;
        private Button btnAgregar;
        private Label label11;
        private TextBox txtStock;
        private Label label13;
        private DataGridView dgvPedidos;
        private ComboBox cbTipomenu;
        private Label label7;
        private ComboBox cbViandas;
        private Label label3;
        private TextBox txtNroclienteb;
        private Button btnVerificarStock;
        private Label label10;
        private Label lblMensajeStock;
        private NumericUpDown numCantidadViandas;
        private Label label8;
        private Label label1;
        private ComboBox cbPacks;
        private ListBox lbViandasPacks;
        private Label label6;
    }
}