using ElBrezal.Application.ARCA;
using ElBrezal.Application.Interfaces.ARCA;
using ElBrezal.Application.Models.ARCA;
using ElBrezal.Infrastructure.Data;
using ElBrezal.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ElBrezal.Infrastructure.Services
{
    public sealed class ArcaCredencialesService : IArcaCredencialesService
    {
        private const string ServicioWsfe = "wsfe";

        private static readonly TimeSpan MargenRenovacion =
            TimeSpan.FromMinutes(10);

        private static readonly SemaphoreSlim SemaforoRenovacion =
            new(1, 1);

        private readonly ElBrezalDbContext _context;
        private readonly IArcaAuthService _arcaAuthService;

        public ArcaCredencialesService(
            ElBrezalDbContext context,
            IArcaAuthService arcaAuthService)
        {
            _context = context;
            _arcaAuthService = arcaAuthService;
        }

        public async Task<ArcaAuthDto> ObtenerCredencialesValidasAsync(
            long cuitEmisor,
            string ambiente,
            string rutaCertificadoPfx,
            string? password = null,
            CancellationToken cancellationToken = default)
        {
            if (cuitEmisor <= 0)
                throw new ArgumentException("El CUIT no es válido.");

            ambiente = ambiente.Trim().ToUpperInvariant();

            if (ambiente is not ("HOMOLOGACION" or "PRODUCCION"))
                throw new ArgumentException("Ambiente ARCA no válido.");

            await SemaforoRenovacion.WaitAsync(cancellationToken);

            try
            {
                // Consultamos dentro del semáforo para evitar
                // renovaciones simultáneas en este proceso.
                var credencial = await _context.ArcaCredenciales
                    .FirstOrDefaultAsync(
                        x => x.CUIT == cuitEmisor &&
                             x.Ambiente == ambiente &&
                             x.Servicio == ServicioWsfe,
                        cancellationToken);

                if (credencial != null &&
                    credencial.FechaExpiracion >
                        DateTimeOffset.UtcNow.Add(MargenRenovacion))
                {
                    try
                    {
                        return new ArcaAuthDto
                        {
                            Token = Desproteger(credencial.TokenProtegido),
                            Sign = Desproteger(credencial.SignProtegido),
                            ExpirationTime =
                                credencial.FechaExpiracion.UtcDateTime
                        };
                    }
                    catch (CryptographicException ex)
                    {
                        throw new InvalidOperationException(
                            "Las credenciales guardadas no se pueden " +
                            "descifrar en esta computadora. " +
                            "No se intentará renovarlas automáticamente.",
                            ex);
                    }
                }

                if (string.IsNullOrWhiteSpace(password))
                    throw new ArcaPasswordRequeridaException();

                if (string.IsNullOrWhiteSpace(rutaCertificadoPfx) ||
                    !File.Exists(rutaCertificadoPfx))
                {
                    throw new FileNotFoundException(
                        "No se encontró el certificado PFX.",
                        rutaCertificadoPfx);
                }

                // Autenticación real contra WSAA.
                var nuevaAuth = await _arcaAuthService.AutenticarAsync(
                    rutaCertificadoPfx,
                    password,
                    ambiente,
                    cancellationToken);

                if (string.IsNullOrWhiteSpace(nuevaAuth.Token) ||
                    string.IsNullOrWhiteSpace(nuevaAuth.Sign))
                {
                    throw new InvalidOperationException(
                        "WSAA devolvió credenciales incompletas.");
                }

                var expiracion = new DateTimeOffset(
                    nuevaAuth.ExpirationTime.ToUniversalTime());

                if (expiracion <=
                    DateTimeOffset.UtcNow.Add(MargenRenovacion))
                {
                    throw new InvalidOperationException(
                        "WSAA devolvió un ticket vencido " +
                        "o demasiado próximo a vencer.");
                }

                // Ciframos antes de persistir.
                byte[] tokenProtegido = Proteger(nuevaAuth.Token);
                byte[] signProtegido = Proteger(nuevaAuth.Sign);

                if (credencial == null)
                {
                    credencial = new ArcaCredenciales
                    {
                        CUIT = cuitEmisor,
                        Ambiente = ambiente,
                        Servicio = ServicioWsfe,
                        TokenProtegido = tokenProtegido,
                        SignProtegido = signProtegido,
                        FechaExpiracion = expiracion,
                        UpdatedAt = DateTime.Now
                    };

                    _context.ArcaCredenciales.Add(credencial);
                }
                else
                {
                    credencial.TokenProtegido = tokenProtegido;
                    credencial.SignProtegido = signProtegido;
                    credencial.FechaExpiracion = expiracion;
                    credencial.UpdatedAt = DateTime.Now;
                }

                await _context.SaveChangesAsync(cancellationToken);

                return nuevaAuth;
            }
            finally
            {
                SemaforoRenovacion.Release();
            }
        }

        private static byte[] Proteger(string valor)
        {
            byte[] datos = Encoding.UTF8.GetBytes(valor);

            try
            {
                return ProtectedData.Protect(
                    datos,
                    optionalEntropy: null,
                    scope: DataProtectionScope.LocalMachine);
            }
            finally
            {
                CryptographicOperations.ZeroMemory(datos);
            }
        }

        private static string Desproteger(byte[] valor)
        {
            byte[] datos = ProtectedData.Unprotect(
                valor,
                optionalEntropy: null,
                scope: DataProtectionScope.LocalMachine);

            try
            {
                return Encoding.UTF8.GetString(datos);
            }
            finally
            {
                CryptographicOperations.ZeroMemory(datos);
            }
        }
    }
}
