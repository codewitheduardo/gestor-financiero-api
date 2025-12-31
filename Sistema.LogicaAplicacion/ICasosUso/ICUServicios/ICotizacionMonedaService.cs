using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.ICasosUso.IServicios
{
    public interface ICotizacionMonedaService
    {
        /// <summary>
        /// Retorna la cotización de 1 unidad de la moneda dada a UYU
        /// </summary>
        Task<decimal> GetRateToUYUAsync(Moneda desde);
    }
}
