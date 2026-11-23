
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
        /// Calcula el desglose fiscal de un comprobante cuyos precios incluyen IVA.
        /// Distribuye proporcionalmente los descuentos o recargos entre las alícuotas,
        /// valida los importes comerciales y garantiza que el total fiscal coincida
        /// con el total del comprobante.
        /// </summary>
        /// <param name="detalles">Artículos del comprobante con sus importes y alícuotas.</param>
        /// <param name="montoVariacion">
        /// Importe del descuento (positivo) o recargo (negativo).
        /// </param>
        /// <param name="totalComprobante">Importe final del comprobante con IVA incluido.</param>
        /// <returns>Desglose fiscal listo para construir la solicitud a ARCA.</returns>
        public static ComprobanteFiscalResultado Calcular(
            IEnumerable<ComprobanteFiscalDetalle> detalles,
            decimal montoVariacion,
            decimal totalComprobante)
        {
            ArgumentNullException.ThrowIfNull(detalles);

            var items = detalles.ToList();

            // 1. Validar que existan artículos.
            if (items.Count == 0)
            {
                throw new InvalidOperationException(
                    "El comprobante no contiene artículos.");
            }

            // 2. Validar importes negativos.
            if (items.Any(x => x.Importe < 0))
            {
                throw new InvalidOperationException(
                    "Existen artículos con importes negativos.");
            }

            // 3. Validar porcentajes de IVA.
            if (items.Any(x =>
                x.PorcentajeIVA < 0 ||
                x.PorcentajeIVA > 100))
            {
                throw new InvalidOperationException(
                    "Existen porcentajes de IVA inválidos.");
            }

            // 4. Validar que los artículos gravados tengan código ARCA.
            if (items.Any(x =>
                !x.EsExento && x.CodigoArcaIVA <= 0))
            {
                throw new InvalidOperationException(
                    "Existen alícuotas sin código ARCA.");
            }

            // 5. Validar que los artículos exentos no tengan IVA.
            if (items.Any(x =>
                x.EsExento && x.PorcentajeIVA != 0m))
            {
                throw new InvalidOperationException(
                    "Un artículo exento no puede tener IVA gravado.");
            }

            // 6. Validar correspondencia entre porcentaje y código ARCA.
            // Códigos utilizados actualmente en ElBrezal:
            // 3 = Exento
            // 4 = IVA 10,5 %
            // 5 = IVA 21 %
            // 6 = IVA 27 %
            if (items.Any(x =>
                x.CodigoArcaIVA switch
                {
                    3 => !x.EsExento || x.PorcentajeIVA != 0m,
                    4 => x.EsExento || x.PorcentajeIVA != 10.5m,
                    5 => x.EsExento || x.PorcentajeIVA != 21m,
                    6 => x.EsExento || x.PorcentajeIVA != 27m,
                    _ => true
                }))
            {
                throw new InvalidOperationException(
                    "Existen artículos con alícuotas de IVA incompatibles " +
                    "con su código ARCA.");
            }

            // 7. Validar precisión de los importes comerciales.
            if (Redondear(totalComprobante) != totalComprobante ||
                Redondear(montoVariacion) != montoVariacion)
            {
                throw new InvalidOperationException(
                    "Los importes comerciales deben tener como máximo dos decimales.");
            }

            // 8. Calcular subtotal comercial.
            decimal subtotal = Redondear(
                items.Sum(x => x.Importe));

            if (subtotal <= 0 || totalComprobante <= 0)
            {
                throw new InvalidOperationException(
                    "Los importes del comprobante deben ser positivos.");
            }

            // 9. Verificar que el total coincida con el descuento o recargo.
            // montoVariacion positivo = descuento.
            // montoVariacion negativo = recargo.
            decimal totalEsperado = Redondear(
                subtotal - montoVariacion);

            if (totalEsperado != totalComprobante)
            {
                throw new InvalidOperationException(
                    "El total comercial no coincide con la variación aplicada.");
            }

            // 10. Agrupar artículos por tratamiento fiscal y alícuota.
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

            // 11. Distribuir el total final proporcionalmente.
            // El último grupo absorbe cualquier diferencia de centavos.
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
                {
                    throw new InvalidOperationException(
                        "La distribución produjo un importe negativo.");
                }
            }

            // 12. Inicializar el resultado fiscal.
            var resultado = new ComprobanteFiscalResultado
            {
                ImporteTotal = totalComprobante,
                ImporteNeto = 0m,
                ImporteNoGravado = 0m,
                ImporteExento = 0m,
                ImporteIVA = 0m,
                ImporteTributos = 0m
            };

            // 13. Calcular base imponible e IVA por grupo.
            foreach (var grupo in grupos)
            {
                if (grupo.EsExento)
                {
                    resultado.ImporteExento +=
                        grupo.ImporteFinal;

                    continue;
                }

                // Los precios comerciales incluyen IVA.
                // Se extrae el impuesto, no se suma nuevamente.
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

            // 14. Normalizar importes fiscales.
            resultado.ImporteNeto =
                Redondear(resultado.ImporteNeto);

            resultado.ImporteIVA =
                Redondear(resultado.ImporteIVA);

            resultado.ImporteExento =
                Redondear(resultado.ImporteExento);

            // 15. Verificar consistencia del desglose fiscal.
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
