using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using Services.Exceptions;

namespace Server.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (FileNotFoundException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(e.ToString());
            }
            catch (FileAlreadyExistsException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Found;

                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(e.ToString());
            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                context.Response.ContentType = "text/plain";
                //await context.Response.WriteAsync("Internal server error");
                await context.Response.WriteAsync(e.ToString());
            }
        }
    }

    public static class ErrorHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
