using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.ARCA
{
    public class ArcaAuthDto
    {
        public string Token { get; set; } = string.Empty;

        public string Sign { get; set; } = string.Empty;

        public DateTime ExpirationTime { get; set; }
    }
}
