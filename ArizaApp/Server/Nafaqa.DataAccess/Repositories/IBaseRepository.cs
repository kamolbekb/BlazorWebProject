namespace Nafaqa.DataAccess.Repositories;

public interface IBaseRepository<TEntity, TKey>
{
    ValueTask<TEntity> InsertAsync(TEntity entity);
    IQueryable<TEntity> SelectAll();
    ValueTask<TEntity> SelectByIdAsync(int id);

    public Task<List<TEntity>> SelectAllWithIncludesAsync(params string[] includes);
    
    ValueTask<TEntity> UpdateAsync(TEntity entity);
    ValueTask<TEntity> DeleteAsync(TEntity entity);
    ValueTask<int> SaveChangesAsync();
}