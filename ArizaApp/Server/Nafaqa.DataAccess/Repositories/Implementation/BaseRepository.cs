using Microsoft.EntityFrameworkCore;

namespace Nafaqa.DataAccess.Repositories.Implementation;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : class
{
    private readonly DbContext _appDbContext;
    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(DbContext dbContext)
    {
        _appDbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }

    public async ValueTask<TEntity> InsertAsync(
        TEntity entity)
    {
        var entityEntry = await _appDbContext
            .AddAsync<TEntity>(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public IQueryable<TEntity> SelectAll() =>
        DbSet.AsQueryable();

    public async ValueTask<TEntity> SelectByIdAsync(int id) =>
        await _appDbContext.Set<TEntity>().FindAsync(id);

    public async Task<List<TEntity>> SelectAllWithIncludesAsync(params string[] includes)
    {
        IQueryable<TEntity> query = _appDbContext.Set<TEntity>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var entityEntry = _appDbContext
            .Update<TEntity>(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<TEntity> DeleteAsync(TEntity entity)
    {
        var entityEntry = _appDbContext
            .Set<TEntity>()
            .Remove(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<int> SaveChangesAsync()=>    
        await _appDbContext
            .SaveChangesAsync();
}