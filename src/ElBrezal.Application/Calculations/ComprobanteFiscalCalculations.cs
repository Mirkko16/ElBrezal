
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElBrezal.Application.Calculations
{
    /// <summary>
    /// Representa una línea comercial utilizada para calcular
    /// el desglose fiscal de un comprobante.
    /// </summary>
    public sealed class ComprobanteFiscalDetalle
    {
        public decimal Importe { get; set; }

        public decimal PorcentajeIVA { get; set; }

        public int CodigoArcaIVA { get; set; }

        public bool EsExento { get; set; }
    }

    /// <summary>
    /// Representa una alícuota gravada y sus importes fiscales.
    /// </summary>
    public sealed class ComprobanteFiscalAlicuota
    {
        public int CodigoArcaIVA { get; set; }

        public decimal PorcentajeIVA { get; set; }

        public decimal BaseImponible { get; set; }

        public decimal ImporteIVA { get; set; }
    }

    /// <summary>
    /// Contiene el desglose fiscal calculado para un comprobante.
    /// </summary>
    public sealed class ComprobanteFiscalResultado
    {
        public decimal ImporteTotal { get; set; }

        public decimal ImporteNeto { get; set; }

        public decimal ImporteNoGravado { get; set; }

        public decimal ImporteExento { get; set; }

        public decimal ImporteIVA { get; set; }

        public decimal ImporteTributos { get; set; }

        public List<ComprobanteFiscalAlicuota> AlicuotasIVA { get; set; } = new();
    }

    /// <summary>
    /// Calcula los importes fiscales de comprobantes comerciales
    /// cuyos precios incluyen IVA.
    /// </summary>
    public static class ComprobanteFiscalCalculations
    {
        /// <summary>
        /// Calcula el desglose fiscal distribuyendo proporcionalmente
        /// el descuento o recargo comercial entre las alícuotas.
        /// </summary>
        public static ComprobanteFiscalResultado Calcular(
            IEnumerable<ComprobanteFiscalDetalle> detalles,
            decimal montoVariacion,
            decimal totalComprobante)
        {
            ArgumentNullException.ThrowIfNull(detalles);

            var items = detalles.ToList();

            if (items.Count == 0)
                throw new InvalidOperationException(
                    "El comprobante no contiene artículos.");

            if (items.Any(x => x.Importe < 0))
                throw new InvalidOperationException(
                    "Existen artículos con importes negativos.");

            if (items.Any(x =>
                x.PorcentajeIVA < 0 ||
                x.PorcentajeIVA > 100))
            {
                throw new InvalidOperationException(
                    "Existen porcentajes de IVA inválidos.");
            }

            if (items.Any(x =>
                !x.EsExento && x.CodigoArcaIVA <= 0))
            {
                throw new InvalidOperationException(
                    "Existen alícuotas sin código ARCA.");
            }

            if (items.Any(x =>
                x.EsExento && x.PorcentajeIVA != 0))
            {
                throw new InvalidOperationException(
                    "Un artículo exento no puede tener IVA gravado.");
            }

            decimal subtotal = Redondear(
                items.Sum(x => x.Importe));

            if (subtotal <= 0 || totalComprobante <= 0)
                throw new InvalidOperationException(
                    "Los importes del comprobante deben ser positivos.");

            decimal totalEsperado = Redondear(
                subtotal - montoVariacion);

            if (totalEsperado != totalComprobante)
                throw new InvalidOperationException(
                    "El total comercial no coincide con la variación aplicada.");

            // Agrupamos por tratamiento fiscal y alícuota.
            var grupos = items
                .GroupBy(x => new
                {
                    x.EsExento,
                    x.CodigoArcaIVA,
                    x.PorcentajeIVA
                })
                .Select(x => new GrupoFiscal
                {
                    EsExento = x.Key.EsExento,
                    CodigoArcaIVA = x.Key.CodigoArcaIVA,
                    PorcentajeIVA = x.Key.PorcentajeIVA,
                    ImporteOriginal = Redondear(
                        x.Sum(y => y.Importe))
                })
                .OrderBy(x => x.EsExento)
                .ThenBy(x => x.CodigoArcaIVA)
                .ToList();

            // Distribuimos el total final proporcionalmente.
            // El último grupo absorbe los centavos residuales.
            decimal acumulado = 0m;

            for (int i = 0; i < grupos.Count; i++)
            {
                var grupo = grupos[i];

                if (i == grupos.Count - 1)
                {
                    grupo.ImporteFinal =
                        totalComprobante - acumulado;
                }
                else
                {
                    grupo.ImporteFinal = Redondear(
                        totalComprobante *
                        grupo.ImporteOriginal / subtotal);

                    acumulado += grupo.ImporteFinal;
                }

                if (grupo.ImporteFinal < 0)
                    throw new InvalidOperationException(
                        "La distribución produjo un importe negativo.");
            }

            var resultado = new ComprobanteFiscalResultado
            {
                ImporteTotal = totalComprobante,
                ImporteTributos = 0m,
                ImporteNoGravado = 0m
            };

            foreach (var grupo in grupos)
            {
                if (grupo.EsExento)
                {
                    resultado.ImporteExento +=
                        grupo.ImporteFinal;

                    continue;
                }

                // El importe comercial incluye IVA.
                decimal baseImponible = Redondear(
                    grupo.ImporteFinal /
                    (1m + grupo.PorcentajeIVA / 100m));

                decimal importeIVA =
                    grupo.ImporteFinal - baseImponible;

                resultado.AlicuotasIVA.Add(
                    new ComprobanteFiscalAlicuota
                    {
                        CodigoArcaIVA = grupo.CodigoArcaIVA,
                        PorcentajeIVA = grupo.PorcentajeIVA,
                        BaseImponible = baseImponible,
                        ImporteIVA = importeIVA
                    });

                resultado.ImporteNeto += baseImponible;
                resultado.ImporteIVA += importeIVA;
            }

            resultado.ImporteNeto =
                Redondear(resultado.ImporteNeto);

            resultado.ImporteIVA =
                Redondear(resultado.ImporteIVA);

            resultado.ImporteExento =
                Redondear(resultado.ImporteExento);

            decimal totalFiscal =
                resultado.ImporteNeto +
                resultado.ImporteIVA +
                resultado.ImporteExento +
                resultado.ImporteNoGravado +
                resultado.ImporteTributos;

            if (totalFiscal != resultado.ImporteTotal)
            {
                throw new InvalidOperationException(
                    "El desglose fiscal no coincide con el total comercial.");
            }

            return resultado;
        }

        /// <summary>
        /// Redondea importes monetarios a dos decimales.
        /// </summary>
        private static decimal Redondear(decimal importe)
        {
            return OperacionComercialCalculations
                .RedondearImporte(importe);
        }

        /// <summary>
        /// Representa internamente un grupo de artículos
        /// que comparten tratamiento fiscal.
        /// </summary>
        private sealed class GrupoFiscal
        {
            public bool EsExento { get; set; }

            public int CodigoArcaIVA { get; set; }

            public decimal PorcentajeIVA { get; set; }

            public decimal ImporteOriginal { get; set; }

            public decimal ImporteFinal { get; set; }
        }
    }
}
