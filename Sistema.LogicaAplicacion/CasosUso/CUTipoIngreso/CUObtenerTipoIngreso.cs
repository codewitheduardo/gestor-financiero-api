using Sistema.DTOs.DTOs.DTOsTipoGasto;
using Sistema.DTOs.DTOs.DTOsTipoIngreso;
using Sistema.DTOs.Mappers;
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
    public class CUObtenerTipoIngreso : ICUObtenerTipoIngreso
    {
        private IRepositorioTipoIngreso _repoTipoIngreso;

        public CUObtenerTipoIngreso(IRepositorioTipoIngreso repoTipoIngreso)
        {
            _repoTipoIngreso = repoTipoIngreso;
        }

        public DTOTipoIngreso ObtenerTipoIngreso(int id)
        {
            TipoIngreso ti = _repoTipoIngreso.FindById(id);

            if (ti is null)
            {
                throw new TipoIngresoNoExisteException("El tipo de ingreso con el id especificado no existe.");
            }

            DTOTipoIngreso retorno = MapperTipoIngreso.FromTipoIngresoToDTOTipoIngreso(ti);

            return retorno;
        }
    }
}
