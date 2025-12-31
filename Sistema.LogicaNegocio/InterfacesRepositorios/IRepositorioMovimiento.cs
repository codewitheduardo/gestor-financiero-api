using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioMovimiento : IRepositorio<Movimiento>
    {
        List<Movimiento> FindByUsuario(string nombreUsuario);
        List<Movimiento> FindByUsuarioPorMesAnio(string nombreUsuario, int mes, int anio);
    }
}
