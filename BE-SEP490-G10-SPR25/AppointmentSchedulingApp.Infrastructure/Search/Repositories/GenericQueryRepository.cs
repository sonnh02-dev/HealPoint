using AppointmentSchedulingApp.Application.Abstractions.Search.Repositories;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Options;

namespace AppointmentSchedulingApp.Infrastructure.Search.Repositories
{
    public class GenericQueryRepository<T> : IGenericQueryRepository<T> where T : class
    {
        private readonly ElasticsearchClient client;

        public GenericQueryRepository(ElasticsearchClient client)
        {
            this.client = client;
        }

        public async Task<bool> CreateIndexIfNotExistsAsync(string indexName, CancellationToken cancellationToken = default)
        {
            var exists = await client.Indices.ExistsAsync(indexName, cancellationToken);
            if (exists.Exists) return true;

            var response = await client.Indices.CreateAsync(indexName, cancellationToken);
            return response.IsValidResponse;
        }

        public async Task<bool> AddOrUpdateAsync(T document, string indexName, CancellationToken cancellationToken)
        {
            var response = await client.IndexAsync(document, i => i.Index(indexName), cancellationToken);
            return response.IsValidResponse;
        }

        public async Task<bool> AddOrUpdateBulkAsync(IEnumerable<T> documents, string indexName, CancellationToken cancellationToken)
        {
            var response = await client.BulkAsync(b => b
                .Index(indexName)
                .IndexMany(documents), cancellationToken);
            return !response.Errors;
        }

        public async Task<bool> DeleteAsync(string id, string indexName, CancellationToken cancellationToken)
        {
            var response = await client.DeleteAsync<T>(id, d => d.Index(indexName), cancellationToken);
            return response.IsValidResponse;
        }

        public async Task<T?> GetAsync(string id, string indexName, CancellationToken cancellationToken)
        {
            var response = await client.GetAsync<T>(id, g => g.Index(indexName), cancellationToken);
            return response.Found ? response.Source : null;
        }
    }
}
