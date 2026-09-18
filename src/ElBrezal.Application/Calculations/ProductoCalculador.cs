using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Calculations
{
    public static class ProductoCalculador
    {
        public static decimal CalcularPrecio(
            decimal costo,
            decimal rentabilidad)
        {
            return costo + (costo * rentabilidad / 100m);
        }

        public static decimal CalcularRentabilidad(
            decimal costo,
            decimal precio)
        {
            if (costo == 0)
                return 0;

            return ((precio - costo) / costo) * 100m;
        }

        public static decimal CalcularPrecioConIVA(
            decimal precio,
            decimal alicuotaIVA)
        {
            return precio + (precio * alicuotaIVA / 100m);
        }

        public static int CalcularCategoria(
            decimal rentabilidadContado)
        {
            if (rentabilidadContado > 50m)
                return 1;

            if (rentabilidadContado >= 30m)
                return 2;

            return 3;
        }
    }
}
