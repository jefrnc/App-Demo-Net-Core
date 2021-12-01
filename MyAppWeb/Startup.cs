using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using MyAppWeb.Mock;

namespace MyAppWeb
{
    public class Startup
    {

        private const string Liveness = "Liveness";
        private const string Readiness = "Readiness";

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddHealthChecks();
           
            //ASP.NET Core 2.2
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("*");
                                  });
            });

            services.AddHealthChecks().AddCheck<RandomHealthCheck>("Version Health Check");
            services.AddControllers();

        }
     
             
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseExceptionHandler("/Error/500");
            app.UseStatusCodePagesWithReExecute("/Error/500");
            app.UseHsts();


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseHealthChecks("/actuator/health/liveness");
            app.UseCors();




            //ASP.NET Core 3.x
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/actuator/health/liveness");
            });

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHealthChecks("/health/startup");
                //endpoints.MapHealthChecks("/healthz");
                //endpoints.MapHealthChecks("/ready");
                 
                 
                endpoints.MapRazorPages();                 
                endpoints.MapControllers();
            });
             
        }
    }
 


}
