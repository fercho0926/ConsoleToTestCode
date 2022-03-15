using Generics.Generics.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Generics.Generics.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> _dbset;

        public SqlRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            _dbset = dbContext.Set<T>();

        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetById(int id) => _dbset.Find(id);

        public void Add(T item)
        {
            _dbset.Add(item);

        }

        public void Save()
        {
            dbContext.SaveChanges();

        }

        public void Remove(T item)
        {
            _dbset.Remove(item);
        }
    }

}
