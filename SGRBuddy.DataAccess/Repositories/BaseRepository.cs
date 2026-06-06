using Microsoft.EntityFrameworkCore;
using SGRBuddy.DataAccess.Repositories.Abstractions;

namespace SGRBuddy.DataAccess.Repositories;

internal class BaseRepository <TEntity>(SGRContext sgrContext) :IRepository<TEntity> where TEntity : class
{
    protected readonly SGRContext _context = sgrContext;
    protected DbSet<TEntity> CurrentSet => _context.Set<TEntity>();
    
    public TEntity Get(Guid id)
    {
        var entity = CurrentSet.Find(id);

        if (entity == null)
        {
            throw new ArgumentException("Id not present in database", nameof(id));
        }

        return entity;
    }
    public IEnumerable<TEntity> GetAll()
    {
        return CurrentSet.ToList();
    }
    public void Add(TEntity entity)
    {
        CurrentSet.Add(entity);
        
    }

    public void Delete(TEntity entity)
    {
        CurrentSet.Remove(entity);
    }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}