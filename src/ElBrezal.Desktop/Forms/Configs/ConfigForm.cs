using ElBrezal.Application.Interfaces.Configuraciones;
using ElBrezal.Application.Models.Config;
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
        private ConfigDto? _config;
        private bool _cargando;

        public ConfigForm(IConfigService configService)
        {
            InitializeComponent();

            _configService = configService;

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
    }

}
