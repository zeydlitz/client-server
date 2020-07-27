using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using baseIC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using texode.data;

namespace texode
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(DataWarehouse<InformationCard>));
            
            //services.AddMvc(option =>
            //{
            //    option.Filters.Add<GloblaException>();
            //});
            services.ConfigureLoggerService();
            services.ConfigureIISIntegration();
            services.AddControllers();
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            env.EnvironmentName = "Production";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.ConfigureExceptionHandler(logger);
            
            app.UseHttpsRedirection();
            app.UseRouting();
           
           // app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
           //app.UseAuthorization();
            //app.UseStaticFiles();
            //app.UseCors("CorsPolicy");
            //app.UseExceptionHandler("/error");
            //app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            //app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

    }
}
