using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Text.Json.Serialization;

namespace Sistema.DTOs.DTOs.DTOsMovimiento
{
    public class DTOAltaMovimiento
    {
        public bool esSalida { get; set; }
        public string Moneda { get; set; }

        [JsonIgnore]     // No aparece en el JSON
        [BindNever]      // El cliente no puede enviarlo
        [ValidateNever]  // No se valida automáticamente
        public string NombreUsuario { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        // -- Para salidas
        public int TipoGastoId { get; set; }

        // -- Para ingresos
        public int TipoIngresoId { get; set; }
    }
}
