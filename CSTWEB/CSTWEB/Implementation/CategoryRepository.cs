using CST_Web.Data;
using CST_Web.Models;
using CSTWEB.Repositories;

namespace CSTWEB.Implementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var categoryindb = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (categoryindb != null)
            {
                categoryindb.Name = category.Name;
                categoryindb.Description = category.Description;
                categoryindb.createdtime = DateTime.Now;
            }
        }
    }
}