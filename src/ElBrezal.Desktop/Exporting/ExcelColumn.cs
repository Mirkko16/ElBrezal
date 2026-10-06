using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Desktop.Exporting
{
    public class ExcelColumn<T>
    {
        public string Titulo { get; set; } = string.Empty;

        public Func<T, object?> Valor { get; set; } = null!;

        public string? Formato { get; set; }
    }
}
