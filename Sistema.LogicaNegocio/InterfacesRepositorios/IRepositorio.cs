using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T> where T : class
    {
        int Add(T nuevo);
        T FindById(int id);
        List<T> FindAll();
        void Update(T obj);
        void Remove(int id);
    }
}
