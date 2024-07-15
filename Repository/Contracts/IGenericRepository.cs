using System.Linq.Expressions;

namespace Assessment_Task.Repository.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetByIdsAsync(List<Guid> ids);
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task<decimal> SumAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> selector); // New method


    }

}