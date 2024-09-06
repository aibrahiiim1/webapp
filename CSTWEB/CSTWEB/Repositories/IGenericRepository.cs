using System.Linq.Expressions;

namespace CSTWEB.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        //_context.Categories.ToList();
        //_context.Categories.Include("Categories").ToList();
        //_context.Categories.Where(x=>x.Id==id).ToList();
        IEnumerable<T> GetAll(Expression<Func<T,bool>>? predicate=null,string? Includeword = null);
        //_context.Categories.ToList();
        //_context.Categories.Include("Categories").ToSingleOrDefault();
        //_context.Categories.Where(x=>x.Id==id).ToSingleOrDefault();
        T GetFirstorDefault(Expression<Func<T, bool>>? predicate=null, string? Includeword = null);
        //_context.Categories.Add(Category);
        void Add(T entity);
        //_context.Categories.Remove(Category);
        void Remove(T entity);
        //_context.Categories.Add(Category);
        void RemoveRange(IEnumerable<T> entities);
    }
}
