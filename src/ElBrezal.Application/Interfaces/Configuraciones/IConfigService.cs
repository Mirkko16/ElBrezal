using ElBrezal.Application.Models.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.Configuraciones
{
    public interface IConfigService
    {
        // NUEVA CONFIGURACION TIPADA

        /// <summary>
        /// Obtiene la configuración general del negocio.
        /// </summary>
        Task<ConfigDto?> ObtenerAsync();

        /// <summary>
        /// Guarda la configuración general del negocio.
        /// Si no existe, crea el registro.
        /// </summary>
        Task GuardarAsync(ConfigDto config);

        /// <summary>
        /// Indica si se permite facturar con stock insuficiente.
        /// </summary>
        Task<bool> PermiteFacturacionNegativaAsync();


        // COMPATIBILIDAD TEMPORAL

        /// <summary>
        /// Método heredado del sistema de configuración clave-valor.
        /// Se eliminará cuando migremos sus consumidores.
        /// </summary>
        [Obsolete("Utilizar ObtenerAsync() y acceder a las propiedades de ConfigDto.")]
        Task<string?> ObtenerValorAsync(string clave);

        /// <summary>
        /// Método heredado del sistema de configuración clave-valor.
        /// Se eliminará cuando migremos sus consumidores.
        /// </summary>
        [Obsolete("Utilizar ObtenerAsync() o PermiteFacturacionNegativaAsync().")]
        Task<bool> ObtenerBooleanoAsync(string clave);
    }
}
