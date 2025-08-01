using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.Abstractions.Search.Repositories
{
    public interface IGenericQueryRepository<T> where T : class
    {
        Task<bool> CreateIndexIfNotExistsAsync(string indexName, CancellationToken cancellationToken = default);
        Task<bool> AddOrUpdateAsync(T document, string indexName, CancellationToken cancellationToken);
        Task<bool> AddOrUpdateBulkAsync(IEnumerable<T> documents, string indexName, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(string id, string indexName, CancellationToken cancellationToken);
        Task<T?> GetAsync(string id, string indexName, CancellationToken cancellationToken);
    }



}
