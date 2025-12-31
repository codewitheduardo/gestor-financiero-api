using Microsoft.EntityFrameworkCore;
using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAccesoDatos.Repositorios
{
    public class RepositorioTipoGasto : IRepositorioTipoGasto
    {
        private ApplicationDbContext _context;

        public RepositorioTipoGasto(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(TipoGasto nuevo)
        {
            nuevo.Usuario.AgregarTiposGastos(nuevo);
            _context.TipoGastos.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<TipoGasto> FindAll()
        {
            return _context.TipoGastos.ToList();
        }

        public TipoGasto FindById(int id)
        {
            return _context.TipoGastos.Include(tg => tg.Salidas).Include(tg => tg.Usuario).Where(tg => tg.Id == id).SingleOrDefault();
        }

        public TipoGasto FindByNombre(string nombre, int usuarioId)
        {
            return _context.TipoGastos.Where(tg => tg.Nombre == nombre && tg.Usuario.Id == usuarioId).SingleOrDefault();
        }

        public List<TipoGasto> FindByUsuario(int usuarioId)
        {
            return _context.TipoGastos.Where(tg => tg.Usuario.Id == usuarioId).ToList();
        }

        public List<TipoGasto> FindByUsuarioActivos(int usuarioId)
        {
            return _context.TipoGastos.Where(tg => tg.Usuario.Id == usuarioId && tg.Activo).ToList();
        }

        public void Remove(int id)
        {
            TipoGasto tg = FindById(id);
            tg.Usuario.TiposGastos.Remove(tg);
            _context.TipoGastos.Remove(tg);
            _context.SaveChanges();
        }

        public void Update(TipoGasto obj)
        {
            _context.TipoGastos.Update(obj);
            _context.SaveChanges();
        }
    }
}
