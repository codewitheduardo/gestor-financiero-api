using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioTipoGasto : IRepositorio<TipoGasto>
    {
        TipoGasto FindByNombre(string nombre, int usuarioId);
        List<TipoGasto> FindByUsuario(int usuarioId);
        List<TipoGasto> FindByUsuarioActivos(int usuarioId);
    }
}
