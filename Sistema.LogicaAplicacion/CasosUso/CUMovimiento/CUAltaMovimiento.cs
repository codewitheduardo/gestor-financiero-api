using Sistema.DTOs.DTOs.DTOsMovimiento;
using Sistema.DTOs.Mappers;
using Sistema.LogicaAplicacion.ICasosUso.ICUMovimiento;
using Sistema.LogicaNegocio.CustomExceptions.CETipoGasto;
using Sistema.LogicaNegocio.CustomExceptions.CETipoIngreso;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUMovimiento
{
    public class CUAltaMovimiento : ICUAltaMovimiento
    {
        private IRepositorioMovimiento _repoMovimiento;
        private IRepositorioTipoIngreso _repoTipoIngreso;
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioUsuario _repoUsuario;

        public CUAltaMovimiento(IRepositorioMovimiento repoMovimiento, IRepositorioTipoIngreso repoTipoIngreso, IRepositorioTipoGasto repoTipoGasto, IRepositorioUsuario repoUsuario)
        {
            _repoMovimiento = repoMovimiento;
            _repoTipoIngreso = repoTipoIngreso;
            _repoTipoGasto = repoTipoGasto;
            _repoUsuario = repoUsuario;
        }

        public void AltaMovimiento(DTOAltaMovimiento dto)
        {
            Movimiento nuevo = MapperMovimiento.FromDTOAltaMovimientoToMovimiento(dto);
            Usuario u = _repoUsuario.FindByNombre(dto.NombreUsuario);

            if (u is null)
            {
                throw new UsuarioNoExisteException("El usuario no existe.");
            }

            nuevo.Usuario = u;
            nuevo.Validar();

            if (dto.esSalida && nuevo is Salida ms)
            {
                TipoGasto tipoGasto = _repoTipoGasto.FindById(dto.TipoGastoId);

                if (tipoGasto is null)
                {
                    throw new TipoGastoNoExisteException("El tipo de gasto no existe.");
                }

                ms.TipoGasto = tipoGasto;

            }
            else if (!dto.esSalida && nuevo is Entrada me)
            {
                TipoIngreso tipoIngreso = _repoTipoIngreso.FindById(dto.TipoIngresoId);

                if (tipoIngreso is null)
                {
                    throw new TipoIngresoNoExisteException("El tipo de ingreso no existe.");
                }

                me.TipoIngreso = tipoIngreso;
            }

            _repoMovimiento.Add(nuevo);
        }
    }
}
