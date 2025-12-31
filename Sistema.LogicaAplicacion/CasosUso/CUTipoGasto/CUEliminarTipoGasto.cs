using Sistema.DTOs.DTOs.DTOsTipoGasto;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Sistema.LogicaNegocio.CustomExceptions.CETipoGasto;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUTipoGasto
{
    public class CUEliminarTipoGasto : ICUEliminarTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;

        public CUEliminarTipoGasto(IRepositorioTipoGasto repoTipoGasto)
        {
            _repoTipoGasto = repoTipoGasto;
        }

        public void Eliminar(int tipoGastoId)
        {
            TipoGasto tg = _repoTipoGasto.FindById(tipoGastoId);

            try
            {
                if (tg is null)
                {
                    throw new TipoGastoNoExisteException("El tipo de gasto no existe.");
                }

                if (tg.Salidas.Count > 0)
                {
                    throw new TipoGastoConSalidasAsociadasException("No se puede eliminar el tipo de gasto porque tiene salidas asociadas.");
                }

                _repoTipoGasto.Remove(tg.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
