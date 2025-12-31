using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.ICasosUso.ICUMovimiento
{
    public interface ICUObtenerCotizacionUYU
    {
        Task<decimal> EjecutarAsync(Moneda desde);
    }
}
