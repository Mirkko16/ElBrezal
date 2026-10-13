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
            tabControlConfig.SuspendLayout();
            tabPageFacturacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPuntoVenta).BeginInit();
            tabPageDatosNegocio.SuspendLayout();
            tabPageSistemaImpresion.SuspendLayout();
            gpRespaldos.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlConfig
            // 
            tabControlConfig.Controls.Add(tabPageFacturacion);
            tabControlConfig.Controls.Add(tabPageDatosNegocio);
            tabControlConfig.Controls.Add(tabPageSistemaImpresion);
            tabControlConfig.Location = new Point(12, 12);
            tabControlConfig.Name = "tabControlConfig";
            tabControlConfig.SelectedIndex = 0;
            tabControlConfig.Size = new Size(681, 267);
            tabControlConfig.TabIndex = 0;
            // 
            // tabPageFacturacion
            // 
            tabPageFacturacion.Controls.Add(numPuntoVenta);
            tabPageFacturacion.Controls.Add(lblPuntoVenta);
            tabPageFacturacion.Controls.Add(lblAmbiente);
            tabPageFacturacion.Controls.Add(lblRutaCert);
            tabPageFacturacion.Controls.Add(cmbAmbienteArca);
            tabPageFacturacion.Controls.Add(btnExaminarCertificado);
            tabPageFacturacion.Controls.Add(textBoxRutaCertificadoPfx);
            tabPageFacturacion.Controls.Add(chkFacturacionNegativa);
            tabPageFacturacion.Controls.Add(chkFacturacionElectronica);
            tabPageFacturacion.Location = new Point(4, 24);
            tabPageFacturacion.Name = "tabPageFacturacion";
            tabPageFacturacion.Padding = new Padding(3);
            tabPageFacturacion.Size = new Size(673, 239);
            tabPageFacturacion.TabIndex = 0;
            tabPageFacturacion.Text = "Facturacion";
            tabPageFacturacion.UseVisualStyleBackColor = true;
            // 
            // numPuntoVenta
            // 
            numPuntoVenta.Location = new Point(160, 161);
            numPuntoVenta.Name = "numPuntoVenta";
            numPuntoVenta.Size = new Size(39, 23);
            numPuntoVenta.TabIndex = 9;
            // 
            // lblPuntoVenta
            // 
            lblPuntoVenta.AutoSize = true;
            lblPuntoVenta.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblPuntoVenta.Location = new Point(28, 167);
            lblPuntoVenta.Name = "lblPuntoVenta";
            lblPuntoVenta.Size = new Size(105, 17);
            lblPuntoVenta.TabIndex = 8;
            lblPuntoVenta.Text = "Punto de Venta:";
            // 
            // lblAmbiente
            // 
            lblAmbiente.AutoSize = true;
            lblAmbiente.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblAmbiente.Location = new Point(28, 68);
            lblAmbiente.Name = "lblAmbiente";
            lblAmbiente.Size = new Size(70, 17);
            lblAmbiente.TabIndex = 7;
            lblAmbiente.Text = "Ambiente:";
            // 
            // lblRutaCert
            // 
            lblRutaCert.AutoSize = true;
            lblRutaCert.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblRutaCert.Location = new Point(28, 116);
            lblRutaCert.Name = "lblRutaCert";
            lblRutaCert.Size = new Size(130, 17);
            lblRutaCert.TabIndex = 6;
            lblRutaCert.Text = "Ruta Certificado Pfx:";
            // 
            // cmbAmbienteArca
            // 
            cmbAmbienteArca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAmbienteArca.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            cmbAmbienteArca.FormattingEnabled = true;
            cmbAmbienteArca.Location = new Point(160, 60);
            cmbAmbienteArca.Name = "cmbAmbienteArca";
            cmbAmbienteArca.Size = new Size(209, 25);
            cmbAmbienteArca.TabIndex = 4;
            // 
            // btnExaminarCertificado
            // 
            btnExaminarCertificado.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnExaminarCertificado.Location = new Point(619, 110);
            btnExaminarCertificado.Name = "btnExaminarCertificado";
            btnExaminarCertificado.Size = new Size(27, 23);
            btnExaminarCertificado.TabIndex = 3;
            btnExaminarCertificado.Text = "...";
            btnExaminarCertificado.UseVisualStyleBackColor = true;
            btnExaminarCertificado.Click += btnExaminarCertificado_Click;
            // 
            // textBoxRutaCertificadoPfx
            // 
            textBoxRutaCertificadoPfx.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBoxRutaCertificadoPfx.Location = new Point(160, 108);
            textBoxRutaCertificadoPfx.Name = "textBoxRutaCertificadoPfx";
            textBoxRutaCertificadoPfx.ReadOnly = true;
            textBoxRutaCertificadoPfx.Size = new Size(453, 25);
            textBoxRutaCertificadoPfx.TabIndex = 2;
            // 
            // chkFacturacionNegativa
            // 
            chkFacturacionNegativa.AutoSize = true;
            chkFacturacionNegativa.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            chkFacturacionNegativa.Location = new Point(214, 17);
            chkFacturacionNegativa.Name = "chkFacturacionNegativa";
            chkFacturacionNegativa.Size = new Size(155, 21);
            chkFacturacionNegativa.TabIndex = 1;
            chkFacturacionNegativa.Text = "Facturación Negativa";
            chkFacturacionNegativa.UseVisualStyleBackColor = true;
            // 
            // chkFacturacionElectronica
            // 
            chkFacturacionElectronica.AutoSize = true;
            chkFacturacionElectronica.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            chkFacturacionElectronica.Location = new Point(25, 17);
            chkFacturacionElectronica.Name = "chkFacturacionElectronica";
            chkFacturacionElectronica.Size = new Size(166, 21);
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
            tabPageDatosNegocio.Location = new Point(4, 24);
            tabPageDatosNegocio.Name = "tabPageDatosNegocio";
            tabPageDatosNegocio.Padding = new Padding(3);
            tabPageDatosNegocio.Size = new Size(673, 239);
            tabPageDatosNegocio.TabIndex = 1;
            tabPageDatosNegocio.Text = "Datos Negocio";
            tabPageDatosNegocio.UseVisualStyleBackColor = true;
            // 
            // dtpInicioActividades
            // 
            dtpInicioActividades.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dtpInicioActividades.Format = DateTimePickerFormat.Custom;
            dtpInicioActividades.Location = new Point(164, 169);
            dtpInicioActividades.Name = "dtpInicioActividades";
            dtpInicioActividades.Size = new Size(112, 25);
            dtpInicioActividades.TabIndex = 13;
            dtpInicioActividades.Value = new DateTime(2016, 9, 1, 0, 0, 0, 0);
            // 
            // lblInicioActividades
            // 
            lblInicioActividades.AutoSize = true;
            lblInicioActividades.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblInicioActividades.Location = new Point(15, 175);
            lblInicioActividades.Name = "lblInicioActividades";
            lblInicioActividades.Size = new Size(132, 17);
            lblInicioActividades.TabIndex = 12;
            lblInicioActividades.Text = "Inicio de Actividades";
            // 
            // lblIngresosBrutos
            // 
            lblIngresosBrutos.AutoSize = true;
            lblIngresosBrutos.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblIngresosBrutos.Location = new Point(436, 119);
            lblIngresosBrutos.Name = "lblIngresosBrutos";
            lblIngresosBrutos.Size = new Size(78, 17);
            lblIngresosBrutos.TabIndex = 11;
            lblIngresosBrutos.Text = "Ing. Brutos:";
            // 
            // textBoxIngresosBrutos
            // 
            textBoxIngresosBrutos.CharacterCasing = CharacterCasing.Upper;
            textBoxIngresosBrutos.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBoxIngresosBrutos.Location = new Point(520, 111);
            textBoxIngresosBrutos.Name = "textBoxIngresosBrutos";
            textBoxIngresosBrutos.Size = new Size(134, 25);
            textBoxIngresosBrutos.TabIndex = 10;
            // 
            // lblCondicion
            // 
            lblCondicion.AutoSize = true;
            lblCondicion.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblCondicion.Location = new Point(456, 77);
            lblCondicion.Name = "lblCondicion";
            lblCondicion.Size = new Size(70, 17);
            lblCondicion.TabIndex = 9;
            lblCondicion.Text = "Cond. IVA:";
            // 
            // cmbCondFrenteIVA
            // 
            cmbCondFrenteIVA.FormattingEnabled = true;
            cmbCondFrenteIVA.Location = new Point(533, 71);
            cmbCondFrenteIVA.Name = "cmbCondFrenteIVA";
            cmbCondFrenteIVA.Size = new Size(121, 23);
            cmbCondFrenteIVA.TabIndex = 8;
            // 
            // lblDomicilio
            // 
            lblDomicilio.AutoSize = true;
            lblDomicilio.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblDomicilio.Location = new Point(15, 119);
            lblDomicilio.Name = "lblDomicilio";
            lblDomicilio.Size = new Size(66, 17);
            lblDomicilio.TabIndex = 7;
            lblDomicilio.Text = "Domicilio:";
            // 
            // textBoxDomicilioComercial
            // 
            textBoxDomicilioComercial.CharacterCasing = CharacterCasing.Upper;
            textBoxDomicilioComercial.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBoxDomicilioComercial.Location = new Point(141, 111);
            textBoxDomicilioComercial.Name = "textBoxDomicilioComercial";
            textBoxDomicilioComercial.Size = new Size(197, 25);
            textBoxDomicilioComercial.TabIndex = 6;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblCuit.Location = new Point(479, 24);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(39, 17);
            lblCuit.TabIndex = 5;
            lblCuit.Text = "CUIT:";
            // 
            // textBoxCUIT
            // 
            textBoxCUIT.Location = new Point(533, 16);
            textBoxCUIT.Name = "textBoxCUIT";
            textBoxCUIT.Size = new Size(121, 23);
            textBoxCUIT.TabIndex = 4;
            // 
            // lblNombreFantasia
            // 
            lblNombreFantasia.AutoSize = true;
            lblNombreFantasia.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblNombreFantasia.Location = new Point(15, 77);
            lblNombreFantasia.Name = "lblNombreFantasia";
            lblNombreFantasia.Size = new Size(115, 17);
            lblNombreFantasia.TabIndex = 3;
            lblNombreFantasia.Text = "Nombre Negocio:";
            // 
            // textBoxNombreFantasia
            // 
            textBoxNombreFantasia.CharacterCasing = CharacterCasing.Upper;
            textBoxNombreFantasia.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBoxNombreFantasia.Location = new Point(141, 69);
            textBoxNombreFantasia.Name = "textBoxNombreFantasia";
            textBoxNombreFantasia.Size = new Size(289, 25);
            textBoxNombreFantasia.TabIndex = 2;
            // 
            // lblRazonSocial
            // 
            lblRazonSocial.AutoSize = true;
            lblRazonSocial.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblRazonSocial.Location = new Point(15, 24);
            lblRazonSocial.Name = "lblRazonSocial";
            lblRazonSocial.Size = new Size(86, 17);
            lblRazonSocial.TabIndex = 1;
            lblRazonSocial.Text = "Razon Social:";
            // 
            // textBoxRazonSocial
            // 
            textBoxRazonSocial.CharacterCasing = CharacterCasing.Upper;
            textBoxRazonSocial.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBoxRazonSocial.Location = new Point(141, 16);
            textBoxRazonSocial.Name = "textBoxRazonSocial";
            textBoxRazonSocial.Size = new Size(289, 25);
            textBoxRazonSocial.TabIndex = 0;
            // 
            // tabPageSistemaImpresion
            // 
            tabPageSistemaImpresion.Controls.Add(gpRespaldos);
            tabPageSistemaImpresion.Controls.Add(lblModoImpresion);
            tabPageSistemaImpresion.Controls.Add(comboBox1);
            tabPageSistemaImpresion.Location = new Point(4, 24);
            tabPageSistemaImpresion.Name = "tabPageSistemaImpresion";
            tabPageSistemaImpresion.Size = new Size(673, 239);
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
            gpRespaldos.Location = new Point(21, 50);
            gpRespaldos.Name = "gpRespaldos";
            gpRespaldos.Size = new Size(622, 174);
            gpRespaldos.TabIndex = 2;
            gpRespaldos.TabStop = false;
            // 
            // btnRealizarBackup
            // 
            btnRealizarBackup.Location = new Point(307, 123);
            btnRealizarBackup.Name = "btnRealizarBackup";
            btnRealizarBackup.Size = new Size(114, 23);
            btnRealizarBackup.TabIndex = 5;
            btnRealizarBackup.Text = "Realizar Backup";
            btnRealizarBackup.UseVisualStyleBackColor = true;
            // 
            // dtpHoraBackup
            // 
            dtpHoraBackup.Format = DateTimePickerFormat.Time;
            dtpHoraBackup.Location = new Point(124, 84);
            dtpHoraBackup.Name = "dtpHoraBackup";
            dtpHoraBackup.Size = new Size(83, 23);
            dtpHoraBackup.TabIndex = 4;
            // 
            // lblHoraBackup
            // 
            lblHoraBackup.AutoSize = true;
            lblHoraBackup.Location = new Point(40, 92);
            lblHoraBackup.Name = "lblHoraBackup";
            lblHoraBackup.Size = new Size(78, 15);
            lblHoraBackup.TabIndex = 3;
            lblHoraBackup.Text = "Hora Backup:";
            // 
            // cmbFrecuenciaBackup
            // 
            cmbFrecuenciaBackup.FormattingEnabled = true;
            cmbFrecuenciaBackup.Location = new Point(460, 31);
            cmbFrecuenciaBackup.Name = "cmbFrecuenciaBackup";
            cmbFrecuenciaBackup.Size = new Size(121, 23);
            cmbFrecuenciaBackup.TabIndex = 2;
            // 
            // lblFrecuenciaBackup
            // 
            lblFrecuenciaBackup.AutoSize = true;
            lblFrecuenciaBackup.Location = new Point(331, 39);
            lblFrecuenciaBackup.Name = "lblFrecuenciaBackup";
            lblFrecuenciaBackup.Size = new Size(109, 15);
            lblFrecuenciaBackup.TabIndex = 1;
            lblFrecuenciaBackup.Text = "Frecuencia Backup:";
            // 
            // chkBackupAutomatico
            // 
            chkBackupAutomatico.AutoSize = true;
            chkBackupAutomatico.Location = new Point(32, 39);
            chkBackupAutomatico.Name = "chkBackupAutomatico";
            chkBackupAutomatico.Size = new Size(131, 19);
            chkBackupAutomatico.TabIndex = 0;
            chkBackupAutomatico.Text = "Backup Automático";
            chkBackupAutomatico.UseVisualStyleBackColor = true;
            // 
            // lblModoImpresion
            // 
            lblModoImpresion.AutoSize = true;
            lblModoImpresion.Location = new Point(21, 29);
            lblModoImpresion.Name = "lblModoImpresion";
            lblModoImpresion.Size = new Size(98, 15);
            lblModoImpresion.TabIndex = 1;
            lblModoImpresion.Text = "Modo Impresión:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(129, 21);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(191, 285);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(327, 285);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 320);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(tabControlConfig);
            KeyPreview = true;
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
    }
}