using Sistema.DTOs.DTOs.DTOsTipoGasto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.ICasosUso.ICUTipoGasto
{
    public interface ICUObtenerTipoGastosActivos
    {
        List<DTOTipoGasto> ObtenerTipoGastosActivos(string nombreUsuario);
    }
}
