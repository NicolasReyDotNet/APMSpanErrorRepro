using APMSpanErrorRepro.Helpers;
using Elastic.Apm;
using Elastic.Apm.Api;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APMSpanErrorRepro
{
    public class TestGarbageService : CustomBackgroundService
    {
        private readonly ILogger _logger;
        private readonly ITestEntityElkRepository _testEntityElkRepository;

        public TestGarbageService(ILogger<TestGarbageService> logger, ITestEntityElkRepository testEntityElkRepository)
        {
            _logger = logger;
            _testEntityElkRepository = testEntityElkRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Prevent APM singleton implicit creation with default parameters
            // https://www.elastic.co/guide/en/apm/agent/dotnet/1.x/troubleshooting.html#double-agent-initialization
            await Task.Delay(5 * 1000, stoppingToken);

            _logger.LogInformation("{service} is starting", nameof(TestGarbageService));

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Agent.Tracer
                    .CaptureTransaction("TestTransaction", ApiConstants.SubtypeElasticsearch, async (t) =>
                    {
                        var name = RandomGenerator.RandomString(5);
                        await t.CaptureSpan("GetOrAdd", ApiConstants.SubtypeElasticsearch, async span =>
                        {
                            var entity = await _testEntityElkRepository.GetById(name);

                            if (entity.Found)
                                _logger.LogInformation("Entity {entityId} was found", entity.Source.Id);
                            else
                            {
                                await _testEntityElkRepository.Add(new TestEntity { Id = name, Name = name });
                                _logger.LogInformation("Entity {entityId} was added", name);
                            }
                        });


                        await t.CaptureSpan("CheckItExists", ApiConstants.SubtypeElasticsearch, async span =>
                        {
                            var entity = await _testEntityElkRepository.GetById(name);

                            if (entity.Found)
                                _logger.LogInformation("Entity {entityId} was found", entity.Source.Id);
                            else
                                _logger.LogError("Entity {entityId} was not found", entity.Source.Id); 
                        });
                    });
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }

                // Delay
                await Task.Delay(1 * 60 * 1000, stoppingToken);
            }
        }
    }
}
