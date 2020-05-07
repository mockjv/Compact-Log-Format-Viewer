﻿using LogViewer.Server.Parser;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogViewer.Server
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
            services
                .AddMvcCore(options => options.EnableEndpointRouting = false);
                //.AddJsonFormatters();

            services.AddSingleton<ILogParser, LogParser>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles(); // index.html etc
            app.UseStaticFiles(); // serve assets from wwwroot

            app.UseDeveloperExceptionPage();
            app.UseMvc(); // WebAPI MVC Routing
        }
    }
}
