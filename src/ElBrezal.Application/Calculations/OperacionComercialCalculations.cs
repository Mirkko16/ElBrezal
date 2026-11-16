using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Calculations
{


    public static class OperacionComercialCalculations
    {
        /// <summary>
        /// Redondea un importe monetario a dos decimales.
        /// </summary>
        public static decimal RedondearImporte(decimal importe)
        {
            return Math.Round(
                importe,
                2,
                MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Calcula el importe total de una línea comercial.
        /// </summary>
        public static decimal CalcularImporte(
            decimal cantidad,
            decimal precio)
        {
            return RedondearImporte(cantidad * precio);
        }

        /// <summary>
        /// Calcula el monto correspondiente a una variación porcentual.
        /// </summary>
        public static decimal CalcularVariacion(
            decimal subtotal,
            decimal porcentajeVariacion)
        {
            return CalcularMontoVariacion(
                subtotal,
                porcentajeVariacion);
        }

        /// <summary>
        /// Calcula el importe monetario de la variación comercial.
        /// Un porcentaje positivo representa un descuento.
        /// </summary>
        public static decimal CalcularMontoVariacion(
            decimal subtotal,
            decimal porcentajeVariacion)
        {
            return RedondearImporte(
                subtotal * porcentajeVariacion / 100m);
        }

        /// <summary>
        /// Calcula el total después de aplicar la variación.
        /// </summary>
        public static decimal CalcularTotal(
            decimal subtotal,
            decimal montoVariacion)
        {
            return RedondearImporte(subtotal - montoVariacion);
        }
    }


}
