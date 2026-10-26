using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.ARCA
{
    public sealed class ArcaPasswordRequeridaException : Exception
    {
        public ArcaPasswordRequeridaException()
            : base(
                "Es necesario ingresar la contraseña del certificado " +
                "para renovar las credenciales de ARCA.")
        {
        }
    }
}
