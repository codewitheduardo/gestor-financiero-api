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
    public class CUEditarTipoGasto : ICUEditarTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;

        public CUEditarTipoGasto(IRepositorioTipoGasto repoTipoGasto)
        {
            _repoTipoGasto = repoTipoGasto;
        }

        public void Editar(DTOTipoGasto dto)
        {
            TipoGasto tg = _repoTipoGasto.FindById(dto.Id);

            try
            {
                if (tg is null)
                {
                    throw new TipoGastoNoExisteException("El tipo de gasto no existe.");
                }

                if (tg.Nombre != dto.Nombre)
                {
                    if (_repoTipoGasto.FindByNombre(dto.Nombre, tg.Usuario.Id) is not null)
                    {
                        throw new TipoGastoExistenteException("Ya existe un tipo de gasto con ese nombre.");
                    }
                }

                tg.Nombre = dto.Nombre;
                tg.Activo = dto.Activo;
                tg.Validar();
                _repoTipoGasto.Update(tg);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
