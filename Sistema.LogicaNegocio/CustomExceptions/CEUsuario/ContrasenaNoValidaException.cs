using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CEUsuario
{
    public class ContrasenaNoValidaException : Exception
    {
        public ContrasenaNoValidaException() : base()
        {
        }

        public ContrasenaNoValidaException(string message) : base(message)
        {
        }
    }
}
