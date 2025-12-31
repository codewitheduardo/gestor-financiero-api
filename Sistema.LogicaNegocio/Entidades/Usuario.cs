using Sistema.LogicaNegocio.CustomExceptions.CECompartidos;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public List<Movimiento> Movimientos { get; set; }
        public List<TipoGasto> TiposGastos { get; set; }
        public List<TipoIngreso> TiposIngresos { get; set; }

        public void Validar()
        {
            ValidarNombreUsuario();
        }

        private void ValidarNombreUsuario()
        {
            if (string.IsNullOrWhiteSpace(NombreUsuario))
            {
                throw new NombreNoValidoException("El nombre de usuario no puede ser nulo o vacío.");
            }

            NombreUsuario = NombreUsuario.Trim();

            if (NombreUsuario.Length < 3)
            {
                throw new NombreNoValidoException("El nombre de usuario debe tener al menos 3 caracteres.");
            }
            if (NombreUsuario.Length > 20)
            {
                throw new NombreNoValidoException("El nombre de usuario no puede exceder los 20 caracteres.");
            }
        }

        public void AgregarMovimiento(Movimiento movimiento)
        {
            if (Movimientos == null)
            {
                Movimientos = new List<Movimiento>();
            }

            movimiento.Usuario = this;
            Movimientos.Add(movimiento);
        }

        public void AgregarTiposGastos(TipoGasto tipoGasto)
        {
            if (TiposGastos == null)
            {
                TiposGastos = new List<TipoGasto>();
            }

            tipoGasto.Usuario = this;
            TiposGastos.Add(tipoGasto);
        }

        public void AgregarTiposIngresos(TipoIngreso tipoIngreso)
        {
            if (TiposIngresos == null)
            {
                TiposIngresos = new List<TipoIngreso>();
            }

            tipoIngreso.Usuario = this;
            TiposIngresos.Add(tipoIngreso);
        }
    }
}
