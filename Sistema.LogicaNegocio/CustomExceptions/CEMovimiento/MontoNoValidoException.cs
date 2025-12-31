using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CEMovimiento
{
    public class MontoNoValidoException : Exception
    {
        public MontoNoValidoException() : base()
        {
        }
        public MontoNoValidoException(string message) : base(message)
        {
        }
    }
}
