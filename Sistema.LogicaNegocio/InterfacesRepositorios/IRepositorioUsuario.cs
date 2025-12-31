using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario FindByNombre(string nombre);
    }
}
