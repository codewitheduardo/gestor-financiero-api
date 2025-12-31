using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.CustomExceptions.CEUsuario
{
    public class UsuarioYaExisteException : Exception
    {
        public UsuarioYaExisteException() : base()
        {
        }
        public UsuarioYaExisteException(string message) : base(message)
        {
        }
    }
}
