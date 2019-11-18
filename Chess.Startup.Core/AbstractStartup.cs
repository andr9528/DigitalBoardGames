using System;
using System.IO;
using Chess.Repository.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chess.Startup.Core
{
    public abstract class AbstractStartup : IStartupEf
    {
        private IStartupEf _startupEf = null;

        public AbstractStartup(IConfiguration config = null, string connectionStringName = "")
        {
            if (config == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                Configuration = builder.Build();
            }
            else
                Configuration = config;

            if (connectionStringName != "")
            {
                _startupEf = new StartupEf(Configuration, connectionStringName);
            }
        }

        public IConfiguration Configuration { get; protected set; }

        public void SetupServices(IServiceCollection services)
        {
            Console.WriteLine("Setting up Services...");

            if (_startupEf != null)
            {
                _startupEf.SetupServices(services);
            }
        }
    }
}
