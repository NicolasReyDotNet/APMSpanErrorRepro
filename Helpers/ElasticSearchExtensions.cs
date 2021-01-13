using Elastic.Apm.NetCoreAll;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APMSpanErrorRepro.Helpers
{
    public static class ElasticSearchExtensions
    {

        public static IServiceCollection UseElasticSearch(this IServiceCollection services)
        {
            var pool = new StaticConnectionPool(new[] { new Uri("http://elasticsearch:9200/") });
            var settings = new ConnectionSettings(pool);
            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);

            return services;
        }
        public static IApplicationBuilder UseElasticSearchAPM(this IApplicationBuilder app, IConfiguration config)
        {
            try
            {
                if (!Elastic.Apm.Agent.IsConfigured)
                    app.UseAllElasticApm(config);
            }
            catch { }

            return app;
        }
    }
}
