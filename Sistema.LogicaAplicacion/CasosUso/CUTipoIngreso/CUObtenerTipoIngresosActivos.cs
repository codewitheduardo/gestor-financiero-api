using Sistema.DTOs.DTOs.DTOsTipoGasto;
using Sistema.DTOs.DTOs.DTOsTipoIngreso;
using Sistema.DTOs.Mappers;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoIngreso;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUTipoIngreso
{
    public class CUObtenerTipoIngresosActivos : ICUObtenerTipoIngresosActivos
    {
        private IRepositorioTipoIngreso _repoTipoIngreso;
        private IRepositorioUsuario _repoUsuario;

        public CUObtenerTipoIngresosActivos(IRepositorioTipoIngreso repoTipoIngreso, IRepositorioUsuario repoUsuario)
        {
            _repoTipoIngreso = repoTipoIngreso;
            _repoUsuario = repoUsuario;
        }

        public List<DTOTipoIngreso> ObtenerTipoIngresosActivos(string nombreUsuario)
        {
            Usuario u = _repoUsuario.FindByNombre(nombreUsuario);

            if (u is null)
            {
                throw new UsuarioNoExisteException("El usuario no existe.");
            }

            List<TipoIngreso> tiposIngresosActivos = _repoTipoIngreso.FindByUsuarioActivos(u.Id);

            List<DTOTipoIngreso> retorno = MapperTipoIngreso.FromListTipoIngresoToListDTOTipoIngreso(tiposIngresosActivos);

            return retorno;
        }
    }
}
