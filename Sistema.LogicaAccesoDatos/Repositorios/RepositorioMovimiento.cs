using Microsoft.EntityFrameworkCore;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAccesoDatos.Repositorios
{
    public class RepositorioMovimiento : IRepositorioMovimiento
    {
        private ApplicationDbContext _context;

        public RepositorioMovimiento(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Movimiento nuevo)
        {
            nuevo.Usuario.AgregarMovimiento(nuevo);
            _context.Movimientos.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Movimiento> FindAll()
        {
            return _context.Movimientos.ToList();
        }

        public Movimiento FindById(int id)
        {
            return _context.Movimientos.Include(m => m.Usuario).Where(m => m.Id == id).SingleOrDefault();
        }

        public List<Movimiento> FindByUsuario(string nombreUsuario)
        {
            var entradas = _context.Set<Entrada>()
                .Include(e => e.Usuario)
                .Include(e => e.TipoIngreso)
                .Where(e => e.Usuario.NombreUsuario == nombreUsuario)
                .AsNoTracking()
                .ToList();

            var salidas = _context.Set<Salida>()
                .Include(s => s.Usuario)
                .Include(s => s.TipoGasto)
                .Where(s => s.Usuario.NombreUsuario == nombreUsuario)
                .AsNoTracking()
                .ToList();

            var retorno = entradas.Cast<Movimiento>()
                .Concat(salidas)
                .OrderByDescending(m => m.Fecha)
                .ThenByDescending(m => m.Id)
                .ToList();

            return retorno;
        }

        public List<Movimiento> FindByUsuarioPorMesAnio(
    string nombreUsuario,
    int mes,
    int anio)
        {
            var desde = new DateTime(anio, mes, 1);
            var hasta = desde.AddMonths(1);

            var entradas = _context.Set<Entrada>()
                .Include(e => e.Usuario)
                .Include(e => e.TipoIngreso)
                .Where(e =>
                    e.Usuario.NombreUsuario == nombreUsuario &&
                    e.Fecha >= desde &&
                    e.Fecha < hasta
                )
                .AsNoTracking()
                .ToList();   

            var salidas = _context.Set<Salida>()
                .Include(s => s.Usuario)
                .Include(s => s.TipoGasto)
                .Where(s =>
                    s.Usuario.NombreUsuario == nombreUsuario &&
                    s.Fecha >= desde &&
                    s.Fecha < hasta
                )
                .AsNoTracking()
                .ToList();   

            return entradas
                .Cast<Movimiento>()
                .Concat(salidas)
                .OrderByDescending(m => m.Fecha)
                .ThenByDescending(m => m.Id)
                .ToList();
        }

        public void Remove(int id)
        {
            Movimiento m = FindById(id);
            m.Usuario.Movimientos.Remove(m);
            _context.Movimientos.Remove(m);
            _context.SaveChanges();
        }

        public void Update(Movimiento obj)
        {
            _context.Movimientos.Update(obj);
            _context.SaveChanges();
        }
    }
}
