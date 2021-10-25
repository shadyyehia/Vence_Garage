using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private DbContext _context = null;
        //temp dataSet 
        protected DbSet<T> _table = null;

        public RepositoryBase(DbContext context)
        {
            this._context = context;
            _table = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsNoTracking();
        }
        public T GetById(object id)
        {
            return _table.Find(id);
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).AsNoTracking();
        }

        public void Create(T obj)
        { 
            _table.Add(obj);
        }
        public void Update(T obj)
        {
            _table.Update(obj);
        }
        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }
        public void Save()
        {

            _context.SaveChanges();

        }
    }
}
