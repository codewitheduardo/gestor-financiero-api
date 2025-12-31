using Sistema.LogicaAplicacion.ICasosUso.ICUMovimiento;
using Sistema.LogicaAplicacion.ICasosUso.IServicios;
using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUMovimiento
{
    public class CUObtenerCotizacionUYU : ICUObtenerCotizacionUYU
    {
        private readonly ICotizacionMonedaService _service;

        public CUObtenerCotizacionUYU(ICotizacionMonedaService service)
        {
            _service = service;
        }

        public async Task<decimal> EjecutarAsync(Moneda desde)
        {
            // Delegamos la obtención de la cotización al servicio externo
            return await _service.GetRateToUYUAsync(desde);
        }
    }
}
