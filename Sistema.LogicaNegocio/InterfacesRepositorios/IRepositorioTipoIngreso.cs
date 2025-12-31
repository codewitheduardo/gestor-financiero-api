using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioTipoIngreso : IRepositorio<TipoIngreso>
    {
        TipoIngreso FindByNombre(string nombre, int usuarioId);

        List<TipoIngreso> FindByUsuario(int usuarioId);

        List<TipoIngreso> FindByUsuarioActivos(int usuarioId);
    }
}
