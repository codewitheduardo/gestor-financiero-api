using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CEMovimiento
{
    public class MovimientoNoExisteException : Exception
    {
        public MovimientoNoExisteException() : base() 
        {
        }
        public MovimientoNoExisteException(string message) : base(message)
        {
        }
    }
}
