using System;
using Chess.Repository.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Chess.Repository.EntityFramework
{
    public class StartupEf : IStartupEf
    {
        public StartupEf(IConfiguration configuration, string connectionStringName)
        {
            Configuration = configuration;
            ConnectionStringName = connectionStringName;
        }

        public IConfiguration Configuration { get; }
        private string ConnectionStringName { get; }

        public void SetupServices(IServiceCollection services)
        {
            services.AddDbContext<ChessRepository>(option => option.UseSqlServer(Configuration.GetConnectionString(ConnectionStringName)));

            services.AddTransient(typeof(IGenericRepository), typeof(GenericEntityRepositoryHandler));

            Console.WriteLine("Finished Configuring Services for Entity Framework...");
        }
    }

    public interface IStartupEf
    {
        void SetupServices(IServiceCollection services);
    }
}
