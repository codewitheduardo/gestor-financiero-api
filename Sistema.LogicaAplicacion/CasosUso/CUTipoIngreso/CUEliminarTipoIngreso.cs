using Sistema.LogicaAplicacion.ICasosUso.ICUTipoIngreso;
using Sistema.LogicaNegocio.CustomExceptions.CETipoGasto;
using Sistema.LogicaNegocio.CustomExceptions.CETipoIngreso;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUTipoIngreso
{
    public class CUEliminarTipoIngreso : ICUEliminarTipoIngreso
    {
        private IRepositorioTipoIngreso _repoTipoIngreso;

        public CUEliminarTipoIngreso(IRepositorioTipoIngreso repoTipoIngreso)
        {
            _repoTipoIngreso = repoTipoIngreso;
        }

        public void Eliminar(int tipoIngresoId)
        {
           TipoIngreso ti = _repoTipoIngreso.FindById(tipoIngresoId);

            try
            {
                if (ti is null)
                {
                    throw new TipoIngresoNoExisteException("El tipo de ingreso no existe.");
                }

                if (ti.Entradas.Count > 0)
                {
                    throw new TipoIngresoConEntradasAsociadasException("No se puede eliminar el tipo de ingreso porque tiene entradas asociadas.");
                }

                _repoTipoIngreso.Remove(ti.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
