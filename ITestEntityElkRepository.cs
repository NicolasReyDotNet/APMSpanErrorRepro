using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APMSpanErrorRepro
{
    public interface ITestEntityElkRepository : IElasticSearchRepository<TestEntity>
    {
    }
}
