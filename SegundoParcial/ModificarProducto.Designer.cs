namespace SegundoParcial
{
    partial class ModificarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarProducto));
            this.MenuAccesoRapido = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.nudPrecioPublico = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.chkPermitirStockNegativo = new System.Windows.Forms.CheckBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnNuevoRubro = new System.Windows.Forms.Button();
            this.btnNuevaMarca = new System.Windows.Forms.Button();
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcodigoBarra = new System.Windows.Forms.TextBox();
            this.lblCodigoBarra = new System.Windows.Forms.Label();
            this.MenuAccesoRapido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioPublico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuAccesoRapido
            // 
            this.MenuAccesoRapido.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.MenuAccesoRapido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnLimpiar,
            this.btnSalir});
            this.MenuAccesoRapido.Location = new System.Drawing.Point(0, 0);
            this.MenuAccesoRapido.Name = "MenuAccesoRapido";
            this.MenuAccesoRapido.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.MenuAccesoRapido.Size = new System.Drawing.Size(732, 69);
            this.MenuAccesoRapido.TabIndex = 3;
            this.MenuAccesoRapido.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(79, 64);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(74, 64);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(49, 64);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // nudPrecioPublico
            // 
            this.nudPrecioPublico.DecimalPlaces = 2;
            this.nudPrecioPublico.Location = new System.Drawing.Point(477, 220);
            this.nudPrecioPublico.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudPrecioPublico.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrecioPublico.Name = "nudPrecioPublico";
            this.nudPrecioPublico.Size = new System.Drawing.Size(150, 26);
            this.nudPrecioPublico.TabIndex = 144;
            this.nudPrecioPublico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPrecioPublico.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 157;
            this.label2.Text = "Precio Publico";
            // 
            // nudPrecioCosto
            // 
            this.nudPrecioCosto.DecimalPlaces = 2;
            this.nudPrecioCosto.Location = new System.Drawing.Point(127, 217);
            this.nudPrecioCosto.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudPrecioCosto.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrecioCosto.Name = "nudPrecioCosto";
            this.nudPrecioCosto.Size = new System.Drawing.Size(150, 26);
            this.nudPrecioCosto.TabIndex = 143;
            this.nudPrecioCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPrecioCosto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 156;
            this.label1.Text = "Precio Costo";
            // 
            // nudStock
            // 
            this.nudStock.Location = new System.Drawing.Point(127, 180);
            this.nudStock.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(150, 26);
            this.nudStock.TabIndex = 142;
            this.nudStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudStock.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkPermitirStockNegativo
            // 
            this.chkPermitirStockNegativo.AutoSize = true;
            this.chkPermitirStockNegativo.Location = new System.Drawing.Point(361, 183);
            this.chkPermitirStockNegativo.Name = "chkPermitirStockNegativo";
            this.chkPermitirStockNegativo.Size = new System.Drawing.Size(199, 24);
            this.chkPermitirStockNegativo.TabIndex = 155;
            this.chkPermitirStockNegativo.Text = "Permitir Stock Negativo";
            this.chkPermitirStockNegativo.UseVisualStyleBackColor = true;
            this.chkPermitirStockNegativo.CheckedChanged += new System.EventHandler(this.chkPermitirStockNegativo_CheckedChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(127, 106);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(170, 26);
            this.txtCodigo.TabIndex = 139;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // btnNuevoRubro
            // 
            this.btnNuevoRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoRubro.Location = new System.Drawing.Point(633, 305);
            this.btnNuevoRubro.Name = "btnNuevoRubro";
            this.btnNuevoRubro.Size = new System.Drawing.Size(60, 32);
            this.btnNuevoRubro.TabIndex = 148;
            this.btnNuevoRubro.Text = "...";
            this.btnNuevoRubro.UseVisualStyleBackColor = true;
            this.btnNuevoRubro.Click += new System.EventHandler(this.btnNuevoRubro_Click);
            // 
            // btnNuevaMarca
            // 
            this.btnNuevaMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaMarca.Location = new System.Drawing.Point(633, 258);
            this.btnNuevaMarca.Name = "btnNuevaMarca";
            this.btnNuevaMarca.Size = new System.Drawing.Size(60, 32);
            this.btnNuevaMarca.TabIndex = 147;
            this.btnNuevaMarca.Text = "...";
            this.btnNuevaMarca.UseVisualStyleBackColor = true;
            this.btnNuevaMarca.Click += new System.EventHandler(this.btnNuevaMarca_Click);
            // 
            // cmbRubro
            // 
            this.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Location = new System.Drawing.Point(127, 305);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(498, 28);
            this.cmbRubro.TabIndex = 146;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(67, 312);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 20);
            this.label21.TabIndex = 154;
            this.label21.Text = "Rubro";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.Location = new System.Drawing.Point(127, 258);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(498, 28);
            this.cmbMarca.TabIndex = 145;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(66, 266);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(53, 20);
            this.lblMarca.TabIndex = 153;
            this.lblMarca.Text = "Marca";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(61, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 20);
            this.label17.TabIndex = 152;
            this.label17.Text = "Codigo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 20);
            this.label12.TabIndex = 151;
            this.label12.Text = "Stock";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(127, 143);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(498, 26);
            this.txtDescripcion.TabIndex = 141;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 150;
            this.label3.Text = "Descripcion";
            // 
            // txtcodigoBarra
            // 
            this.txtcodigoBarra.Location = new System.Drawing.Point(462, 106);
            this.txtcodigoBarra.Name = "txtcodigoBarra";
            this.txtcodigoBarra.Size = new System.Drawing.Size(163, 26);
            this.txtcodigoBarra.TabIndex = 140;
            this.txtcodigoBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigoBarra_KeyPress);
            // 
            // lblCodigoBarra
            // 
            this.lblCodigoBarra.AutoSize = true;
            this.lblCodigoBarra.Location = new System.Drawing.Point(329, 111);
            this.lblCodigoBarra.Name = "lblCodigoBarra";
            this.lblCodigoBarra.Size = new System.Drawing.Size(127, 20);
            this.lblCodigoBarra.TabIndex = 149;
            this.lblCodigoBarra.Text = "Codigo De Barra";
            // 
            // ModificarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 375);
            this.Controls.Add(this.nudPrecioPublico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudPrecioCosto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudStock);
            this.Controls.Add(this.chkPermitirStockNegativo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btnNuevoRubro);
            this.Controls.Add(this.btnNuevaMarca);
            this.Controls.Add(this.cmbRubro);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcodigoBarra);
            this.Controls.Add(this.lblCodigoBarra);
            this.Controls.Add(this.MenuAccesoRapido);
            this.MaximumSize = new System.Drawing.Size(754, 431);
            this.MinimumSize = new System.Drawing.Size(754, 431);
            this.Name = "ModificarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Producto";
            this.MenuAccesoRapido.ResumeLayout(false);
            this.MenuAccesoRapido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioPublico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MenuAccesoRapido;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        public System.Windows.Forms.NumericUpDown nudPrecioPublico;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown nudPrecioCosto;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown nudStock;
        public System.Windows.Forms.CheckBox chkPermitirStockNegativo;
        public System.Windows.Forms.TextBox txtCodigo;
        public System.Windows.Forms.Button btnNuevoRubro;
        public System.Windows.Forms.Button btnNuevaMarca;
        public System.Windows.Forms.ComboBox cmbRubro;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.ComboBox cmbMarca;
        public System.Windows.Forms.Label lblMarca;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtcodigoBarra;
        public System.Windows.Forms.Label lblCodigoBarra;
    }
}