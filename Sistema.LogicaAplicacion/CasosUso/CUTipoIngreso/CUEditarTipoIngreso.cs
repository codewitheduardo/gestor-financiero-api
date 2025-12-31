using Sistema.DTOs.DTOs.DTOsTipoIngreso;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoIngreso;
using Sistema.LogicaNegocio.CustomExceptions.CETipoGasto;
using Sistema.LogicaNegocio.CustomExceptions.CETipoIngreso;
using Sistema.LogicaNegocio.CustomExceptions.CETipoPago;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUTipoIngreso
{
    public class CUEditarTipoIngreso : ICUEditarTipoIngreso
    {
        private IRepositorioTipoIngreso _repoTipoIngreso;

        public CUEditarTipoIngreso(IRepositorioTipoIngreso repoTipoIngreso)
        {
            _repoTipoIngreso = repoTipoIngreso;
        }

        public void Editar(DTOTipoIngreso dto)
        {
            TipoIngreso ti = _repoTipoIngreso.FindById(dto.Id);

            try
            {
                if (ti is null)
                {
                    throw new TipoIngresoNoExisteException("El tipo de ingreso no existe.");
                }

                if (ti.Nombre != dto.Nombre)
                {
                    if (_repoTipoIngreso.FindByNombre(dto.Nombre, ti.Usuario.Id) is not null)
                    {
                        throw new TipoIngresoExistenteException("Ya existe un tipo de ingreso con ese nombre.");
                    }
                }

                ti.Nombre = dto.Nombre;
                ti.Activo = dto.Activo;
                ti.Validar();
                _repoTipoIngreso.Update(ti);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
