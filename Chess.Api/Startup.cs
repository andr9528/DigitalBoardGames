using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Startup.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Chess.Api
{
    public class Startup : AbstractStartup
    {
        public Startup(IConfiguration configuration) : base(configuration, ConnectionString)
        {

        }

        private static string ConnectionString
        {
            get
            {
                switch (Environment.MachineName)
                {
                    case "ANDRE-PC":
                        return "WolfStatic";
                    case "LAPTOP-9OO230TR":
                        return "WolfLaptop";
                    default:
                        return "Default";
                }
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            SetupServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
