using Sistema.DTOs.DTOs.DTOsTipoGasto;
using Sistema.DTOs.Mappers;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUTipoGasto
{
    public class CUObtenerTipoGastosActivos : ICUObtenerTipoGastosActivos
    {
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioUsuario _repoUsuario;

        public CUObtenerTipoGastosActivos(IRepositorioTipoGasto repoTipoGasto, IRepositorioUsuario repoUsuario)
        {
            _repoTipoGasto = repoTipoGasto;
            _repoUsuario = repoUsuario;
        }

        public List<DTOTipoGasto> ObtenerTipoGastosActivos(string nombreUsuario)
        {
            Usuario u = _repoUsuario.FindByNombre(nombreUsuario);

            if (u is null)
            {
                throw new UsuarioNoExisteException("El usuario no existe.");
            }

            List<TipoGasto> tiposGastosActivos = _repoTipoGasto.FindByUsuarioActivos(u.Id);

            List<DTOTipoGasto> retorno = MapperTipoGasto.FromListTipoGastoToListDTOTipoGasto(tiposGastosActivos);

            return retorno;
        }
    }
}
