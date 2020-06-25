using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EntityFrameworkUnitTestingWithAspNetWebApi.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext _context { get; set; }

        public BaseRepository(DbContext context)
        {
            this._context = context;
        }

        public IQueryable<T> FindAll()
        {
            return this._context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this._context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
