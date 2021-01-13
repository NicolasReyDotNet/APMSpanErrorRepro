using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APMSpanErrorRepro
{
    public class TestEntityElkRepository : ElasticSearchRepository<TestEntity>, ITestEntityElkRepository
    {
        public TestEntityElkRepository(IElasticClient elasticClient) : base(elasticClient, nameof(TestEntity))
        {
        }
    }
}
