using Core.Models;
using Core.Models.Response;

namespace Core.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    IQueryable<TEntity> GetQueryWithPagination(int pageNumber, int pageSize);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}