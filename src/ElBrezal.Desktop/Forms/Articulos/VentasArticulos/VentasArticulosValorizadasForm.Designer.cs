namespace ElBrezal.Desktop.Forms.Articulos.VentasArticulos
{
    partial class VentasArticulosValorizadasForm
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
            btnSalir = new Button();
            btnMigrarExcel = new Button();
            gpFiltros = new GroupBox();
            dateTimePickerHasta = new DateTimePicker();
            dateTimePickerDesde = new DateTimePicker();
            lblDesde = new Label();
            dtHasta = new Label();
            gpResultados = new GroupBox();
            lblTotal = new Label();
            label3 = new Label();
            lblCantidadArticulos = new Label();
            label1 = new Label();
            dataGridViewVentasArticulos = new DataGridView();
            DataGridViewTextBoxCodigo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxArticulo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxCantidad = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxTotal = new DataGridViewTextBoxColumn();
            gpTitulo = new GroupBox();
            lblTitulo = new Label();
            gpFiltros.SuspendLayout();
            gpResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVentasArticulos).BeginInit();
            gpTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(302, 522);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(63, 23);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnMigrarExcel
            // 
            btnMigrarExcel.Location = new Point(199, 522);
            btnMigrarExcel.Name = "btnMigrarExcel";
            btnMigrarExcel.Size = new Size(97, 23);
            btnMigrarExcel.TabIndex = 8;
            btnMigrarExcel.Text = "Exportar a Excel";
            btnMigrarExcel.UseVisualStyleBackColor = true;
            btnMigrarExcel.Click += btnMigrarExcel_Click;
            // 
            // gpFiltros
            // 
            gpFiltros.Controls.Add(dateTimePickerHasta);
            gpFiltros.Controls.Add(dateTimePickerDesde);
            gpFiltros.Controls.Add(lblDesde);
            gpFiltros.Controls.Add(dtHasta);
            gpFiltros.Location = new Point(55, 68);
            gpFiltros.Name = "gpFiltros";
            gpFiltros.Size = new Size(505, 45);
            gpFiltros.TabIndex = 6;
            gpFiltros.TabStop = false;
            // 
            // dateTimePickerHasta
            // 
            dateTimePickerHasta.Format = DateTimePickerFormat.Short;
            dateTimePickerHasta.Location = new Point(271, 11);
            dateTimePickerHasta.Name = "dateTimePickerHasta";
            dateTimePickerHasta.Size = new Size(103, 23);
            dateTimePickerHasta.TabIndex = 8;
            dateTimePickerHasta.ValueChanged += dateTimePickerHasta_ValueChanged;
            // 
            // dateTimePickerDesde
            // 
            dateTimePickerDesde.Format = DateTimePickerFormat.Short;
            dateTimePickerDesde.Location = new Point(88, 13);
            dateTimePickerDesde.Name = "dateTimePickerDesde";
            dateTimePickerDesde.Size = new Size(103, 23);
            dateTimePickerDesde.TabIndex = 7;
            dateTimePickerDesde.ValueChanged += dateTimePickerDesde_ValueChanged;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(23, 19);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 4;
            lblDesde.Text = "Desde:";
            // 
            // dtHasta
            // 
            dtHasta.AutoSize = true;
            dtHasta.Location = new Point(213, 17);
            dtHasta.Name = "dtHasta";
            dtHasta.Size = new Size(40, 15);
            dtHasta.TabIndex = 2;
            dtHasta.Text = "Hasta:";
            // 
            // gpResultados
            // 
            gpResultados.Controls.Add(lblTotal);
            gpResultados.Controls.Add(label3);
            gpResultados.Controls.Add(lblCantidadArticulos);
            gpResultados.Controls.Add(label1);
            gpResultados.Controls.Add(dataGridViewVentasArticulos);
            gpResultados.Location = new Point(54, 119);
            gpResultados.Name = "gpResultados";
            gpResultados.Size = new Size(506, 379);
            gpResultados.TabIndex = 7;
            gpResultados.TabStop = false;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblTotal.Location = new Point(336, 342);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(39, 17);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "$00.0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.Location = new Point(294, 342);
            label3.Name = "label3";
            label3.Size = new Size(40, 17);
            label3.TabIndex = 3;
            label3.Text = "Total:";
            // 
            // lblCantidadArticulos
            // 
            lblCantidadArticulos.AutoSize = true;
            lblCantidadArticulos.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblCantidadArticulos.Location = new Point(116, 342);
            lblCantidadArticulos.Name = "lblCantidadArticulos";
            lblCantidadArticulos.Size = new Size(22, 17);
            lblCantidadArticulos.TabIndex = 2;
            lblCantidadArticulos.Text = "00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.Location = new Point(46, 342);
            label1.Name = "label1";
            label1.Size = new Size(64, 17);
            label1.TabIndex = 1;
            label1.Text = "Artículos:";
            // 
            // dataGridViewVentasArticulos
            // 
            dataGridViewVentasArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewVentasArticulos.Columns.AddRange(new DataGridViewColumn[] { DataGridViewTextBoxCodigo, DataGridViewTextBoxArticulo, DataGridViewTextBoxCantidad, DataGridViewTextBoxTotal });
            dataGridViewVentasArticulos.Location = new Point(6, 22);
            dataGridViewVentasArticulos.Name = "dataGridViewVentasArticulos";
            dataGridViewVentasArticulos.Size = new Size(494, 306);
            dataGridViewVentasArticulos.TabIndex = 0;
            // 
            // DataGridViewTextBoxCodigo
            // 
            DataGridViewTextBoxCodigo.HeaderText = "Código";
            DataGridViewTextBoxCodigo.Name = "DataGridViewTextBoxCodigo";
            DataGridViewTextBoxCodigo.ReadOnly = true;
            // 
            // DataGridViewTextBoxArticulo
            // 
            DataGridViewTextBoxArticulo.HeaderText = "Artículo";
            DataGridViewTextBoxArticulo.Name = "DataGridViewTextBoxArticulo";
            DataGridViewTextBoxArticulo.ReadOnly = true;
            // 
            // DataGridViewTextBoxCantidad
            // 
            DataGridViewTextBoxCantidad.HeaderText = "Cantidad";
            DataGridViewTextBoxCantidad.Name = "DataGridViewTextBoxCantidad";
            // 
            // DataGridViewTextBoxTotal
            // 
            DataGridViewTextBoxTotal.HeaderText = "Total";
            DataGridViewTextBoxTotal.Name = "DataGridViewTextBoxTotal";
            DataGridViewTextBoxTotal.ReadOnly = true;
            // 
            // gpTitulo
            // 
            gpTitulo.Controls.Add(lblTitulo);
            gpTitulo.Location = new Point(55, 12);
            gpTitulo.Name = "gpTitulo";
            gpTitulo.Size = new Size(505, 50);
            gpTitulo.TabIndex = 5;
            gpTitulo.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(66, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(308, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Ventas Articulo Valorizadas";
            // 
            // VentasArticulosValorizadasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 557);
            Controls.Add(btnSalir);
            Controls.Add(btnMigrarExcel);
            Controls.Add(gpFiltros);
            Controls.Add(gpResultados);
            Controls.Add(gpTitulo);
            KeyPreview = true;
            Name = "VentasArticulosValorizadasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas Articulos Valorizadas";
            Load += VentasArticulosValorizadasForm_Load;
            KeyDown += VentasArticulosValorizadasForm_KeyDown;
            gpFiltros.ResumeLayout(false);
            gpFiltros.PerformLayout();
            gpResultados.ResumeLayout(false);
            gpResultados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVentasArticulos).EndInit();
            gpTitulo.ResumeLayout(false);
            gpTitulo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Button btnMigrarExcel;
        private GroupBox gpFiltros;
        private DateTimePicker dateTimePickerHasta;
        private DateTimePicker dateTimePickerDesde;
        private Label lblDesde;
        private Label dtHasta;
        private GroupBox gpResultados;
        private Label lblTotal;
        private Label label3;
        private Label lblCantidadComprobantes;
        private DataGridView dataGridViewVentasArticulos;
        private DataGridViewTextBoxColumn DataGridViewTextBoxTotalGeneral;
        private GroupBox gpTitulo;
        private Label lblTitulo;
        private Label lblCantidadArticulos;
        private Label label1;
        private DataGridViewTextBoxColumn DataGridViewTextBoxCodigo;
        private DataGridViewTextBoxColumn DataGridViewTextBoxArticulo;
        private DataGridViewTextBoxColumn DataGridViewTextBoxCantidad;
        private DataGridViewTextBoxColumn DataGridViewTextBoxTotal;
    }
}