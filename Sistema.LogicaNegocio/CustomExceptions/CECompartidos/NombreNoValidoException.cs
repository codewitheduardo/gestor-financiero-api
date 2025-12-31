using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CECompartidos
{
    public class NombreNoValidoException : Exception
    {
        public NombreNoValidoException() : base()
        {
        }
        public NombreNoValidoException(string message) : base(message)
        {
        }
    }
}
