using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CECompartidos
{
    public class DescripcionNoValidaException : Exception
    {
        public DescripcionNoValidaException() : base()
        {
        }
        public DescripcionNoValidaException(string message) : base(message)
        {
        }
    }
}
