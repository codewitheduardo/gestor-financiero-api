using Sistema.DTOs.DTOs.DTOsTipoIngreso;
using Sistema.DTOs.Mappers;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoIngreso;
using Sistema.LogicaNegocio.CustomExceptions.CETipoPago;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUTipoIngreso
{
    public class CUAltaTipoIngreso : ICUAltaTipoIngreso
    {
        private IRepositorioTipoIngreso _repoTipoIngreso;
        private IRepositorioUsuario _repoUsuario;

        public CUAltaTipoIngreso(IRepositorioTipoIngreso repoTipoIngreso, IRepositorioUsuario repoUsuario)
        {
            _repoTipoIngreso = repoTipoIngreso;
            _repoUsuario = repoUsuario;
        }

        public void AltaTipoIngreso(DTOAltaTipoIngreso dto)
        {
            Usuario u = _repoUsuario.FindByNombre(dto.NombreUsuario);

            if (u is null)
            {
                throw new UsuarioNoExisteException("El usuario no existe.");
            }

            if (_repoTipoIngreso.FindByNombre(dto.Nombre, u.Id) is not null)
            {
                throw new TipoIngresoExistenteException("Ya existe un tipo de ingreso con ese nombre.");
            }

            TipoIngreso ti = MapperTipoIngreso.FromDTOAltaTipoIngresoToTipoIngreso(dto);
            ti.Usuario = u;
            ti.Validar();
            _repoTipoIngreso.Add(ti);
        }
    }
}
