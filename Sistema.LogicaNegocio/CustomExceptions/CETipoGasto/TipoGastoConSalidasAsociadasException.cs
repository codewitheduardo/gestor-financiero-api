using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CETipoGasto
{
    public class TipoGastoConSalidasAsociadasException : Exception
    {
        public TipoGastoConSalidasAsociadasException() : base()
        {
        }
        public TipoGastoConSalidasAsociadasException(string message) : base(message)
        {
        }
    }
}
