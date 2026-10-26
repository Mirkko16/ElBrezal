namespace ElBrezal.Desktop.Forms.Configs.Arca
{
    partial class ComprobantesPendientesForm
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
            dataGridViewComprobantes = new DataGridView();
            DataGridViewTextBoxColId = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColFecha = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColTipoComprobante = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColPuntoVenta = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColNumero = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColCliente = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColTotal = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColEstado = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColCantidadIntentos = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColUltimoIntento = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColUltimoError = new DataGridViewTextBoxColumn();
            lblTitulo = new Label();
            lblEstado = new Label();
            lblComprobante = new Label();
            lblSubtitulo = new Label();
            btnConsultarArca = new Button();
            btnAutorizar = new Button();
            btnVerDetalle = new Button();
            cmbEstado = new ComboBox();
            textBoxNumero = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewComprobantes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewComprobantes
            // 
            dataGridViewComprobantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewComprobantes.Columns.AddRange(new DataGridViewColumn[] { DataGridViewTextBoxColId, DataGridViewTextBoxColFecha, DataGridViewTextBoxColTipoComprobante, DataGridViewTextBoxColPuntoVenta, DataGridViewTextBoxColNumero, DataGridViewTextBoxColCliente, DataGridViewTextBoxColTotal, DataGridViewTextBoxColEstado, DataGridViewTextBoxColCantidadIntentos, DataGridViewTextBoxColUltimoIntento, DataGridViewTextBoxColUltimoError });
            dataGridViewComprobantes.Location = new Point(10, 103);
            dataGridViewComprobantes.Margin = new Padding(3, 2, 3, 2);
            dataGridViewComprobantes.Name = "dataGridViewComprobantes";
            dataGridViewComprobantes.RowHeadersWidth = 51;
            dataGridViewComprobantes.Size = new Size(987, 219);
            dataGridViewComprobantes.TabIndex = 0;
            dataGridViewComprobantes.CellDoubleClick += dataGridViewComprobantes_CellDoubleClick;
            dataGridViewComprobantes.SelectionChanged += dataGridViewComprobantes_SelectionChanged;
            // 
            // DataGridViewTextBoxColId
            // 
            DataGridViewTextBoxColId.HeaderText = "Id";
            DataGridViewTextBoxColId.Name = "DataGridViewTextBoxColId";
            DataGridViewTextBoxColId.ReadOnly = true;
            // 
            // DataGridViewTextBoxColFecha
            // 
            DataGridViewTextBoxColFecha.HeaderText = "Fecha";
            DataGridViewTextBoxColFecha.Name = "DataGridViewTextBoxColFecha";
            DataGridViewTextBoxColFecha.ReadOnly = true;
            // 
            // DataGridViewTextBoxColTipoComprobante
            // 
            DataGridViewTextBoxColTipoComprobante.HeaderText = "Tipo";
            DataGridViewTextBoxColTipoComprobante.Name = "DataGridViewTextBoxColTipoComprobante";
            DataGridViewTextBoxColTipoComprobante.ReadOnly = true;
            // 
            // DataGridViewTextBoxColPuntoVenta
            // 
            DataGridViewTextBoxColPuntoVenta.HeaderText = "Pv";
            DataGridViewTextBoxColPuntoVenta.Name = "DataGridViewTextBoxColPuntoVenta";
            DataGridViewTextBoxColPuntoVenta.ReadOnly = true;
            // 
            // DataGridViewTextBoxColNumero
            // 
            DataGridViewTextBoxColNumero.HeaderText = "Número";
            DataGridViewTextBoxColNumero.Name = "DataGridViewTextBoxColNumero";
            DataGridViewTextBoxColNumero.ReadOnly = true;
            // 
            // DataGridViewTextBoxColCliente
            // 
            DataGridViewTextBoxColCliente.HeaderText = "Cliente";
            DataGridViewTextBoxColCliente.Name = "DataGridViewTextBoxColCliente";
            DataGridViewTextBoxColCliente.ReadOnly = true;
            // 
            // DataGridViewTextBoxColTotal
            // 
            DataGridViewTextBoxColTotal.HeaderText = "Total";
            DataGridViewTextBoxColTotal.Name = "DataGridViewTextBoxColTotal";
            DataGridViewTextBoxColTotal.ReadOnly = true;
            // 
            // DataGridViewTextBoxColEstado
            // 
            DataGridViewTextBoxColEstado.HeaderText = "Estado Arca";
            DataGridViewTextBoxColEstado.Name = "DataGridViewTextBoxColEstado";
            DataGridViewTextBoxColEstado.ReadOnly = true;
            // 
            // DataGridViewTextBoxColCantidadIntentos
            // 
            DataGridViewTextBoxColCantidadIntentos.HeaderText = "Intentos";
            DataGridViewTextBoxColCantidadIntentos.Name = "DataGridViewTextBoxColCantidadIntentos";
            DataGridViewTextBoxColCantidadIntentos.ReadOnly = true;
            // 
            // DataGridViewTextBoxColUltimoIntento
            // 
            DataGridViewTextBoxColUltimoIntento.HeaderText = "Ultimo Intento";
            DataGridViewTextBoxColUltimoIntento.Name = "DataGridViewTextBoxColUltimoIntento";
            DataGridViewTextBoxColUltimoIntento.ReadOnly = true;
            // 
            // DataGridViewTextBoxColUltimoError
            // 
            DataGridViewTextBoxColUltimoError.HeaderText = "Ultimo Error";
            DataGridViewTextBoxColUltimoError.Name = "DataGridViewTextBoxColUltimoError";
            DataGridViewTextBoxColUltimoError.ReadOnly = true;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(10, 7);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(304, 20);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "LISTADO DE COMPROBANTES PENDIENTES";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(10, 53);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Estado";
            // 
            // lblComprobante
            // 
            lblComprobante.AutoSize = true;
            lblComprobante.Location = new Point(447, 53);
            lblComprobante.Name = "lblComprobante";
            lblComprobante.Size = new Size(81, 15);
            lblComprobante.TabIndex = 3;
            lblComprobante.Text = "Comprobante";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(10, 26);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(208, 15);
            lblSubtitulo.TabIndex = 4;
            lblSubtitulo.Text = "Control de autorizaciones electrónicas";
            // 
            // btnConsultarArca
            // 
            btnConsultarArca.Location = new Point(304, 326);
            btnConsultarArca.Margin = new Padding(3, 2, 3, 2);
            btnConsultarArca.Name = "btnConsultarArca";
            btnConsultarArca.Size = new Size(102, 22);
            btnConsultarArca.TabIndex = 5;
            btnConsultarArca.Text = "Consultar Arca";
            btnConsultarArca.UseVisualStyleBackColor = true;
            btnConsultarArca.Click += btnConsultarArca_Click;
            // 
            // btnAutorizar
            // 
            btnAutorizar.Location = new Point(444, 326);
            btnAutorizar.Margin = new Padding(3, 2, 3, 2);
            btnAutorizar.Name = "btnAutorizar";
            btnAutorizar.Size = new Size(82, 22);
            btnAutorizar.TabIndex = 6;
            btnAutorizar.Text = "Autorizar";
            btnAutorizar.UseVisualStyleBackColor = true;
            btnAutorizar.Click += btnAutorizar_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Location = new Point(575, 326);
            btnVerDetalle.Margin = new Padding(3, 2, 3, 2);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(82, 22);
            btnVerDetalle.TabIndex = 7;
            btnVerDetalle.Text = "Ver Detalle";
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(10, 70);
            cmbEstado.Margin = new Padding(3, 2, 3, 2);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(162, 23);
            cmbEstado.TabIndex = 8;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;
            // 
            // textBoxNumero
            // 
            textBoxNumero.Location = new Point(447, 71);
            textBoxNumero.Margin = new Padding(3, 2, 3, 2);
            textBoxNumero.Name = "textBoxNumero";
            textBoxNumero.PlaceholderText = "Buscar número...";
            textBoxNumero.Size = new Size(210, 23);
            textBoxNumero.TabIndex = 9;
            textBoxNumero.TextChanged += textBoxNumero_TextChanged;
            // 
            // ComprobantesPendientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1009, 359);
            Controls.Add(textBoxNumero);
            Controls.Add(cmbEstado);
            Controls.Add(btnVerDetalle);
            Controls.Add(btnAutorizar);
            Controls.Add(btnConsultarArca);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblComprobante);
            Controls.Add(lblEstado);
            Controls.Add(lblTitulo);
            Controls.Add(dataGridViewComprobantes);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ComprobantesPendientesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ComprobantesPendientesForm";
            Load += ComprobantesPendientesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewComprobantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewComprobantes;
        private Label lblTitulo;
        private Label lblEstado;
        private Label lblComprobante;
        private Label lblSubtitulo;
        private Button btnConsultarArca;
        private Button btnAutorizar;
        private Button btnVerDetalle;
        private ComboBox cmbEstado;
        private TextBox textBoxNumero;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColId;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColFecha;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColTipoComprobante;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColPuntoVenta;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColNumero;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColCliente;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColTotal;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColEstado;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColCantidadIntentos;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColUltimoIntento;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColUltimoError;
    }
}