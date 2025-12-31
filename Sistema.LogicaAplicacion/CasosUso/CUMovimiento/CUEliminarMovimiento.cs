using Sistema.LogicaAplicacion.ICasosUso.ICUMovimiento;
using Sistema.LogicaNegocio.CustomExceptions.CEMovimiento;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUMovimiento
{
    public class CUEliminarMovimiento : ICUEliminarMovimieno
    {
        private IRepositorioMovimiento _repoMovimiento;

        public CUEliminarMovimiento(IRepositorioMovimiento repoMovimiento)
        {
            _repoMovimiento = repoMovimiento;
        }

        public void EliminarMovimiento(int idMovimiento)
        {
            Movimiento m = _repoMovimiento.FindById(idMovimiento);

            try
            {
                if (m is null)
                {
                    throw new MovimientoNoExisteException("El movimiento no existe.");
                }

                _repoMovimiento.Remove(m.Id);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el movimiento: " + ex.Message);
            }
        }
    }
}
