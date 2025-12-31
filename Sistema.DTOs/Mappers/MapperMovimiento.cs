using Sistema.DTOs.DTOs.DTOsMovimiento;
using Sistema.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.DTOs.Mappers
{
    public class MapperMovimiento
    {
        public static Movimiento FromDTOAltaMovimientoToMovimiento(DTOAltaMovimiento dto)
        {
            if (dto.esSalida)
            {
                Salida ms = new Salida();

                ms.Descripcion = dto.Descripcion;
                ms.Fecha = dto.Fecha;
                ms.Monto = dto.Monto;

                if (dto.Moneda == "UYU")
                {
                    ms.Moneda = Moneda.UYU;
                }
                else if (dto.Moneda == "USD")
                {
                    ms.Moneda = Moneda.USD;
                }
                else if (dto.Moneda == "EUR")
                {
                    ms.Moneda = Moneda.EUR;
                }
                else if (dto.Moneda == "ARS")
                {
                    ms.Moneda = Moneda.ARS;
                }
                else if (dto.Moneda == "BRL")
                {
                    ms.Moneda = Moneda.BRL;
                }


                return ms;
            }
            else
            {
                Entrada mi = new Entrada();

                mi.Descripcion = dto.Descripcion;
                mi.Fecha = dto.Fecha;
                mi.Monto = dto.Monto;

                if (dto.Moneda == "UYU")
                {
                    mi.Moneda = Moneda.UYU;
                }
                else if (dto.Moneda == "USD")
                {
                    mi.Moneda = Moneda.USD;
                }
                else if (dto.Moneda == "EUR")
                {
                    mi.Moneda = Moneda.EUR;
                }
                else if (dto.Moneda == "ARS")
                {
                    mi.Moneda = Moneda.ARS;
                }
                else if (dto.Moneda == "BRL")
                {
                    mi.Moneda = Moneda.BRL;
                }

                return mi;
            }
        }

        public static DTOMovimiento FromMovimientoToDTOMovimiento(Movimiento m)
        {
            DTOMovimiento dto = new DTOMovimiento();

            dto.Id = m.Id;
            dto.Fecha = m.Fecha;
            dto.Monto = m.Monto;
            dto.Moneda = m.Moneda.ToString();
            dto.Descripcion = m.Descripcion;
            dto.TipoMovimiento = (m is Salida) ? "Salida" : "Entrada";
            dto.NombreUsuario = m.Usuario.NombreUsuario;
            dto.NombreTipoGasto = (m is Salida ms) ? ms.TipoGasto.Nombre : "NO APLICA";
            dto.NombreTipoIngreso = (m is Entrada me) ? me.TipoIngreso.Nombre : "NO APLICA";
            dto.TipoGastoId = (m is Salida ms2) ? ms2.TipoGasto.Id : null;
            dto.TipoIngresoId = (m is Entrada me2) ? me2.TipoIngreso.Id : null;

            return dto;
        }

        public static List<DTOMovimiento> FromListMovimientoToListDTOMovimiento(List<Movimiento> listaMovimientos)
        {
            List<DTOMovimiento> retorno = new List<DTOMovimiento>();

            foreach (var m in listaMovimientos)
            {
                retorno.Add(FromMovimientoToDTOMovimiento(m));
            }

            return retorno;
        }
    }
}
