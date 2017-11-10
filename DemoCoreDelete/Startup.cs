﻿using DemoCoreDelete.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCoreDelete
{
    public class Startup
    {
        public IConfiguration ConfigurationBinder { get; }

        public Startup(IConfiguration configuration)
        {
            ConfigurationBinder = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(
                options => options.UseSqlServer(ConfigurationBinder.GetConnectionString("DefaultConnection")));
            services.AddDbContextPool<LincContext>(
                options => options.UseSqlServer(ConfigurationBinder.GetConnectionString("DefaultConnection")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MVC Didn't find anything to route to.");
            });
        }
    }
}
