namespace ElBrezal.Desktop.Forms.Comprobantes.BusquedaComprobantes
{
    partial class BuscarComprobanteForm
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
            lblNumero = new Label();
            lblPuntaVenta = new Label();
            groupBox1 = new GroupBox();
            dataGridViewComprobantes = new DataGridView();
            btnAceptar = new Button();
            btnCancelar = new Button();
            btnBuscar = new Button();
            textBoxPuntoVenta = new TextBox();
            textBoxNumero = new TextBox();
            label1 = new Label();
            lblTipoComprobante = new Label();
            DataGridViewTextBoxFecha = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxNumero = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxCliente = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxTotal = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewComprobantes).BeginInit();
            SuspendLayout();
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNumero.Location = new Point(220, 48);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(74, 21);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "Número:";
            // 
            // lblPuntaVenta
            // 
            lblPuntaVenta.AutoSize = true;
            lblPuntaVenta.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblPuntaVenta.Location = new Point(11, 48);
            lblPuntaVenta.Name = "lblPuntaVenta";
            lblPuntaVenta.Size = new Size(125, 21);
            lblPuntaVenta.TabIndex = 1;
            lblPuntaVenta.Text = "Punto de Venta:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewComprobantes);
            groupBox1.Location = new Point(9, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(608, 166);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // dataGridViewComprobantes
            // 
            dataGridViewComprobantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewComprobantes.Columns.AddRange(new DataGridViewColumn[] { DataGridViewTextBoxFecha, DataGridViewTextBoxNumero, DataGridViewTextBoxCliente, DataGridViewTextBoxTotal });
            dataGridViewComprobantes.Location = new Point(12, 10);
            dataGridViewComprobantes.Name = "dataGridViewComprobantes";
            dataGridViewComprobantes.Size = new Size(590, 150);
            dataGridViewComprobantes.TabIndex = 0;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(220, 249);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(320, 249);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(468, 45);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // textBoxPuntoVenta
            // 
            textBoxPuntoVenta.Location = new Point(142, 46);
            textBoxPuntoVenta.Name = "textBoxPuntoVenta";
            textBoxPuntoVenta.Size = new Size(50, 23);
            textBoxPuntoVenta.TabIndex = 7;
            textBoxPuntoVenta.KeyPress += textBoxPuntoVenta_KeyPress;
            // 
            // textBoxNumero
            // 
            textBoxNumero.Location = new Point(296, 46);
            textBoxNumero.Name = "textBoxNumero";
            textBoxNumero.Size = new Size(135, 23);
            textBoxNumero.TabIndex = 8;
            textBoxNumero.KeyPress += textBoxNumero_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 21);
            label1.TabIndex = 9;
            label1.Text = "Buscar";
            // 
            // lblTipoComprobante
            // 
            lblTipoComprobante.AutoSize = true;
            lblTipoComprobante.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTipoComprobante.Location = new Point(85, 9);
            lblTipoComprobante.Name = "lblTipoComprobante";
            lblTipoComprobante.Size = new Size(16, 21);
            lblTipoComprobante.TabIndex = 10;
            lblTipoComprobante.Text = "-";
            // 
            // DataGridViewTextBoxFecha
            // 
            DataGridViewTextBoxFecha.HeaderText = "Fecha";
            DataGridViewTextBoxFecha.Name = "DataGridViewTextBoxFecha";
            DataGridViewTextBoxFecha.ReadOnly = true;
            // 
            // DataGridViewTextBoxNumero
            // 
            DataGridViewTextBoxNumero.HeaderText = "Número";
            DataGridViewTextBoxNumero.Name = "DataGridViewTextBoxNumero";
            DataGridViewTextBoxNumero.ReadOnly = true;
            // 
            // DataGridViewTextBoxCliente
            // 
            DataGridViewTextBoxCliente.HeaderText = "Cliente";
            DataGridViewTextBoxCliente.Name = "DataGridViewTextBoxCliente";
            DataGridViewTextBoxCliente.ReadOnly = true;
            // 
            // DataGridViewTextBoxTotal
            // 
            DataGridViewTextBoxTotal.HeaderText = "Total";
            DataGridViewTextBoxTotal.Name = "DataGridViewTextBoxTotal";
            DataGridViewTextBoxTotal.ReadOnly = true;
            // 
            // BuscarComprobanteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 284);
            Controls.Add(lblTipoComprobante);
            Controls.Add(label1);
            Controls.Add(textBoxNumero);
            Controls.Add(textBoxPuntoVenta);
            Controls.Add(btnBuscar);
            Controls.Add(lblNumero);
            Controls.Add(lblPuntaVenta);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(groupBox1);
            KeyPreview = true;
            Name = "BuscarComprobanteForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BuscarComprobanteForm";
            Load += BuscarComprobanteForm_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewComprobantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumero;
        private Label lblPuntaVenta;
        private GroupBox groupBox1;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnBuscar;
        private TextBox textBoxPuntoVenta;
        private TextBox textBoxNumero;
        private Label label1;
        private Label lblTipoComprobante;
        private DataGridView dataGridViewComprobantes;
        private DataGridViewTextBoxColumn DataGridViewTextBoxFecha;
        private DataGridViewTextBoxColumn DataGridViewTextBoxNumero;
        private DataGridViewTextBoxColumn DataGridViewTextBoxCliente;
        private DataGridViewTextBoxColumn DataGridViewTextBoxTotal;
    }
}