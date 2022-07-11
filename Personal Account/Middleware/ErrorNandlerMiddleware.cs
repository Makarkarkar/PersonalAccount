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

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
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
            }
            catch (TicketNumberValidateException e)
            {
                ErrorResponse(HttpStatusCode.Conflict, e.Message);
            }
            // catch (DbUpdateException e)
            // {
            //     ErrorResponse(HttpStatusCode.Conflict, e.Message);
            // }
            catch (BadHttpRequestException e) when (e.Message == "Request body too large.")
            {
                ErrorResponse(HttpStatusCode.RequestEntityTooLarge, e.Message);
            }
          
        }
    }
}