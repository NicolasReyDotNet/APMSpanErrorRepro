using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APMSpanErrorRepro
{
    public class TestEntity : BaseEntity<string>
    {
        public string Name { get; set; }
    }
}
