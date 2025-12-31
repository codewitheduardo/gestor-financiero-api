using Sistema.DTOs.DTOs.DTOsUsuario;
using Sistema.DTOs.Mappers;
using Sistema.LogicaAplicacion.ICasosUso.ICUUsuario;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using Sistema.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private IRepositorioUsuario _repoUsuario;

        public CUAltaUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public void AltaUsuario(DTOAltaUsuario dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Contrasena) || dto.Contrasena.Length < 6)
                {
                    throw new ContrasenaNoValidaException("La contraseña debe tener al menos 6 caracteres");
                }

                if (_repoUsuario.FindByNombre(dto.NombreUsuario) is not null)
                {
                    throw new UsuarioYaExisteException($"El usuario '{dto.NombreUsuario}' ya existe");
                }

                Usuario nuevo = MapperUsuario.FromDTOAltaUsuarioToUsuario(dto);
                nuevo.Contrasena = Crypto.HashConBcrypt(nuevo.Contrasena, 10);
                nuevo.Validar();

                _repoUsuario.Add(nuevo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
