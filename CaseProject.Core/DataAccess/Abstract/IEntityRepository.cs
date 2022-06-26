using CaseProject.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace CaseProject.Core.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> AddAsync(TEntity Entity);

        Task<ICollection<TEntity>> GetWithPaginationAsync(Expression<Func<TEntity, bool>>? filter = null, string? orderBy = null, int page = 1, int limit = 10);

        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? match = null);
    }
}
