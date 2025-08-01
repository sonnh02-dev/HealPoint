using AppointmentSchedulingApp.Domain.Commons;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class GenericCommandRepository<T> : IGenericCommandRepository<T> where T : class
    {
        protected readonly ApplicationCommandDbContext _dbContext;
        protected readonly DbSet<T> _entitySet;

        public GenericCommandRepository(ApplicationCommandDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<T>();
        }

        // CREATE
        public void Add(T entity) => _entitySet.Add(entity);

        public async Task AddAsync(T entity) => await _entitySet.AddAsync(entity);

        public void AddRange(IEnumerable<T> entities) => _entitySet.AddRange(entities);

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            => await _entitySet.AddRangeAsync(entities, cancellationToken);

        // READ
        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
            => await _entitySet.AsNoTracking().FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _entitySet.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => await _entitySet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => await _entitySet.AsNoTracking().AnyAsync(predicate, cancellationToken);

        public virtual IQueryable<T> GetQueryable()
            => _entitySet.AsNoTracking();

        public virtual IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate)
            => _entitySet.AsNoTracking().Where(predicate);

        // UPDATE
        public void Update(T entity) => _entitySet.Update(entity);

        public void UpdateRange(IEnumerable<T> entities) => _entitySet.UpdateRange(entities);

        // DELETE
        public void Remove(T entity) => _entitySet.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => _entitySet.RemoveRange(entities);
    }
}
