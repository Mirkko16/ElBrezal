namespace ElBrezal.Desktop.Forms.Configs
{
    partial class ConfigForm
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
            tabControlConfig = new TabControl();
            tabPageFacturacion = new TabPage();
            btnConsultarUltimoComprobante = new Button();
            btnConsultarTiposComprobante = new Button();
            btnProbarEstadoArca = new Button();
            btnProbarConexionArca = new Button();
            textBoxCUITEmisorHomologacion = new TextBox();
            btnConsultarPuntosVenta = new Button();
            lblCUITEmisorHomologacion = new Label();
            numPuntoVenta = new NumericUpDown();
            lblPuntoVenta = new Label();
            lblAmbiente = new Label();
            lblRutaCert = new Label();
            cmbAmbienteArca = new ComboBox();
            btnExaminarCertificado = new Button();
            textBoxRutaCertificadoPfx = new TextBox();
            chkFacturacionNegativa = new CheckBox();
            chkFacturacionElectronica = new CheckBox();
            tabPageDatosNegocio = new TabPage();
            dtpInicioActividades = new DateTimePicker();
            lblInicioActividades = new Label();
            lblIngresosBrutos = new Label();
            textBoxIngresosBrutos = new TextBox();
            lblCondicion = new Label();
            cmbCondFrenteIVA = new ComboBox();
            lblDomicilio = new Label();
            textBoxDomicilioComercial = new TextBox();
            lblCuit = new Label();
            textBoxCUIT = new TextBox();
            lblNombreFantasia = new Label();
            textBoxNombreFantasia = new TextBox();
            lblRazonSocial = new Label();
            textBoxRazonSocial = new TextBox();
            tabPageSistemaImpresion = new TabPage();
            gpRespaldos = new GroupBox();
            btnRealizarBackup = new Button();
            dtpHoraBackup = new DateTimePicker();
            lblHoraBackup = new Label();
            cmbFrecuenciaBackup = new ComboBox();
            lblFrecuenciaBackup = new Label();
            chkBackupAutomatico = new CheckBox();
            lblModoImpresion = new Label();
            comboBox1 = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            numTipoComprobanteArca = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            lblTipoComprobanteArca = new Label();
            tabControlConfig.SuspendLayout();
            tabPageFacturacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPuntoVenta).BeginInit();
            tabPageDatosNegocio.SuspendLayout();
            tabPageSistemaImpresion.SuspendLayout();
            gpRespaldos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTipoComprobanteArca).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // tabControlConfig
            // 
            tabControlConfig.Controls.Add(tabPageFacturacion);
            tabControlConfig.Controls.Add(tabPageDatosNegocio);
            tabControlConfig.Controls.Add(tabPageSistemaImpresion);
            tabControlConfig.Location = new Point(14, 16);
            tabControlConfig.Margin = new Padding(3, 4, 3, 4);
            tabControlConfig.Name = "tabControlConfig";
            tabControlConfig.SelectedIndex = 0;
            tabControlConfig.Size = new Size(920, 637);
            tabControlConfig.TabIndex = 0;
            // 
            // tabPageFacturacion
            // 
            tabPageFacturacion.Controls.Add(btnConsultarUltimoComprobante);
            tabPageFacturacion.Controls.Add(btnConsultarTiposComprobante);
            tabPageFacturacion.Controls.Add(btnProbarEstadoArca);
            tabPageFacturacion.Controls.Add(btnProbarConexionArca);
            tabPageFacturacion.Controls.Add(textBoxCUITEmisorHomologacion);
            tabPageFacturacion.Controls.Add(btnConsultarPuntosVenta);
            tabPageFacturacion.Controls.Add(lblTipoComprobanteArca);
            tabPageFacturacion.Controls.Add(lblCUITEmisorHomologacion);
            tabPageFacturacion.Controls.Add(numericUpDown1);
            tabPageFacturacion.Controls.Add(numTipoComprobanteArca);
            tabPageFacturacion.Controls.Add(numPuntoVenta);
            tabPageFacturacion.Controls.Add(lblPuntoVenta);
            tabPageFacturacion.Controls.Add(lblAmbiente);
            tabPageFacturacion.Controls.Add(lblRutaCert);
            tabPageFacturacion.Controls.Add(cmbAmbienteArca);
            tabPageFacturacion.Controls.Add(btnExaminarCertificado);
            tabPageFacturacion.Controls.Add(textBoxRutaCertificadoPfx);
            tabPageFacturacion.Controls.Add(chkFacturacionNegativa);
            tabPageFacturacion.Controls.Add(chkFacturacionElectronica);
            tabPageFacturacion.Location = new Point(4, 29);
            tabPageFacturacion.Margin = new Padding(3, 4, 3, 4);
            tabPageFacturacion.Name = "tabPageFacturacion";
            tabPageFacturacion.Padding = new Padding(3, 4, 3, 4);
            tabPageFacturacion.Size = new Size(912, 604);
            tabPageFacturacion.TabIndex = 0;
            tabPageFacturacion.Text = "Facturacion";
            tabPageFacturacion.UseVisualStyleBackColor = true;
            // 
            // btnConsultarUltimoComprobante
            // 
            btnConsultarUltimoComprobante.Location = new Point(365, 447);
            btnConsultarUltimoComprobante.Name = "btnConsultarUltimoComprobante";
            btnConsultarUltimoComprobante.Size = new Size(312, 29);
            btnConsultarUltimoComprobante.TabIndex = 18;
            btnConsultarUltimoComprobante.Text = "Consultar Ultimo Comprobante";
            btnConsultarUltimoComprobante.UseVisualStyleBackColor = true;
            btnConsultarUltimoComprobante.Click += btnConsultarUltimoComprobante_Click;
            // 
            // btnConsultarTiposComprobante
            // 
            btnConsultarTiposComprobante.Location = new Point(32, 447);
            btnConsultarTiposComprobante.Name = "btnConsultarTiposComprobante";
            btnConsultarTiposComprobante.Size = new Size(256, 29);
            btnConsultarTiposComprobante.TabIndex = 17;
            btnConsultarTiposComprobante.Text = "Consultar Tipos Comprobante";
            btnConsultarTiposComprobante.UseVisualStyleBackColor = true;
            btnConsultarTiposComprobante.Click += btnConsultarTiposComprobante_Click;
            // 
            // btnProbarEstadoArca
            // 
            btnProbarEstadoArca.Location = new Point(612, 345);
            btnProbarEstadoArca.Margin = new Padding(3, 4, 3, 4);
            btnProbarEstadoArca.Name = "btnProbarEstadoArca";
            btnProbarEstadoArca.Size = new Size(157, 31);
            btnProbarEstadoArca.TabIndex = 16;
            btnProbarEstadoArca.Text = "Probar Estado Arca";
            btnProbarEstadoArca.UseVisualStyleBackColor = true;
            btnProbarEstadoArca.Click += btnProbarEstadoArca_Click;
            // 
            // btnProbarConexionArca
            // 
            btnProbarConexionArca.Location = new Point(412, 345);
            btnProbarConexionArca.Margin = new Padding(3, 4, 3, 4);
            btnProbarConexionArca.Name = "btnProbarConexionArca";
            btnProbarConexionArca.Size = new Size(157, 31);
            btnProbarConexionArca.TabIndex = 15;
            btnProbarConexionArca.Text = "Probar Conexion";
            btnProbarConexionArca.UseVisualStyleBackColor = true;
            btnProbarConexionArca.Click += btnProbarConexionArca_Click;
            // 
            // textBoxCUITEmisorHomologacion
            // 
            textBoxCUITEmisorHomologacion.Location = new Point(255, 282);
            textBoxCUITEmisorHomologacion.Margin = new Padding(3, 4, 3, 4);
            textBoxCUITEmisorHomologacion.Name = "textBoxCUITEmisorHomologacion";
            textBoxCUITEmisorHomologacion.Size = new Size(202, 27);
            textBoxCUITEmisorHomologacion.TabIndex = 12;
            // 
            // btnConsultarPuntosVenta
            // 
            btnConsultarPuntosVenta.Location = new Point(168, 345);
            btnConsultarPuntosVenta.Margin = new Padding(3, 4, 3, 4);
            btnConsultarPuntosVenta.Name = "btnConsultarPuntosVenta";
            btnConsultarPuntosVenta.Size = new Size(182, 31);
            btnConsultarPuntosVenta.TabIndex = 11;
            btnConsultarPuntosVenta.Text = "Consultar Puntos Venta";
            btnConsultarPuntosVenta.UseVisualStyleBackColor = true;
            btnConsultarPuntosVenta.Click += btnConsultarPuntosVenta_Click;
            // 
            // lblCUITEmisorHomologacion
            // 
            lblCUITEmisorHomologacion.AutoSize = true;
            lblCUITEmisorHomologacion.Location = new Point(52, 293);
            lblCUITEmisorHomologacion.Name = "lblCUITEmisorHomologacion";
            lblCUITEmisorHomologacion.Size = new Size(185, 20);
            lblCUITEmisorHomologacion.TabIndex = 10;
            lblCUITEmisorHomologacion.Text = "CUITEmisorHomologacion";
            // 
            // numPuntoVenta
            // 
            numPuntoVenta.Location = new Point(183, 215);
            numPuntoVenta.Margin = new Padding(3, 4, 3, 4);
            numPuntoVenta.Name = "numPuntoVenta";
            numPuntoVenta.Size = new Size(45, 27);
            numPuntoVenta.TabIndex = 9;
            // 
            // lblPuntoVenta
            // 
            lblPuntoVenta.AutoSize = true;
            lblPuntoVenta.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPuntoVenta.Location = new Point(32, 223);
            lblPuntoVenta.Name = "lblPuntoVenta";
            lblPuntoVenta.Size = new Size(133, 23);
            lblPuntoVenta.TabIndex = 8;
            lblPuntoVenta.Text = "Punto de Venta:";
            // 
            // lblAmbiente
            // 
            lblAmbiente.AutoSize = true;
            lblAmbiente.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblAmbiente.Location = new Point(32, 91);
            lblAmbiente.Name = "lblAmbiente";
            lblAmbiente.Size = new Size(88, 23);
            lblAmbiente.TabIndex = 7;
            lblAmbiente.Text = "Ambiente:";
            // 
            // lblRutaCert
            // 
            lblRutaCert.AutoSize = true;
            lblRutaCert.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblRutaCert.Location = new Point(32, 155);
            lblRutaCert.Name = "lblRutaCert";
            lblRutaCert.Size = new Size(168, 23);
            lblRutaCert.TabIndex = 6;
            lblRutaCert.Text = "Ruta Certificado Pfx:";
            // 
            // cmbAmbienteArca
            // 
            cmbAmbienteArca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAmbienteArca.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            cmbAmbienteArca.FormattingEnabled = true;
            cmbAmbienteArca.Location = new Point(183, 80);
            cmbAmbienteArca.Margin = new Padding(3, 4, 3, 4);
            cmbAmbienteArca.Name = "cmbAmbienteArca";
            cmbAmbienteArca.Size = new Size(238, 29);
            cmbAmbienteArca.TabIndex = 4;
            // 
            // btnExaminarCertificado
            // 
            btnExaminarCertificado.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnExaminarCertificado.Location = new Point(707, 147);
            btnExaminarCertificado.Margin = new Padding(3, 4, 3, 4);
            btnExaminarCertificado.Name = "btnExaminarCertificado";
            btnExaminarCertificado.Size = new Size(31, 31);
            btnExaminarCertificado.TabIndex = 3;
            btnExaminarCertificado.Text = "...";
            btnExaminarCertificado.UseVisualStyleBackColor = true;
            btnExaminarCertificado.Click += btnExaminarCertificado_Click;
            // 
            // textBoxRutaCertificadoPfx
            // 
            textBoxRutaCertificadoPfx.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBoxRutaCertificadoPfx.Location = new Point(206, 144);
            textBoxRutaCertificadoPfx.Margin = new Padding(3, 4, 3, 4);
            textBoxRutaCertificadoPfx.Name = "textBoxRutaCertificadoPfx";
            textBoxRutaCertificadoPfx.ReadOnly = true;
            textBoxRutaCertificadoPfx.Size = new Size(494, 29);
            textBoxRutaCertificadoPfx.TabIndex = 2;
            // 
            // chkFacturacionNegativa
            // 
            chkFacturacionNegativa.AutoSize = true;
            chkFacturacionNegativa.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            chkFacturacionNegativa.Location = new Point(245, 23);
            chkFacturacionNegativa.Margin = new Padding(3, 4, 3, 4);
            chkFacturacionNegativa.Name = "chkFacturacionNegativa";
            chkFacturacionNegativa.Size = new Size(194, 27);
            chkFacturacionNegativa.TabIndex = 1;
            chkFacturacionNegativa.Text = "Facturación Negativa";
            chkFacturacionNegativa.UseVisualStyleBackColor = true;
            // 
            // chkFacturacionElectronica
            // 
            chkFacturacionElectronica.AutoSize = true;
            chkFacturacionElectronica.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            chkFacturacionElectronica.Location = new Point(29, 23);
            chkFacturacionElectronica.Margin = new Padding(3, 4, 3, 4);
            chkFacturacionElectronica.Name = "chkFacturacionElectronica";
            chkFacturacionElectronica.Size = new Size(208, 27);
            chkFacturacionElectronica.TabIndex = 0;
            chkFacturacionElectronica.Text = "Facturación Electrónica";
            chkFacturacionElectronica.UseVisualStyleBackColor = true;
            chkFacturacionElectronica.CheckedChanged += chkFacturacionElectronica_CheckedChanged;
            // 
            // tabPageDatosNegocio
            // 
            tabPageDatosNegocio.Controls.Add(dtpInicioActividades);
            tabPageDatosNegocio.Controls.Add(lblInicioActividades);
            tabPageDatosNegocio.Controls.Add(lblIngresosBrutos);
            tabPageDatosNegocio.Controls.Add(textBoxIngresosBrutos);
            tabPageDatosNegocio.Controls.Add(lblCondicion);
            tabPageDatosNegocio.Controls.Add(cmbCondFrenteIVA);
            tabPageDatosNegocio.Controls.Add(lblDomicilio);
            tabPageDatosNegocio.Controls.Add(textBoxDomicilioComercial);
            tabPageDatosNegocio.Controls.Add(lblCuit);
            tabPageDatosNegocio.Controls.Add(textBoxCUIT);
            tabPageDatosNegocio.Controls.Add(lblNombreFantasia);
            tabPageDatosNegocio.Controls.Add(textBoxNombreFantasia);
            tabPageDatosNegocio.Controls.Add(lblRazonSocial);
            tabPageDatosNegocio.Controls.Add(textBoxRazonSocial);
            tabPageDatosNegocio.Location = new Point(4, 29);
            tabPageDatosNegocio.Margin = new Padding(3, 4, 3, 4);
            tabPageDatosNegocio.Name = "tabPageDatosNegocio";
            tabPageDatosNegocio.Padding = new Padding(3, 4, 3, 4);
            tabPageDatosNegocio.Size = new Size(912, 604);
            tabPageDatosNegocio.TabIndex = 1;
            tabPageDatosNegocio.Text = "Datos Negocio";
            tabPageDatosNegocio.UseVisualStyleBackColor = true;
            // 
            // dtpInicioActividades
            // 
            dtpInicioActividades.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dtpInicioActividades.Format = DateTimePickerFormat.Custom;
            dtpInicioActividades.Location = new Point(187, 225);
            dtpInicioActividades.Margin = new Padding(3, 4, 3, 4);
            dtpInicioActividades.Name = "dtpInicioActividades";
            dtpInicioActividades.Size = new Size(127, 29);
            dtpInicioActividades.TabIndex = 13;
            dtpInicioActividades.Value = new DateTime(2016, 9, 1, 0, 0, 0, 0);
            // 
            // lblInicioActividades
            // 
            lblInicioActividades.AutoSize = true;
            lblInicioActividades.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblInicioActividades.Location = new Point(17, 233);
            lblInicioActividades.Name = "lblInicioActividades";
            lblInicioActividades.Size = new Size(167, 23);
            lblInicioActividades.TabIndex = 12;
            lblInicioActividades.Text = "Inicio de Actividades";
            // 
            // lblIngresosBrutos
            // 
            lblIngresosBrutos.AutoSize = true;
            lblIngresosBrutos.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblIngresosBrutos.Location = new Point(498, 159);
            lblIngresosBrutos.Name = "lblIngresosBrutos";
            lblIngresosBrutos.Size = new Size(97, 23);
            lblIngresosBrutos.TabIndex = 11;
            lblIngresosBrutos.Text = "Ing. Brutos:";
            // 
            // textBoxIngresosBrutos
            // 
            textBoxIngresosBrutos.CharacterCasing = CharacterCasing.Upper;
            textBoxIngresosBrutos.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBoxIngresosBrutos.Location = new Point(594, 148);
            textBoxIngresosBrutos.Margin = new Padding(3, 4, 3, 4);
            textBoxIngresosBrutos.Name = "textBoxIngresosBrutos";
            textBoxIngresosBrutos.Size = new Size(153, 29);
            textBoxIngresosBrutos.TabIndex = 10;
            // 
            // lblCondicion
            // 
            lblCondicion.AutoSize = true;
            lblCondicion.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblCondicion.Location = new Point(521, 103);
            lblCondicion.Name = "lblCondicion";
            lblCondicion.Size = new Size(90, 23);
            lblCondicion.TabIndex = 9;
            lblCondicion.Text = "Cond. IVA:";
            // 
            // cmbCondFrenteIVA
            // 
            cmbCondFrenteIVA.FormattingEnabled = true;
            cmbCondFrenteIVA.Location = new Point(609, 95);
            cmbCondFrenteIVA.Margin = new Padding(3, 4, 3, 4);
            cmbCondFrenteIVA.Name = "cmbCondFrenteIVA";
            cmbCondFrenteIVA.Size = new Size(138, 28);
            cmbCondFrenteIVA.TabIndex = 8;
            // 
            // lblDomicilio
            // 
            lblDomicilio.AutoSize = true;
            lblDomicilio.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblDomicilio.Location = new Point(17, 159);
            lblDomicilio.Name = "lblDomicilio";
            lblDomicilio.Size = new Size(85, 23);
            lblDomicilio.TabIndex = 7;
            lblDomicilio.Text = "Domicilio:";
            // 
            // textBoxDomicilioComercial
            // 
            textBoxDomicilioComercial.CharacterCasing = CharacterCasing.Upper;
            textBoxDomicilioComercial.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBoxDomicilioComercial.Location = new Point(161, 148);
            textBoxDomicilioComercial.Margin = new Padding(3, 4, 3, 4);
            textBoxDomicilioComercial.Name = "textBoxDomicilioComercial";
            textBoxDomicilioComercial.Size = new Size(225, 29);
            textBoxDomicilioComercial.TabIndex = 6;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblCuit.Location = new Point(547, 32);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(51, 23);
            lblCuit.TabIndex = 5;
            lblCuit.Text = "CUIT:";
            // 
            // textBoxCUIT
            // 
            textBoxCUIT.Location = new Point(609, 21);
            textBoxCUIT.Margin = new Padding(3, 4, 3, 4);
            textBoxCUIT.Name = "textBoxCUIT";
            textBoxCUIT.Size = new Size(138, 27);
            textBoxCUIT.TabIndex = 4;
            // 
            // lblNombreFantasia
            // 
            lblNombreFantasia.AutoSize = true;
            lblNombreFantasia.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblNombreFantasia.Location = new Point(17, 103);
            lblNombreFantasia.Name = "lblNombreFantasia";
            lblNombreFantasia.Size = new Size(146, 23);
            lblNombreFantasia.TabIndex = 3;
            lblNombreFantasia.Text = "Nombre Negocio:";
            // 
            // textBoxNombreFantasia
            // 
            textBoxNombreFantasia.CharacterCasing = CharacterCasing.Upper;
            textBoxNombreFantasia.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBoxNombreFantasia.Location = new Point(161, 92);
            textBoxNombreFantasia.Margin = new Padding(3, 4, 3, 4);
            textBoxNombreFantasia.Name = "textBoxNombreFantasia";
            textBoxNombreFantasia.Size = new Size(330, 29);
            textBoxNombreFantasia.TabIndex = 2;
            // 
            // lblRazonSocial
            // 
            lblRazonSocial.AutoSize = true;
            lblRazonSocial.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblRazonSocial.Location = new Point(17, 32);
            lblRazonSocial.Name = "lblRazonSocial";
            lblRazonSocial.Size = new Size(111, 23);
            lblRazonSocial.TabIndex = 1;
            lblRazonSocial.Text = "Razon Social:";
            // 
            // textBoxRazonSocial
            // 
            textBoxRazonSocial.CharacterCasing = CharacterCasing.Upper;
            textBoxRazonSocial.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBoxRazonSocial.Location = new Point(161, 21);
            textBoxRazonSocial.Margin = new Padding(3, 4, 3, 4);
            textBoxRazonSocial.Name = "textBoxRazonSocial";
            textBoxRazonSocial.Size = new Size(330, 29);
            textBoxRazonSocial.TabIndex = 0;
            // 
            // tabPageSistemaImpresion
            // 
            tabPageSistemaImpresion.Controls.Add(gpRespaldos);
            tabPageSistemaImpresion.Controls.Add(lblModoImpresion);
            tabPageSistemaImpresion.Controls.Add(comboBox1);
            tabPageSistemaImpresion.Location = new Point(4, 29);
            tabPageSistemaImpresion.Margin = new Padding(3, 4, 3, 4);
            tabPageSistemaImpresion.Name = "tabPageSistemaImpresion";
            tabPageSistemaImpresion.Size = new Size(912, 604);
            tabPageSistemaImpresion.TabIndex = 2;
            tabPageSistemaImpresion.Text = "Sistema";
            tabPageSistemaImpresion.UseVisualStyleBackColor = true;
            // 
            // gpRespaldos
            // 
            gpRespaldos.Controls.Add(btnRealizarBackup);
            gpRespaldos.Controls.Add(dtpHoraBackup);
            gpRespaldos.Controls.Add(lblHoraBackup);
            gpRespaldos.Controls.Add(cmbFrecuenciaBackup);
            gpRespaldos.Controls.Add(lblFrecuenciaBackup);
            gpRespaldos.Controls.Add(chkBackupAutomatico);
            gpRespaldos.Location = new Point(24, 67);
            gpRespaldos.Margin = new Padding(3, 4, 3, 4);
            gpRespaldos.Name = "gpRespaldos";
            gpRespaldos.Padding = new Padding(3, 4, 3, 4);
            gpRespaldos.Size = new Size(711, 232);
            gpRespaldos.TabIndex = 2;
            gpRespaldos.TabStop = false;
            // 
            // btnRealizarBackup
            // 
            btnRealizarBackup.Location = new Point(351, 164);
            btnRealizarBackup.Margin = new Padding(3, 4, 3, 4);
            btnRealizarBackup.Name = "btnRealizarBackup";
            btnRealizarBackup.Size = new Size(130, 31);
            btnRealizarBackup.TabIndex = 5;
            btnRealizarBackup.Text = "Realizar Backup";
            btnRealizarBackup.UseVisualStyleBackColor = true;
            // 
            // dtpHoraBackup
            // 
            dtpHoraBackup.Format = DateTimePickerFormat.Time;
            dtpHoraBackup.Location = new Point(142, 112);
            dtpHoraBackup.Margin = new Padding(3, 4, 3, 4);
            dtpHoraBackup.Name = "dtpHoraBackup";
            dtpHoraBackup.Size = new Size(94, 27);
            dtpHoraBackup.TabIndex = 4;
            // 
            // lblHoraBackup
            // 
            lblHoraBackup.AutoSize = true;
            lblHoraBackup.Location = new Point(46, 123);
            lblHoraBackup.Name = "lblHoraBackup";
            lblHoraBackup.Size = new Size(97, 20);
            lblHoraBackup.TabIndex = 3;
            lblHoraBackup.Text = "Hora Backup:";
            // 
            // cmbFrecuenciaBackup
            // 
            cmbFrecuenciaBackup.FormattingEnabled = true;
            cmbFrecuenciaBackup.Location = new Point(526, 41);
            cmbFrecuenciaBackup.Margin = new Padding(3, 4, 3, 4);
            cmbFrecuenciaBackup.Name = "cmbFrecuenciaBackup";
            cmbFrecuenciaBackup.Size = new Size(138, 28);
            cmbFrecuenciaBackup.TabIndex = 2;
            // 
            // lblFrecuenciaBackup
            // 
            lblFrecuenciaBackup.AutoSize = true;
            lblFrecuenciaBackup.Location = new Point(378, 52);
            lblFrecuenciaBackup.Name = "lblFrecuenciaBackup";
            lblFrecuenciaBackup.Size = new Size(134, 20);
            lblFrecuenciaBackup.TabIndex = 1;
            lblFrecuenciaBackup.Text = "Frecuencia Backup:";
            // 
            // chkBackupAutomatico
            // 
            chkBackupAutomatico.AutoSize = true;
            chkBackupAutomatico.Location = new Point(37, 52);
            chkBackupAutomatico.Margin = new Padding(3, 4, 3, 4);
            chkBackupAutomatico.Name = "chkBackupAutomatico";
            chkBackupAutomatico.Size = new Size(161, 24);
            chkBackupAutomatico.TabIndex = 0;
            chkBackupAutomatico.Text = "Backup Automático";
            chkBackupAutomatico.UseVisualStyleBackColor = true;
            // 
            // lblModoImpresion
            // 
            lblModoImpresion.AutoSize = true;
            lblModoImpresion.Location = new Point(24, 39);
            lblModoImpresion.Name = "lblModoImpresion";
            lblModoImpresion.Size = new Size(122, 20);
            lblModoImpresion.TabIndex = 1;
            lblModoImpresion.Text = "Modo Impresión:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(147, 28);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 28);
            comboBox1.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(227, 661);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(86, 31);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(383, 661);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 31);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // numTipoComprobanteArca
            // 
            numTipoComprobanteArca.Location = new Point(693, 518);
            numTipoComprobanteArca.Margin = new Padding(3, 4, 3, 4);
            numTipoComprobanteArca.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numTipoComprobanteArca.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTipoComprobanteArca.Name = "numTipoComprobanteArca";
            numTipoComprobanteArca.Size = new Size(45, 27);
            numTipoComprobanteArca.TabIndex = 9;
            numTipoComprobanteArca.Value = new decimal(new int[] { 11, 0, 0, 0 });
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(1223, 681);
            numericUpDown1.Margin = new Padding(3, 4, 3, 4);
            numericUpDown1.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(45, 27);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.Value = new decimal(new int[] { 11, 0, 0, 0 });
            // 
            // lblTipoComprobanteArca
            // 
            lblTipoComprobanteArca.AutoSize = true;
            lblTipoComprobanteArca.Location = new Point(551, 525);
            lblTipoComprobanteArca.Name = "lblTipoComprobanteArca";
            lblTipoComprobanteArca.Size = new Size(136, 20);
            lblTipoComprobanteArca.TabIndex = 10;
            lblTipoComprobanteArca.Text = "Tipo comprobante:";
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 720);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(tabControlConfig);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ConfigForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración general - ElBrezal";
            Load += ConfigForm_Load;
            tabControlConfig.ResumeLayout(false);
            tabPageFacturacion.ResumeLayout(false);
            tabPageFacturacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPuntoVenta).EndInit();
            tabPageDatosNegocio.ResumeLayout(false);
            tabPageDatosNegocio.PerformLayout();
            tabPageSistemaImpresion.ResumeLayout(false);
            tabPageSistemaImpresion.PerformLayout();
            gpRespaldos.ResumeLayout(false);
            gpRespaldos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTipoComprobanteArca).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlConfig;
        private TabPage tabPageFacturacion;
        private TabPage tabPageDatosNegocio;
        private TabPage tabPageSistemaImpresion;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnExaminarCertificado;
        private TextBox textBoxRutaCertificadoPfx;
        private CheckBox chkFacturacionNegativa;
        private CheckBox chkFacturacionElectronica;
        private ComboBox cmbAmbienteArca;
        private Label lblRutaCert;
        private Label lblAmbiente;
        private Label lblPuntoVenta;
        private Label lblNombreFantasia;
        private TextBox textBoxNombreFantasia;
        private Label lblRazonSocial;
        private TextBox textBoxRazonSocial;
        private Label lblIngresosBrutos;
        private TextBox textBoxIngresosBrutos;
        private Label lblCondicion;
        private ComboBox cmbCondFrenteIVA;
        private Label lblDomicilio;
        private TextBox textBoxDomicilioComercial;
        private Label lblCuit;
        private TextBox textBoxCUIT;
        private DateTimePicker dtpInicioActividades;
        private Label lblInicioActividades;
        private GroupBox gpRespaldos;
        private Label lblModoImpresion;
        private ComboBox comboBox1;
        private CheckBox chkBackupAutomatico;
        private Button btnRealizarBackup;
        private DateTimePicker dtpHoraBackup;
        private Label lblHoraBackup;
        private ComboBox cmbFrecuenciaBackup;
        private Label lblFrecuenciaBackup;
        private NumericUpDown numPuntoVenta;
        private TextBox textBoxCUITEmisorHomologacion;
        private Button btnConsultarPuntosVenta;
        private Label lblCUITEmisorHomologacion;
        private Button btnProbarEstadoArca;
        private Button btnProbarConexionArca;
        private Button btnConsultarTiposComprobante;
        private Button btnConsultarUltimoComprobante;
        private Label lblTipoComprobanteArca;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numTipoComprobanteArca;
    }
}