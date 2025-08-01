using System.Linq.Expressions;

namespace AppointmentSchedulingApp.Domain.Commons
{
    public interface IGenericCommandRepository<T> where T : class
    {
        // CREATE
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        // READ
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

         IQueryable<T> GetQueryable(); 
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate);

        // UPDATE
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        // DELETE
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
