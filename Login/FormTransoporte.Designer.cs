namespace Login
{
    partial class FormTransoporte
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
            dataGridView1 = new DataGridView();
            NroVehiculo = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            NroPedidoTr = new DataGridViewTextBoxColumn();
            label2 = new Label();
            comboBox3 = new ComboBox();
            label5 = new Label();
            comboBox2 = new ComboBox();
            label4 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { NroVehiculo, Estado, NroPedidoTr });
            dataGridView1.Location = new Point(235, 35);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(343, 359);
            dataGridView1.TabIndex = 16;
            // 
            // NroVehiculo
            // 
            NroVehiculo.HeaderText = "NroVehiculo";
            NroVehiculo.Name = "NroVehiculo";
            // 
            // Estado
            // 
            Estado.HeaderText = "Estado";
            Estado.Name = "Estado";
            // 
            // NroPedidoTr
            // 
            NroPedidoTr.HeaderText = "NroPedidoTr";
            NroPedidoTr.Name = "NroPedidoTr";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(235, 9);
            label2.Name = "label2";
            label2.Size = new Size(159, 15);
            label2.TabIndex = 15;
            label2.Text = "Informacion de los vehiculos";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(23, 126);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 92);
            label5.Name = "label5";
            label5.Size = new Size(74, 15);
            label5.TabIndex = 13;
            label5.Text = "Nro Sucursal";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(23, 50);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 17);
            label4.Name = "label4";
            label4.Size = new Size(145, 15);
            label4.TabIndex = 11;
            label4.Text = "Seleccionar departamento";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 32);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // FormTransoporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTransoporte";
            Text = "FormTransoporte";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private ComboBox comboBox3;
        private Label label5;
        private ComboBox comboBox2;
        private Label label4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn NroVehiculo;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn NroPedidoTr;
    }
}