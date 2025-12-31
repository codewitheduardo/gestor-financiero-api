using Sistema.DTOs.DTOs.DTOsMovimiento;
using Sistema.DTOs.Mappers;
using Sistema.LogicaAplicacion.ICasosUso.ICUMovimiento;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAplicacion.CasosUso.CUMovimiento
{
    public class CUObtenerMovimientosPorMesAnio : ICUObtenerMovimientosPorMesAnio
    {
        private IRepositorioMovimiento _repoMovimiento;
        private ICUObtenerCotizacionUYU _cuCotizacion;

        public CUObtenerMovimientosPorMesAnio(IRepositorioMovimiento repoMovimiento, ICUObtenerCotizacionUYU cuCotizacion)
        {
            _repoMovimiento = repoMovimiento;
            _cuCotizacion = cuCotizacion;
        }

        public async Task<List<DTOMovimiento>> ObtenerMovimientosPorMesAnioAsync(string nombreUsuario, int mes, int anio)
        {
            List<Movimiento> movimientos = _repoMovimiento.FindByUsuarioPorMesAnio(nombreUsuario, mes, anio);

            var listaDTO = MapperMovimiento.FromListMovimientoToListDTOMovimiento(movimientos);

            foreach (var dto in listaDTO)
            {
                var monedaEnum = Enum.Parse<Moneda>(dto.Moneda);

                var rate = await _cuCotizacion.EjecutarAsync(monedaEnum);

                dto.MontoUYU = dto.Monto * rate;
            }

            return listaDTO;
        }
    }
}
