namespace ElBrezal.Desktop.Forms.Clientes.ActualizacionClientes
{
    partial class ClientesForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesForm));
            groupBoxDatsoPRincipales = new GroupBox();
            btnNuevaLocalidad = new Button();
            textBoxProvincia = new TextBox();
            lblProvincia = new Label();
            textBoxCodigoPostal = new TextBox();
            lblCodigoPostal = new Label();
            cmbLocalidades = new ComboBox();
            lblLocalidad = new Label();
            lblDireccion = new Label();
            textBoxDireccion = new TextBox();
            textBoxDNI = new TextBox();
            textBoxNombre = new TextBox();
            textBoxCodigo = new TextBox();
            lblDni = new Label();
            lblNombre = new Label();
            lblCodigo = new Label();
            groupBoxContacto = new GroupBox();
            textBoxEmail = new TextBox();
            textBoxTelefono = new TextBox();
            lblEmail = new Label();
            lblTelefono = new Label();
            groupBoxDatosFiscalesYCuenta = new GroupBox();
            cmbEstadoCuenta = new ComboBox();
            textBoxIngresosBrutos = new TextBox();
            textBoxCUIT = new MaskedTextBox();
            btnVerificarCuit = new Button();
            lblEstadoCuenta = new Label();
            lblCuit = new Label();
            lblVendedor = new Label();
            lblIngBrutos = new Label();
            lblSitImpositiva = new Label();
            cmbVendedor = new ComboBox();
            cmbSituacionImpositiva = new ComboBox();
            groupBoxObservaciones = new GroupBox();
            btnImprimir = new Button();
            lblObservaciones = new Label();
            richTextBoxObservaciones = new RichTextBox();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            lblPosicion = new Label();
            btnUltimo = new Button();
            btnPrimero = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            bindingSourceClientes = new BindingSource(components);
            bindingSourceLocalidades = new BindingSource(components);
            bindingSourceSituacionesImpositivas = new BindingSource(components);
            bindingSourceEstadosCuenta = new BindingSource(components);
            bindingSourceVendedores = new BindingSource(components);
            groupBoxDatsoPRincipales.SuspendLayout();
            groupBoxContacto.SuspendLayout();
            groupBoxDatosFiscalesYCuenta.SuspendLayout();
            groupBoxObservaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSourceClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceLocalidades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceSituacionesImpositivas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceEstadosCuenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceVendedores).BeginInit();
            SuspendLayout();
            // 
            // groupBoxDatsoPRincipales
            // 
            groupBoxDatsoPRincipales.Controls.Add(btnNuevaLocalidad);
            groupBoxDatsoPRincipales.Controls.Add(textBoxProvincia);
            groupBoxDatsoPRincipales.Controls.Add(lblProvincia);
            groupBoxDatsoPRincipales.Controls.Add(textBoxCodigoPostal);
            groupBoxDatsoPRincipales.Controls.Add(lblCodigoPostal);
            groupBoxDatsoPRincipales.Controls.Add(cmbLocalidades);
            groupBoxDatsoPRincipales.Controls.Add(lblLocalidad);
            groupBoxDatsoPRincipales.Controls.Add(lblDireccion);
            groupBoxDatsoPRincipales.Controls.Add(textBoxDireccion);
            groupBoxDatsoPRincipales.Controls.Add(textBoxDNI);
            groupBoxDatsoPRincipales.Controls.Add(textBoxNombre);
            groupBoxDatsoPRincipales.Controls.Add(textBoxCodigo);
            groupBoxDatsoPRincipales.Controls.Add(lblDni);
            groupBoxDatsoPRincipales.Controls.Add(lblNombre);
            groupBoxDatsoPRincipales.Controls.Add(lblCodigo);
            groupBoxDatsoPRincipales.Location = new Point(10, 18);
            groupBoxDatsoPRincipales.Margin = new Padding(3, 2, 3, 2);
            groupBoxDatsoPRincipales.Name = "groupBoxDatsoPRincipales";
            groupBoxDatsoPRincipales.Padding = new Padding(3, 2, 3, 2);
            groupBoxDatsoPRincipales.Size = new Size(875, 113);
            groupBoxDatsoPRincipales.TabIndex = 12;
            groupBoxDatsoPRincipales.TabStop = false;
            groupBoxDatsoPRincipales.Text = "Datos Principales";
            // 
            // btnNuevaLocalidad
            // 
            btnNuevaLocalidad.Location = new Point(341, 82);
            btnNuevaLocalidad.Margin = new Padding(3, 2, 3, 2);
            btnNuevaLocalidad.Name = "btnNuevaLocalidad";
            btnNuevaLocalidad.Size = new Size(28, 22);
            btnNuevaLocalidad.TabIndex = 26;
            btnNuevaLocalidad.Text = "...";
            btnNuevaLocalidad.UseVisualStyleBackColor = true;
            btnNuevaLocalidad.Click += btnNuevaLocalidad_Click;
            // 
            // textBoxProvincia
            // 
            textBoxProvincia.Location = new Point(711, 80);
            textBoxProvincia.Margin = new Padding(3, 2, 3, 2);
            textBoxProvincia.Name = "textBoxProvincia";
            textBoxProvincia.ReadOnly = true;
            textBoxProvincia.Size = new Size(110, 23);
            textBoxProvincia.TabIndex = 25;
            // 
            // lblProvincia
            // 
            lblProvincia.AutoSize = true;
            lblProvincia.Location = new Point(634, 86);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(59, 15);
            lblProvincia.TabIndex = 24;
            lblProvincia.Text = "Provincia:";
            // 
            // textBoxCodigoPostal
            // 
            textBoxCodigoPostal.Location = new Point(495, 80);
            textBoxCodigoPostal.Margin = new Padding(3, 2, 3, 2);
            textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            textBoxCodigoPostal.ReadOnly = true;
            textBoxCodigoPostal.Size = new Size(110, 23);
            textBoxCodigoPostal.TabIndex = 23;
            // 
            // lblCodigoPostal
            // 
            lblCodigoPostal.AutoSize = true;
            lblCodigoPostal.Location = new Point(416, 86);
            lblCodigoPostal.Name = "lblCodigoPostal";
            lblCodigoPostal.Size = new Size(70, 15);
            lblCodigoPostal.TabIndex = 22;
            lblCodigoPostal.Text = "Cód. Postal:";
            // 
            // cmbLocalidades
            // 
            cmbLocalidades.FormattingEnabled = true;
            cmbLocalidades.Location = new Point(117, 83);
            cmbLocalidades.Margin = new Padding(3, 2, 3, 2);
            cmbLocalidades.Name = "cmbLocalidades";
            cmbLocalidades.Size = new Size(219, 23);
            cmbLocalidades.TabIndex = 21;
            cmbLocalidades.SelectedIndexChanged += cmbLocalidades_SelectedIndexChanged;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(38, 86);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(61, 15);
            lblLocalidad.TabIndex = 20;
            lblLocalidad.Text = "Localidad:";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(33, 53);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(60, 15);
            lblDireccion.TabIndex = 19;
            lblDireccion.Text = "Dirección:";
            // 
            // textBoxDireccion
            // 
            textBoxDireccion.CharacterCasing = CharacterCasing.Upper;
            textBoxDireccion.Location = new Point(117, 51);
            textBoxDireccion.Margin = new Padding(3, 2, 3, 2);
            textBoxDireccion.Name = "textBoxDireccion";
            textBoxDireccion.Size = new Size(330, 23);
            textBoxDireccion.TabIndex = 18;
            // 
            // textBoxDNI
            // 
            textBoxDNI.Location = new Point(685, 17);
            textBoxDNI.Margin = new Padding(3, 2, 3, 2);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.Size = new Size(158, 23);
            textBoxDNI.TabIndex = 17;
            // 
            // textBoxNombre
            // 
            textBoxNombre.CharacterCasing = CharacterCasing.Upper;
            textBoxNombre.Location = new Point(317, 17);
            textBoxNombre.Margin = new Padding(3, 2, 3, 2);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(265, 23);
            textBoxNombre.TabIndex = 16;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.Location = new Point(117, 17);
            textBoxCodigo.Margin = new Padding(3, 2, 3, 2);
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.ReadOnly = true;
            textBoxCodigo.Size = new Size(61, 23);
            textBoxCodigo.TabIndex = 15;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(631, 22);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(30, 15);
            lblDni.TabIndex = 14;
            lblDni.Text = "DNI:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(253, 22);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 13;
            lblNombre.Text = "Nombre:";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(59, 22);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(49, 15);
            lblCodigo.TabIndex = 12;
            lblCodigo.Text = "Código:";
            // 
            // groupBoxContacto
            // 
            groupBoxContacto.Controls.Add(textBoxEmail);
            groupBoxContacto.Controls.Add(textBoxTelefono);
            groupBoxContacto.Controls.Add(lblEmail);
            groupBoxContacto.Controls.Add(lblTelefono);
            groupBoxContacto.Location = new Point(10, 132);
            groupBoxContacto.Margin = new Padding(3, 2, 3, 2);
            groupBoxContacto.Name = "groupBoxContacto";
            groupBoxContacto.Padding = new Padding(3, 2, 3, 2);
            groupBoxContacto.Size = new Size(876, 63);
            groupBoxContacto.TabIndex = 13;
            groupBoxContacto.TabStop = false;
            groupBoxContacto.Text = "Contacto";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(527, 29);
            textBoxEmail.Margin = new Padding(3, 2, 3, 2);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(219, 23);
            textBoxEmail.TabIndex = 6;
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(117, 29);
            textBoxTelefono.Margin = new Padding(3, 2, 3, 2);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.Size = new Size(219, 23);
            textBoxTelefono.TabIndex = 4;
            textBoxTelefono.KeyPress += textBoxTelefono1_KeyPress;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(434, 34);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(38, 34);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(56, 15);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "Teléfono:";
            // 
            // groupBoxDatosFiscalesYCuenta
            // 
            groupBoxDatosFiscalesYCuenta.Controls.Add(cmbEstadoCuenta);
            groupBoxDatosFiscalesYCuenta.Controls.Add(textBoxIngresosBrutos);
            groupBoxDatosFiscalesYCuenta.Controls.Add(textBoxCUIT);
            groupBoxDatosFiscalesYCuenta.Controls.Add(btnVerificarCuit);
            groupBoxDatosFiscalesYCuenta.Controls.Add(lblEstadoCuenta);
            groupBoxDatosFiscalesYCuenta.Controls.Add(lblCuit);
            groupBoxDatosFiscalesYCuenta.Controls.Add(lblVendedor);
            groupBoxDatosFiscalesYCuenta.Controls.Add(lblIngBrutos);
            groupBoxDatosFiscalesYCuenta.Controls.Add(lblSitImpositiva);
            groupBoxDatosFiscalesYCuenta.Controls.Add(cmbVendedor);
            groupBoxDatosFiscalesYCuenta.Controls.Add(cmbSituacionImpositiva);
            groupBoxDatosFiscalesYCuenta.Location = new Point(10, 199);
            groupBoxDatosFiscalesYCuenta.Margin = new Padding(3, 2, 3, 2);
            groupBoxDatosFiscalesYCuenta.Name = "groupBoxDatosFiscalesYCuenta";
            groupBoxDatosFiscalesYCuenta.Padding = new Padding(3, 2, 3, 2);
            groupBoxDatosFiscalesYCuenta.Size = new Size(877, 119);
            groupBoxDatosFiscalesYCuenta.TabIndex = 15;
            groupBoxDatosFiscalesYCuenta.TabStop = false;
            groupBoxDatosFiscalesYCuenta.Text = "Datos fiscales y cuenta";
            // 
            // cmbEstadoCuenta
            // 
            cmbEstadoCuenta.FormattingEnabled = true;
            cmbEstadoCuenta.Location = new Point(522, 63);
            cmbEstadoCuenta.Margin = new Padding(3, 2, 3, 2);
            cmbEstadoCuenta.Name = "cmbEstadoCuenta";
            cmbEstadoCuenta.Size = new Size(192, 23);
            cmbEstadoCuenta.TabIndex = 16;
            // 
            // textBoxIngresosBrutos
            // 
            textBoxIngresosBrutos.Location = new Point(102, 64);
            textBoxIngresosBrutos.Margin = new Padding(3, 2, 3, 2);
            textBoxIngresosBrutos.Name = "textBoxIngresosBrutos";
            textBoxIngresosBrutos.Size = new Size(192, 23);
            textBoxIngresosBrutos.TabIndex = 15;
            // 
            // textBoxCUIT
            // 
            textBoxCUIT.Location = new Point(522, 27);
            textBoxCUIT.Margin = new Padding(3, 2, 3, 2);
            textBoxCUIT.Mask = "00-00000000-0";
            textBoxCUIT.Name = "textBoxCUIT";
            textBoxCUIT.Size = new Size(192, 23);
            textBoxCUIT.TabIndex = 14;
            // 
            // btnVerificarCuit
            // 
            btnVerificarCuit.Location = new Point(729, 27);
            btnVerificarCuit.Margin = new Padding(3, 2, 3, 2);
            btnVerificarCuit.Name = "btnVerificarCuit";
            btnVerificarCuit.Size = new Size(138, 22);
            btnVerificarCuit.TabIndex = 12;
            btnVerificarCuit.Text = "Validar CUIT";
            btnVerificarCuit.UseVisualStyleBackColor = true;
            btnVerificarCuit.Click += btnVerificarCuit_Click;
            // 
            // lblEstadoCuenta
            // 
            lblEstadoCuenta.AutoSize = true;
            lblEstadoCuenta.Location = new Point(416, 69);
            lblEstadoCuenta.Name = "lblEstadoCuenta";
            lblEstadoCuenta.Size = new Size(86, 15);
            lblEstadoCuenta.TabIndex = 8;
            lblEstadoCuenta.Text = "Estado Cuenta:";
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(416, 34);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(36, 15);
            lblCuit.TabIndex = 7;
            lblCuit.Text = "CUIT:";
            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Location = new Point(5, 100);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(60, 15);
            lblVendedor.TabIndex = 6;
            lblVendedor.Text = "Vendedor:";
            // 
            // lblIngBrutos
            // 
            lblIngBrutos.AutoSize = true;
            lblIngBrutos.Location = new Point(5, 69);
            lblIngBrutos.Name = "lblIngBrutos";
            lblIngBrutos.Size = new Size(67, 15);
            lblIngBrutos.TabIndex = 5;
            lblIngBrutos.Text = "Ing. Brutos:";
            // 
            // lblSitImpositiva
            // 
            lblSitImpositiva.AutoSize = true;
            lblSitImpositiva.Location = new Point(5, 34);
            lblSitImpositiva.Name = "lblSitImpositiva";
            lblSitImpositiva.Size = new Size(84, 15);
            lblSitImpositiva.TabIndex = 4;
            lblSitImpositiva.Text = "Sit. Impositiva:";
            // 
            // cmbVendedor
            // 
            cmbVendedor.FormattingEnabled = true;
            cmbVendedor.Location = new Point(102, 94);
            cmbVendedor.Margin = new Padding(3, 2, 3, 2);
            cmbVendedor.Name = "cmbVendedor";
            cmbVendedor.Size = new Size(192, 23);
            cmbVendedor.TabIndex = 3;
            // 
            // cmbSituacionImpositiva
            // 
            cmbSituacionImpositiva.FormattingEnabled = true;
            cmbSituacionImpositiva.Location = new Point(102, 28);
            cmbSituacionImpositiva.Margin = new Padding(3, 2, 3, 2);
            cmbSituacionImpositiva.Name = "cmbSituacionImpositiva";
            cmbSituacionImpositiva.Size = new Size(192, 23);
            cmbSituacionImpositiva.TabIndex = 0;
            // 
            // groupBoxObservaciones
            // 
            groupBoxObservaciones.Controls.Add(btnImprimir);
            groupBoxObservaciones.Controls.Add(lblObservaciones);
            groupBoxObservaciones.Controls.Add(richTextBoxObservaciones);
            groupBoxObservaciones.Location = new Point(10, 322);
            groupBoxObservaciones.Margin = new Padding(3, 2, 3, 2);
            groupBoxObservaciones.Name = "groupBoxObservaciones";
            groupBoxObservaciones.Padding = new Padding(3, 2, 3, 2);
            groupBoxObservaciones.Size = new Size(877, 88);
            groupBoxObservaciones.TabIndex = 16;
            groupBoxObservaciones.TabStop = false;
            groupBoxObservaciones.Text = "Observaciones";
            // 
            // btnImprimir
            // 
            btnImprimir.BackgroundImage = (Image)resources.GetObject("btnImprimir.BackgroundImage");
            btnImprimir.BackgroundImageLayout = ImageLayout.Stretch;
            btnImprimir.Enabled = false;
            btnImprimir.Location = new Point(628, 20);
            btnImprimir.Margin = new Padding(3, 2, 3, 2);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(67, 48);
            btnImprimir.TabIndex = 2;
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(18, 32);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(76, 15);
            lblObservaciones.TabIndex = 1;
            lblObservaciones.Text = "Observación:";
            // 
            // richTextBoxObservaciones
            // 
            richTextBoxObservaciones.Location = new Point(126, 20);
            richTextBoxObservaciones.Margin = new Padding(3, 2, 3, 2);
            richTextBoxObservaciones.Name = "richTextBoxObservaciones";
            richTextBoxObservaciones.Size = new Size(415, 54);
            richTextBoxObservaciones.TabIndex = 0;
            richTextBoxObservaciones.Text = "";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(509, 427);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(82, 22);
            btnNuevo.TabIndex = 17;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(596, 427);
            btnModificar.Margin = new Padding(3, 2, 3, 2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(82, 22);
            btnModificar.TabIndex = 18;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(684, 427);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(82, 22);
            btnEliminar.TabIndex = 19;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(771, 427);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(82, 22);
            btnSalir.TabIndex = 20;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblPosicion
            // 
            lblPosicion.AutoSize = true;
            lblPosicion.Location = new Point(119, 430);
            lblPosicion.Name = "lblPosicion";
            lblPosicion.Size = new Size(12, 15);
            lblPosicion.TabIndex = 25;
            lblPosicion.Text = "-";
            // 
            // btnUltimo
            // 
            btnUltimo.BackgroundImage = (Image)resources.GetObject("btnUltimo.BackgroundImage");
            btnUltimo.BackgroundImageLayout = ImageLayout.Stretch;
            btnUltimo.Location = new Point(247, 425);
            btnUltimo.Margin = new Padding(3, 2, 3, 2);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(32, 23);
            btnUltimo.TabIndex = 24;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.BackgroundImage = (Image)resources.GetObject("btnPrimero.BackgroundImage");
            btnPrimero.BackgroundImageLayout = ImageLayout.Stretch;
            btnPrimero.Location = new Point(8, 425);
            btnPrimero.Margin = new Padding(3, 2, 3, 2);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(32, 23);
            btnPrimero.TabIndex = 23;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.BackgroundImage = (Image)resources.GetObject("btnAnterior.BackgroundImage");
            btnAnterior.BackgroundImageLayout = ImageLayout.Stretch;
            btnAnterior.Location = new Point(50, 425);
            btnAnterior.Margin = new Padding(3, 2, 3, 2);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(32, 23);
            btnAnterior.TabIndex = 22;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.BackgroundImage = (Image)resources.GetObject("btnSiguiente.BackgroundImage");
            btnSiguiente.BackgroundImageLayout = ImageLayout.Stretch;
            btnSiguiente.Location = new Point(210, 425);
            btnSiguiente.Margin = new Padding(3, 2, 3, 2);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(32, 23);
            btnSiguiente.TabIndex = 21;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // bindingSourceClientes
            // 
            bindingSourceClientes.PositionChanged += bindingSourceClientes_PositionChanged;
            // 
            // ClientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 464);
            Controls.Add(lblPosicion);
            Controls.Add(btnUltimo);
            Controls.Add(btnPrimero);
            Controls.Add(btnAnterior);
            Controls.Add(btnSiguiente);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(groupBoxObservaciones);
            Controls.Add(groupBoxDatosFiscalesYCuenta);
            Controls.Add(groupBoxContacto);
            Controls.Add(groupBoxDatsoPRincipales);
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ClientesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ActualizacionClientesForm";
            Load += ActualizacionClientesForm_Load;
            KeyDown += ActualizacionClientesForm_KeyDown;
            groupBoxDatsoPRincipales.ResumeLayout(false);
            groupBoxDatsoPRincipales.PerformLayout();
            groupBoxContacto.ResumeLayout(false);
            groupBoxContacto.PerformLayout();
            groupBoxDatosFiscalesYCuenta.ResumeLayout(false);
            groupBoxDatosFiscalesYCuenta.PerformLayout();
            groupBoxObservaciones.ResumeLayout(false);
            groupBoxObservaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSourceClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceLocalidades).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceSituacionesImpositivas).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceEstadosCuenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceVendedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxDatsoPRincipales;
        private TextBox textBoxCodigoPostal;
        private Label lblCodigoPostal;
        private ComboBox cmbLocalidades;
        private Label lblLocalidad;
        private Label lblDireccion;
        private TextBox textBoxDireccion;
        private TextBox textBoxDNI;
        private TextBox textBoxNombre;
        private TextBox textBoxCodigo;
        private Label lblDni;
        private Label lblNombre;
        private Label lblCodigo;
        private GroupBox groupBoxContacto;
        private TextBox textBoxTelefono;
        private Label lblTelefono;
        private GroupBox groupBoxDatosFiscalesYCuenta;
        private Label lblSitImpositiva;
        private ComboBox cmbVendedor;
        private ComboBox comboBox3;
        private ComboBox cmbSituacionImpositiva;
        private TextBox textBoxProvincia;
        private Label lblEstadoCuenta;
        private Label lblCuit;
        private Label lblVendedor;
        private Label lblIngBrutos;
        private Button btnVerificarCuit;
        private GroupBox groupBoxObservaciones;
        private Button btnImprimir;
        private Label lblObservaciones;
        private RichTextBox richTextBoxObservaciones;
        private Button btnNuevo;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnSalir;
        private MaskedTextBox textBoxCUIT;
        private TextBox textBoxIngresosBrutos;
        private Label lblPosicion;
        private Button btnUltimo;
        private Button btnPrimero;
        private Button btnAnterior;
        private Button btnSiguiente;
        private ComboBox cmbEstadoCuenta;
        private BindingSource bindingSourceClientes;
        private BindingSource bindingSourceLocalidades;
        private BindingSource bindingSourceSituacionesImpositivas;
        private BindingSource bindingSourceEstadosCuenta;
        private BindingSource bindingSourceVendedores;
        private Label lblProvincia;
        private Button btnNuevaLocalidad;
        private TextBox textBoxEmail;
        private Label lblEmail;
    }
}