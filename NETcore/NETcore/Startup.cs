using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NETcore.Context;
using NETcore.Repository;
using NETcore.Repository.Data;
//using Microsoft.Extensions.Configuration.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();
        //    services.AddScoped<PersonRepository>();
        //    services.AddScoped<AccountRepository>();
        //    services.AddScoped<EducationRepository>();
        //    services.AddScoped<ProfilingRepository>();
        //    services.AddScoped<UniversityRepository>();
        //    // IServiceCollection serviceCollection = services.AddDbContext<MyContext>(Options => options.usesqlserver);
        //    services.AddDbContext<MyContext>(options => options.UseLazyLoadingProxies()
        //    .UseSqlServer(Configuration.GetConnectionString("NETCoreContext")));
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllers();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddScoped<PersonRepository>();
            services.AddScoped<AccountRepository>();
            services.AddScoped<ProfilingRepository>();
            services.AddScoped<EducationRepository>();
            services.AddScoped<UniversityRepository>();
            // services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NETCoreContext")));

            services.AddDbContext<MyContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("NETCoreContext"))
            );
        }
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
