using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;

namespace Repository.Interfaces
{
    public interface IGenericRepositoryAsync<TEntity>
        where TEntity : class
    {
        Task<int> GetCount(CancellationToken ct = default);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken ct = default);
        Task<TEntity> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyCollection<TEntity>> FindAsync(int skip = 0, int count = 1,
            bool toTrack = false,
            IEnumerable<Expression<Func<TEntity, bool>>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            CancellationToken ct = default);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<bool> DeleteAsync(TEntity entity, CancellationToken ct = default);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken ct = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct = default);
    }
}
