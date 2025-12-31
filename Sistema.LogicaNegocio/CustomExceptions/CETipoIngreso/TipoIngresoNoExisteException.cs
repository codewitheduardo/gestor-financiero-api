using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CETipoIngreso
{
    public class TipoIngresoNoExisteException : Exception
    {
        public TipoIngresoNoExisteException() : base()
        {
        }
        public TipoIngresoNoExisteException(string message) : base(message)
        {
        }
    }
}
