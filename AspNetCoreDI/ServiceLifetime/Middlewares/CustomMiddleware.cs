using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceLifetime.Services;
using System;
using System.Threading.Tasks;

namespace ServiceLifetime.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider sp, GuidService guidService)
        {
            var logMessage1 = $"Middleware: The GUID from GuidService (Scope 1) is {guidService.GetGuid()}";
            _logger.LogInformation(logMessage1);
            context.Items.Add("MiddlewareGuid1", logMessage1);

            using (var scope = sp.CreateScope())
            {
                var svc = scope.ServiceProvider.GetService<GuidService>();
                var logMessage2 = $"Middleware: The GUID from GuidService (Scope 2) is {svc.GetGuid()}";
                _logger.LogInformation(logMessage1);
                context.Items.Add("MiddlewareGuid2", logMessage2);
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
