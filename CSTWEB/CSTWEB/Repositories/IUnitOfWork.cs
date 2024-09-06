namespace CSTWEB.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        // call all repositories
        ICategoryRepository Category { get; }
        int Complete();

    }
}
