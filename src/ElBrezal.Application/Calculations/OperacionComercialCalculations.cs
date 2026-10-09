using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Calculations
{
    public static class OperacionComercialCalculations
    {
        public static decimal CalcularImporte(decimal cantidad, decimal precio)
        {
            return cantidad * precio;
        }

        public static decimal CalcularVariacion(decimal subtotal, decimal porcentajeVariacion)
        {
            return subtotal * porcentajeVariacion / 100m;
        }

        public static decimal CalcularMontoVariacion(decimal subtotal, decimal porcentajeVariacion)
        {
            return subtotal * porcentajeVariacion / 100m;
        }

        public static decimal CalcularTotal(decimal subtotal, decimal montoVariacion)
        {
            return subtotal - montoVariacion;
        }
    }
}
