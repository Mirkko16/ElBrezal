namespace ElBrezal.Desktop.Forms.Clientes.Remitos
{
    partial class RemitoForm
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
            lblObservacion = new Label();
            dataGridViewProductos = new DataGridView();
            DataGridViewTextBoxColumnCantidad = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnArticulo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnDescripcion = new DataGridViewTextBoxColumn();
            btnSalir = new Button();
            btnConfirmar = new Button();
            btnNuevoRemito = new Button();
            textBoxObservacion = new TextBox();
            gpDatosCliente = new GroupBox();
            maskedTextBoxNumeroComprob = new MaskedTextBox();
            textBoxDNI = new TextBox();
            textBoxDireccion = new TextBox();
            lblTipo = new Label();
            textBoxNumCuenta = new TextBox();
            textBoxNombreCLiente = new TextBox();
            btnBuscarCliente = new Button();
            textBoxFecha = new TextBox();
            textBoxZona = new TextBox();
            textBoxVendedor = new TextBox();
            comboBoxTipo = new ComboBox();
            comboBoxTipoComprobante = new ComboBox();
            lblFecha = new Label();
            lblNumero = new Label();
            lblDireccion = new Label();
            lblDni = new Label();
            lblComprobante = new Label();
            lblZona = new Label();
            lblVendedor = new Label();
            lblCuenta = new Label();
            groupBoxObservaciones = new GroupBox();
            groupBoxArticulosVendidos = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            gpDatosCliente.SuspendLayout();
            groupBoxObservaciones.SuspendLayout();
            groupBoxArticulosVendidos.SuspendLayout();
            SuspendLayout();
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Location = new Point(6, 10);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(76, 15);
            lblObservacion.TabIndex = 30;
            lblObservacion.Text = "Observación:";
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Columns.AddRange(new DataGridViewColumn[] { DataGridViewTextBoxColumnCantidad, DataGridViewTextBoxColumnArticulo, DataGridViewTextBoxColumnDescripcion });
            dataGridViewProductos.Location = new Point(74, 21);
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.RowHeadersWidth = 51;
            dataGridViewProductos.Size = new Size(683, 230);
            dataGridViewProductos.TabIndex = 1;
            dataGridViewProductos.CellValueChanged += dataGridViewProductos_CellValueChanged;
            dataGridViewProductos.KeyDown += dataGridViewProductos_KeyDown;
            // 
            // DataGridViewTextBoxColumnCantidad
            // 
            DataGridViewTextBoxColumnCantidad.HeaderText = "Cant.";
            DataGridViewTextBoxColumnCantidad.MinimumWidth = 6;
            DataGridViewTextBoxColumnCantidad.Name = "DataGridViewTextBoxColumnCantidad";
            DataGridViewTextBoxColumnCantidad.Width = 125;
            // 
            // DataGridViewTextBoxColumnArticulo
            // 
            DataGridViewTextBoxColumnArticulo.HeaderText = "Articulo";
            DataGridViewTextBoxColumnArticulo.MinimumWidth = 6;
            DataGridViewTextBoxColumnArticulo.Name = "DataGridViewTextBoxColumnArticulo";
            DataGridViewTextBoxColumnArticulo.Width = 125;
            // 
            // DataGridViewTextBoxColumnDescripcion
            // 
            DataGridViewTextBoxColumnDescripcion.HeaderText = "Descripción";
            DataGridViewTextBoxColumnDescripcion.MinimumWidth = 6;
            DataGridViewTextBoxColumnDescripcion.Name = "DataGridViewTextBoxColumnDescripcion";
            DataGridViewTextBoxColumnDescripcion.ReadOnly = true;
            DataGridViewTextBoxColumnDescripcion.Width = 125;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(726, 27);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(118, 23);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(602, 27);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(118, 23);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar - F11";
            btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // btnNuevoRemito
            // 
            btnNuevoRemito.Location = new Point(479, 27);
            btnNuevoRemito.Name = "btnNuevoRemito";
            btnNuevoRemito.Size = new Size(118, 23);
            btnNuevoRemito.TabIndex = 4;
            btnNuevoRemito.Text = "Nuevo - F9";
            btnNuevoRemito.UseVisualStyleBackColor = true;
            btnNuevoRemito.Click += btnNuevoRemito_Click;
            // 
            // textBoxObservacion
            // 
            textBoxObservacion.Location = new Point(6, 28);
            textBoxObservacion.Margin = new Padding(3, 2, 3, 2);
            textBoxObservacion.Name = "textBoxObservacion";
            textBoxObservacion.Size = new Size(351, 23);
            textBoxObservacion.TabIndex = 30;
            // 
            // gpDatosCliente
            // 
            gpDatosCliente.Controls.Add(maskedTextBoxNumeroComprob);
            gpDatosCliente.Controls.Add(textBoxDNI);
            gpDatosCliente.Controls.Add(textBoxDireccion);
            gpDatosCliente.Controls.Add(lblTipo);
            gpDatosCliente.Controls.Add(textBoxNumCuenta);
            gpDatosCliente.Controls.Add(textBoxNombreCLiente);
            gpDatosCliente.Controls.Add(btnBuscarCliente);
            gpDatosCliente.Controls.Add(textBoxFecha);
            gpDatosCliente.Controls.Add(textBoxZona);
            gpDatosCliente.Controls.Add(textBoxVendedor);
            gpDatosCliente.Controls.Add(comboBoxTipo);
            gpDatosCliente.Controls.Add(comboBoxTipoComprobante);
            gpDatosCliente.Controls.Add(lblFecha);
            gpDatosCliente.Controls.Add(lblNumero);
            gpDatosCliente.Controls.Add(lblDireccion);
            gpDatosCliente.Controls.Add(lblDni);
            gpDatosCliente.Controls.Add(lblComprobante);
            gpDatosCliente.Controls.Add(lblZona);
            gpDatosCliente.Controls.Add(lblVendedor);
            gpDatosCliente.Controls.Add(lblCuenta);
            gpDatosCliente.Location = new Point(16, 24);
            gpDatosCliente.Margin = new Padding(3, 2, 3, 2);
            gpDatosCliente.Name = "gpDatosCliente";
            gpDatosCliente.Padding = new Padding(3, 2, 3, 2);
            gpDatosCliente.Size = new Size(853, 128);
            gpDatosCliente.TabIndex = 3;
            gpDatosCliente.TabStop = false;
            // 
            // maskedTextBoxNumeroComprob
            // 
            maskedTextBoxNumeroComprob.Location = new Point(721, 11);
            maskedTextBoxNumeroComprob.Mask = " \"0000-000000\"";
            maskedTextBoxNumeroComprob.Name = "maskedTextBoxNumeroComprob";
            maskedTextBoxNumeroComprob.Size = new Size(110, 23);
            maskedTextBoxNumeroComprob.TabIndex = 2;
            maskedTextBoxNumeroComprob.Text = "0000000000";
            // 
            // textBoxDNI
            // 
            textBoxDNI.Location = new Point(423, 38);
            textBoxDNI.Margin = new Padding(3, 2, 3, 2);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.Size = new Size(143, 23);
            textBoxDNI.TabIndex = 28;
            // 
            // textBoxDireccion
            // 
            textBoxDireccion.CharacterCasing = CharacterCasing.Upper;
            textBoxDireccion.Location = new Point(85, 38);
            textBoxDireccion.Margin = new Padding(3, 2, 3, 2);
            textBoxDireccion.Name = "textBoxDireccion";
            textBoxDireccion.Size = new Size(294, 23);
            textBoxDireccion.TabIndex = 25;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(297, 78);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(34, 15);
            lblTipo.TabIndex = 3;
            lblTipo.Text = "Tipo:";
            // 
            // textBoxNumCuenta
            // 
            textBoxNumCuenta.Location = new Point(70, 11);
            textBoxNumCuenta.Margin = new Padding(3, 2, 3, 2);
            textBoxNumCuenta.Name = "textBoxNumCuenta";
            textBoxNumCuenta.Size = new Size(41, 23);
            textBoxNumCuenta.TabIndex = 24;
            textBoxNumCuenta.KeyDown += textBoxNumCuenta_KeyDown;
            textBoxNumCuenta.KeyPress += textBoxNumCuenta_KeyPress;
            // 
            // textBoxNombreCLiente
            // 
            textBoxNombreCLiente.CharacterCasing = CharacterCasing.Upper;
            textBoxNombreCLiente.Location = new Point(116, 11);
            textBoxNombreCLiente.Margin = new Padding(3, 2, 3, 2);
            textBoxNombreCLiente.Name = "textBoxNombreCLiente";
            textBoxNombreCLiente.Size = new Size(263, 23);
            textBoxNombreCLiente.TabIndex = 23;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Location = new Point(383, 11);
            btnBuscarCliente.Margin = new Padding(3, 2, 3, 2);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(31, 21);
            btnBuscarCliente.TabIndex = 22;
            btnBuscarCliente.Text = "...";
            btnBuscarCliente.UseVisualStyleBackColor = true;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // textBoxFecha
            // 
            textBoxFecha.Location = new Point(488, 11);
            textBoxFecha.Margin = new Padding(3, 2, 3, 2);
            textBoxFecha.Name = "textBoxFecha";
            textBoxFecha.Size = new Size(110, 23);
            textBoxFecha.TabIndex = 21;
            // 
            // textBoxZona
            // 
            textBoxZona.CharacterCasing = CharacterCasing.Upper;
            textBoxZona.Location = new Point(721, 39);
            textBoxZona.Margin = new Padding(3, 2, 3, 2);
            textBoxZona.Name = "textBoxZona";
            textBoxZona.Size = new Size(110, 23);
            textBoxZona.TabIndex = 18;
            // 
            // textBoxVendedor
            // 
            textBoxVendedor.CharacterCasing = CharacterCasing.Upper;
            textBoxVendedor.Location = new Point(721, 70);
            textBoxVendedor.Margin = new Padding(3, 2, 3, 2);
            textBoxVendedor.Name = "textBoxVendedor";
            textBoxVendedor.Size = new Size(110, 23);
            textBoxVendedor.TabIndex = 17;
            textBoxVendedor.Enter += textBoxVendedor_Enter;
            textBoxVendedor.KeyDown += textBoxVendedor_KeyDown;
            // 
            // comboBoxTipo
            // 
            comboBoxTipo.FormattingEnabled = true;
            comboBoxTipo.Location = new Point(357, 70);
            comboBoxTipo.Margin = new Padding(3, 2, 3, 2);
            comboBoxTipo.Name = "comboBoxTipo";
            comboBoxTipo.Size = new Size(158, 23);
            comboBoxTipo.TabIndex = 15;
            comboBoxTipo.SelectedValueChanged += comboBoxTipo_SelectedValueChanged;
            // 
            // comboBoxTipoComprobante
            // 
            comboBoxTipoComprobante.FormattingEnabled = true;
            comboBoxTipoComprobante.Location = new Point(104, 70);
            comboBoxTipoComprobante.Margin = new Padding(3, 2, 3, 2);
            comboBoxTipoComprobante.Name = "comboBoxTipoComprobante";
            comboBoxTipoComprobante.Size = new Size(158, 23);
            comboBoxTipoComprobante.TabIndex = 13;
            comboBoxTipoComprobante.SelectedValueChanged += comboBoxTipoComprobante_SelectedValueChanged;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(439, 14);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 12;
            lblFecha.Text = "Fecha:";
            lblFecha.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(654, 14);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(21, 15);
            lblNumero.TabIndex = 11;
            lblNumero.Text = "N°";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(14, 42);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(60, 15);
            lblDireccion.TabIndex = 10;
            lblDireccion.Text = "Dirección:";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(385, 42);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(30, 15);
            lblDni.TabIndex = 9;
            lblDni.Text = "DNI:";
            // 
            // lblComprobante
            // 
            lblComprobante.AutoSize = true;
            lblComprobante.Location = new Point(14, 78);
            lblComprobante.Name = "lblComprobante";
            lblComprobante.Size = new Size(84, 15);
            lblComprobante.TabIndex = 8;
            lblComprobante.Text = "Comprobante:";
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Location = new Point(649, 46);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(37, 15);
            lblZona.TabIndex = 6;
            lblZona.Text = "Zona:";
            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Location = new Point(649, 78);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(60, 15);
            lblVendedor.TabIndex = 5;
            lblVendedor.Text = "Vendedor:";
            // 
            // lblCuenta
            // 
            lblCuenta.AutoSize = true;
            lblCuenta.Location = new Point(14, 14);
            lblCuenta.Name = "lblCuenta";
            lblCuenta.Size = new Size(48, 15);
            lblCuenta.TabIndex = 0;
            lblCuenta.Text = "Cuenta:";
            // 
            // groupBoxObservaciones
            // 
            groupBoxObservaciones.Controls.Add(btnSalir);
            groupBoxObservaciones.Controls.Add(btnConfirmar);
            groupBoxObservaciones.Controls.Add(btnNuevoRemito);
            groupBoxObservaciones.Controls.Add(textBoxObservacion);
            groupBoxObservaciones.Controls.Add(lblObservacion);
            groupBoxObservaciones.Location = new Point(16, 436);
            groupBoxObservaciones.Margin = new Padding(3, 2, 3, 2);
            groupBoxObservaciones.Name = "groupBoxObservaciones";
            groupBoxObservaciones.Padding = new Padding(3, 2, 3, 2);
            groupBoxObservaciones.Size = new Size(853, 61);
            groupBoxObservaciones.TabIndex = 5;
            groupBoxObservaciones.TabStop = false;
            // 
            // groupBoxArticulosVendidos
            // 
            groupBoxArticulosVendidos.Controls.Add(dataGridViewProductos);
            groupBoxArticulosVendidos.Location = new Point(16, 156);
            groupBoxArticulosVendidos.Margin = new Padding(3, 2, 3, 2);
            groupBoxArticulosVendidos.Name = "groupBoxArticulosVendidos";
            groupBoxArticulosVendidos.Padding = new Padding(3, 2, 3, 2);
            groupBoxArticulosVendidos.Size = new Size(853, 265);
            groupBoxArticulosVendidos.TabIndex = 6;
            groupBoxArticulosVendidos.TabStop = false;
            // 
            // RemitoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 508);
            Controls.Add(gpDatosCliente);
            Controls.Add(groupBoxObservaciones);
            Controls.Add(groupBoxArticulosVendidos);
            KeyPreview = true;
            Name = "RemitoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RemitoForm";
            Load += RemitoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            gpDatosCliente.ResumeLayout(false);
            gpDatosCliente.PerformLayout();
            groupBoxObservaciones.ResumeLayout(false);
            groupBoxObservaciones.PerformLayout();
            groupBoxArticulosVendidos.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblObservacion;
        private DataGridView dataGridViewProductos;
        private Button btnSalir;
        private Button btnConfirmar;
        private Button btnNuevoRemito;
        private TextBox textBoxObservacion;
        private GroupBox gpDatosCliente;
        private MaskedTextBox maskedTextBoxNumeroComprob;
        private TextBox textBoxDNI;
        private TextBox textBoxDireccion;
        private Label lblTipo;
        private TextBox textBoxNumCuenta;
        private TextBox textBoxNombreCLiente;
        private Button btnBuscarCliente;
        private TextBox textBoxFecha;
        private TextBox textBoxZona;
        private TextBox textBoxVendedor;
        private ComboBox comboBoxTipo;
        private ComboBox comboBoxTipoComprobante;
        private Label lblFecha;
        private Label lblNumero;
        private Label lblDireccion;
        private Label lblDni;
        private Label lblComprobante;
        private Label lblZona;
        private Label lblVendedor;
        private Label lblCuenta;
        private GroupBox groupBoxObservaciones;
        private GroupBox groupBoxArticulosVendidos;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnCantidad;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnArticulo;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnDescripcion;
    }
}