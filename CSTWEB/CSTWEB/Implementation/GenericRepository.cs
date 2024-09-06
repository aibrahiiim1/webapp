using CST_Web.Data;
using CSTWEB.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CSTWEB.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _Context;
        private DbSet<T> _dbSet;
        public GenericRepository(ApplicationDBContext Context)
        {
            _Context=Context;
            _dbSet=_Context.Set<T>();
        }
        public void Add(T entity)
        {
            //Categories.Add(Category)
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate=null, string? Includeword = null)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null) 
            {
                query = query.Where(predicate);
            }
            if (Includeword != null) 
            {
                //_context.Category.Include("product,users,family")
                foreach (var item in Includeword.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query=query.Include(item);
                }
            }
            return query.ToList();
        }

        public T GetFirstorDefault(Expression<Func<T, bool>>? predicate=null, string? Includeword=null)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (Includeword != null)
            {
                //_context.Category.Include("product,users,family")
                foreach (var item in Includeword.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.SingleOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
