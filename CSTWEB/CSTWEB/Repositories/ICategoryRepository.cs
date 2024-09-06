using CST_Web.Models;

namespace CSTWEB.Repositories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        void Update(Category category);
    }
}
