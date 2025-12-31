using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CEUsuario
{
    public class UsuarioNoExisteException : Exception
    {
        public UsuarioNoExisteException() : base()
        {
        }
        public UsuarioNoExisteException(string message) : base(message)
        {
        }
    }
}
