using ElBrezal.Desktop.UI.Controls;

namespace ElBrezal.Desktop.Forms.Clientes.Remitos
{
    partial class RemitoForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            gpDatosCliente = new GroupBox();
            textBoxCUIT = new MaskedTextBox();
            lblCuit = new Label();
            maskedTextBoxPresupAsociado = new MaskedTextBox();
            maskedTextBoxNumeroComprob = new MaskedTextBox();
            lblCondicionVta = new Label();
            textBoxDNI = new TextBox();
            textBoxVariacionRemito = new TextBox();
            textBoxTelCliente = new TextBox();
            textBoxDireccion = new TextBox();
            lblTipo = new Label();
            textBoxNumCuenta = new TextBox();
            lblPorcentajeVariacion = new Label();
            textBoxNombreCliente = new TextBox();
            lblVar = new Label();
            btnBuscarCliente = new Button();
            textBoxFecha = new TextBox();
            lblTelefono = new Label();
            textBoxZona = new TextBox();
            textBoxVendedor = new TextBox();
            comboBoxSituacionImpositiva = new ComboBox();
            comboBoxCondicionRemito = new ComboBox();
            comboBoxTipoComprobante = new ComboBox();
            lblFecha = new Label();
            lblNumero = new Label();
            lblDireccion = new Label();
            lblDni = new Label();
            lblComprobante = new Label();
            lblPresup = new Label();
            lblZona = new Label();
            lblVendedor = new Label();
            lblCuenta = new Label();
            groupBoxInfoVenta = new GroupBox();
            lblAlicuotaProcentaje = new Label();
            lblArticulosCantidad = new Label();
            lblImporteSaldo = new Label();
            lblSaldo = new Label();
            lblCategoria = new Label();
            lblCategoriaCliente = new Label();
            lblArticulos = new Label();
            lblAlicuota = new Label();
            groupBoxArticulosVendidos = new GroupBox();
            dataGridViewProductos = new DataGridView();
            DataGridViewTextBoxColumnCantidad = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnArticulo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnDescripcion = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnPrecio = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnImporte = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumnAlicuotaIVA = new DataGridViewTextBoxColumn();
            groupBoxTotales = new GroupBox();
            lblSubTotal = new Label();
            lblVariacion = new Label();
            lblTotal = new Label();
            lblMontoTotal = new Label();
            label2 = new Label();
            label1 = new Label();
            lblTotales = new Label();
            groupBoxObservaciones = new GroupBox();
            btnSalir = new Button();
            btnConfirmar = new Button();
            btnNuevoRemito = new Button();
            textBoxObservacion = new TextBox();
            lblObservacion = new Label();
            lblTitulo = new Label();
            DataGridViewTextBoxColumnAlicuotaIVAId = new DataGridViewTextBoxColumn();
            gpDatosCliente.SuspendLayout();
            groupBoxInfoVenta.SuspendLayout();
            groupBoxArticulosVendidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            groupBoxTotales.SuspendLayout();
            groupBoxObservaciones.SuspendLayout();
            SuspendLayout();
            // 
            // gpDatosCliente
            // 
            gpDatosCliente.Controls.Add(textBoxCUIT);
            gpDatosCliente.Controls.Add(lblCuit);
            gpDatosCliente.Controls.Add(maskedTextBoxPresupAsociado);
            gpDatosCliente.Controls.Add(maskedTextBoxNumeroComprob);
            gpDatosCliente.Controls.Add(lblCondicionVta);
            gpDatosCliente.Controls.Add(textBoxDNI);
            gpDatosCliente.Controls.Add(textBoxVariacionRemito);
            gpDatosCliente.Controls.Add(textBoxTelCliente);
            gpDatosCliente.Controls.Add(textBoxDireccion);
            gpDatosCliente.Controls.Add(lblTipo);
            gpDatosCliente.Controls.Add(textBoxNumCuenta);
            gpDatosCliente.Controls.Add(lblPorcentajeVariacion);
            gpDatosCliente.Controls.Add(textBoxNombreCliente);
            gpDatosCliente.Controls.Add(lblVar);
            gpDatosCliente.Controls.Add(btnBuscarCliente);
            gpDatosCliente.Controls.Add(textBoxFecha);
            gpDatosCliente.Controls.Add(lblTelefono);
            gpDatosCliente.Controls.Add(textBoxZona);
            gpDatosCliente.Controls.Add(textBoxVendedor);
            gpDatosCliente.Controls.Add(comboBoxSituacionImpositiva);
            gpDatosCliente.Controls.Add(comboBoxCondicionRemito);
            gpDatosCliente.Controls.Add(comboBoxTipoComprobante);
            gpDatosCliente.Controls.Add(lblFecha);
            gpDatosCliente.Controls.Add(lblNumero);
            gpDatosCliente.Controls.Add(lblDireccion);
            gpDatosCliente.Controls.Add(lblDni);
            gpDatosCliente.Controls.Add(lblComprobante);
            gpDatosCliente.Controls.Add(lblPresup);
            gpDatosCliente.Controls.Add(lblZona);
            gpDatosCliente.Controls.Add(lblVendedor);
            gpDatosCliente.Controls.Add(lblCuenta);
            gpDatosCliente.Location = new Point(11, 73);
            gpDatosCliente.Name = "gpDatosCliente";
            gpDatosCliente.Size = new Size(975, 171);
            gpDatosCliente.TabIndex = 0;
            gpDatosCliente.TabStop = false;
            // 
            // textBoxCUIT
            // 
            textBoxCUIT.Location = new Point(296, 87);
            textBoxCUIT.Mask = "00-00000000-0";
            textBoxCUIT.Name = "textBoxCUIT";
            textBoxCUIT.Size = new Size(114, 27);
            textBoxCUIT.TabIndex = 34;
            textBoxCUIT.Leave += textBoxCUIT_Leave;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(248, 95);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(43, 20);
            lblCuit.TabIndex = 33;
            lblCuit.Text = "CUIT:";
            // 
            // maskedTextBoxPresupAsociado
            // 
            maskedTextBoxPresupAsociado.Location = new Point(824, 51);
            maskedTextBoxPresupAsociado.Margin = new Padding(3, 4, 3, 4);
            maskedTextBoxPresupAsociado.Mask = " \"0000-000000\"";
            maskedTextBoxPresupAsociado.Name = "maskedTextBoxPresupAsociado";
            maskedTextBoxPresupAsociado.Size = new Size(125, 27);
            maskedTextBoxPresupAsociado.TabIndex = 30;
            maskedTextBoxPresupAsociado.Text = "0000000000";
            maskedTextBoxPresupAsociado.KeyDown += maskedTextBoxPresupAsociado_KeyDown;
            // 
            // maskedTextBoxNumeroComprob
            // 
            maskedTextBoxNumeroComprob.Location = new Point(824, 15);
            maskedTextBoxNumeroComprob.Margin = new Padding(3, 4, 3, 4);
            maskedTextBoxNumeroComprob.Mask = " \"0000-000000\"";
            maskedTextBoxNumeroComprob.Name = "maskedTextBoxNumeroComprob";
            maskedTextBoxNumeroComprob.ReadOnly = true;
            maskedTextBoxNumeroComprob.Size = new Size(125, 27);
            maskedTextBoxNumeroComprob.TabIndex = 2;
            maskedTextBoxNumeroComprob.Text = "0000000000";
            // 
            // lblCondicionVta
            // 
            lblCondicionVta.AutoSize = true;
            lblCondicionVta.Location = new Point(497, 95);
            lblCondicionVta.Name = "lblCondicionVta";
            lblCondicionVta.Size = new Size(79, 20);
            lblCondicionVta.TabIndex = 29;
            lblCondicionVta.Text = "Cond. Vta.:";
            // 
            // textBoxDNI
            // 
            textBoxDNI.Location = new Point(59, 88);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.Size = new Size(163, 27);
            textBoxDNI.TabIndex = 28;
            // 
            // textBoxVariacionRemito
            // 
            textBoxVariacionRemito.Location = new Point(654, 51);
            textBoxVariacionRemito.Name = "textBoxVariacionRemito";
            textBoxVariacionRemito.Size = new Size(54, 27);
            textBoxVariacionRemito.TabIndex = 27;
            textBoxVariacionRemito.TextChanged += textBoxVariacionRemito_TextChanged;
            // 
            // textBoxTelCliente
            // 
            textBoxTelCliente.Location = new Point(478, 51);
            textBoxTelCliente.Name = "textBoxTelCliente";
            textBoxTelCliente.Size = new Size(125, 27);
            textBoxTelCliente.TabIndex = 26;
            // 
            // textBoxDireccion
            // 
            textBoxDireccion.CharacterCasing = CharacterCasing.Upper;
            textBoxDireccion.Location = new Point(97, 51);
            textBoxDireccion.Name = "textBoxDireccion";
            textBoxDireccion.Size = new Size(335, 27);
            textBoxDireccion.TabIndex = 25;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(317, 135);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(42, 20);
            lblTipo.TabIndex = 3;
            lblTipo.Text = "Tipo:";
            // 
            // textBoxNumCuenta
            // 
            textBoxNumCuenta.Location = new Point(80, 15);
            textBoxNumCuenta.Name = "textBoxNumCuenta";
            textBoxNumCuenta.Size = new Size(46, 27);
            textBoxNumCuenta.TabIndex = 24;
            textBoxNumCuenta.KeyDown += textBoxNumCuenta_KeyDown;
            textBoxNumCuenta.KeyPress += textBoxNumCuenta_KeyPress;
            // 
            // lblPorcentajeVariacion
            // 
            lblPorcentajeVariacion.AutoSize = true;
            lblPorcentajeVariacion.Location = new Point(705, 57);
            lblPorcentajeVariacion.Name = "lblPorcentajeVariacion";
            lblPorcentajeVariacion.Size = new Size(21, 20);
            lblPorcentajeVariacion.TabIndex = 4;
            lblPorcentajeVariacion.Text = "%";
            // 
            // textBoxNombreCliente
            // 
            textBoxNombreCliente.CharacterCasing = CharacterCasing.Upper;
            textBoxNombreCliente.Location = new Point(133, 15);
            textBoxNombreCliente.Name = "textBoxNombreCliente";
            textBoxNombreCliente.Size = new Size(300, 27);
            textBoxNombreCliente.TabIndex = 23;
            // 
            // lblVar
            // 
            lblVar.AutoSize = true;
            lblVar.Location = new Point(613, 57);
            lblVar.Name = "lblVar";
            lblVar.Size = new Size(36, 20);
            lblVar.TabIndex = 2;
            lblVar.Text = "Var.:";
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Location = new Point(438, 15);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(35, 28);
            btnBuscarCliente.TabIndex = 22;
            btnBuscarCliente.Text = "...";
            btnBuscarCliente.UseVisualStyleBackColor = true;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // textBoxFecha
            // 
            textBoxFecha.Location = new Point(558, 15);
            textBoxFecha.Name = "textBoxFecha";
            textBoxFecha.Size = new Size(125, 27);
            textBoxFecha.TabIndex = 21;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(438, 57);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(34, 20);
            lblTelefono.TabIndex = 1;
            lblTelefono.Text = "Tel.:";
            // 
            // textBoxZona
            // 
            textBoxZona.CharacterCasing = CharacterCasing.Upper;
            textBoxZona.Location = new Point(824, 88);
            textBoxZona.Name = "textBoxZona";
            textBoxZona.Size = new Size(125, 27);
            textBoxZona.TabIndex = 18;
            textBoxZona.KeyDown += textBoxZona_KeyDown;
            // 
            // textBoxVendedor
            // 
            textBoxVendedor.CharacterCasing = CharacterCasing.Upper;
            textBoxVendedor.Location = new Point(824, 127);
            textBoxVendedor.Name = "textBoxVendedor";
            textBoxVendedor.Size = new Size(125, 27);
            textBoxVendedor.TabIndex = 17;
            textBoxVendedor.Enter += textBoxVendedor_Enter;
            textBoxVendedor.KeyDown += textBoxVendedor_KeyDown;
            // 
            // comboBoxSituacionImpositiva
            // 
            comboBoxSituacionImpositiva.FormattingEnabled = true;
            comboBoxSituacionImpositiva.Location = new Point(365, 128);
            comboBoxSituacionImpositiva.Name = "comboBoxSituacionImpositiva";
            comboBoxSituacionImpositiva.Size = new Size(180, 28);
            comboBoxSituacionImpositiva.TabIndex = 15;
            // 
            // comboBoxCondicionRemito
            // 
            comboBoxCondicionRemito.FormattingEnabled = true;
            comboBoxCondicionRemito.Location = new Point(579, 88);
            comboBoxCondicionRemito.Name = "comboBoxCondicionRemito";
            comboBoxCondicionRemito.Size = new Size(147, 28);
            comboBoxCondicionRemito.TabIndex = 14;
            // 
            // comboBoxTipoComprobante
            // 
            comboBoxTipoComprobante.FormattingEnabled = true;
            comboBoxTipoComprobante.Location = new Point(97, 127);
            comboBoxTipoComprobante.Name = "comboBoxTipoComprobante";
            comboBoxTipoComprobante.Size = new Size(180, 28);
            comboBoxTipoComprobante.TabIndex = 13;
            comboBoxTipoComprobante.SelectedValueChanged += comboBoxTipoComprobante_SelectedValueChanged;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(502, 20);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 12;
            lblFecha.Text = "Fecha:";
            lblFecha.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(747, 20);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(26, 20);
            lblNumero.TabIndex = 11;
            lblNumero.Text = "N°";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(16, 57);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(75, 20);
            lblDireccion.TabIndex = 10;
            lblDireccion.Text = "Dirección:";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(16, 95);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(38, 20);
            lblDni.TabIndex = 9;
            lblDni.Text = "DNI:";
            // 
            // lblComprobante
            // 
            lblComprobante.AutoSize = true;
            lblComprobante.Location = new Point(16, 135);
            lblComprobante.Name = "lblComprobante";
            lblComprobante.Size = new Size(75, 20);
            lblComprobante.TabIndex = 8;
            lblComprobante.Text = "Comprob:";
            // 
            // lblPresup
            // 
            lblPresup.AutoSize = true;
            lblPresup.Location = new Point(747, 57);
            lblPresup.Name = "lblPresup";
            lblPresup.Size = new Size(56, 20);
            lblPresup.TabIndex = 7;
            lblPresup.Text = "Presup.";
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Location = new Point(747, 95);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(46, 20);
            lblZona.TabIndex = 6;
            lblZona.Text = "Zona:";
            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Location = new Point(742, 135);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(76, 20);
            lblVendedor.TabIndex = 5;
            lblVendedor.Text = "Vendedor:";
            // 
            // lblCuenta
            // 
            lblCuenta.AutoSize = true;
            lblCuenta.Location = new Point(16, 20);
            lblCuenta.Name = "lblCuenta";
            lblCuenta.Size = new Size(58, 20);
            lblCuenta.TabIndex = 0;
            lblCuenta.Text = "Cuenta:";
            // 
            // groupBoxInfoVenta
            // 
            groupBoxInfoVenta.Controls.Add(lblAlicuotaProcentaje);
            groupBoxInfoVenta.Controls.Add(lblArticulosCantidad);
            groupBoxInfoVenta.Controls.Add(lblImporteSaldo);
            groupBoxInfoVenta.Controls.Add(lblSaldo);
            groupBoxInfoVenta.Controls.Add(lblCategoria);
            groupBoxInfoVenta.Controls.Add(lblCategoriaCliente);
            groupBoxInfoVenta.Controls.Add(lblArticulos);
            groupBoxInfoVenta.Controls.Add(lblAlicuota);
            groupBoxInfoVenta.Location = new Point(810, 249);
            groupBoxInfoVenta.Name = "groupBoxInfoVenta";
            groupBoxInfoVenta.Size = new Size(176, 420);
            groupBoxInfoVenta.TabIndex = 1;
            groupBoxInfoVenta.TabStop = false;
            // 
            // lblAlicuotaProcentaje
            // 
            lblAlicuotaProcentaje.AutoSize = true;
            lblAlicuotaProcentaje.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAlicuotaProcentaje.ForeColor = SystemColors.Highlight;
            lblAlicuotaProcentaje.Location = new Point(117, 228);
            lblAlicuotaProcentaje.Name = "lblAlicuotaProcentaje";
            lblAlicuotaProcentaje.Size = new Size(50, 20);
            lblAlicuotaProcentaje.TabIndex = 41;
            lblAlicuotaProcentaje.Text = "0,00%";
            // 
            // lblArticulosCantidad
            // 
            lblArticulosCantidad.AutoSize = true;
            lblArticulosCantidad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblArticulosCantidad.ForeColor = SystemColors.Highlight;
            lblArticulosCantidad.Location = new Point(101, 167);
            lblArticulosCantidad.Name = "lblArticulosCantidad";
            lblArticulosCantidad.Size = new Size(17, 20);
            lblArticulosCantidad.TabIndex = 40;
            lblArticulosCantidad.Text = "0";
            // 
            // lblImporteSaldo
            // 
            lblImporteSaldo.AutoSize = true;
            lblImporteSaldo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblImporteSaldo.ForeColor = SystemColors.Highlight;
            lblImporteSaldo.Location = new Point(93, 40);
            lblImporteSaldo.Name = "lblImporteSaldo";
            lblImporteSaldo.Size = new Size(37, 20);
            lblImporteSaldo.TabIndex = 39;
            lblImporteSaldo.Text = "$0,0";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(19, 40);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(50, 20);
            lblSaldo.TabIndex = 17;
            lblSaldo.Text = "Saldo:";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(19, 92);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(37, 20);
            lblCategoria.TabIndex = 15;
            lblCategoria.Text = "Cat.:";
            // 
            // lblCategoriaCliente
            // 
            lblCategoriaCliente.AutoSize = true;
            lblCategoriaCliente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategoriaCliente.ForeColor = SystemColors.Highlight;
            lblCategoriaCliente.Location = new Point(74, 92);
            lblCategoriaCliente.Name = "lblCategoriaCliente";
            lblCategoriaCliente.Size = new Size(72, 20);
            lblCategoriaCliente.TabIndex = 14;
            lblCategoriaCliente.Text = "NORMAL";
            // 
            // lblArticulos
            // 
            lblArticulos.AutoSize = true;
            lblArticulos.Location = new Point(25, 167);
            lblArticulos.Name = "lblArticulos";
            lblArticulos.Size = new Size(70, 20);
            lblArticulos.TabIndex = 11;
            lblArticulos.Text = "Articulos:";
            // 
            // lblAlicuota
            // 
            lblAlicuota.AutoSize = true;
            lblAlicuota.Location = new Point(25, 228);
            lblAlicuota.Name = "lblAlicuota";
            lblAlicuota.Size = new Size(93, 20);
            lblAlicuota.TabIndex = 8;
            lblAlicuota.Text = "Alícuota IVA:";
            // 
            // groupBoxArticulosVendidos
            // 
            groupBoxArticulosVendidos.Controls.Add(dataGridViewProductos);
            groupBoxArticulosVendidos.Controls.Add(groupBoxTotales);
            groupBoxArticulosVendidos.Location = new Point(14, 249);
            groupBoxArticulosVendidos.Name = "groupBoxArticulosVendidos";
            groupBoxArticulosVendidos.Size = new Size(787, 420);
            groupBoxArticulosVendidos.TabIndex = 1;
            groupBoxArticulosVendidos.TabStop = false;
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Columns.AddRange(new DataGridViewColumn[] { DataGridViewTextBoxColumnCantidad, DataGridViewTextBoxColumnArticulo, DataGridViewTextBoxColumnDescripcion, DataGridViewTextBoxColumnPrecio, DataGridViewTextBoxColumnImporte, DataGridViewTextBoxColumnAlicuotaIVA, DataGridViewTextBoxColumnAlicuotaIVAId });
            dataGridViewProductos.Location = new Point(7, 21);
            dataGridViewProductos.Margin = new Padding(3, 4, 3, 4);
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.RowHeadersWidth = 51;
            dataGridViewProductos.Size = new Size(774, 307);
            dataGridViewProductos.TabIndex = 1;
            dataGridViewProductos.CellValueChanged += dataGridViewProductos_CellValueChanged;
            dataGridViewProductos.SelectionChanged += dataGridViewProductos_SelectionChanged;
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
            // DataGridViewTextBoxColumnPrecio
            // 
            DataGridViewTextBoxColumnPrecio.HeaderText = "Precio";
            DataGridViewTextBoxColumnPrecio.MinimumWidth = 6;
            DataGridViewTextBoxColumnPrecio.Name = "DataGridViewTextBoxColumnPrecio";
            DataGridViewTextBoxColumnPrecio.Width = 125;
            // 
            // DataGridViewTextBoxColumnImporte
            // 
            DataGridViewTextBoxColumnImporte.HeaderText = "Importe";
            DataGridViewTextBoxColumnImporte.MinimumWidth = 6;
            DataGridViewTextBoxColumnImporte.Name = "DataGridViewTextBoxColumnImporte";
            DataGridViewTextBoxColumnImporte.ReadOnly = true;
            DataGridViewTextBoxColumnImporte.Width = 125;
            // 
            // DataGridViewTextBoxColumnAlicuotaIVA
            // 
            DataGridViewTextBoxColumnAlicuotaIVA.HeaderText = "AlicuotaIVA";
            DataGridViewTextBoxColumnAlicuotaIVA.MinimumWidth = 6;
            DataGridViewTextBoxColumnAlicuotaIVA.Name = "DataGridViewTextBoxColumnAlicuotaIVA";
            DataGridViewTextBoxColumnAlicuotaIVA.Visible = false;
            DataGridViewTextBoxColumnAlicuotaIVA.Width = 125;
            // 
            // groupBoxTotales
            // 
            groupBoxTotales.Controls.Add(lblSubTotal);
            groupBoxTotales.Controls.Add(lblVariacion);
            groupBoxTotales.Controls.Add(lblTotal);
            groupBoxTotales.Controls.Add(lblMontoTotal);
            groupBoxTotales.Controls.Add(label2);
            groupBoxTotales.Controls.Add(label1);
            groupBoxTotales.Controls.Add(lblTotales);
            groupBoxTotales.Location = new Point(7, 324);
            groupBoxTotales.Margin = new Padding(3, 4, 3, 4);
            groupBoxTotales.Name = "groupBoxTotales";
            groupBoxTotales.Padding = new Padding(3, 4, 3, 4);
            groupBoxTotales.Size = new Size(774, 83);
            groupBoxTotales.TabIndex = 0;
            groupBoxTotales.TabStop = false;
            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSubTotal.ForeColor = SystemColors.Highlight;
            lblSubTotal.Location = new Point(143, 53);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(37, 20);
            lblSubTotal.TabIndex = 38;
            lblSubTotal.Text = "$0,0";
            // 
            // lblVariacion
            // 
            lblVariacion.AutoSize = true;
            lblVariacion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblVariacion.ForeColor = SystemColors.Highlight;
            lblVariacion.Location = new Point(302, 53);
            lblVariacion.Name = "lblVariacion";
            lblVariacion.Size = new Size(37, 20);
            lblVariacion.TabIndex = 37;
            lblVariacion.Text = "$0,0";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTotal.Location = new Point(683, 25);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(61, 23);
            lblTotal.TabIndex = 34;
            lblTotal.Text = "TOTAL";
            // 
            // lblMontoTotal
            // 
            lblMontoTotal.AutoSize = true;
            lblMontoTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblMontoTotal.ForeColor = SystemColors.Highlight;
            lblMontoTotal.Location = new Point(689, 53);
            lblMontoTotal.Name = "lblMontoTotal";
            lblMontoTotal.Size = new Size(37, 20);
            lblMontoTotal.TabIndex = 33;
            lblMontoTotal.Text = "$0,0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(302, 25);
            label2.Name = "label2";
            label2.Size = new Size(63, 23);
            label2.TabIndex = 32;
            label2.Text = "Variac.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.Location = new Point(143, 25);
            label1.Name = "label1";
            label1.Size = new Size(85, 23);
            label1.TabIndex = 31;
            label1.Text = "Sub Total";
            // 
            // lblTotales
            // 
            lblTotales.AutoSize = true;
            lblTotales.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTotales.Location = new Point(7, 53);
            lblTotales.Name = "lblTotales";
            lblTotales.Size = new Size(80, 23);
            lblTotales.TabIndex = 30;
            lblTotales.Text = "TOTALES";
            // 
            // groupBoxObservaciones
            // 
            groupBoxObservaciones.Controls.Add(btnSalir);
            groupBoxObservaciones.Controls.Add(btnConfirmar);
            groupBoxObservaciones.Controls.Add(btnNuevoRemito);
            groupBoxObservaciones.Controls.Add(textBoxObservacion);
            groupBoxObservaciones.Controls.Add(lblObservacion);
            groupBoxObservaciones.Location = new Point(14, 663);
            groupBoxObservaciones.Name = "groupBoxObservaciones";
            groupBoxObservaciones.Size = new Size(973, 81);
            groupBoxObservaciones.TabIndex = 1;
            groupBoxObservaciones.TabStop = false;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(830, 36);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(135, 31);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            btnSalir.KeyDown += btnSalir_KeyDown;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(688, 36);
            btnConfirmar.Margin = new Padding(3, 4, 3, 4);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(135, 31);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar - F11";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnNuevoRemito
            // 
            btnNuevoRemito.Location = new Point(547, 36);
            btnNuevoRemito.Margin = new Padding(3, 4, 3, 4);
            btnNuevoRemito.Name = "btnNuevoRemito";
            btnNuevoRemito.Size = new Size(135, 31);
            btnNuevoRemito.TabIndex = 4;
            btnNuevoRemito.Text = "Nuevo - F9";
            btnNuevoRemito.UseVisualStyleBackColor = true;
            btnNuevoRemito.Click += btnNuevoRemito_Click;
            // 
            // textBoxObservacion
            // 
            textBoxObservacion.Location = new Point(7, 37);
            textBoxObservacion.Name = "textBoxObservacion";
            textBoxObservacion.Size = new Size(401, 27);
            textBoxObservacion.TabIndex = 30;
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Location = new Point(7, 15);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(94, 20);
            lblObservacion.TabIndex = 30;
            lblObservacion.Text = "Observación:";
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(0, 102, 153);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(983, 48);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "FACTURACIÓN ELECTRÓNICA";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DataGridViewTextBoxColumnAlicuotaIVAId
            // 
            DataGridViewTextBoxColumnAlicuotaIVAId.HeaderText = "AlicuotaIVAId";
            DataGridViewTextBoxColumnAlicuotaIVAId.MinimumWidth = 6;
            DataGridViewTextBoxColumnAlicuotaIVAId.Name = "DataGridViewTextBoxColumnAlicuotaIVAId";
            DataGridViewTextBoxColumnAlicuotaIVAId.ReadOnly = true;
            DataGridViewTextBoxColumnAlicuotaIVAId.Visible = false;
            DataGridViewTextBoxColumnAlicuotaIVAId.Width = 125;
            // 
            // RemitoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 759);
            Controls.Add(groupBoxInfoVenta);
            Controls.Add(groupBoxArticulosVendidos);
            Controls.Add(groupBoxObservaciones);
            Controls.Add(gpDatosCliente);
            KeyPreview = true;
            Name = "RemitoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Remito";
            Load += RemitoForm_Load;
            gpDatosCliente.ResumeLayout(false);
            gpDatosCliente.PerformLayout();
            groupBoxInfoVenta.ResumeLayout(false);
            groupBoxInfoVenta.PerformLayout();
            groupBoxArticulosVendidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            groupBoxTotales.ResumeLayout(false);
            groupBoxTotales.PerformLayout();
            groupBoxObservaciones.ResumeLayout(false);
            groupBoxObservaciones.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpDatosCliente;
        private GroupBox groupBoxInfoVenta;
        private GroupBox groupBoxArticulosVendidos;
        private GroupBox groupBoxObservaciones;

