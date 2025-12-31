using Sistema.DTOs.DTOs.DTOsTipoIngreso;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.ICasosUso.ICUTipoIngreso
{
    public interface ICUObtenerTipoIngreso
    {
        DTOTipoIngreso ObtenerTipoIngreso(int id);
    }
}
