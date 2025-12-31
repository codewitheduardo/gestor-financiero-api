using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CETipoPago
{
    public class TipoIngresoExistenteException : Exception
    {
        public TipoIngresoExistenteException() : base()
        {
        }
        public TipoIngresoExistenteException(string message) : base(message)
        {
        }
    }
}
