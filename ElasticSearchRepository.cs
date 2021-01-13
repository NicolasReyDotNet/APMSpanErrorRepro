using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APMSpanErrorRepro
{
    public abstract class ElasticSearchRepository<T> : IElasticSearchRepository<T> where T : BaseEntity<string>
    {
        private readonly IElasticClient _elasticClient;
        private readonly string _index;

        public ElasticSearchRepository(IElasticClient elasticClient, string index)
        {
            _elasticClient = elasticClient;
            _index = index.ToLower();

            var exist = _elasticClient.Indices.Exists(_index);
            if (!exist.Exists)
            {
                var res = _elasticClient.Indices.Create(_index,
                        index => index.Map<T>(x => x.AutoMap()));

                if (!res.IsValid)
                    throw res.OriginalException;
            }
        }

        public async Task<IndexResponse> Add(T entity) => await _elasticClient.IndexAsync(entity, idx => idx.Index(_index));
        public async Task<GetResponse<T>> GetById(DocumentPath<T> Id) => await _elasticClient.GetAsync(Id, idx => idx.Index(_index));
    }
}
