using ElBrezal.Desktop.UI.Controls;

namespace ElBrezal.Desktop.Forms.Clientes.Ventas
{
    partial class VentaForm
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
            maskedTextBoxPresupAsociado = new MaskedTextBox();
            maskedTextBoxNumeroComprob = new MaskedTextBox();
            lblCondicionVta = new Label();
            textBoxDNI = new TextBox();
            textBoxVariacionVenta = new TextBox();
            textBoxTelCliente = new TextBox();
            textBoxDireccion = new TextBox();
            lblTipo = new Label();
            textBoxNumCuenta = new TextBox();
            lblPorcentajeVariacion = new Label();
            textBoxNombreCLiente = new TextBox();
            lblVar = new Label();
            btnBuscarCliente = new Button();
            textBoxFecha = new TextBox();
            lblTelefono = new Label();
            textBoxZona = new TextBox();
            textBoxVendedor = new TextBox();
            comboBoxTipo = new ComboBox();
            comboBoxCondicionVenta = new ComboBox();
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
            button1 = new Button();
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
            btnNuevaVenta = new Button();
            textBoxObservacion = new TextBox();
            lblObservacion = new Label();
            lblTitulo = new Label();
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
            gpDatosCliente.Controls.Add(maskedTextBoxPresupAsociado);
            gpDatosCliente.Controls.Add(maskedTextBoxNumeroComprob);
            gpDatosCliente.Controls.Add(lblCondicionVta);
            gpDatosCliente.Controls.Add(textBoxDNI);
            gpDatosCliente.Controls.Add(textBoxVariacionVenta);
            gpDatosCliente.Controls.Add(textBoxTelCliente);
            gpDatosCliente.Controls.Add(textBoxDireccion);
            gpDatosCliente.Controls.Add(lblTipo);
            gpDatosCliente.Controls.Add(textBoxNumCuenta);
            gpDatosCliente.Controls.Add(lblPorcentajeVariacion);
            gpDatosCliente.Controls.Add(textBoxNombreCLiente);
            gpDatosCliente.Controls.Add(lblVar);
            gpDatosCliente.Controls.Add(btnBuscarCliente);
            gpDatosCliente.Controls.Add(textBoxFecha);
            gpDatosCliente.Controls.Add(lblTelefono);
            gpDatosCliente.Controls.Add(textBoxZona);
            gpDatosCliente.Controls.Add(textBoxVendedor);
            gpDatosCliente.Controls.Add(comboBoxTipo);
            gpDatosCliente.Controls.Add(comboBoxCondicionVenta);
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
            gpDatosCliente.Location = new Point(10, 55);
            gpDatosCliente.Margin = new Padding(3, 2, 3, 2);
            gpDatosCliente.Name = "gpDatosCliente";
            gpDatosCliente.Padding = new Padding(3, 2, 3, 2);
            gpDatosCliente.Size = new Size(853, 128);
            gpDatosCliente.TabIndex = 0;
            gpDatosCliente.TabStop = false;
            // 
            // maskedTextBoxPresupAsociado
            // 
            maskedTextBoxPresupAsociado.Location = new Point(721, 38);
            maskedTextBoxPresupAsociado.Mask = " \"0000-000000\"";
            maskedTextBoxPresupAsociado.Name = "maskedTextBoxPresupAsociado";
            maskedTextBoxPresupAsociado.Size = new Size(110, 23);
            maskedTextBoxPresupAsociado.TabIndex = 30;
            maskedTextBoxPresupAsociado.Text = "0000000000";
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
            // lblCondicionVta
            // 
            lblCondicionVta.AutoSize = true;
            lblCondicionVta.Location = new Point(435, 71);
            lblCondicionVta.Name = "lblCondicionVta";
            lblCondicionVta.Size = new Size(65, 15);
            lblCondicionVta.TabIndex = 29;
            lblCondicionVta.Text = "Cond. Vta.:";
            // 
            // textBoxDNI
            // 
            textBoxDNI.Location = new Point(52, 66);
            textBoxDNI.Margin = new Padding(3, 2, 3, 2);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.Size = new Size(143, 23);
            textBoxDNI.TabIndex = 28;
            // 
            // textBoxVariacionVenta
            // 
            textBoxVariacionVenta.Location = new Point(572, 38);
            textBoxVariacionVenta.Margin = new Padding(3, 2, 3, 2);
            textBoxVariacionVenta.Name = "textBoxVariacionVenta";
            textBoxVariacionVenta.Size = new Size(48, 23);
            textBoxVariacionVenta.TabIndex = 27;
            textBoxVariacionVenta.TextChanged += textBoxVariacionVenta_TextChanged;
            // 
            // textBoxTelCliente
            // 
            textBoxTelCliente.Location = new Point(418, 38);
            textBoxTelCliente.Margin = new Padding(3, 2, 3, 2);
            textBoxTelCliente.Name = "textBoxTelCliente";
            textBoxTelCliente.Size = new Size(110, 23);
            textBoxTelCliente.TabIndex = 26;
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
            lblTipo.Location = new Point(230, 71);
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
            // lblPorcentajeVariacion
            // 
            lblPorcentajeVariacion.AutoSize = true;
            lblPorcentajeVariacion.Location = new Point(617, 43);
            lblPorcentajeVariacion.Name = "lblPorcentajeVariacion";
            lblPorcentajeVariacion.Size = new Size(17, 15);
            lblPorcentajeVariacion.TabIndex = 4;
            lblPorcentajeVariacion.Text = "%";
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
            // lblVar
            // 
            lblVar.AutoSize = true;
            lblVar.Location = new Point(536, 43);
            lblVar.Name = "lblVar";
            lblVar.Size = new Size(29, 15);
            lblVar.TabIndex = 2;
            lblVar.Text = "Var.:";
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
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(383, 43);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(28, 15);
            lblTelefono.TabIndex = 1;
            lblTelefono.Text = "Tel.:";
            // 
            // textBoxZona
            // 
            textBoxZona.CharacterCasing = CharacterCasing.Upper;
            textBoxZona.Location = new Point(721, 66);
            textBoxZona.Margin = new Padding(3, 2, 3, 2);
            textBoxZona.Name = "textBoxZona";
            textBoxZona.Size = new Size(110, 23);
            textBoxZona.TabIndex = 18;
            // 
            // textBoxVendedor
            // 
            textBoxVendedor.CharacterCasing = CharacterCasing.Upper;
            textBoxVendedor.Location = new Point(721, 95);
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
            comboBoxTipo.Location = new Point(272, 66);
            comboBoxTipo.Margin = new Padding(3, 2, 3, 2);
            comboBoxTipo.Name = "comboBoxTipo";
            comboBoxTipo.Size = new Size(158, 23);
            comboBoxTipo.TabIndex = 15;
            comboBoxTipo.SelectedValueChanged += comboBoxTipo_SelectedValueChanged;
            // 
            // comboBoxCondicionVenta
            // 
            comboBoxCondicionVenta.FormattingEnabled = true;
            comboBoxCondicionVenta.Location = new Point(507, 66);
            comboBoxCondicionVenta.Margin = new Padding(3, 2, 3, 2);
            comboBoxCondicionVenta.Name = "comboBoxCondicionVenta";
            comboBoxCondicionVenta.Size = new Size(129, 23);
            comboBoxCondicionVenta.TabIndex = 14;
            // 
            // comboBoxTipoComprobante
            // 
            comboBoxTipoComprobante.FormattingEnabled = true;
            comboBoxTipoComprobante.Location = new Point(85, 95);
            comboBoxTipoComprobante.Margin = new Padding(3, 2, 3, 2);
            comboBoxTipoComprobante.Name = "comboBoxTipoComprobante";
            comboBoxTipoComprobante.Size = new Size(158, 23);
            comboBoxTipoComprobante.TabIndex = 13;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(439, 15);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 12;
            lblFecha.Text = "Fecha:";
            lblFecha.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(654, 15);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(21, 15);
            lblNumero.TabIndex = 11;
            lblNumero.Text = "N°";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(14, 43);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(60, 15);
            lblDireccion.TabIndex = 10;
            lblDireccion.Text = "Dirección:";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(14, 71);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(30, 15);
            lblDni.TabIndex = 9;
            lblDni.Text = "DNI:";
            // 
            // lblComprobante
            // 
            lblComprobante.AutoSize = true;
            lblComprobante.Location = new Point(14, 101);
            lblComprobante.Name = "lblComprobante";
            lblComprobante.Size = new Size(61, 15);
            lblComprobante.TabIndex = 8;
            lblComprobante.Text = "Comprob:";
            // 
            // lblPresup
            // 
            lblPresup.AutoSize = true;
            lblPresup.Location = new Point(654, 43);
            lblPresup.Name = "lblPresup";
            lblPresup.Size = new Size(46, 15);
            lblPresup.TabIndex = 7;
            lblPresup.Text = "Presup.";
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Location = new Point(654, 71);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(37, 15);
            lblZona.TabIndex = 6;
            lblZona.Text = "Zona:";
            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Location = new Point(649, 101);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(60, 15);
            lblVendedor.TabIndex = 5;
            lblVendedor.Text = "Vendedor:";
            // 
            // lblCuenta
            // 
            lblCuenta.AutoSize = true;
            lblCuenta.Location = new Point(14, 15);
            lblCuenta.Name = "lblCuenta";
            lblCuenta.Size = new Size(48, 15);
            lblCuenta.TabIndex = 0;
            lblCuenta.Text = "Cuenta:";
            // 
            // groupBoxInfoVenta
            // 
            groupBoxInfoVenta.Controls.Add(lblAlicuotaProcentaje);
            groupBoxInfoVenta.Controls.Add(lblArticulosCantidad);
            groupBoxInfoVenta.Controls.Add(button1);
            groupBoxInfoVenta.Controls.Add(lblImporteSaldo);
            groupBoxInfoVenta.Controls.Add(lblSaldo);
            groupBoxInfoVenta.Controls.Add(lblCategoria);
            groupBoxInfoVenta.Controls.Add(lblCategoriaCliente);
            groupBoxInfoVenta.Controls.Add(lblArticulos);
            groupBoxInfoVenta.Controls.Add(lblAlicuota);
            groupBoxInfoVenta.Location = new Point(709, 187);
            groupBoxInfoVenta.Margin = new Padding(3, 2, 3, 2);
            groupBoxInfoVenta.Name = "groupBoxInfoVenta";
            groupBoxInfoVenta.Padding = new Padding(3, 2, 3, 2);
            groupBoxInfoVenta.Size = new Size(154, 315);
            groupBoxInfoVenta.TabIndex = 1;
            groupBoxInfoVenta.TabStop = false;
            // 
            // lblAlicuotaProcentaje
            // 
            lblAlicuotaProcentaje.AutoSize = true;
            lblAlicuotaProcentaje.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAlicuotaProcentaje.ForeColor = SystemColors.Highlight;
            lblAlicuotaProcentaje.Location = new Point(102, 171);
            lblAlicuotaProcentaje.Name = "lblAlicuotaProcentaje";
            lblAlicuotaProcentaje.Size = new Size(41, 15);
            lblAlicuotaProcentaje.TabIndex = 41;
            lblAlicuotaProcentaje.Text = "0,00%";
            // 
            // lblArticulosCantidad
            // 
            lblArticulosCantidad.AutoSize = true;
            lblArticulosCantidad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblArticulosCantidad.ForeColor = SystemColors.Highlight;
            lblArticulosCantidad.Location = new Point(88, 125);
            lblArticulosCantidad.Name = "lblArticulosCantidad";
            lblArticulosCantidad.Size = new Size(14, 15);
            lblArticulosCantidad.TabIndex = 40;
            lblArticulosCantidad.Text = "0";
            // 
            // button1
            // 
            button1.Location = new Point(17, 275);
            button1.Name = "button1";
            button1.Size = new Size(115, 23);
            button1.TabIndex = 1;
            button1.Text = "F3 - Remitar";
            button1.UseVisualStyleBackColor = true;
            // 
            // lblImporteSaldo
            // 
            lblImporteSaldo.AutoSize = true;
            lblImporteSaldo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblImporteSaldo.ForeColor = SystemColors.Highlight;
            lblImporteSaldo.Location = new Point(81, 30);
            lblImporteSaldo.Name = "lblImporteSaldo";
            lblImporteSaldo.Size = new Size(31, 15);
            lblImporteSaldo.TabIndex = 39;
            lblImporteSaldo.Text = "$0,0";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(17, 30);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(39, 15);
            lblSaldo.TabIndex = 17;
            lblSaldo.Text = "Saldo:";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(17, 69);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(31, 15);
            lblCategoria.TabIndex = 15;
            lblCategoria.Text = "Cat.:";
            // 
            // lblCategoriaCliente
            // 
            lblCategoriaCliente.AutoSize = true;
            lblCategoriaCliente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategoriaCliente.ForeColor = SystemColors.Highlight;
            lblCategoriaCliente.Location = new Point(65, 69);
            lblCategoriaCliente.Name = "lblCategoriaCliente";
            lblCategoriaCliente.Size = new Size(57, 15);
            lblCategoriaCliente.TabIndex = 14;
            lblCategoriaCliente.Text = "NORMAL";
            // 
            // lblArticulos
            // 
            lblArticulos.AutoSize = true;
            lblArticulos.Location = new Point(22, 125);
            lblArticulos.Name = "lblArticulos";
            lblArticulos.Size = new Size(57, 15);
            lblArticulos.TabIndex = 11;
            lblArticulos.Text = "Articulos:";
            // 
            // lblAlicuota
            // 
            lblAlicuota.AutoSize = true;
            lblAlicuota.Location = new Point(22, 171);
            lblAlicuota.Name = "lblAlicuota";
            lblAlicuota.Size = new Size(74, 15);
            lblAlicuota.TabIndex = 8;
            lblAlicuota.Text = "Alícuota IVA:";
            // 
            // groupBoxArticulosVendidos
            // 
            groupBoxArticulosVendidos.Controls.Add(dataGridViewProductos);
            groupBoxArticulosVendidos.Controls.Add(groupBoxTotales);
            groupBoxArticulosVendidos.Location = new Point(12, 187);
            groupBoxArticulosVendidos.Margin = new Padding(3, 2, 3, 2);
            groupBoxArticulosVendidos.Name = "groupBoxArticulosVendidos";
            groupBoxArticulosVendidos.Padding = new Padding(3, 2, 3, 2);
            groupBoxArticulosVendidos.Size = new Size(689, 315);
            groupBoxArticulosVendidos.TabIndex = 1;
            groupBoxArticulosVendidos.TabStop = false;
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Columns.AddRange(new DataGridViewColumn[] { DataGridViewTextBoxColumnCantidad, DataGridViewTextBoxColumnArticulo, DataGridViewTextBoxColumnDescripcion, DataGridViewTextBoxColumnPrecio, DataGridViewTextBoxColumnImporte });
            dataGridViewProductos.Location = new Point(6, 16);
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.Size = new Size(677, 230);
            dataGridViewProductos.TabIndex = 1;
            dataGridViewProductos.CellValueChanged += dataGridViewProductos_CellValueChanged;
            dataGridViewProductos.KeyDown += dataGridViewProductos_KeyDown;
            // 
            // DataGridViewTextBoxColumnCantidad
            // 
            DataGridViewTextBoxColumnCantidad.HeaderText = "Cant.";
            DataGridViewTextBoxColumnCantidad.Name = "DataGridViewTextBoxColumnCantidad";
            // 
            // DataGridViewTextBoxColumnArticulo
            // 
            DataGridViewTextBoxColumnArticulo.HeaderText = "Articulo";
            DataGridViewTextBoxColumnArticulo.Name = "DataGridViewTextBoxColumnArticulo";
            // 
            // DataGridViewTextBoxColumnDescripcion
            // 
            DataGridViewTextBoxColumnDescripcion.HeaderText = "Descripción";
            DataGridViewTextBoxColumnDescripcion.Name = "DataGridViewTextBoxColumnDescripcion";
            DataGridViewTextBoxColumnDescripcion.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumnPrecio
            // 
            DataGridViewTextBoxColumnPrecio.HeaderText = "Precio";
            DataGridViewTextBoxColumnPrecio.Name = "DataGridViewTextBoxColumnPrecio";
            // 
            // DataGridViewTextBoxColumnImporte
            // 
            DataGridViewTextBoxColumnImporte.HeaderText = "Importe";
            DataGridViewTextBoxColumnImporte.Name = "DataGridViewTextBoxColumnImporte";
            DataGridViewTextBoxColumnImporte.ReadOnly = true;
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
            groupBoxTotales.Location = new Point(6, 243);
            groupBoxTotales.Name = "groupBoxTotales";
            groupBoxTotales.Size = new Size(677, 62);
            groupBoxTotales.TabIndex = 0;
            groupBoxTotales.TabStop = false;
            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSubTotal.ForeColor = SystemColors.Highlight;
            lblSubTotal.Location = new Point(125, 40);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(31, 15);
            lblSubTotal.TabIndex = 38;
            lblSubTotal.Text = "$0,0";
            // 
            // lblVariacion
            // 
            lblVariacion.AutoSize = true;
            lblVariacion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblVariacion.ForeColor = SystemColors.Highlight;
            lblVariacion.Location = new Point(264, 40);
            lblVariacion.Name = "lblVariacion";
            lblVariacion.Size = new Size(31, 15);
            lblVariacion.TabIndex = 37;
            lblVariacion.Text = "$0,0";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTotal.Location = new Point(598, 19);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(48, 17);
            lblTotal.TabIndex = 34;
            lblTotal.Text = "TOTAL";
            // 
            // lblMontoTotal
            // 
            lblMontoTotal.AutoSize = true;
            lblMontoTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblMontoTotal.ForeColor = SystemColors.Highlight;
            lblMontoTotal.Location = new Point(603, 40);
            lblMontoTotal.Name = "lblMontoTotal";
            lblMontoTotal.Size = new Size(31, 15);
            lblMontoTotal.TabIndex = 33;
            lblMontoTotal.Text = "$0,0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(264, 19);
            label2.Name = "label2";
            label2.Size = new Size(49, 17);
            label2.TabIndex = 32;
            label2.Text = "Variac.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.Location = new Point(125, 19);
            label1.Name = "label1";
            label1.Size = new Size(66, 17);
            label1.TabIndex = 31;
            label1.Text = "Sub Total";
            // 
            // lblTotales
            // 
            lblTotales.AutoSize = true;
            lblTotales.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTotales.Location = new Point(6, 40);
            lblTotales.Name = "lblTotales";
            lblTotales.Size = new Size(62, 17);
            lblTotales.TabIndex = 30;
            lblTotales.Text = "TOTALES";
            // 
            // groupBoxObservaciones
            // 
            groupBoxObservaciones.Controls.Add(btnSalir);
            groupBoxObservaciones.Controls.Add(btnConfirmar);
            groupBoxObservaciones.Controls.Add(btnNuevaVenta);
            groupBoxObservaciones.Controls.Add(textBoxObservacion);
            groupBoxObservaciones.Controls.Add(lblObservacion);
            groupBoxObservaciones.Location = new Point(12, 497);
            groupBoxObservaciones.Margin = new Padding(3, 2, 3, 2);
            groupBoxObservaciones.Name = "groupBoxObservaciones";
            groupBoxObservaciones.Padding = new Padding(3, 2, 3, 2);
            groupBoxObservaciones.Size = new Size(851, 61);
            groupBoxObservaciones.TabIndex = 1;
            groupBoxObservaciones.TabStop = false;
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
            btnSalir.KeyDown += btnSalir_KeyDown;
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
            // btnNuevaVenta
            // 
            btnNuevaVenta.Location = new Point(479, 27);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(118, 23);
            btnNuevaVenta.TabIndex = 4;
            btnNuevaVenta.Text = "Nueva - F9";
            btnNuevaVenta.UseVisualStyleBackColor = true;
            btnNuevaVenta.Click += btnNuevaVenta_Click;
            // 
            // textBoxObservacion
            // 
            textBoxObservacion.Location = new Point(6, 28);
            textBoxObservacion.Margin = new Padding(3, 2, 3, 2);
            textBoxObservacion.Name = "textBoxObservacion";
            textBoxObservacion.Size = new Size(351, 23);
            textBoxObservacion.TabIndex = 30;
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Location = new Point(6, 11);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(76, 15);
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
            // VentaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 569);
            Controls.Add(groupBoxInfoVenta);
            Controls.Add(groupBoxArticulosVendidos);
            Controls.Add(groupBoxObservaciones);
            Controls.Add(gpDatosCliente);
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "VentaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Facturación Electronica";
            Load += VentaForm_Load;
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
        private ComboBox comboBoxTipo;
        private ComboBox comboBoxCondicionVenta;
        private ComboBox comboBoxTipoComprobante;
        private TextBox textBoxDireccion;
        private TextBox textBoxNumCuenta;
        private TextBox textBoxNombreCLiente;
        private Button btnBuscarCliente;
        private TextBox textBoxFecha;
        private TextBox textBoxVariacionVenta;
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
        private Button button1;
        private Button btnSalir;
        private Button btnConfirmar;
        private Button btnNuevaVenta;
        private DataGridView dataGridViewProductos;
        private MaskedTextBox maskedTextBoxNumeroComprob;
        private MaskedTextBox maskedTextBoxPresupAsociado;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnCantidad;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnArticulo;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnDescripcion;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnPrecio;
        private DataGridViewTextBoxColumn DataGridViewTextBoxColumnImporte;
    }
}