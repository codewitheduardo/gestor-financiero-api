using Sistema.DTOs.DTOs.DTOsTipoIngreso;
using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.DTOs.Mappers
{
    public class MapperTipoIngreso
    {
        public static TipoIngreso FromDTOAltaTipoIngresoToTipoIngreso(DTOAltaTipoIngreso dto)
        {
            TipoIngreso ti = new TipoIngreso();

            ti.Nombre = dto.Nombre;
            ti.Activo = true;

            return ti;
        }

        public static DTOTipoIngreso FromTipoIngresoToDTOTipoIngreso(TipoIngreso tipoIngreso)
        {
            DTOTipoIngreso dto = new DTOTipoIngreso();

            dto.Id = tipoIngreso.Id;
            dto.Nombre = tipoIngreso.Nombre;
            dto.Activo = tipoIngreso.Activo;

            return dto;
        }

        public static List<DTOTipoIngreso> FromListTipoIngresoToListDTOTipoIngreso(List<TipoIngreso> tiposIngreso)
        {
            List<DTOTipoIngreso> retorno = new List<DTOTipoIngreso>();

            foreach (TipoIngreso tipoIngreso in tiposIngreso)
            {
                retorno.Add(FromTipoIngresoToDTOTipoIngreso(tipoIngreso));
            }

            return retorno;
        }
    }
}
