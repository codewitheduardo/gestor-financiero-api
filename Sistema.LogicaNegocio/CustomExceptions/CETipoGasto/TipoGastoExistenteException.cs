using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CETipoGasto
{
    public class TipoGastoExistenteException : Exception
    {
        public TipoGastoExistenteException() : base()
        {
        }
        public TipoGastoExistenteException(string message) : base(message)
        {
        }
    }
}
