using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CETipoIngreso
{
    public class TipoIngresoConEntradasAsociadasException : Exception
    {
        public TipoIngresoConEntradasAsociadasException() : base()
        {
        }
        public TipoIngresoConEntradasAsociadasException(string message) : base(message)
        {
        }
    }
}
