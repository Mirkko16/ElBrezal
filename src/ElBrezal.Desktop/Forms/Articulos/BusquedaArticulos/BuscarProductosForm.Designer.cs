namespace ElBrezal.Desktop.Forms.Articulos.BusquedaArticulos
{
    partial class BuscarProductosForm
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
            lblBuscar = new Label();
            textBoxBuscar = new TextBox();
            dataGridViewProductos = new DataGridView();
            dataGridViewTextBoxColumnCodigo = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnDescripcion = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnStock = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscar.Location = new Point(52, 31);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(47, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Location = new Point(108, 28);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(368, 23);
            textBoxBuscar.TabIndex = 1;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            textBoxBuscar.KeyDown += textBoxBuscar_KeyDown;
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumnCodigo, dataGridViewTextBoxColumnDescripcion, dataGridViewTextBoxColumnStock });
            dataGridViewProductos.Location = new Point(29, 81);
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.Size = new Size(580, 336);
            dataGridViewProductos.TabIndex = 2;
            dataGridViewProductos.CellDoubleClick += dataGridViewProductos_CellDoubleClick;
            dataGridViewProductos.KeyDown += dataGridViewProductos_KeyDown;
            // 
            // dataGridViewTextBoxColumnCodigo
            // 
            dataGridViewTextBoxColumnCodigo.HeaderText = "Código";
            dataGridViewTextBoxColumnCodigo.Name = "dataGridViewTextBoxColumnCodigo";
            dataGridViewTextBoxColumnCodigo.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnDescripcion
            // 
            dataGridViewTextBoxColumnDescripcion.HeaderText = "Descripción";
            dataGridViewTextBoxColumnDescripcion.Name = "dataGridViewTextBoxColumnDescripcion";
            dataGridViewTextBoxColumnDescripcion.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnStock
            // 
            dataGridViewTextBoxColumnStock.HeaderText = "Stock";
            dataGridViewTextBoxColumnStock.Name = "dataGridViewTextBoxColumnStock";
            dataGridViewTextBoxColumnStock.ReadOnly = true;
            // 
            // BuscarProductosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 451);
            Controls.Add(dataGridViewProductos);
            Controls.Add(textBoxBuscar);
            Controls.Add(lblBuscar);
            Name = "BuscarProductosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BuscarProductosForm";
            Load += BuscarProductosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private TextBox textBoxBuscar;
        private DataGridView dataGridViewProductos;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnCodigo;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnDescripcion;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnStock;
    }
}