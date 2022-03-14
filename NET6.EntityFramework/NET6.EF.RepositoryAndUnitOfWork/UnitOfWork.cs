using NET6.EF.Startup;

namespace NET6.EF.RepositoryAndUnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private BloggingContext context = new BloggingContext();
        private IRepository<Blog> blogRepository;
        private IRepository<Post> postRepository;
        private IRepository<Author> authorRepository;

        public IRepository<Blog> BlogRepository
        {
            get
            {
                if (this.blogRepository == null)
                {
                    this.blogRepository = new Repository<Blog>(context);
                }
                return blogRepository;
            }
        }

        public IRepository<Post> PostRepository
        {
            get
            {
                if (this.postRepository == null)
                {
                    this.postRepository = new Repository<Post>(context);
                }
                return postRepository;
            }
        }

        public IRepository<Author> AuthorRepository
        {
            get
            {
                if (this.authorRepository == null)
                {
                    this.authorRepository = new Repository<Author>(context);
                }
                return authorRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}