        private HeaderPanel headerPanelTitulo;
        private Label lblTitulo;
        private Label lblFecha;
        private Label lblNumero;
        private Label lblDireccion;
        private Label lblDni;
        private Label lblComprobante;
        private Label lblPresup;
        private Label lblZona;
        private Label lblVendedor;
        private Label lblPorcentajeVariacion;
        private Label lblTipo;
        private Label lblVar;
        private Label lblTelefono;
        private Label lblCuenta;
        private TextBox textBoxZona;
        private TextBox textBoxVendedor;
        private ComboBox comboBoxSituacionImpositiva;
        private ComboBox comboBoxCondicionRemito;
        private ComboBox comboBoxTipoComprobante;
        private TextBox textBoxDireccion;
        private TextBox textBoxNumCuenta;
        private TextBox textBoxNombreCliente;
        private Button btnBuscarCliente;
        private TextBox textBoxFecha;
        private TextBox textBoxVariacionRemito;
        private TextBox textBoxTelCliente;
        private TextBox textBoxDNI;
        private Label lblCondicionVta;
        private Label lblObservacion;
        private TextBox textBoxObservacion;
        private GroupBox groupBoxTotales;
        private Label label1;
        private Label lblTotales;
        private Label lblSubTotal;
        private Label lblVariacion;
        private Label lblTotal;
        private Label lblMontoTotal;
        private Label label2;
        private Label lblSaldo;
        private Label lblCategoria;
        private Label lblCategoriaCliente;
        private Label lblArticulos;
        private Label label5;
        private Label label4;
        private Label lblAlicuota;
        private Label lblImporteSaldo;
        private Label lblArticulosCantidad;
        private Label lblAlicuotaProcentaje;
        private Button btnSalir;
        private Button btnConfirmar;
        private Button btnNuevoRemito;
        private DataGridView dataGridViewProductos;
        private MaskedTextBox maskedTextBoxNumeroComprob;
        private MaskedTextBox maskedTextBoxPresupAsociado;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnCantidad;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnArticulo;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnDescripcion;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnPrecio;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnImporte;
        private MaskedTextBox textBoxCUIT;
        private Label lblCuit;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnAlicuotaIVA;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnAlicuotaIVAId;
    }
}