using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace TN.Admin.Services.API.Middleware
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		//private readonly ILogger _logger;

       
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
			_next = next;
		}
  //      public ErrorHandlingMiddleware(RequestDelegate next, ILogger logger) : this(next)
  //      {
            
		//	_logger = logger;
		//}

        public async Task Invoke(HttpContext context)
        {
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				//_logger.Log(LogLevel.Error, ex.Message);
				await HandleExceptionAsync(context, ex);
			}
        }

		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var problemDetails = new ProblemDetails() {
				Status = (int)HttpStatusCode.InternalServerError,
				Title = "Lo sentimos, se ha presentado un error.",
				Detail = exception.Message,
				Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
				Instance = context.Request.Path
			};

		
			return context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
		}
    }
}
