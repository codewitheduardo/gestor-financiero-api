using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sistema.DTOs.DTOs.DTOsTipoIngreso
{
    public class DTOAltaTipoIngreso
    {
        public string Nombre { get; set; }
        [JsonIgnore]     // No aparece en el JSON
        [BindNever]      // El cliente no puede enviarlo
        [ValidateNever]  // No se valida automáticamente
        public string NombreUsuario { get; set; }
    }
}
