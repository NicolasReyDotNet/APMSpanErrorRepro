using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog.Core;
using Serilog;
using Elastic.Apm.SerilogEnricher;
using Serilog.Sinks.Elasticsearch;
using Elastic.CommonSchema.Serilog;

namespace APMSpanErrorRepro.Helpers
{
    public static class LoggerFactory
    {
        public static Logger GetELKLogger(IConfiguration config)
        {
            return new LoggerConfiguration()
            .ReadFrom.Configuration(config)
            .Enrich.WithElasticApmCorrelationInfo()
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://elasticsearch:9200/"))
            {
                AutoRegisterTemplate = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                        EmitEventFailureHandling.WriteToFailureSink |
                                        EmitEventFailureHandling.RaiseCallback,
                CustomFormatter = new EcsTextFormatter()
            })
            .CreateLogger();
        }
    }
}
