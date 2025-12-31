using Sistema.DTOs.DTOs.DTOsTipoGasto;
using Sistema.DTOs.Mappers;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Sistema.LogicaNegocio.CustomExceptions.CETipoGasto;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUTipoGasto
{
    public class CUAltaTipoGasto : ICUAltaTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioUsuario _repoUsuario;

        public CUAltaTipoGasto(IRepositorioTipoGasto repoTipoGasto, IRepositorioUsuario repoUsuario)
        {
            _repoTipoGasto = repoTipoGasto;
            _repoUsuario = repoUsuario;
        }

        public void AltaTipoGasto(DTOAltaTipoGasto dto)
        {
            Usuario u = _repoUsuario.FindByNombre(dto.NombreUsuario);

            if (u is null)
            {
                throw new UsuarioNoExisteException("El usuario no existe.");
            }

            if (_repoTipoGasto.FindByNombre(dto.Nombre, u.Id) is not null)
            {
                throw new TipoGastoExistenteException("Ya existe un tipo de gasto con ese nombre.");
            }

            TipoGasto tg = MapperTipoGasto.FromDTOAltaTipoGastoToTipoGasto(dto);
            tg.Usuario = u;
            tg.Validar();
            _repoTipoGasto.Add(tg);
        }
    }
}
