using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceLifetime.Middlewares;
using ServiceLifetime.Services;
using System;

namespace ServiceLifetime
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Transient objects are always different: a new instance is provided to every controller and every service.
            services.AddTransient<GuidService>();
            // Singleton objects are the same for every object and every request.
            //services.AddSingleton<GuidService>();
            // Scoped objects are the same within a request, but different across different requests.
            //services.AddScoped<GuidService>();

            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<CustomMiddleware>();
            app.UseMvc();
        }
    }
}
