using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CECompartidos
{
    public class DatosNoValidosException : Exception
    {
        public DatosNoValidosException() : base()
        {
        }
        public DatosNoValidosException(string message) : base(message)
        {
        }
    }
}
