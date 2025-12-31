using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CETipoGasto
{
    public class TipoGastoNoExisteException : Exception
    {
        public TipoGastoNoExisteException() : base()
        {
        }
        public TipoGastoNoExisteException(string message) : base(message)
        {
        }
    }
}
