using NET6.EF.Startup;

namespace NET6.EF.RepositoryAndUnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Blog> BlogRepository { get; }
        IRepository<Post> PostRepository { get; }
        IRepository<Author> AuthorRepository { get; }
    }
}