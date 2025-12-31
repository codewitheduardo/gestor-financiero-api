using Sistema.DTOs.DTOs.DTOsMovimiento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.ICasosUso.ICUMovimiento
{
    public interface ICUObtenerMovimientosPorMesAnio
    {
        Task<List<DTOMovimiento>> ObtenerMovimientosPorMesAnioAsync(string nombreUsuario, int mes, int anio);
    }
}
