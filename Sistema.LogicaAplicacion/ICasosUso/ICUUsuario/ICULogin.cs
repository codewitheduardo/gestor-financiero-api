using Sistema.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.ICasosUso.ICUUsuario
{
    public interface ICULogin
    {
        DTOUsuario VerificarExistencia(DTOLogin dto);
    }
}
