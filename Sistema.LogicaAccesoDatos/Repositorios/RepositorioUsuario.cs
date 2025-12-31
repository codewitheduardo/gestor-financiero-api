using Sistema.LogicaNegocio.Entidades;
using Sistema.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ApplicationDbContext _context;

        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Usuario nuevo)
        {
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Usuario> FindAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
        }

        public Usuario FindByNombre(string nombre)
        {
            return _context.Usuarios.Where(u => u.NombreUsuario == nombre).SingleOrDefault();
        }

        public void Remove(int id)
        {
            _context.Usuarios.Remove(FindById(id));
            _context.SaveChanges();
        }

        public void Update(Usuario obj)
        {
            _context.Usuarios.Update(obj);
            _context.SaveChanges();
        }


    }
}
