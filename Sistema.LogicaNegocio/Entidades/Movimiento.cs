using Sistema.LogicaNegocio.CustomExceptions.CECompartidos;
using Sistema.LogicaNegocio.CustomExceptions.CEMoneda;
using Sistema.LogicaNegocio.CustomExceptions.CEMovimiento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.Entidades
{
    public abstract class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public Usuario Usuario { get; set; }
        public string Descripcion { get; set; }
        public Moneda Moneda { get; set; }

        public void Validar()
        {
            ValidarMonto();
            ValidarDescripcion();
            ValidarMoneda();
        }

        private void ValidarMoneda()
        {
            if (!Enum.IsDefined(typeof(Moneda), Moneda))
            {
                throw new MonedaNoValidaException("Moneda inválida.");
            }
        }

        private void ValidarMonto()
        {
            if (Monto < 0)
            {
                throw new MontoNoValidoException("El monto no puede ser negativo.");
            }
        }

        private void ValidarDescripcion()
        {
            if (Descripcion.Length > 200)
            {
                throw new DescripcionNoValidaException("La descripción no puede exceder los 200 caracteres.");
            }
        }
    }
}
