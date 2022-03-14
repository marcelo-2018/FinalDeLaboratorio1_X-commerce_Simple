namespace SegundoParcial
{
    partial class ConsultaCuentaCorriente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaCuentaCorriente));
            this.btnPagar = new System.Windows.Forms.ToolStripButton();
            this.menuAccesoRapido = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvCuentaCorriente = new System.Windows.Forms.DataGridView();
            this.menuAccesoRapido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentaCorriente)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPagar
            // 
            this.btnPagar.Image = ((System.Drawing.Image)(resources.GetObject("btnPagar.Image")));
            this.btnPagar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(60, 69);
            this.btnPagar.Text = "Pagar";
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // menuAccesoRapido
            // 
            this.menuAccesoRapido.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuAccesoRapido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPagar,
            this.btnSalir});
            this.menuAccesoRapido.Location = new System.Drawing.Point(0, 0);
            this.menuAccesoRapido.Name = "menuAccesoRapido";
            this.menuAccesoRapido.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.menuAccesoRapido.Size = new System.Drawing.Size(867, 74);
            this.menuAccesoRapido.TabIndex = 18;
            this.menuAccesoRapido.Text = "toolStrip1";
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(79, 69);
            this.btnSalir.Text = "   Salir   ";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvCuentaCorriente
            // 
            this.dgvCuentaCorriente.AllowUserToAddRows = false;
            this.dgvCuentaCorriente.AllowUserToDeleteRows = false;
            this.dgvCuentaCorriente.BackgroundColor = System.Drawing.Color.White;
            this.dgvCuentaCorriente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentaCorriente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCuentaCorriente.Location = new System.Drawing.Point(0, 74);
            this.dgvCuentaCorriente.MultiSelect = false;
            this.dgvCuentaCorriente.Name = "dgvCuentaCorriente";
            this.dgvCuentaCorriente.ReadOnly = true;
            this.dgvCuentaCorriente.RowHeadersVisible = false;
            this.dgvCuentaCorriente.RowHeadersWidth = 62;
            this.dgvCuentaCorriente.RowTemplate.Height = 24;
            this.dgvCuentaCorriente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentaCorriente.Size = new System.Drawing.Size(867, 609);
            this.dgvCuentaCorriente.TabIndex = 20;
            // 
            // CuentaCorriente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 683);
            this.Controls.Add(this.dgvCuentaCorriente);
            this.Controls.Add(this.menuAccesoRapido);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(889, 739);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(889, 739);
            this.Name = "CuentaCorriente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cuenta Corriente";
            this.menuAccesoRapido.ResumeLayout(false);
            this.menuAccesoRapido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentaCorriente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStripButton btnPagar;
        private System.Windows.Forms.ToolStrip menuAccesoRapido;
        private System.Windows.Forms.ToolStripButton btnSalir;
        protected System.Windows.Forms.DataGridView dgvCuentaCorriente;
    }
}