namespace NET6.EF.RepositoryAndUnitOfWork
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(int entityId);
        void Insert(TEntity entity);
        void Delete(int entityId);
        void Update(TEntity entity);
        void Save();
    }
}