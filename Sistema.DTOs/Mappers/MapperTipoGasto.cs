using Sistema.DTOs.DTOs.DTOsTipoGasto;
using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.DTOs.Mappers
{
    public class MapperTipoGasto
    {
        public static TipoGasto FromDTOAltaTipoGastoToTipoGasto(DTOAltaTipoGasto dto)
        {
            TipoGasto tg = new TipoGasto();

            tg.Nombre = dto.Nombre;
            tg.Activo = true;

            return tg;
        }

        public static DTOTipoGasto FromTipoGastoToDTOTipoGasto(TipoGasto tg)
        {
            DTOTipoGasto dto = new DTOTipoGasto();

            dto.Id = tg.Id;
            dto.Nombre = tg.Nombre;
            dto.Activo = tg.Activo;

            return dto;
        }

        public static List<DTOTipoGasto> FromListTipoGastoToListDTOTipoGasto(List<TipoGasto> tiposGastos)
        {
            List<DTOTipoGasto> retorno = new List<DTOTipoGasto>();

            foreach (var tg in tiposGastos)
            {
                retorno.Add(FromTipoGastoToDTOTipoGasto(tg));
            }

            return retorno;
        }
    }
}
