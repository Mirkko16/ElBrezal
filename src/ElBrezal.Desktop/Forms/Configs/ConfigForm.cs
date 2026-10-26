using ElBrezal.Application.ARCA;
using ElBrezal.Application.Interfaces.ARCA;
using ElBrezal.Application.Interfaces.Configuraciones;
using ElBrezal.Application.Models.ARCA;
using ElBrezal.Application.Models.Config;
using ElBrezal.Desktop.Forms.Configs.Arca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Configs
{
    public partial class ConfigForm : Form
    {
        private readonly IConfigService _configService;
        private readonly IArcaAuthService _arcaAuthService;
        private readonly IArcaFacturacionService _arcaFacturacionService;
        private readonly IArcaCredencialesService _arcaCredencialesService;
        private ConfigDto? _config;
        private bool _cargando;

        public ConfigForm(IConfigService configService, IArcaAuthService arcaAuthService,
            IArcaFacturacionService arcaFacturacionService, IArcaCredencialesService arcaCredencialesService)
        {
            InitializeComponent();

            _configService = configService;
            _arcaAuthService = arcaAuthService;
            _arcaFacturacionService = arcaFacturacionService;
            _arcaCredencialesService = arcaCredencialesService;

            ConfigurarControles();
            ConfigurarControlesDatosNegocio();
        }

        private void ConfigurarControles()
        {
            cmbAmbienteArca.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbAmbienteArca.Items.Clear();
            cmbAmbienteArca.Items.Add("HOMOLOGACION");
            cmbAmbienteArca.Items.Add("PRODUCCION");

            textBoxRutaCertificadoPfx.ReadOnly = true;

            numPuntoVenta.Minimum = 1;
            numPuntoVenta.Maximum = 99999;

            btnGuardar.Enabled = false;
        }


        private async void ConfigForm_Load(object sender, EventArgs e)
        {
            try
            {
                _cargando = true;

                _config = await _configService.ObtenerAsync();

                if (_config == null)
                {
                    MessageBox.Show(
                        "No se encontró la configuración del negocio.",
                        "Configuración",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    Close();
                    return;
                }

                // PESTAÑA FACTURACIÓN

                chkFacturacionElectronica.Checked =
                    _config.FacturacionElectronica;

                chkFacturacionNegativa.Checked =
                    _config.FacturacionNegativa;

                cmbAmbienteArca.SelectedItem =
                    _config.AmbienteArca;

                if (cmbAmbienteArca.SelectedIndex == -1)
                    cmbAmbienteArca.SelectedIndex = 0;

                textBoxRutaCertificadoPfx.Text =
                    _config.RutaCertificadoPfx ?? string.Empty;

                numPuntoVenta.Value = Math.Clamp(
                    _config.PuntoVenta,
                    (int)numPuntoVenta.Minimum,
                    (int)numPuntoVenta.Maximum);

                ActualizarEstadoFacturacionElectronica();

                // PESTAÑA DATOS DEL NEGOCIO
                CargarDatosNegocio();

                btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al cargar la configuración:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _cargando = false;
            }
        }


        private void chkFacturacionElectronica_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (_cargando)
                return;

            ActualizarEstadoFacturacionElectronica();
        }

        private void ActualizarEstadoFacturacionElectronica()
        {
            bool habilitada = chkFacturacionElectronica.Checked;

            cmbAmbienteArca.Enabled = habilitada;
            textBoxRutaCertificadoPfx.Enabled = habilitada;
            btnExaminarCertificado.Enabled = habilitada;
            numPuntoVenta.Enabled = habilitada;
            btnProbarConexionArca.Enabled = habilitada;
        }

        private void btnExaminarCertificado_Click(
            object sender,
            EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Seleccionar certificado digital ARCA",
                Filter = "Certificados PFX (*.pfx)|*.pfx",
                CheckFileExists = true,
                Multiselect = false
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                textBoxRutaCertificadoPfx.Text =
                    dialog.FileName;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_config == null)
                return;

            if (!ValidarConfiguracion())
                return;

            if (!ValidarDatosNegocio())
                return;

            try
            {
                btnGuardar.Enabled = false;

                _config.FacturacionElectronica =
                    chkFacturacionElectronica.Checked;

                _config.FacturacionNegativa =
                    chkFacturacionNegativa.Checked;

                _config.AmbienteArca =
                    cmbAmbienteArca.SelectedItem?.ToString()
                    ?? "HOMOLOGACION";

                _config.RutaCertificadoPfx =
                    string.IsNullOrWhiteSpace(
                        textBoxRutaCertificadoPfx.Text)
                        ? null
                        : textBoxRutaCertificadoPfx.Text.Trim();

                _config.PuntoVenta = (int)numPuntoVenta.Value;

                ActualizarDatosNegocio();
                await _configService.GuardarAsync(_config);

                MessageBox.Show(
                    "La configuración se guardó correctamente.",
                    "Configuración",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo guardar la configuración:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }

        private bool ValidarDatosNegocio()
        {
            if (string.IsNullOrWhiteSpace(textBoxRazonSocial.Text))
            {
                MessageBox.Show(
                    "Debe ingresar la razón social.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tabControlConfig.SelectedTab = tabPageDatosNegocio;
                textBoxRazonSocial.Focus();
                return false;
            }

            string cuit = textBoxCUIT.Text
                .Replace("-", "")
                .Replace(" ", "");

            if (cuit.Length != 11 ||
                !cuit.All(char.IsDigit) ||
                !long.TryParse(cuit, out _))
            {
                MessageBox.Show(
                    "El CUIT debe contener 11 dígitos numéricos.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tabControlConfig.SelectedTab = tabPageDatosNegocio;
                textBoxCUIT.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarConfiguracion()
        {
            if (!chkFacturacionElectronica.Checked)
                return true;

            if (cmbAmbienteArca.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar un ambiente de ARCA.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbAmbienteArca.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                textBoxRutaCertificadoPfx.Text))
            {
                MessageBox.Show(
                    "Debe seleccionar un certificado PFX para habilitar la facturación electrónica.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnExaminarCertificado.Focus();
                return false;
            }

            if (!File.Exists(textBoxRutaCertificadoPfx.Text))
            {
                MessageBox.Show(
                    "El certificado seleccionado no existe en la ruta indicada.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnExaminarCertificado.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ConfigurarControlesDatosNegocio()
        {
            cmbCondFrenteIVA.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbCondFrenteIVA.Items.Clear();
            cmbCondFrenteIVA.Items.Add("RESPONSABLE INSCRIPTO");
            cmbCondFrenteIVA.Items.Add("MONOTRIBUTISTA");
            cmbCondFrenteIVA.Items.Add("EXENTO");
            cmbCondFrenteIVA.Items.Add("CONSUMIDOR FINAL");

            dtpInicioActividades.Format = DateTimePickerFormat.Custom;
            dtpInicioActividades.CustomFormat = "dd/MM/yyyy";

            textBoxCUIT.MaxLength = 13;
            textBoxRazonSocial.MaxLength = 150;
            textBoxNombreFantasia.MaxLength = 150;
            textBoxDomicilioComercial.MaxLength = 200;
            textBoxIngresosBrutos.MaxLength = 30;
        }
        private void CargarDatosNegocio()
        {
            if (_config == null)
                return;

            textBoxRazonSocial.Text = _config.RazonSocial;
            textBoxNombreFantasia.Text = _config.NombreFantasia ?? string.Empty;
            textBoxDomicilioComercial.Text = _config.DomicilioComercial ?? string.Empty;

            textBoxCUIT.Text = FormatearCUIT(_config.CUIT);
            textBoxIngresosBrutos.Text = _config.IngresosBrutos ?? string.Empty;

            cmbCondFrenteIVA.SelectedItem = _config.CondFrenteIVA;

            if (cmbCondFrenteIVA.SelectedIndex == -1)
                cmbCondFrenteIVA.SelectedIndex = -1;

            dtpInicioActividades.Value =
                _config.InicioActividades.ToDateTime(TimeOnly.MinValue);
        }

        private void ActualizarDatosNegocio()
        {
            if (_config == null)
                return;

            _config.RazonSocial =
                textBoxRazonSocial.Text.Trim();

            _config.NombreFantasia =
                string.IsNullOrWhiteSpace(textBoxNombreFantasia.Text)
                    ? null
                    : textBoxNombreFantasia.Text.Trim();

            _config.DomicilioComercial =
                string.IsNullOrWhiteSpace(textBoxDomicilioComercial.Text)
                    ? null
                    : textBoxDomicilioComercial.Text.Trim();

            _config.CUIT = long.Parse(textBoxCUIT.Text.Replace("-", "").Replace(" ", "").Trim());

            _config.CondFrenteIVA =
                cmbCondFrenteIVA.SelectedItem?.ToString();

            _config.IngresosBrutos =
                string.IsNullOrWhiteSpace(textBoxIngresosBrutos.Text)
                    ? null
                    : textBoxIngresosBrutos.Text.Trim();

            _config.InicioActividades =
                DateOnly.FromDateTime(dtpInicioActividades.Value);
        }

        private static string FormatearCUIT(long cuit)
        {
            string numero = cuit.ToString("D11");

            return $"{numero[..2]}-{numero.Substring(2, 8)}-{numero[^1]}";
        }






        private async void btnConsultarPuntosVenta_Click(
            object sender,
            EventArgs e)
        {
            string ambiente =
                cmbAmbienteArca.SelectedItem?.ToString() ?? "";

            if (ambiente != "HOMOLOGACION")
            {
                MessageBox.Show(
                    "Esta consulta solo está habilitada para homologación.",
                    "ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string cuitTexto = textBoxCUITEmisorHomologacion.Text
                .Replace("-", "")
                .Replace(" ", "")
                .Trim();

            if (cuitTexto.Length != 11 ||
                !cuitTexto.All(char.IsDigit) ||
                !long.TryParse(cuitTexto, out long cuitEmisor))
            {
                MessageBox.Show(
                    "Ingresá un CUIT de homologación válido de 11 dígitos.",
                    "ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string rutaPfx = textBoxRutaCertificadoPfx.Text.Trim();

            if (!File.Exists(rutaPfx))
            {
                MessageBox.Show(
                    "Seleccioná un certificado PFX existente.",
                    "ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnConsultarPuntosVenta.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // Obtiene el token desde SQL Server si está vigente.
                // Si no existe o está vencido, solicita la contraseña.
                var auth = await ObtenerAuthArcaAsync();

                var resultado = await _arcaFacturacionService
                    .ObtenerPuntosVentaAsync(
                        auth,
                        cuitEmisor,
                        ambiente);

                if (resultado.PuntosVenta.Count == 0)
                {
                    MessageBox.Show(
                        "WSFEv1 respondió correctamente, pero no devolvió " +
                        "puntos de venta para el CUIT consultado.\n\n" +
                        string.Join("\n", resultado.Observaciones),
                        "ARCA - Puntos de venta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                string detalle = string.Join(
                    "\n",
                    resultado.PuntosVenta.Select(p =>
                        $"Punto de venta: {p.Numero}\n" +
                        $"Tipo de emisión: {p.TipoEmision}\n" +
                        $"Bloqueado: {p.Bloqueado}\n" +
                        $"Fecha de baja: {p.FechaBaja ?? "-"}\n"));

                MessageBox.Show(
                    $"CUIT consultado: {cuitEmisor}\n\n" +
                    $"Puntos de venta encontrados: {resultado.PuntosVenta.Count}\n\n" +
                    detalle +
                    (resultado.Observaciones.Count > 0
                        ? "\nObservaciones:\n" +
                          string.Join("\n", resultado.Observaciones)
                        : ""),
                    "ARCA - WSFEv1",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                // El usuario canceló el ingreso de la contraseña.
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo consultar WSFEv1:\n\n{ex.Message}",
                    "ARCA - Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnConsultarPuntosVenta.Enabled = true;
                Cursor = Cursors.Default;
            }
        }


        private async void btnProbarEstadoArca_Click(object sender, EventArgs e)
        {
            try
            {
                btnProbarEstadoArca.Enabled = false;
                Cursor = Cursors.WaitCursor;

                string estado = await _arcaFacturacionService
                    .ConsultarEstadoServicioAsync();

                MessageBox.Show(
                    estado,
                    "ARCA - Estado WSFEv1",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo consultar el estado de ARCA:\n\n{ex.Message}",
                    "ARCA - Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnProbarEstadoArca.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private async Task<ArcaAuthDto> ObtenerAuthArcaAsync()
        {
            if (_config == null)
                throw new InvalidOperationException(
                    "No se cargó la configuración del sistema.");

            string ambiente = _config.AmbienteArca;

            if (!long.TryParse(
                textBoxCUITEmisorHomologacion.Text.Replace("-", "").Trim(),
                out long cuitEmisor))
            {
                throw new InvalidOperationException(
                    "El CUIT de homologación no es válido.");
            }

            string rutaPfx = textBoxRutaCertificadoPfx.Text.Trim()
                ?? throw new InvalidOperationException(
                    "No se configuró el certificado PFX.");

            try
            {
                // Primer intento: reutilizar el token almacenado.
                return await _arcaCredencialesService
                    .ObtenerCredencialesValidasAsync(
                        cuitEmisor,
                        ambiente,
                        rutaPfx);
            }
            catch (ArcaPasswordRequeridaException)
            {
                // Solo pedimos contraseña si debemos renovar.
                using var form = new CertificadoPasswordForm();

                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    throw new OperationCanceledException(
                        "Se canceló la autenticación con ARCA.");
                }

                return await _arcaCredencialesService
                    .ObtenerCredencialesValidasAsync(
                        cuitEmisor,
                        ambiente,
                        rutaPfx,
                        form.Password);
            }
        }


        private async void btnProbarConexionArca_Click(
            object sender,
            EventArgs e)
        {
            if (_config == null)
            {
                MessageBox.Show(
                    "Todavía no se cargó la configuración.",
                    "ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string rutaCertificado = textBoxRutaCertificadoPfx.Text.Trim();

            if (!File.Exists(rutaCertificado))
            {
                MessageBox.Show(
                    "Seleccioná un certificado PFX existente.",
                    "ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string ambiente =
                cmbAmbienteArca.SelectedItem?.ToString() ?? "";

            if (ambiente != "HOMOLOGACION")
            {
                MessageBox.Show(
                    "La prueba de conexión está habilitada solamente para homologación.",
                    "ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                btnProbarConexionArca.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // Utilizamos el servicio centralizado de credenciales.
                var resultado = await ObtenerAuthArcaAsync();

                MessageBox.Show(
                    "Credenciales de ARCA disponibles.\n\n" +
                    "Servicio: WSAA / wsfe\n" +
                    $"Ambiente: {ambiente}\n" +
                    $"Ticket válido hasta: " +
                    $"{resultado.ExpirationTime.ToLocalTime():dd/MM/yyyy HH:mm:ss}\n\n" +
                    "El sistema reutiliza el ticket almacenado " +
                    "mientras permanece vigente.",
                    "ARCA - Autenticación correcta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                // El usuario canceló el ingreso de la contraseña.
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron obtener las credenciales de ARCA.\n\n" +
                    $"Detalle: {ex.Message}",
                    "ARCA - Error de autenticación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnProbarConexionArca.Enabled = true;
                Cursor = Cursors.Default;
            }
        }


        private async void btnConsultarTiposComprobante_Click(
            object sender,
            EventArgs e)
        {
            string ambiente =
                cmbAmbienteArca.SelectedItem?.ToString() ?? "";

            if (ambiente != "HOMOLOGACION")
            {
                MessageBox.Show(
                    "La consulta solamente está habilitada en homologación.",
                    "ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string cuitTexto = textBoxCUITEmisorHomologacion.Text
                .Replace("-", "")
                .Replace(" ", "")
                .Trim();

            if (cuitTexto.Length != 11 ||
                !cuitTexto.All(char.IsDigit) ||
                !long.TryParse(cuitTexto, out long cuitEmisor))
            {
                MessageBox.Show(
                    "Ingresá un CUIT de homologación válido.",
                    "ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnConsultarTiposComprobante.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // Reutiliza Token y Sign almacenados en SQL Server.
                var auth = await ObtenerAuthArcaAsync();

                var resultado = await _arcaFacturacionService
                    .ObtenerTiposComprobanteAsync(
                        auth,
                        cuitEmisor,
                        ambiente);

                if (resultado.TiposComprobante.Count == 0)
                {
                    MessageBox.Show(
                        "ARCA no devolvió tipos de comprobantes.\n\n" +
                        string.Join("\n", resultado.Observaciones),
                        "ARCA - Tipos de comprobante",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                string detalle = string.Join(
                    "\n",
                    resultado.TiposComprobante.Select(x =>
                        $"{x.Id} - {x.Descripcion}"));

                MessageBox.Show(
                    $"Tipos de comprobante encontrados: " +
                    $"{resultado.TiposComprobante.Count}\n\n" +
                    detalle,
                    "ARCA - Tipos de comprobante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                // El usuario canceló el ingreso de contraseña.
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron consultar los tipos de comprobante.\n\n" +
                    ex.Message,
                    "ARCA - Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnConsultarTiposComprobante.Enabled = true;
                Cursor = Cursors.Default;
            }
        }


        private async void btnConsultarUltimoComprobante_Click(
            object sender,
            EventArgs e)
        {
            string ambiente =
                cmbAmbienteArca.SelectedItem?.ToString() ?? "";

            if (ambiente != "HOMOLOGACION")
            {
                MessageBox.Show(
                    "La consulta solamente está habilitada en homologación.",
                    "ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string cuitTexto = textBoxCUITEmisorHomologacion.Text
                .Replace("-", "")
                .Replace(" ", "")
                .Trim();

            if (cuitTexto.Length != 11 ||
                !cuitTexto.All(char.IsDigit) ||
                !long.TryParse(cuitTexto, out long cuitEmisor))
            {
                MessageBox.Show(
                    "Ingresá un CUIT de homologación válido.",
                    "ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int puntoVenta = (int)numPuntoVenta.Value;
            int tipoComprobante = (int)numTipoComprobanteArca.Value;

            try
            {
                btnConsultarUltimoComprobante.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // Recuperamos Token y Sign desde el caché.
                var auth = await ObtenerAuthArcaAsync();

                var resultado = await _arcaFacturacionService
                    .ObtenerUltimoComprobanteAutorizadoAsync(
                        auth,
                        cuitEmisor,
                        ambiente,
                        puntoVenta,
                        tipoComprobante);

                MessageBox.Show(
                    "Consulta realizada correctamente.\n\n" +
                    $"Punto de venta: {resultado.PuntoVenta}\n" +
                    $"Tipo de comprobante: {resultado.TipoComprobante}\n" +
                    $"Último número autorizado: {resultado.UltimoNumero}\n" +
                    $"Próximo número estimado: {resultado.UltimoNumero + 1}",
                    "ARCA - Último comprobante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                // El usuario canceló la autenticación.
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo consultar el último comprobante autorizado.\n\n" +
                    ex.Message,
                    "ARCA - Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnConsultarUltimoComprobante.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

    }

}
