using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.DTOs.DTOs.DTOsMovimiento
{
    public class DTOMovimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoUYU { get; set; }
        public string Moneda { get; set; }
        public string Descripcion { get; set; }
        public string TipoMovimiento { get; set; }
        public string NombreUsuario { get; set; }

        // -- Para salidas
        public string NombreTipoGasto { get; set; }
        public int? TipoGastoId { get; set; }

        // -- Para ingresos
        public string NombreTipoIngreso { get; set; }
        public int? TipoIngresoId { get; set; }
    }
}
