using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace OOP.TwilightSparkle.Middlewares
{
    public sealed class ErrorLoggerMiddleware //PATTERN Chain of Responsibility
    {
        private readonly RequestDelegate _next;


        public ErrorLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context, ILogger<ErrorLoggerMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception while sending '{context.Request.Method} {context.Request.GetDisplayUrl()}'");

                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.StatusCode = 500;
            }
        }
    }
}
