using Sistema.DTOs.DTOs.DTOsTipoGasto;
using Sistema.DTOs.DTOs.DTOsTipoIngreso;
using Sistema.DTOs.Mappers;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoIngreso;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUTipoIngreso
{
    public class CUObtenerTipoIngresos : ICUObtenerTipoIngresos
    {
        private IRepositorioTipoIngreso _repoTipoIngreso;
        private IRepositorioUsuario _repoUsuario;

        public CUObtenerTipoIngresos(IRepositorioTipoIngreso repoTipoIngreso, IRepositorioUsuario repoUsuario)
        {
            _repoTipoIngreso = repoTipoIngreso;
            _repoUsuario = repoUsuario;
        }

        public List<DTOTipoIngreso> ObtenerTipoIngresos(string nombreUsuario)
        {
            Usuario u = _repoUsuario.FindByNombre(nombreUsuario);

            if (u is null)
            {
                throw new UsuarioNoExisteException("El usuario no existe.");
            }

            List<TipoIngreso> tiposIngresos = _repoTipoIngreso.FindByUsuario(u.Id);

            List<DTOTipoIngreso> retorno = MapperTipoIngreso.FromListTipoIngresoToListDTOTipoIngreso(tiposIngresos);

            return retorno;
        }
    }
}
