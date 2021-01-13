using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APMSpanErrorRepro
{
    public interface IElasticSearchRepository<T> where T : BaseEntity<string>
    {
        Task<GetResponse<T>> GetById(DocumentPath<T> Id);
        Task<IndexResponse> Add(T entity);
    }
}
