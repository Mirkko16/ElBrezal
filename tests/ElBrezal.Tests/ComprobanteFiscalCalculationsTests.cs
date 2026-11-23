
using ElBrezal.Application.Calculations;
using Xunit;

namespace ElBrezal.Tests.Calculations
{
    public class ComprobanteFiscalCalculationsTests
    {
        /// <summary>
        /// Verifica que el cálculo fiscal extraiga correctamente
        /// el IVA incluido en productos con distintas alícuotas.
        /// </summary>
        [Fact]
        public void Calcular_DosAlicuotas_DebeDesglosarIVA()
        {
            var detalles = new List<ComprobanteFiscalDetalle>
            {
                new()
                {
                    Importe = 206.36m,
                    PorcentajeIVA = 10.5m,
                    CodigoArcaIVA = 4,
                    EsExento = false
                },
                new()
                {
                    Importe = 223.85m,
                    PorcentajeIVA = 21m,
                    CodigoArcaIVA = 5,
                    EsExento = false
                }
            };

            var resultado = ComprobanteFiscalCalculations.Calcular(
                detalles,
                montoVariacion: 0m,
                totalComprobante: 430.21m);

            Assert.Equal(430.21m, resultado.ImporteTotal);
            Assert.Equal(371.75m, resultado.ImporteNeto);
            Assert.Equal(58.46m, resultado.ImporteIVA);
            Assert.Equal(0m, resultado.ImporteExento);
            Assert.Equal(0m, resultado.ImporteNoGravado);
            Assert.Equal(0m, resultado.ImporteTributos);

            Assert.Equal(2, resultado.AlicuotasIVA.Count);

            var iva105 = Assert.Single(
                resultado.AlicuotasIVA,
                x => x.CodigoArcaIVA == 4);

            Assert.Equal(186.75m, iva105.BaseImponible);
            Assert.Equal(19.61m, iva105.ImporteIVA);

            var iva21 = Assert.Single(
                resultado.AlicuotasIVA,
                x => x.CodigoArcaIVA == 5);

            Assert.Equal(185.00m, iva21.BaseImponible);
            Assert.Equal(38.85m, iva21.ImporteIVA);
        }

        /// <summary>
        /// Verifica que se rechace una alícuota cuyo código ARCA
        /// no corresponda al porcentaje de IVA.
        /// </summary>
        [Fact]
        public void Calcular_CodigoArcaIncorrecto_DebeRechazar()
        {
            var detalles = new List<ComprobanteFiscalDetalle>
            {
                new()
                {
                    Importe = 121m,
                    PorcentajeIVA = 21m,
                    CodigoArcaIVA = 4,
                    EsExento = false
                }
            };

            Assert.Throws<InvalidOperationException>(() =>
                ComprobanteFiscalCalculations.Calcular(
                    detalles,
                    montoVariacion: 0m,
                    totalComprobante: 121m));
        }

        /// <summary>
        /// Verifica que se rechace un total que no coincida
        /// con los artículos y la variación comercial.
        /// </summary>
        [Fact]
        public void Calcular_TotalInconsistente_DebeRechazar()
        {
            var detalles = new List<ComprobanteFiscalDetalle>
            {
                new()
                {
                    Importe = 121m,
                    PorcentajeIVA = 21m,
                    CodigoArcaIVA = 5,
                    EsExento = false
                }
            };

            Assert.Throws<InvalidOperationException>(() =>
                ComprobanteFiscalCalculations.Calcular(
                    detalles,
                    montoVariacion: 0m,
                    totalComprobante: 120m));
        }

        /// <summary>
        /// Verifica que el descuento comercial se distribuya
        /// correctamente y que el total fiscal permanezca consistente.
        /// </summary>
        [Fact]
        public void Calcular_ConDescuento_DebeMantenerTotalFiscal()
        {
            var detalles = new List<ComprobanteFiscalDetalle>
            {
                new()
                {
                    Importe = 121m,
                    PorcentajeIVA = 21m,
                    CodigoArcaIVA = 5,
                    EsExento = false
                }
            };

            var resultado = ComprobanteFiscalCalculations.Calcular(
                detalles,
                montoVariacion: 12.10m,
                totalComprobante: 108.90m);

            Assert.Equal(90m, resultado.ImporteNeto);
            Assert.Equal(18.90m, resultado.ImporteIVA);
            Assert.Equal(108.90m, resultado.ImporteTotal);
        }
    }
}
