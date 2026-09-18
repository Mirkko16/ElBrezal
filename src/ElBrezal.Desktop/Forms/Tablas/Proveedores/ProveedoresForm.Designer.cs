namespace ElBrezal.Desktop.Forms.Tablas.Proveedores
{
    partial class ProveedoresForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProveedoresForm));
            textBoxCUIT = new MaskedTextBox();
            btnVerificarCuit = new Button();
            lblCuit = new Label();
            lblIngBrutos = new Label();
            lblSitImpositiva = new Label();
            cmbSituacionImpositiva = new ComboBox();
            groupBoxObservaciones = new GroupBox();
            btnImprimir = new Button();
            lblObservaciones = new Label();
            richTextBoxObservaciones = new RichTextBox();
            textBoxIngresosBrutos = new TextBox();
            lblPosicion = new Label();
            btnUltimo = new Button();
            btnPrimero = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnSalir = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnNuevo = new Button();
            bindingSourceProveedores = new BindingSource(components);
            bindingSourceLocalidades = new BindingSource(components);
            bindingSourceSituacionesImpositivas = new BindingSource(components);
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
            textBoxNombre = new TextBox();
            textBoxCodigo = new TextBox();
            lblNombre = new Label();
            lblCodigo = new Label();
            groupBoxContacto = new GroupBox();
            textBoxEmail = new TextBox();
            textBoxTelefono = new TextBox();
            lblEmail = new Label();
            lblTelefono = new Label();
            groupBoxDatosFiscalesYCuenta = new GroupBox();
            groupBoxObservaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceLocalidades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceSituacionesImpositivas).BeginInit();
            groupBoxDatsoPRincipales.SuspendLayout();
            groupBoxContacto.SuspendLayout();
            groupBoxDatosFiscalesYCuenta.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxCUIT
            // 
            textBoxCUIT.Location = new Point(596, 42);
            textBoxCUIT.Mask = "00-00000000-0";
            textBoxCUIT.Name = "textBoxCUIT";
            textBoxCUIT.Size = new Size(219, 27);
            textBoxCUIT.TabIndex = 14;
            // 
            // btnVerificarCuit
            // 
            btnVerificarCuit.Location = new Point(833, 42);
            btnVerificarCuit.Name = "btnVerificarCuit";
            btnVerificarCuit.Size = new Size(158, 29);
            btnVerificarCuit.TabIndex = 12;
            btnVerificarCuit.Text = "Validar CUIT";
            btnVerificarCuit.UseVisualStyleBackColor = true;
            btnVerificarCuit.Click += btnVerificarCuit_Click;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(476, 51);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(43, 20);
            lblCuit.TabIndex = 7;
            lblCuit.Text = "CUIT:";
            // 
            // lblIngBrutos
            // 
            lblIngBrutos.AutoSize = true;
            lblIngBrutos.Location = new Point(6, 98);
            lblIngBrutos.Name = "lblIngBrutos";
            lblIngBrutos.Size = new Size(82, 20);
            lblIngBrutos.TabIndex = 5;
            lblIngBrutos.Text = "Ing. Brutos:";
            // 
            // lblSitImpositiva
            // 
            lblSitImpositiva.AutoSize = true;
            lblSitImpositiva.Location = new Point(6, 51);
            lblSitImpositiva.Name = "lblSitImpositiva";
            lblSitImpositiva.Size = new Size(105, 20);
            lblSitImpositiva.TabIndex = 4;
            lblSitImpositiva.Text = "Sit. Impositiva:";
            // 
            // cmbSituacionImpositiva
            // 
            cmbSituacionImpositiva.FormattingEnabled = true;
            cmbSituacionImpositiva.Location = new Point(117, 43);
            cmbSituacionImpositiva.Name = "cmbSituacionImpositiva";
            cmbSituacionImpositiva.Size = new Size(219, 28);
            cmbSituacionImpositiva.TabIndex = 0;
            // 
            // groupBoxObservaciones
            // 
            groupBoxObservaciones.Controls.Add(btnImprimir);
            groupBoxObservaciones.Controls.Add(lblObservaciones);
            groupBoxObservaciones.Controls.Add(richTextBoxObservaciones);
            groupBoxObservaciones.Location = new Point(24, 454);
            groupBoxObservaciones.Name = "groupBoxObservaciones";
            groupBoxObservaciones.Size = new Size(1007, 118);
            groupBoxObservaciones.TabIndex = 30;
            groupBoxObservaciones.TabStop = false;
            groupBoxObservaciones.Text = "Observaciones";
            // 
            // btnImprimir
            // 
            btnImprimir.BackgroundImage = (Image)resources.GetObject("btnImprimir.BackgroundImage");
            btnImprimir.BackgroundImageLayout = ImageLayout.Stretch;
            btnImprimir.Enabled = false;
            btnImprimir.Location = new Point(718, 32);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(77, 64);
            btnImprimir.TabIndex = 2;
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(21, 49);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(94, 20);
            lblObservaciones.TabIndex = 1;
            lblObservaciones.Text = "Observación:";
            // 
            // richTextBoxObservaciones
            // 
            richTextBoxObservaciones.Location = new Point(144, 32);
            richTextBoxObservaciones.Name = "richTextBoxObservaciones";
            richTextBoxObservaciones.Size = new Size(474, 70);
            richTextBoxObservaciones.TabIndex = 0;
            richTextBoxObservaciones.Text = "";
            // 
            // textBoxIngresosBrutos
            // 
            textBoxIngresosBrutos.Location = new Point(117, 91);
            textBoxIngresosBrutos.Name = "textBoxIngresosBrutos";
            textBoxIngresosBrutos.Size = new Size(219, 27);
            textBoxIngresosBrutos.TabIndex = 15;
            // 
            // lblPosicion
            // 
            lblPosicion.AutoSize = true;
            lblPosicion.Location = new Point(167, 607);
            lblPosicion.Name = "lblPosicion";
            lblPosicion.Size = new Size(15, 20);
            lblPosicion.TabIndex = 39;
            lblPosicion.Text = "-";
            // 
            // btnUltimo
            // 
            btnUltimo.BackgroundImage = (Image)resources.GetObject("btnUltimo.BackgroundImage");
            btnUltimo.BackgroundImageLayout = ImageLayout.Center;
            btnUltimo.Location = new Point(313, 600);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(36, 31);
            btnUltimo.TabIndex = 38;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.BackgroundImage = (Image)resources.GetObject("btnPrimero.BackgroundImage");
            btnPrimero.BackgroundImageLayout = ImageLayout.Center;
            btnPrimero.Location = new Point(40, 600);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(36, 31);
            btnPrimero.TabIndex = 37;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.BackgroundImage = (Image)resources.GetObject("btnAnterior.BackgroundImage");
            btnAnterior.BackgroundImageLayout = ImageLayout.Center;
            btnAnterior.Location = new Point(88, 600);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(36, 31);
            btnAnterior.TabIndex = 36;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.BackgroundImage = (Image)resources.GetObject("btnSiguiente.BackgroundImage");
            btnSiguiente.BackgroundImageLayout = ImageLayout.Center;
            btnSiguiente.Location = new Point(271, 600);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(36, 31);
            btnSiguiente.TabIndex = 35;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(912, 602);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 34;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(812, 602);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 33;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(712, 602);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 32;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(612, 602);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 31;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // bindingSourceProveedores
            // 
            bindingSourceProveedores.PositionChanged += bindingSourceProveedores_PositionChanged;
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
            groupBoxDatsoPRincipales.Controls.Add(textBoxNombre);
            groupBoxDatsoPRincipales.Controls.Add(textBoxCodigo);
            groupBoxDatsoPRincipales.Controls.Add(lblNombre);
            groupBoxDatsoPRincipales.Controls.Add(lblCodigo);
            groupBoxDatsoPRincipales.Location = new Point(24, 46);
            groupBoxDatsoPRincipales.Name = "groupBoxDatsoPRincipales";
            groupBoxDatsoPRincipales.Size = new Size(1000, 151);
            groupBoxDatsoPRincipales.TabIndex = 26;
            groupBoxDatsoPRincipales.TabStop = false;
            groupBoxDatsoPRincipales.Text = "Datos Principales";
            // 
            // btnNuevaLocalidad
            // 
            btnNuevaLocalidad.Location = new Point(390, 116);
            btnNuevaLocalidad.Name = "btnNuevaLocalidad";
            btnNuevaLocalidad.Size = new Size(32, 29);
            btnNuevaLocalidad.TabIndex = 26;
            btnNuevaLocalidad.Text = "...";
            btnNuevaLocalidad.UseVisualStyleBackColor = true;
            btnNuevaLocalidad.Click += btnNuevaLocalidad_Click;
            // 
            // textBoxProvincia
            // 
            textBoxProvincia.Location = new Point(813, 113);
            textBoxProvincia.Name = "textBoxProvincia";
            textBoxProvincia.ReadOnly = true;
            textBoxProvincia.Size = new Size(125, 27);
            textBoxProvincia.TabIndex = 25;
            // 
            // lblProvincia
            // 
            lblProvincia.AutoSize = true;
            lblProvincia.Location = new Point(725, 120);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(72, 20);
            lblProvincia.TabIndex = 24;
            lblProvincia.Text = "Provincia:";
            // 
            // textBoxCodigoPostal
            // 
            textBoxCodigoPostal.Location = new Point(566, 113);
            textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            textBoxCodigoPostal.ReadOnly = true;
            textBoxCodigoPostal.Size = new Size(125, 27);
            textBoxCodigoPostal.TabIndex = 23;
            // 
            // lblCodigoPostal
            // 
            lblCodigoPostal.AutoSize = true;
            lblCodigoPostal.Location = new Point(475, 120);
            lblCodigoPostal.Name = "lblCodigoPostal";
            lblCodigoPostal.Size = new Size(85, 20);
            lblCodigoPostal.TabIndex = 22;
            lblCodigoPostal.Text = "Cód. Postal:";
            // 
            // cmbLocalidades
            // 
            cmbLocalidades.FormattingEnabled = true;
            cmbLocalidades.Location = new Point(134, 117);
            cmbLocalidades.Name = "cmbLocalidades";
            cmbLocalidades.Size = new Size(250, 28);
            cmbLocalidades.TabIndex = 21;
            cmbLocalidades.SelectedIndexChanged += cmbLocalidades_SelectedIndexChanged;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(43, 120);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(77, 20);
            lblLocalidad.TabIndex = 20;
            lblLocalidad.Text = "Localidad:";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(38, 77);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(75, 20);
            lblDireccion.TabIndex = 19;
            lblDireccion.Text = "Dirección:";
            // 
            // textBoxDireccion
            // 
            textBoxDireccion.CharacterCasing = CharacterCasing.Upper;
            textBoxDireccion.Location = new Point(134, 74);
            textBoxDireccion.Name = "textBoxDireccion";
            textBoxDireccion.Size = new Size(377, 27);
            textBoxDireccion.TabIndex = 18;
            // 
            // textBoxNombre
            // 
            textBoxNombre.CharacterCasing = CharacterCasing.Upper;
            textBoxNombre.Location = new Point(362, 29);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(302, 27);
            textBoxNombre.TabIndex = 16;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.Location = new Point(134, 29);
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.ReadOnly = true;
            textBoxCodigo.Size = new Size(69, 27);
            textBoxCodigo.TabIndex = 15;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(289, 36);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 13;
            lblNombre.Text = "Nombre:";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(67, 36);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(61, 20);
            lblCodigo.TabIndex = 12;
            lblCodigo.Text = "Código:";
            // 
            // groupBoxContacto
            // 
            groupBoxContacto.Controls.Add(textBoxEmail);
            groupBoxContacto.Controls.Add(textBoxTelefono);
            groupBoxContacto.Controls.Add(lblEmail);
            groupBoxContacto.Controls.Add(lblTelefono);
            groupBoxContacto.Location = new Point(24, 198);
            groupBoxContacto.Name = "groupBoxContacto";
            groupBoxContacto.Size = new Size(1001, 93);
            groupBoxContacto.TabIndex = 27;
            groupBoxContacto.TabStop = false;
            groupBoxContacto.Text = "Contacto";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(500, 45);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(320, 27);
            textBoxEmail.TabIndex = 6;
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(119, 45);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.Size = new Size(250, 27);
            textBoxTelefono.TabIndex = 4;
            textBoxTelefono.KeyPress += textBoxTelefono_KeyPress;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(445, 52);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(43, 52);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(70, 20);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "Teléfono:";
            // 
            // groupBoxDatosFiscalesYCuenta
            // 
            groupBoxDatosFiscalesYCuenta.Controls.Add(textBoxIngresosBrutos);
            groupBoxDatosFiscalesYCuenta.Controls.Add(textBoxCUIT);
            groupBoxDatosFiscalesYCuenta.Controls.Add(btnVerificarCuit);
            groupBoxDatosFiscalesYCuenta.Controls.Add(lblCuit);
            groupBoxDatosFiscalesYCuenta.Controls.Add(lblIngBrutos);
            groupBoxDatosFiscalesYCuenta.Controls.Add(lblSitImpositiva);
            groupBoxDatosFiscalesYCuenta.Controls.Add(cmbSituacionImpositiva);
            groupBoxDatosFiscalesYCuenta.Location = new Point(24, 297);
            groupBoxDatosFiscalesYCuenta.Name = "groupBoxDatosFiscalesYCuenta";
            groupBoxDatosFiscalesYCuenta.Size = new Size(1002, 140);
            groupBoxDatosFiscalesYCuenta.TabIndex = 29;
            groupBoxDatosFiscalesYCuenta.TabStop = false;
            groupBoxDatosFiscalesYCuenta.Text = "Datos fiscales y cuenta";
            // 
            // ProveedoresForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 662);
            Controls.Add(groupBoxObservaciones);
            Controls.Add(lblPosicion);
            Controls.Add(btnUltimo);
            Controls.Add(btnPrimero);
            Controls.Add(btnAnterior);
            Controls.Add(btnSiguiente);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(groupBoxDatsoPRincipales);
            Controls.Add(groupBoxContacto);
            Controls.Add(groupBoxDatosFiscalesYCuenta);
            Name = "ProveedoresForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProveedoresForm";
            Load += ProveedoresForm_Load;
            KeyDown += ProveedoresForm_KeyDown;
            groupBoxObservaciones.ResumeLayout(false);
            groupBoxObservaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceLocalidades).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceSituacionesImpositivas).EndInit();
            groupBoxDatsoPRincipales.ResumeLayout(false);
            groupBoxDatsoPRincipales.PerformLayout();
            groupBoxContacto.ResumeLayout(false);
            groupBoxContacto.PerformLayout();
            groupBoxDatosFiscalesYCuenta.ResumeLayout(false);
            groupBoxDatosFiscalesYCuenta.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbEstadoCuenta;
        private TextBox textBoxMatricula;
        private TextBox textBoxOcupacion;
        private Label lblMatricula;
        private MaskedTextBox textBoxCUIT;
        private Button btnVerificarCuit;
        private Label lblEstadoCuenta;
        private Label lblCuit;
        private Label lblVendedor;
        private Label lblIngBrutos;
        private Label lblSitImpositiva;
        private ComboBox cmbVendedor;
        private ComboBox cmbSituacionImpositiva;
        private GroupBox groupBoxObservaciones;
        private Button btnImprimir;
        private Label lblObservaciones;
        private RichTextBox richTextBoxObservaciones;
        private TextBox textBoxIngresosBrutos;
        private Label lblPosicion;
        private Button btnUltimo;
        private Button btnPrimero;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnSalir;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnNuevo;
        private BindingSource bindingSourceProveedores;
        private BindingSource bindingSourceLocalidades;
        private BindingSource bindingSourceSituacionesImpositivas;
        private BindingSource bindingSourceVendedores;
        private Label lblOcupacion;
        private GroupBox groupBoxDatsoPRincipales;
        private Button btnNuevaLocalidad;
        private TextBox textBoxProvincia;
        private Label lblProvincia;
        private TextBox textBoxCodigoPostal;
        private Label lblCodigoPostal;
        private ComboBox cmbLocalidades;
        private Label lblLocalidad;
        private Label lblDireccion;
        private TextBox textBoxDireccion;
        private TextBox textBoxNombre;
        private TextBox textBoxCodigo;
        private Label lblNombre;
        private Label lblCodigo;
        private GroupBox groupBoxContacto;
        private TextBox textBoxEmail;
        private TextBox textBoxTelefono;
        private Label lblEmail;
        private Label lblTelefono;
        private GroupBox groupBoxDatosFiscalesYCuenta;
        private GroupBox groupBoxInfoAdicional;
        private BindingSource bindingSourceEstadosCuenta;
    }
}