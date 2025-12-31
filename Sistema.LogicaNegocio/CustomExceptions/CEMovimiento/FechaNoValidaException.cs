using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CEMovimiento
{
    public class FechaNoValidaException : Exception
    {
        public FechaNoValidaException() : base()
        {
        }

        public FechaNoValidaException(string message) : base(message)
        {
        }
    }
}
