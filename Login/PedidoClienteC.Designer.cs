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
            panelcontenedor = new Panel();
            SuspendLayout();
            // 
            // panelcontenedor
            // 
            panelcontenedor.Dock = DockStyle.Fill;
            panelcontenedor.Location = new Point(0, 0);
            panelcontenedor.Name = "panelcontenedor";
            panelcontenedor.Size = new Size(800, 450);
            panelcontenedor.TabIndex = 0;
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
            ResumeLayout(false);
        }

        #endregion

        private Panel panelcontenedor;
    }
}