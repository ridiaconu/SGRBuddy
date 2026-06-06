namespace SGRBuddy.DataAccess.Repositories.Abstractions;

public interface IRepository<TEntity> where TEntity : class
{
    TEntity Get(Guid id);
    IEnumerable<TEntity> GetAll();

    void Add(TEntity entity);
    void SaveChanges();
    void Delete(TEntity entity);
    
    
}