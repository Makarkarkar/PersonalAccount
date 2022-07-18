using System.Text;

namespace Personal_Account.Middleware;

public class ReaquestSIZLogMiddleware
{
    private readonly RequestDelegate _next;

    public ReaquestSIZLogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, ILogger<ReaquestSIZLogMiddleware> logger)
    {
        try
        {
            await _next(httpContext);
        }
        finally
        {
            var sb = new StringBuilder();
            sb.Append($"Request-Time: {DateTime.Now} ");
            sb.Append($"Request-Path: {httpContext.Request.Path} " );
            sb.Append($"Request-Method: {httpContext.Request.Method} ");
            sb.Append($"Response-Code: {httpContext.Response.StatusCode} ");
            sb.Append("\n");
            
            //StreamWriter sw = new StreamWriter("C:\\Users\\ivvm3\\Downloads\\PersonalAccount-745b7718940a3094adf3f34cd9f03b91b313d081\\PersonalAccount-745b7718940a3094adf3f34cd9f03b91b313d081\\Personal Account\\logger.txt");
            
            File.AppendAllText("logger.txt",sb.ToString());
            
            //Console.WriteLine("Лог запроса записан в файл");
            logger.LogTrace(sb.ToString());
        }
        

    }
}