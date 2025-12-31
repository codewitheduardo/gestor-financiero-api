using Sistema.DTOs.DTOs.DTOsMovimiento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.ICasosUso.ICUMovimiento
{
    public interface ICUObtenerMovimientos
    {
        Task<List<DTOMovimiento>> ObtenerMovimientosAsync(string nombreUsuario);
    }
}
