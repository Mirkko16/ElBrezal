namespace ElBrezal.Desktop.Forms.Articulos.StockMinimo
{
    partial class StockMinimoForm
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
            groupBoxStockMinimo = new GroupBox();
            textBoxBuscarProducto = new TextBox();
            lblDescripcion = new Label();
            label1 = new Label();
            groupBoxTablaMinimos = new GroupBox();
            dataGridViewStockMinimos = new DataGridView();
            DataGridViewTextBoxColumnArticulo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnDescripcion = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnStock = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnStockMinimo = new DataGridViewTextBoxColumn();
            btnSalir = new Button();
            groupBoxStockMinimo.SuspendLayout();
            groupBoxTablaMinimos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStockMinimos).BeginInit();
            SuspendLayout();
            // 
            // groupBoxStockMinimo
            // 
            groupBoxStockMinimo.Controls.Add(textBoxBuscarProducto);
            groupBoxStockMinimo.Controls.Add(lblDescripcion);
            groupBoxStockMinimo.Location = new Point(31, 47);
            groupBoxStockMinimo.Name = "groupBoxStockMinimo";
            groupBoxStockMinimo.Size = new Size(559, 67);
            groupBoxStockMinimo.TabIndex = 0;
            groupBoxStockMinimo.TabStop = false;
            // 
            // textBoxBuscarProducto
            // 
            textBoxBuscarProducto.Location = new Point(101, 24);
            textBoxBuscarProducto.Name = "textBoxBuscarProducto";
            textBoxBuscarProducto.Size = new Size(339, 23);
            textBoxBuscarProducto.TabIndex = 1;
            textBoxBuscarProducto.TextChanged += textBoxBuscarProducto_TextChanged;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(23, 32);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 0;
            lblDescripcion.Text = "Descripción:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(187, 19);
            label1.Name = "label1";
            label1.Size = new Size(187, 25);
            label1.TabIndex = 1;
            label1.Text = "Tabla Stock Mínimos";
            // 
            // groupBoxTablaMinimos
            // 
            groupBoxTablaMinimos.Controls.Add(dataGridViewStockMinimos);
            groupBoxTablaMinimos.Location = new Point(31, 130);
            groupBoxTablaMinimos.Name = "groupBoxTablaMinimos";
            groupBoxTablaMinimos.Size = new Size(559, 293);
            groupBoxTablaMinimos.TabIndex = 2;
            groupBoxTablaMinimos.TabStop = false;
            // 
            // dataGridViewStockMinimos
            // 
            dataGridViewStockMinimos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStockMinimos.Columns.AddRange(new DataGridViewColumn[] { DataGridViewTextBoxColumnArticulo, DataGridViewTextBoxColumnDescripcion, DataGridViewTextBoxColumnStock, DataGridViewTextBoxColumnStockMinimo });
            dataGridViewStockMinimos.Location = new Point(6, 18);
            dataGridViewStockMinimos.Name = "dataGridViewStockMinimos";
            dataGridViewStockMinimos.Size = new Size(547, 265);
            dataGridViewStockMinimos.TabIndex = 0;
            // 
            // DataGridViewTextBoxColumnArticulo
            // 
            DataGridViewTextBoxColumnArticulo.HeaderText = "Articulo";
            DataGridViewTextBoxColumnArticulo.Name = "DataGridViewTextBoxColumnArticulo";
            DataGridViewTextBoxColumnArticulo.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumnDescripcion
            // 
            DataGridViewTextBoxColumnDescripcion.HeaderText = "Descripción";
            DataGridViewTextBoxColumnDescripcion.Name = "DataGridViewTextBoxColumnDescripcion";
            DataGridViewTextBoxColumnDescripcion.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumnStock
            // 
            DataGridViewTextBoxColumnStock.HeaderText = "Stock";
            DataGridViewTextBoxColumnStock.Name = "DataGridViewTextBoxColumnStock";
            DataGridViewTextBoxColumnStock.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumnStockMinimo
            // 
            DataGridViewTextBoxColumnStockMinimo.HeaderText = "Stock Minimo";
            DataGridViewTextBoxColumnStockMinimo.Name = "DataGridViewTextBoxColumnStockMinimo";
            DataGridViewTextBoxColumnStockMinimo.ReadOnly = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(519, 436);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(71, 25);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // StockMinimoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 473);
            Controls.Add(btnSalir);
            Controls.Add(groupBoxTablaMinimos);
            Controls.Add(label1);
            Controls.Add(groupBoxStockMinimo);
            KeyPreview = true;
            Name = "StockMinimoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tabla Stock Minimos";
            Load += StockMinimoForm_Load;
            KeyDown += StockMinimoForm_KeyDown;
            groupBoxStockMinimo.ResumeLayout(false);
            groupBoxStockMinimo.PerformLayout();
            groupBoxTablaMinimos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStockMinimos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxStockMinimo;
        private TextBox textBoxBuscarProducto;
        private Label lblDescripcion;
        private Label label1;
        private GroupBox groupBoxTablaMinimos;
        private Button btnSalir;
        private DataGridView dataGridViewStockMinimos;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnArticulo;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnDescripcion;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnStock;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnStockMinimo;
    }
}