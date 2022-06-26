using CaseProject.Core.DataAccess.Abstract;
using CaseProject.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CaseProject.Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        #region Fields

        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        #endregion

        #region Constructor

      
        public EfEntityRepositoryBase(TContext context)
        {
            this._context = context;
            _dbSet = _context.Set<TEntity>();
        }
        
        #endregion

        #region Methods

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? match = null)
        {
            if (match == null)
                return await _dbSet.OrderByDescending(x => x.Value).ToListAsync();
            else
                return await _dbSet.Where(match).OrderByDescending(x=>x.Value).ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetWithPaginationAsync(Expression<Func<TEntity, bool>>? filter = null,string? orderBy = null, int page = 1, int limit = 10)
        {
            IQueryable<TEntity> query = _dbSet;
       
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                if (orderBy.Equals("asc"))
                    query = query.OrderBy(s => s.Value);
                else
                    query = query.OrderByDescending(s => s.Value);
            }

            query = query.Skip((page - 1) * limit)//page * limit göre belirli bir dizi kaydı atlar.
                         .Take(limit);//Yalnızca limit boyutuna göre belirlenen gerekli miktarda veriyi alır.

            return await query.ToListAsync();
        }

        #endregion

    }
}
