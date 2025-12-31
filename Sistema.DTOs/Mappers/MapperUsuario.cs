using Sistema.DTOs.DTOs.DTOsUsuario;
using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.DTOs.Mappers
{
    public class MapperUsuario
    {
        public static Usuario FromDTOAltaUsuarioToUsuario(DTOAltaUsuario dto)
        {
            Usuario u = new Usuario();

            u.NombreUsuario = dto.NombreUsuario;
            u.Contrasena = dto.Contrasena;

            return u;
        }

        public static DTOUsuario FromUsuarioToDTOUsuario(Usuario u)
        {
            DTOUsuario dto = new DTOUsuario();

            dto.Id = u.Id;
            dto.NombreUsuario = u.NombreUsuario;

            return dto;
        }
    }
}
