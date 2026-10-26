using ElBrezal.Application.Interfaces.ARCA;
using ElBrezal.Application.Models.ARCA;
using ElBrezal.Desktop.UI.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Configs.Arca
{
    public partial class ComprobantesPendientesForm : Form
    {

        private readonly IComprobanteAutorizacionService _comprobanteAutorizacionService;
        private List<ComprobantePendienteDto> _comprobantes = new();
        private bool _cargando;
        private bool _operacionEnCurso;

        public ComprobantesPendientesForm(IComprobanteAutorizacionService comprobanteAutorizacionService)
        {
            InitializeComponent();

            _comprobanteAutorizacionService = comprobanteAutorizacionService;

            DataGridViewStyles.AplicarEstiloComprobantesPendientes(dataGridViewComprobantes);

            ConfigurarColumnas();
            ConfigurarFiltros();            

            ActualizarEstadoBotones();
        }
        private void ConfigurarColumnas()
        {
            dataGridViewComprobantes.AutoGenerateColumns = false;

            DataGridViewTextBoxColId.DataPropertyName = "Id";
            DataGridViewTextBoxColFecha.DataPropertyName = "Fecha";
            DataGridViewTextBoxColTipoComprobante.DataPropertyName = "TipoComprobante";
            DataGridViewTextBoxColPuntoVenta.DataPropertyName = "PuntoVenta";
            DataGridViewTextBoxColNumero.DataPropertyName = "Numero";
            DataGridViewTextBoxColCliente.DataPropertyName = "Cliente";
            DataGridViewTextBoxColTotal.DataPropertyName = "Total";
            DataGridViewTextBoxColEstado.DataPropertyName = "Estado";
            DataGridViewTextBoxColCantidadIntentos.DataPropertyName = "CantidadIntentos";
            DataGridViewTextBoxColUltimoIntento.DataPropertyName = "UltimoIntento";
            DataGridViewTextBoxColUltimoError.DataPropertyName = "UltimoError";
            DataGridViewTextBoxColId.Visible = false;

            DataGridViewTextBoxColFecha.FillWeight = 75;
            DataGridViewTextBoxColTipoComprobante.FillWeight = 100;
            DataGridViewTextBoxColPuntoVenta.FillWeight = 40;
            DataGridViewTextBoxColNumero.FillWeight = 75;
            DataGridViewTextBoxColCliente.FillWeight = 180;
            DataGridViewTextBoxColTotal.FillWeight = 95;
            DataGridViewTextBoxColEstado.FillWeight = 100;
            DataGridViewTextBoxColCantidadIntentos.FillWeight = 65;
            DataGridViewTextBoxColUltimoIntento.FillWeight = 120;
            DataGridViewTextBoxColUltimoError.FillWeight = 180;

            DataGridViewTextBoxColFecha.DefaultCellStyle.Format =
                "dd/MM/yyyy";

            DataGridViewTextBoxColTotal.DefaultCellStyle.Format =
                "N2";

            DataGridViewTextBoxColTotal.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColUltimoIntento.DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm";

            DataGridViewTextBoxColPuntoVenta.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColCantidadIntentos.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        private void ConfigurarFiltros()
        {
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new object[]
            {
                "TODOS",
                "PENDIENTE",
                "RECHAZADO",
                "SIN_RESPUESTA",
                "EN_PROCESO"
            });

            cmbEstado.SelectedIndex = 0;
        }

        private async void ComprobantesPendientesForm_Load(object sender, EventArgs e)
        {
            await CargarComprobantesAsync();
        }

        private async Task CargarComprobantesAsync()
        {
            if (_cargando || _operacionEnCurso)
                return;

            _cargando = true;
            ActualizarEstadoBotones();

            try
            {
                _comprobantes = await _comprobanteAutorizacionService
                    .ObtenerPendientesAsync();

                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar los comprobantes.\n\n{ex.Message}",
                    "ElBrezal - ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _cargando = false;
                ActualizarEstadoBotones();
            }
        }

        private void AplicarFiltros()
        {
            string estado = cmbEstado.SelectedItem?.ToString()
                ?? "TODOS";

            string numeroBuscado = textBoxNumero.Text.Trim();

            IEnumerable<ComprobantePendienteDto> consulta =
                _comprobantes;

            if (estado != "TODOS")
            {
                consulta = consulta.Where(x =>
                    string.Equals(
                        x.Estado,
                        estado,
                        StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(numeroBuscado))
            {
                consulta = consulta.Where(x =>
                    x.Numero.ToString().Contains(
                        numeroBuscado,
                        StringComparison.OrdinalIgnoreCase));
            }

            dataGridViewComprobantes.DataSource =
                new BindingList<ComprobantePendienteDto>(
                    consulta.ToList());

            dataGridViewComprobantes.ClearSelection();
            dataGridViewComprobantes.CurrentCell = null;

            ActualizarEstadoBotones();
        }

        private ComprobantePendienteDto? ObtenerSeleccionado()
        {
            if (dataGridViewComprobantes.SelectedRows.Count == 0)
                return null;

            return dataGridViewComprobantes.SelectedRows[0].DataBoundItem
                as ComprobantePendienteDto;
        }


        private void ActualizarEstadoBotones()
        {
            var comprobante = ObtenerSeleccionado();

            bool disponible = !_cargando && !_operacionEnCurso;

            // Autorizar únicamente comprobantes pendientes o rechazados.
            btnAutorizar.Enabled =
                disponible &&
                comprobante?.PuedeAutorizar == true;

            // Consultar comprobantes cuyo resultado ante ARCA
            // todavía es incierto.
            btnConsultarArca.Enabled =
                disponible &&
                comprobante?.RequiereConsulta == true;

            // Permitir consultar el detalle de cualquier
            // comprobante seleccionado.
            btnVerDetalle.Enabled =
                disponible &&
                comprobante != null;
        }




        private async void btnConsultarArca_Click(object sender, EventArgs e)
        {
            if (_cargando || _operacionEnCurso)
                return;

            var comprobante = ObtenerSeleccionado();

            if (comprobante == null)
                return;

            _operacionEnCurso = true;
            ActualizarEstadoBotones();

            try
            {
                var resultado = await _comprobanteAutorizacionService
                    .ConsultarAutorizacionAsync(comprobante.Id);

                if (resultado == null)
                {
                    MessageBox.Show(
                        "ARCA no encontró una autorización para este comprobante.",
                        "Consulta ARCA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else if (resultado.Aprobado)
                {
                    MessageBox.Show(
                        $"Comprobante autorizado.\n\n" +
                        $"CAE: {resultado.CAE}\n" +
                        $"Vencimiento: {resultado.CAEVencimiento:dd/MM/yyyy}",
                        "Consulta ARCA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "ARCA devolvió una respuesta sin autorización.\n\n" +
                        string.Join("\n", resultado.Errores),
                        "Consulta ARCA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo consultar el comprobante.\n\n{ex.Message}",
                    "Consulta ARCA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _operacionEnCurso = false;
                ActualizarEstadoBotones();

                await CargarComprobantesAsync();
            }
        }

        private async void btnAutorizar_Click(object sender, EventArgs e)
        {
            if (_cargando || _operacionEnCurso)
                return;

            var comprobante = ObtenerSeleccionado();

            if (comprobante == null || !comprobante.PuedeAutorizar)
                return;

            var confirmacion = MessageBox.Show(
                $"¿Desea solicitar autorización a ARCA?\n\n" +
                $"Comprobante: {comprobante.TipoComprobante}\n" +
                $"PV interno: {comprobante.PuntoVenta}\n" +
                $"Número interno: {comprobante.Numero}\n" +
                $"Cliente: {comprobante.Cliente}\n" +
                $"Total: {comprobante.Total:N2}",
                "Confirmar autorización",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            _operacionEnCurso = true;
            ActualizarEstadoBotones();

            try
            {
                var resultado = await _comprobanteAutorizacionService
                    .AutorizarAsync(comprobante.Id);

                if (resultado.Aprobado)
                {
                    MessageBox.Show(
                        $"Comprobante autorizado correctamente.\n\n" +
                        $"CAE: {resultado.CAE}\n" +
                        $"Vencimiento: {resultado.CAEVencimiento:dd/MM/yyyy}",
                        "ARCA - Autorización",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "ARCA no autorizó el comprobante.\n\n" +
                        string.Join("\n", resultado.Errores),
                        "ARCA - Resultado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo completar la autorización.\n\n{ex.Message}",
                    "ARCA - Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _operacionEnCurso = false;
                ActualizarEstadoBotones();

                await CargarComprobantesAsync();
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            VerDetalle();
        }

        private void VerDetalle()
        {
            var comprobante = ObtenerSeleccionado();

            if (comprobante == null)
                return;

            // Visualización provisional del resumen.
            // Más adelante conectaremos el detalle completo
            // utilizando IComprobanteService.ObtenerPorIdAsync.

            MessageBox.Show(
                $"Comprobante: {comprobante.TipoComprobante}\n" +
                $"PV: {comprobante.PuntoVenta}\n" +
                $"Número: {comprobante.Numero}\n" +
                $"Fecha: {comprobante.Fecha:dd/MM/yyyy}\n" +
                $"Cliente: {comprobante.Cliente}\n" +
                $"Total: {comprobante.Total:N2}\n" +
                $"Estado ARCA: {comprobante.Estado}\n" +
                $"Intentos: {comprobante.CantidadIntentos}\n" +
                $"Último error: {comprobante.UltimoError ?? "-"}",
                "Detalle del comprobante",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void textBoxNumero_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void dataGridViewComprobantes_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarEstadoBotones();
        }

        private void dataGridViewComprobantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            dataGridViewComprobantes.CurrentCell =
                dataGridViewComprobantes.Rows[e.RowIndex]
                    .Cells.Cast<DataGridViewCell>()
                    .FirstOrDefault(c => c.Visible);

            VerDetalle();
        }
    }
}
