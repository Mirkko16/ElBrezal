using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ElBrezal.Application.Validators
{
    public static class CuitValidator
    {
        public static bool Validar(string? cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                return false;

            string limpio = Regex.Replace(cuit, @"[^\d]", "");

            if (limpio.Length != 11)
                return false;

            int[] multiplicadores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma += (limpio[i] - '0') * multiplicadores[i];
            }

            int resto = suma % 11;

            int digitoVerificador = resto switch
            {
                0 => 0,
                1 => 9,
                _ => 11 - resto
            };

            int ultimoDigito = limpio[10] - '0';

            return digitoVerificador == ultimoDigito;
        }
    }
}
