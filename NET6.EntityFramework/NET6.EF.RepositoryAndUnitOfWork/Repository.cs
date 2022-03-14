using Microsoft.EntityFrameworkCore;
using NET6.EF.Startup;

namespace NET6.EF.RepositoryAndUnitOfWork
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal BloggingContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(BloggingContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public TEntity? GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);
            if(entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}