using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APMSpanErrorRepro.Helpers
{
    public static class CustomHostBuilder
    {
        public static IHostBuilder CreateCustomHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider((context, options) => { options.ValidateScopes = true; })
                .UseSerilog();
            return builder;
        }
    }
}
