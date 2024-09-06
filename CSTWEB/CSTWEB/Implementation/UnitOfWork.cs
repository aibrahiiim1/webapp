using CST_Web.Data;
using CSTWEB.Repositories;

namespace CSTWEB.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Category=new CategoryRepository(context);
        }

        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
