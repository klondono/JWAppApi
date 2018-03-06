using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using BusinessServices.Implementations;
using BusinessServices.Interfaces;
using JWAppApi.DbEntities;

namespace JWAppApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //get connection string from appsettings.json
            services.AddDbContext<JWAppContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("JWApp")));

            services.AddCors(options => {
                options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:4200"));
            });

            services.AddMvc();

            //Register application services
            services.AddScoped<IBusinessService,BusinessService>();
            services.AddScoped<ITerritoryService,TerritoryService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowSpecificOrigin");
            app.UseMvc();


        }
    }
}
