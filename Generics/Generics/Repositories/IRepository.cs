using Generics.Generics.Entities;
using System.Collections.Generic;

namespace Generics.Generics.Repositories
{

    public interface IReadRepository<out T> {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }



    public interface IRepository<T> : IReadRepository<T> where T : EntityBase
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }
}