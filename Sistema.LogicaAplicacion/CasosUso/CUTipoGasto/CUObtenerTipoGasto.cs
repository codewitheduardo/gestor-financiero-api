using Sistema.DTOs.DTOs.DTOsTipoGasto;
using Sistema.DTOs.Mappers;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Sistema.LogicaNegocio.CustomExceptions.CETipoGasto;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUTipoGasto
{
    public class CUObtenerTipoGasto : ICUObtenerTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;

        public CUObtenerTipoGasto(IRepositorioTipoGasto repoTipoGasto)
        {
            _repoTipoGasto = repoTipoGasto;
        }

        public DTOTipoGasto ObtenerTipoGasto(int id)
        {
            TipoGasto tg = _repoTipoGasto.FindById(id);

            if (tg is null)
            {
                throw new TipoGastoNoExisteException("El tipo de gasto con el id especificado no existe.");
            }

            DTOTipoGasto retorno = MapperTipoGasto.FromTipoGastoToDTOTipoGasto(tg);

            return retorno;
        }
    }
}
