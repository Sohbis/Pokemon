using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Domain.Exceptions;
using System.Threading.Tasks;

namespace Pokemon.Api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);  // ← run the rest of the pipeline
            }
            catch (DomainException ex)
            {
                // ← handle known exceptions (e.g. DomainException) here
                //httpContext.Response.StatusCode = ex.StatusCode; // ← set appropriate status code
                //await httpContext.Response.WriteAsJsonAsync(new { error = ex.Message }); // ← return error details as JSON
               
                _logger.LogWarning(                          // ← Warning, not Error — it's an expected outcome
                                    "Domain exception: {Message} | Path: {Path} | StatusCode: {StatusCode}",
                                    ex.Message,
                                    httpContext.Request.Path,
                                    ex.StatusCode
                                    );
                await HandleExceptionAsync(httpContext, ex.StatusCode, ex.Message);


            }
            catch (Exception ex)
            {
                // ← any exception thrown anywhere downstream lands here
                //httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError; // ← set generic 500 status code
                
                _logger.LogError(                            // ← log the unexpected error with stack trace
                                    ex,
                                    "Unhandled exception: {Message} | Path: {Path}",
                                    ex.Message,
                                    httpContext.Request.Path
                                    );

                await HandleExceptionAsync(httpContext, 500, "An unexpected error occurred.");

            }
        }


        private static async Task HandleExceptionAsync(HttpContext httpContext,
        int statusCode,
        string message)
        {
            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = statusCode;
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = GetTitle(statusCode),
                Detail = message,
                Instance = httpContext.Request.Path
            };

            problemDetails.Extensions["traceId"] = httpContext.TraceIdentifier;
            await httpContext.Response.WriteAsJsonAsync(problemDetails);
        }

        private static string GetTitle(int statusCode) => statusCode switch
        {
            400 => "Bad Request",
            404 => "Not Found",
            500 => "Internal Server Error",
            _ => "Error"
        };

    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandler>();
        }
    }

}


