using Sistema.LogicaNegocio.CustomExceptions.CECompartidos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.Entidades
{
    public class TipoIngreso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public Usuario Usuario { get; set; }
        public List<Entrada> Entradas { get; set; }

        public void Validar()
        {
            ValidarNombre();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new NombreNoValidoException("El nombre no puede ser nulo o vacío.");
            }

            Nombre = Nombre.Trim();

            if (Nombre.Length < 3)
            {
                throw new NombreNoValidoException("El nombre debe tener al menos 3 caracteres.");
            }
            if (Nombre.Length > 50)
            {
                throw new NombreNoValidoException("El nombre no puede exceder los 50 caracteres.");
            }
        }
    }
}
