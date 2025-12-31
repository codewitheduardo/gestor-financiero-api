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
    public class CUObtenerMovimientos : ICUObtenerMovimientos
    {
        private IRepositorioMovimiento _repoMovimiento;
        private ICUObtenerCotizacionUYU _cuCotizacion;

        public CUObtenerMovimientos(IRepositorioMovimiento repoMovimiento, ICUObtenerCotizacionUYU cuCotizacion)
        {
            _repoMovimiento = repoMovimiento;
            _cuCotizacion = cuCotizacion;
        }

        public async Task<List<DTOMovimiento>> ObtenerMovimientosAsync(string nombreUsuario)
        {
            List<Movimiento> movimientos = _repoMovimiento.FindByUsuario(nombreUsuario);

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
