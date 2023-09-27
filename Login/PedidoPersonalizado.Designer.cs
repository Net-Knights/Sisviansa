namespace Login
{
    partial class PedidoPersonalizado
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
            btnVolver = new Button();
            lbViandas = new ListBox();
            lbCarrito = new ListBox();
            btnAgregarAlCarrito = new Button();
            btnQuitarDelCarrito = new Button();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.Location = new Point(3, 594);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(102, 27);
            btnVolver.TabIndex = 33;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // lbViandas
            // 
            lbViandas.BackColor = Color.FromArgb(41, 128, 185);
            lbViandas.BorderStyle = BorderStyle.None;
            lbViandas.FormattingEnabled = true;
            lbViandas.ItemHeight = 15;
            lbViandas.Location = new Point(12, 126);
            lbViandas.Name = "lbViandas";
            lbViandas.Size = new Size(217, 405);
            lbViandas.TabIndex = 34;
            // 
            // lbCarrito
            // 
            lbCarrito.BackColor = Color.FromArgb(41, 128, 185);
            lbCarrito.BorderStyle = BorderStyle.None;
            lbCarrito.FormattingEnabled = true;
            lbCarrito.ItemHeight = 15;
            lbCarrito.Location = new Point(469, 126);
            lbCarrito.Name = "lbCarrito";
            lbCarrito.Size = new Size(208, 435);
            lbCarrito.TabIndex = 35;
            // 
            // btnAgregarAlCarrito
            // 
            btnAgregarAlCarrito.Location = new Point(302, 152);
            btnAgregarAlCarrito.Name = "btnAgregarAlCarrito";
            btnAgregarAlCarrito.Size = new Size(75, 23);
            btnAgregarAlCarrito.TabIndex = 36;
            btnAgregarAlCarrito.Text = "Agregar";
            btnAgregarAlCarrito.UseVisualStyleBackColor = true;
            btnAgregarAlCarrito.Click += btnAgregarAlCarrito_Click;
            // 
            // btnQuitarDelCarrito
            // 
            btnQuitarDelCarrito.Location = new Point(302, 291);
            btnQuitarDelCarrito.Name = "btnQuitarDelCarrito";
            btnQuitarDelCarrito.Size = new Size(75, 23);
            btnQuitarDelCarrito.TabIndex = 37;
            btnQuitarDelCarrito.Text = "Quitar";
            btnQuitarDelCarrito.UseVisualStyleBackColor = true;
            btnQuitarDelCarrito.Click += btnQuitarDelCarrito_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Info;
            label1.Location = new Point(23, 80);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 38;
            label1.Text = "Viandas disponibles";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Info;
            label2.Location = new Point(512, 80);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 39;
            label2.Text = "Carrito";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(698, 49);
            panel1.TabIndex = 40;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // PedidoPersonalizado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(698, 622);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnQuitarDelCarrito);
            Controls.Add(btnAgregarAlCarrito);
            Controls.Add(lbCarrito);
            Controls.Add(lbViandas);
            Controls.Add(btnVolver);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PedidoPersonalizado";
            Text = "PedidoPersonalizado";
            FormClosing += PedidoPersonalizado_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private ListBox lbViandas;
        private ListBox lbCarrito;
        private Button btnAgregarAlCarrito;
        private Button btnQuitarDelCarrito;
        private Label label1;
        private Label label2;
        private Panel panel1;
    }
}