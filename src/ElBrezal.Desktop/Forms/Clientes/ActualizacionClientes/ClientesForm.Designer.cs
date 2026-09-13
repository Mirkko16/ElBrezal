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
            textBoxTelefono2 = new TextBox();
            textBoxEmail = new TextBox();
            textBoxFax = new TextBox();
            textBoxTelefono1 = new TextBox();
            lblEmail = new Label();
            lblTelefono2 = new Label();
            lblFax = new Label();
            lblTelefono = new Label();
            groupBoxInfoAdicional = new GroupBox();
            textBoxMatricula = new TextBox();
            textBoxOcupacion = new TextBox();
            lblMatricula = new Label();
            lblOcupacion = new Label();
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
            groupBoxInfoAdicional.SuspendLayout();
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
            groupBoxDatsoPRincipales.Location = new Point(12, 24);
            groupBoxDatsoPRincipales.Name = "groupBoxDatsoPRincipales";
            groupBoxDatsoPRincipales.Size = new Size(1000, 151);
            groupBoxDatsoPRincipales.TabIndex = 12;
            groupBoxDatsoPRincipales.TabStop = false;
            groupBoxDatsoPRincipales.Text = "Datos Principales";
            // 
            // btnNuevaLocalidad
            // 
            btnNuevaLocalidad.Location = new Point(390, 110);
            btnNuevaLocalidad.Name = "btnNuevaLocalidad";
            btnNuevaLocalidad.Size = new Size(32, 29);
            btnNuevaLocalidad.TabIndex = 26;
            btnNuevaLocalidad.Text = "...";
            btnNuevaLocalidad.UseVisualStyleBackColor = true;
            btnNuevaLocalidad.Click += btnNuevaLocalidad_Click;
            // 
            // textBoxProvincia
            // 
            textBoxProvincia.Location = new Point(813, 107);
            textBoxProvincia.Name = "textBoxProvincia";
            textBoxProvincia.ReadOnly = true;
            textBoxProvincia.Size = new Size(125, 27);
            textBoxProvincia.TabIndex = 25;
            // 
            // lblProvincia
            // 
            lblProvincia.AutoSize = true;
            lblProvincia.Location = new Point(725, 114);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(72, 20);
            lblProvincia.TabIndex = 24;
            lblProvincia.Text = "Provincia:";
            // 
            // textBoxCodigoPostal
            // 
            textBoxCodigoPostal.Location = new Point(566, 107);
            textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            textBoxCodigoPostal.ReadOnly = true;
            textBoxCodigoPostal.Size = new Size(125, 27);
            textBoxCodigoPostal.TabIndex = 23;
            // 
            // lblCodigoPostal
            // 
            lblCodigoPostal.AutoSize = true;
            lblCodigoPostal.Location = new Point(475, 114);
            lblCodigoPostal.Name = "lblCodigoPostal";
            lblCodigoPostal.Size = new Size(85, 20);
            lblCodigoPostal.TabIndex = 22;
            lblCodigoPostal.Text = "Cód. Postal:";
            // 
            // cmbLocalidades
            // 
            cmbLocalidades.FormattingEnabled = true;
            cmbLocalidades.Location = new Point(134, 111);
            cmbLocalidades.Name = "cmbLocalidades";
            cmbLocalidades.Size = new Size(250, 28);
            cmbLocalidades.TabIndex = 21;
            cmbLocalidades.SelectedIndexChanged += cmbLocalidades_SelectedIndexChanged;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(43, 114);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(77, 20);
            lblLocalidad.TabIndex = 20;
            lblLocalidad.Text = "Localidad:";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(38, 71);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(75, 20);
            lblDireccion.TabIndex = 19;
            lblDireccion.Text = "Dirección:";
            // 
            // textBoxDireccion
            // 
            textBoxDireccion.CharacterCasing = CharacterCasing.Upper;
            textBoxDireccion.Location = new Point(134, 68);
            textBoxDireccion.Name = "textBoxDireccion";
            textBoxDireccion.Size = new Size(377, 27);
            textBoxDireccion.TabIndex = 18;
            // 
            // textBoxDNI
            // 
            textBoxDNI.Location = new Point(783, 23);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.Size = new Size(180, 27);
            textBoxDNI.TabIndex = 17;
            // 
            // textBoxNombre
            // 
            textBoxNombre.CharacterCasing = CharacterCasing.Upper;
            textBoxNombre.Location = new Point(362, 23);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(302, 27);
            textBoxNombre.TabIndex = 16;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.Location = new Point(134, 23);
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.ReadOnly = true;
            textBoxCodigo.Size = new Size(69, 27);
            textBoxCodigo.TabIndex = 15;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(721, 30);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(38, 20);
            lblDni.TabIndex = 14;
            lblDni.Text = "DNI:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(289, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 13;
            lblNombre.Text = "Nombre:";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(67, 30);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(61, 20);
            lblCodigo.TabIndex = 12;
            lblCodigo.Text = "Código:";
            // 
            // groupBoxContacto
            // 
            groupBoxContacto.Controls.Add(textBoxTelefono2);
            groupBoxContacto.Controls.Add(textBoxEmail);
            groupBoxContacto.Controls.Add(textBoxFax);
            groupBoxContacto.Controls.Add(textBoxTelefono1);
            groupBoxContacto.Controls.Add(lblEmail);
            groupBoxContacto.Controls.Add(lblTelefono2);
            groupBoxContacto.Controls.Add(lblFax);
            groupBoxContacto.Controls.Add(lblTelefono);
            groupBoxContacto.Location = new Point(12, 176);
            groupBoxContacto.Name = "groupBoxContacto";
            groupBoxContacto.Size = new Size(1001, 130);
            groupBoxContacto.TabIndex = 13;
            groupBoxContacto.TabStop = false;
            groupBoxContacto.Text = "Contacto";
            // 
            // textBoxTelefono2
            // 
            textBoxTelefono2.Location = new Point(639, 39);
            textBoxTelefono2.Name = "textBoxTelefono2";
            textBoxTelefono2.Size = new Size(250, 27);
            textBoxTelefono2.TabIndex = 7;
            textBoxTelefono2.KeyPress += textBoxTelefono2_KeyPress;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(639, 88);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(250, 27);
            textBoxEmail.TabIndex = 6;
            // 
            // textBoxFax
            // 
            textBoxFax.Location = new Point(134, 81);
            textBoxFax.Name = "textBoxFax";
            textBoxFax.Size = new Size(250, 27);
            textBoxFax.TabIndex = 5;
            // 
            // textBoxTelefono1
            // 
            textBoxTelefono1.Location = new Point(134, 39);
            textBoxTelefono1.Name = "textBoxTelefono1";
            textBoxTelefono1.Size = new Size(250, 27);
            textBoxTelefono1.TabIndex = 4;
            textBoxTelefono1.KeyPress += textBoxTelefono1_KeyPress;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(536, 88);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // lblTelefono2
            // 
            lblTelefono2.AutoSize = true;
            lblTelefono2.Location = new Point(531, 46);
            lblTelefono2.Name = "lblTelefono2";
            lblTelefono2.Size = new Size(82, 20);
            lblTelefono2.TabIndex = 2;
            lblTelefono2.Text = "Teléfono 2:";
            // 
            // lblFax
            // 
            lblFax.AutoSize = true;
            lblFax.Location = new Point(43, 88);
            lblFax.Name = "lblFax";
            lblFax.Size = new Size(33, 20);
            lblFax.TabIndex = 1;
            lblFax.Text = "Fax:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(43, 46);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(82, 20);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "Teléfono 1:";
            // 
            // groupBoxInfoAdicional
            // 
            groupBoxInfoAdicional.Controls.Add(textBoxMatricula);
            groupBoxInfoAdicional.Controls.Add(textBoxOcupacion);
            groupBoxInfoAdicional.Controls.Add(lblMatricula);
            groupBoxInfoAdicional.Controls.Add(lblOcupacion);
            groupBoxInfoAdicional.Location = new Point(15, 314);
            groupBoxInfoAdicional.Name = "groupBoxInfoAdicional";
            groupBoxInfoAdicional.Size = new Size(1000, 61);
            groupBoxInfoAdicional.TabIndex = 14;
            groupBoxInfoAdicional.TabStop = false;
            groupBoxInfoAdicional.Text = "Informacion Adicional";
            // 
            // textBoxMatricula
            // 
            textBoxMatricula.CharacterCasing = CharacterCasing.Upper;
            textBoxMatricula.Location = new Point(636, 23);
            textBoxMatricula.Name = "textBoxMatricula";
            textBoxMatricula.Size = new Size(357, 27);
            textBoxMatricula.TabIndex = 3;
            // 
            // textBoxOcupacion
            // 
            textBoxOcupacion.CharacterCasing = CharacterCasing.Upper;
            textBoxOcupacion.Location = new Point(92, 23);
            textBoxOcupacion.Name = "textBoxOcupacion";
            textBoxOcupacion.Size = new Size(399, 27);
            textBoxOcupacion.TabIndex = 2;
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Location = new Point(546, 30);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(74, 20);
            lblMatricula.TabIndex = 1;
            lblMatricula.Text = "Matricula:";
            // 
            // lblOcupacion
            // 
            lblOcupacion.AutoSize = true;
            lblOcupacion.Location = new Point(6, 30);
            lblOcupacion.Name = "lblOcupacion";
            lblOcupacion.Size = new Size(83, 20);
            lblOcupacion.TabIndex = 0;
            lblOcupacion.Text = "Ocupación:";
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
            groupBoxDatosFiscalesYCuenta.Location = new Point(17, 385);
            groupBoxDatosFiscalesYCuenta.Name = "groupBoxDatosFiscalesYCuenta";
            groupBoxDatosFiscalesYCuenta.Size = new Size(1002, 159);
            groupBoxDatosFiscalesYCuenta.TabIndex = 15;
            groupBoxDatosFiscalesYCuenta.TabStop = false;
            groupBoxDatosFiscalesYCuenta.Text = "Datos fiscales y cuenta";
            // 
            // cmbEstadoCuenta
            // 
            cmbEstadoCuenta.FormattingEnabled = true;
            cmbEstadoCuenta.Location = new Point(596, 84);
            cmbEstadoCuenta.Name = "cmbEstadoCuenta";
            cmbEstadoCuenta.Size = new Size(219, 28);
            cmbEstadoCuenta.TabIndex = 16;
            // 
            // textBoxIngresosBrutos
            // 
            textBoxIngresosBrutos.Location = new Point(117, 85);
            textBoxIngresosBrutos.Name = "textBoxIngresosBrutos";
            textBoxIngresosBrutos.Size = new Size(219, 27);
            textBoxIngresosBrutos.TabIndex = 15;
            // 
            // textBoxCUIT
            // 
            textBoxCUIT.Location = new Point(596, 36);
            textBoxCUIT.Mask = "00-00000000-0";
            textBoxCUIT.Name = "textBoxCUIT";
            textBoxCUIT.Size = new Size(219, 27);
            textBoxCUIT.TabIndex = 14;
            // 
            // btnVerificarCuit
            // 
            btnVerificarCuit.Location = new Point(833, 36);
            btnVerificarCuit.Name = "btnVerificarCuit";
            btnVerificarCuit.Size = new Size(158, 29);
            btnVerificarCuit.TabIndex = 12;
            btnVerificarCuit.Text = "Validar CUIT";
            btnVerificarCuit.UseVisualStyleBackColor = true;
            btnVerificarCuit.Click += btnVerificarCuit_Click;
            // 
            // lblEstadoCuenta
            // 
            lblEstadoCuenta.AutoSize = true;
            lblEstadoCuenta.Location = new Point(476, 92);
            lblEstadoCuenta.Name = "lblEstadoCuenta";
            lblEstadoCuenta.Size = new Size(107, 20);
            lblEstadoCuenta.TabIndex = 8;
            lblEstadoCuenta.Text = "Estado Cuenta:";
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(476, 45);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(43, 20);
            lblCuit.TabIndex = 7;
            lblCuit.Text = "CUIT:";
            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Location = new Point(6, 133);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(76, 20);
            lblVendedor.TabIndex = 6;
            lblVendedor.Text = "Vendedor:";
            // 
            // lblIngBrutos
            // 
            lblIngBrutos.AutoSize = true;
            lblIngBrutos.Location = new Point(6, 92);
            lblIngBrutos.Name = "lblIngBrutos";
            lblIngBrutos.Size = new Size(82, 20);
            lblIngBrutos.TabIndex = 5;
            lblIngBrutos.Text = "Ing. Brutos:";
            // 
            // lblSitImpositiva
            // 
            lblSitImpositiva.AutoSize = true;
            lblSitImpositiva.Location = new Point(6, 45);
            lblSitImpositiva.Name = "lblSitImpositiva";
            lblSitImpositiva.Size = new Size(105, 20);
            lblSitImpositiva.TabIndex = 4;
            lblSitImpositiva.Text = "Sit. Impositiva:";
            // 
            // cmbVendedor
            // 
            cmbVendedor.FormattingEnabled = true;
            cmbVendedor.Location = new Point(117, 125);
            cmbVendedor.Name = "cmbVendedor";
            cmbVendedor.Size = new Size(219, 28);
            cmbVendedor.TabIndex = 3;
            // 
            // cmbSituacionImpositiva
            // 
            cmbSituacionImpositiva.FormattingEnabled = true;
            cmbSituacionImpositiva.Location = new Point(117, 37);
            cmbSituacionImpositiva.Name = "cmbSituacionImpositiva";
            cmbSituacionImpositiva.Size = new Size(219, 28);
            cmbSituacionImpositiva.TabIndex = 0;
            // 
            // groupBoxObservaciones
            // 
            groupBoxObservaciones.Controls.Add(btnImprimir);
            groupBoxObservaciones.Controls.Add(lblObservaciones);
            groupBoxObservaciones.Controls.Add(richTextBoxObservaciones);
            groupBoxObservaciones.Location = new Point(17, 564);
            groupBoxObservaciones.Name = "groupBoxObservaciones";
            groupBoxObservaciones.Size = new Size(1007, 118);
            groupBoxObservaciones.TabIndex = 16;
            groupBoxObservaciones.TabStop = false;
            groupBoxObservaciones.Text = "Observaciones";
            // 
            // btnImprimir
            // 
            btnImprimir.BackgroundImage = (Image)resources.GetObject("btnImprimir.BackgroundImage");
            btnImprimir.BackgroundImageLayout = ImageLayout.Stretch;
            btnImprimir.Enabled = false;
            btnImprimir.Location = new Point(718, 26);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(77, 64);
            btnImprimir.TabIndex = 2;
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(21, 43);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(94, 20);
            lblObservaciones.TabIndex = 1;
            lblObservaciones.Text = "Observación:";
            // 
            // richTextBoxObservaciones
            // 
            richTextBoxObservaciones.Location = new Point(144, 26);
            richTextBoxObservaciones.Name = "richTextBoxObservaciones";
            richTextBoxObservaciones.Size = new Size(474, 70);
            richTextBoxObservaciones.TabIndex = 0;
            richTextBoxObservaciones.Text = "";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(595, 697);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 17;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(695, 697);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 18;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(795, 697);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 19;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(895, 697);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 20;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblPosicion
            // 
            lblPosicion.AutoSize = true;
            lblPosicion.Location = new Point(150, 702);
            lblPosicion.Name = "lblPosicion";
            lblPosicion.Size = new Size(15, 20);
            lblPosicion.TabIndex = 25;
            lblPosicion.Text = "-";
            // 
            // btnUltimo
            // 
            btnUltimo.BackgroundImage = (Image)resources.GetObject("btnUltimo.BackgroundImage");
            btnUltimo.BackgroundImageLayout = ImageLayout.Center;
            btnUltimo.Location = new Point(296, 695);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(36, 31);
            btnUltimo.TabIndex = 24;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.BackgroundImage = (Image)resources.GetObject("btnPrimero.BackgroundImage");
            btnPrimero.BackgroundImageLayout = ImageLayout.Center;
            btnPrimero.Location = new Point(23, 695);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(36, 31);
            btnPrimero.TabIndex = 23;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.BackgroundImage = (Image)resources.GetObject("btnAnterior.BackgroundImage");
            btnAnterior.BackgroundImageLayout = ImageLayout.Center;
            btnAnterior.Location = new Point(71, 695);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(36, 31);
            btnAnterior.TabIndex = 22;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.BackgroundImage = (Image)resources.GetObject("btnSiguiente.BackgroundImage");
            btnSiguiente.BackgroundImageLayout = ImageLayout.Center;
            btnSiguiente.Location = new Point(254, 695);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(36, 31);
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 748);
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
            Controls.Add(groupBoxInfoAdicional);
            Controls.Add(groupBoxContacto);
            Controls.Add(groupBoxDatsoPRincipales);
            KeyPreview = true;
            Name = "ClientesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ActualizacionClientesForm";
            Load += ActualizacionClientesForm_Load;
            KeyDown += ActualizacionClientesForm_KeyDown;
            groupBoxDatsoPRincipales.ResumeLayout(false);
            groupBoxDatsoPRincipales.PerformLayout();
            groupBoxContacto.ResumeLayout(false);
            groupBoxContacto.PerformLayout();
            groupBoxInfoAdicional.ResumeLayout(false);
            groupBoxInfoAdicional.PerformLayout();
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
        private TextBox textBoxTelefono2;
        private TextBox textBoxEmail;
        private TextBox textBoxFax;
        private TextBox textBoxTelefono1;
        private Label lblEmail;
        private Label lblTelefono2;
        private Label lblFax;
        private Label lblTelefono;
        private GroupBox groupBoxInfoAdicional;
        private TextBox textBoxMatricula;
        private TextBox textBoxOcupacion;
        private Label lblMatricula;
        private Label lblOcupacion;
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
    }
}