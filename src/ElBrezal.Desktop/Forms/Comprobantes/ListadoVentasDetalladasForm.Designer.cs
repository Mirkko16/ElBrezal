namespace ElBrezal.Desktop.Forms.Comprobantes
{
    partial class ListadoVentasDetalladasForm
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
            btnImprimir = new Button();
            gpFiltros = new GroupBox();
            textBoxNumCuenta = new TextBox();
            btnBuscarCliente = new Button();
            dateTimePickerHasta = new DateTimePicker();
            lblCuenta = new Label();
            dateTimePickerDesde = new DateTimePicker();
            textBoxNombreCliente = new TextBox();
            lblDesde = new Label();
            dtHasta = new Label();
            lblTipoComprobante = new Label();
            cmbTipoComprobante = new ComboBox();
            gpResultados = new GroupBox();
            lblTotalComprobantes = new Label();
            label3 = new Label();
            lblCantidadComprobantes = new Label();
            label1 = new Label();
            dataGridViewComprobantes = new DataGridView();
            DataGridViewTextBoxFecha = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxTipo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxNumero = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxCuenta = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxCliente = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxVendedor = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxCondicion = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxTotal = new DataGridViewTextBoxColumn();
            gpTitulo = new GroupBox();
            lblTitulo = new Label();
            gpFiltros.SuspendLayout();
            gpResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewComprobantes).BeginInit();
            gpTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(438, 477);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(63, 23);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(353, 477);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(63, 23);
            btnImprimir.TabIndex = 8;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // gpFiltros
            // 
            gpFiltros.Controls.Add(textBoxNumCuenta);
            gpFiltros.Controls.Add(btnBuscarCliente);
            gpFiltros.Controls.Add(dateTimePickerHasta);
            gpFiltros.Controls.Add(lblCuenta);
            gpFiltros.Controls.Add(dateTimePickerDesde);
            gpFiltros.Controls.Add(textBoxNombreCliente);
            gpFiltros.Controls.Add(lblDesde);
            gpFiltros.Controls.Add(dtHasta);
            gpFiltros.Controls.Add(lblTipoComprobante);
            gpFiltros.Controls.Add(cmbTipoComprobante);
            gpFiltros.Location = new Point(12, 67);
            gpFiltros.Name = "gpFiltros";
            gpFiltros.Size = new Size(866, 91);
            gpFiltros.TabIndex = 6;
            gpFiltros.TabStop = false;
            // 
            // textBoxNumCuenta
            // 
            textBoxNumCuenta.Location = new Point(59, 51);
            textBoxNumCuenta.Margin = new Padding(3, 2, 3, 2);
            textBoxNumCuenta.Name = "textBoxNumCuenta";
            textBoxNumCuenta.Size = new Size(41, 23);
            textBoxNumCuenta.TabIndex = 28;
            textBoxNumCuenta.KeyDown += textBoxNumCuenta_KeyDown;
            textBoxNumCuenta.KeyPress += textBoxNumCuenta_KeyPress;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnBuscarCliente.Location = new Point(373, 51);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(31, 24);
            btnBuscarCliente.TabIndex = 9;
            btnBuscarCliente.Text = "...";
            btnBuscarCliente.UseVisualStyleBackColor = true;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // dateTimePickerHasta
            // 
            dateTimePickerHasta.Format = DateTimePickerFormat.Short;
            dateTimePickerHasta.Location = new Point(445, 17);
            dateTimePickerHasta.Name = "dateTimePickerHasta";
            dateTimePickerHasta.Size = new Size(103, 23);
            dateTimePickerHasta.TabIndex = 8;
            dateTimePickerHasta.ValueChanged += dateTimePickerHasta_ValueChanged;
            // 
            // lblCuenta
            // 
            lblCuenta.AutoSize = true;
            lblCuenta.Location = new Point(6, 58);
            lblCuenta.Name = "lblCuenta";
            lblCuenta.Size = new Size(48, 15);
            lblCuenta.TabIndex = 25;
            lblCuenta.Text = "Cuenta:";
            // 
            // dateTimePickerDesde
            // 
            dateTimePickerDesde.Format = DateTimePickerFormat.Short;
            dateTimePickerDesde.Location = new Point(264, 17);
            dateTimePickerDesde.Name = "dateTimePickerDesde";
            dateTimePickerDesde.Size = new Size(103, 23);
            dateTimePickerDesde.TabIndex = 7;
            dateTimePickerDesde.ValueChanged += dateTimePickerDesde_ValueChanged;
            // 
            // textBoxNombreCliente
            // 
            textBoxNombreCliente.Location = new Point(105, 51);
            textBoxNombreCliente.Name = "textBoxNombreCliente";
            textBoxNombreCliente.Size = new Size(262, 23);
            textBoxNombreCliente.TabIndex = 6;
            textBoxNombreCliente.KeyDown += textBoxCliente_KeyDown;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(216, 25);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 4;
            lblDesde.Text = "Desde:";
            // 
            // dtHasta
            // 
            dtHasta.AutoSize = true;
            dtHasta.Location = new Point(399, 25);
            dtHasta.Name = "dtHasta";
            dtHasta.Size = new Size(40, 15);
            dtHasta.TabIndex = 2;
            dtHasta.Text = "Hasta:";
            // 
            // lblTipoComprobante
            // 
            lblTipoComprobante.AutoSize = true;
            lblTipoComprobante.Location = new Point(6, 25);
            lblTipoComprobante.Name = "lblTipoComprobante";
            lblTipoComprobante.Size = new Size(34, 15);
            lblTipoComprobante.TabIndex = 1;
            lblTipoComprobante.Text = "Tipo:";
            // 
            // cmbTipoComprobante
            // 
            cmbTipoComprobante.FormattingEnabled = true;
            cmbTipoComprobante.Location = new Point(46, 17);
            cmbTipoComprobante.Name = "cmbTipoComprobante";
            cmbTipoComprobante.Size = new Size(154, 23);
            cmbTipoComprobante.TabIndex = 0;
            cmbTipoComprobante.SelectedIndexChanged += cmbTipoComprobante_SelectedIndexChanged;
            // 
            // gpResultados
            // 
            gpResultados.Controls.Add(lblTotalComprobantes);
            gpResultados.Controls.Add(label3);
            gpResultados.Controls.Add(lblCantidadComprobantes);
            gpResultados.Controls.Add(label1);
            gpResultados.Controls.Add(dataGridViewComprobantes);
            gpResultados.Location = new Point(12, 157);
            gpResultados.Name = "gpResultados";
            gpResultados.Size = new Size(866, 314);
            gpResultados.TabIndex = 7;
            gpResultados.TabStop = false;
            // 
            // lblTotalComprobantes
            // 
            lblTotalComprobantes.AutoSize = true;
            lblTotalComprobantes.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblTotalComprobantes.Location = new Point(693, 278);
            lblTotalComprobantes.Name = "lblTotalComprobantes";
            lblTotalComprobantes.Size = new Size(39, 17);
            lblTotalComprobantes.TabIndex = 8;
            lblTotalComprobantes.Text = "$00.0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.Location = new Point(651, 278);
            label3.Name = "label3";
            label3.Size = new Size(40, 17);
            label3.TabIndex = 7;
            label3.Text = "Total:";
            // 
            // lblCantidadComprobantes
            // 
            lblCantidadComprobantes.AutoSize = true;
            lblCantidadComprobantes.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblCantidadComprobantes.Location = new Point(150, 278);
            lblCantidadComprobantes.Name = "lblCantidadComprobantes";
            lblCantidadComprobantes.Size = new Size(39, 17);
            lblCantidadComprobantes.TabIndex = 6;
            lblCantidadComprobantes.Text = "$00.0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.Location = new Point(46, 278);
            label1.Name = "label1";
            label1.Size = new Size(101, 17);
            label1.TabIndex = 5;
            label1.Text = "Comprobantes:";
            // 
            // dataGridViewComprobantes
            // 
            dataGridViewComprobantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewComprobantes.Columns.AddRange(new DataGridViewColumn[] { DataGridViewTextBoxFecha, DataGridViewTextBoxTipo, DataGridViewTextBoxNumero, DataGridViewTextBoxCuenta, DataGridViewTextBoxCliente, DataGridViewTextBoxVendedor, DataGridViewTextBoxCondicion, DataGridViewTextBoxTotal });
            dataGridViewComprobantes.Location = new Point(6, 22);
            dataGridViewComprobantes.Name = "dataGridViewComprobantes";
            dataGridViewComprobantes.Size = new Size(851, 233);
            dataGridViewComprobantes.TabIndex = 0;
            // 
            // DataGridViewTextBoxFecha
            // 
            DataGridViewTextBoxFecha.HeaderText = "Fecha";
            DataGridViewTextBoxFecha.Name = "DataGridViewTextBoxFecha";
            DataGridViewTextBoxFecha.ReadOnly = true;
            // 
            // DataGridViewTextBoxTipo
            // 
            DataGridViewTextBoxTipo.HeaderText = "Tipo";
            DataGridViewTextBoxTipo.Name = "DataGridViewTextBoxTipo";
            DataGridViewTextBoxTipo.ReadOnly = true;
            // 
            // DataGridViewTextBoxNumero
            // 
            DataGridViewTextBoxNumero.HeaderText = "Número";
            DataGridViewTextBoxNumero.Name = "DataGridViewTextBoxNumero";
            // 
            // DataGridViewTextBoxCuenta
            // 
            DataGridViewTextBoxCuenta.HeaderText = "Cuenta";
            DataGridViewTextBoxCuenta.Name = "DataGridViewTextBoxCuenta";
            DataGridViewTextBoxCuenta.ReadOnly = true;
            // 
            // DataGridViewTextBoxCliente
            // 
            DataGridViewTextBoxCliente.HeaderText = "Cliente";
            DataGridViewTextBoxCliente.Name = "DataGridViewTextBoxCliente";
            DataGridViewTextBoxCliente.ReadOnly = true;
            // 
            // DataGridViewTextBoxVendedor
            // 
            DataGridViewTextBoxVendedor.HeaderText = "Vendedor";
            DataGridViewTextBoxVendedor.Name = "DataGridViewTextBoxVendedor";
            DataGridViewTextBoxVendedor.ReadOnly = true;
            // 
            // DataGridViewTextBoxCondicion
            // 
            DataGridViewTextBoxCondicion.HeaderText = "Condición";
            DataGridViewTextBoxCondicion.Name = "DataGridViewTextBoxCondicion";
            DataGridViewTextBoxCondicion.ReadOnly = true;
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
            gpTitulo.Location = new Point(12, 12);
            gpTitulo.Name = "gpTitulo";
            gpTitulo.Size = new Size(866, 56);
            gpTitulo.TabIndex = 5;
            gpTitulo.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(255, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(326, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Listado de Ventas Detalladas";
            // 
            // ListadoVentasDetalladasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 510);
            Controls.Add(btnSalir);
            Controls.Add(btnImprimir);
            Controls.Add(gpFiltros);
            Controls.Add(gpResultados);
            Controls.Add(gpTitulo);
            KeyPreview = true;
            Name = "ListadoVentasDetalladasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListadoVentasDetalladasForm";
            Load += ListadoVentasDetalladasForm_Load;
            KeyDown += ListadoVentasDetalladasForm_KeyDown;
            gpFiltros.ResumeLayout(false);
            gpFiltros.PerformLayout();
            gpResultados.ResumeLayout(false);
            gpResultados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewComprobantes).EndInit();
            gpTitulo.ResumeLayout(false);
            gpTitulo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Button btnImprimir;
        private GroupBox gpFiltros;
        private TextBox textBoxNumCuenta;
        private Button btnBuscarCliente;
        private DateTimePicker dateTimePickerHasta;
        private Label lblCuenta;
        private DateTimePicker dateTimePickerDesde;
        private TextBox textBoxNombreCliente;
        private Label lblDesde;
        private Label dtHasta;
        private Label lblTipoComprobante;
        private ComboBox cmbTipoComprobante;
        private GroupBox gpResultados;
        private DataGridView dataGridViewComprobantes;
        private DataGridViewTextBoxColumn DataGridViewTextBoxFecha;
        private DataGridViewTextBoxColumn DataGridViewTextBoxTipo;
        private DataGridViewTextBoxColumn DataGridViewTextBoxNumero;
        private DataGridViewTextBoxColumn DataGridViewTextBoxCuenta;
        private DataGridViewTextBoxColumn DataGridViewTextBoxCliente;
        private DataGridViewTextBoxColumn DataGridViewTextBoxVendedor;
        private DataGridViewTextBoxColumn DataGridViewTextBoxCondicion;
        private DataGridViewTextBoxColumn DataGridViewTextBoxTotal;
        private GroupBox gpTitulo;
        private Label lblTitulo;
        private Label lblTotalComprobantes;
        private Label label3;
        private Label lblCantidadComprobantes;
        private Label label1;
    }
}