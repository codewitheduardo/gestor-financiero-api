using Sistema.DTOs.DTOs.DTOsUsuario;
using Sistema.DTOs.Mappers;
using Sistema.LogicaAplicacion.ICasosUso.ICUUsuario;
using Sistema.LogicaNegocio.CustomExceptions.CECompartidos;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CULogin : ICULogin
    {
        private IRepositorioUsuario _repoUsuario;

        public CULogin(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public DTOUsuario VerificarExistencia(DTOLogin dto)
        {
            Usuario u = _repoUsuario.FindByNombre(dto.NombreUsuario);

            if (u is not null)
            {
                if (Utilidades.Crypto.VerificarHashBcrypt(dto.Contrasena, u.Contrasena))
                {
                    return MapperUsuario.FromUsuarioToDTOUsuario(u);
                }
            }
            throw new DatosNoValidosException("Nombre de usuario o contraseña incorrectos.");
        }
    }
}
