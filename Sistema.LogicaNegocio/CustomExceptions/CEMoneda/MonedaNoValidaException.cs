using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CEMoneda
{
    public class MonedaNoValidaException : Exception
    {
        public MonedaNoValidaException() : base()
        {
        }
        public MonedaNoValidaException(string message) : base(message)
        {
        }
    }
}
