using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Personal_Account.Middleware.MiddlewareException;


namespace Personal_Account.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next,ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ErrorHandlerMiddleware>();
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorHandlerMiddleware> logger)
        {
            void ErrorResponse(HttpStatusCode errorCode, string errorMessage)
            {
                context.Response.StatusCode = (int)errorCode;
                context.Response.WriteAsync(errorMessage);
            }

            try
            {
                await _next(context);
            }
            catch (LockTimeOutException e)
            {
                ErrorResponse(HttpStatusCode.RequestTimeout, e.Message);
                _logger.LogError($"{HttpStatusCode.RequestTimeout} {e.Message}");
            }
            finally
            {
                DateTime datetime = DateTime.Now;
                var datetimestring = $"{datetime.Day}/{datetime.Month}/{datetime.Year} {datetime.Hour}:{datetime.Minute}:{datetime.Second}:{datetime.Millisecond}";
                _logger.LogInformation("Request №{id}: {datetime} {method} {url} => {statusCode}", context.TraceIdentifier, datetimestring,
                    context.Request.Method, context.Request.Path.Value, context.Response.StatusCode);
            }
          
        }
    }
}