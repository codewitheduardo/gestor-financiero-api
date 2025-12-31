using Microsoft.EntityFrameworkCore;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAccesoDatos.Repositorios
{
    public class RepositorioTipoIngreso : IRepositorioTipoIngreso
    {
        private ApplicationDbContext _context;

        public RepositorioTipoIngreso(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(TipoIngreso nuevo)
        {
            nuevo.Usuario.AgregarTiposIngresos(nuevo);
            _context.TipoIngresos.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<TipoIngreso> FindAll()
        {
            return _context.TipoIngresos.ToList();
        }

        public TipoIngreso FindById(int id)
        {
            return _context.TipoIngresos.Include(ti => ti.Entradas).Include(tg => tg.Usuario).Where(ti => ti.Id == id).SingleOrDefault();
        }

        public TipoIngreso FindByNombre(string nombre, int usuarioId)
        {
            return _context.TipoIngresos.Where(ti => ti.Nombre == nombre && ti.Usuario.Id == usuarioId).SingleOrDefault();
        }

        public List<TipoIngreso> FindByUsuario(int usuarioId)
        {
            return _context.TipoIngresos.Where(ti => ti.Usuario.Id == usuarioId).ToList();
        }

        public List<TipoIngreso> FindByUsuarioActivos(int usuarioId)
        {
            return _context.TipoIngresos.Where(ti => ti.Usuario.Id == usuarioId && ti.Activo).ToList();
        }

        public void Remove(int id)
        {
            TipoIngreso ti = FindById(id);
            ti.Usuario.TiposIngresos.Remove(ti);
            _context.TipoIngresos.Remove(ti);
            _context.SaveChanges();
        }

        public void Update(TipoIngreso obj)
        {
            _context.TipoIngresos.Update(obj);
            _context.SaveChanges();
        }
    }
}
