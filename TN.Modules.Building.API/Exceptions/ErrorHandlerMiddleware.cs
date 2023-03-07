using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TN.Modules.Building.Shared.Exceptions;
using TN.Shared.Utils.Misc;
using TN.Shared.Utils.Misc.Time;

namespace TN.Modules.Building.API.Exceptions
{
    internal sealed class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;
        private readonly IClock _clock;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, IClock clock)
        {
            _logger = logger;
            _clock = clock;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleErrorAsync(context, exception);
            }
        }

        private async Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var coreProcessId = Guid.NewGuid();
            
            context.Request.Headers.TryGetValue("CoreProcessId", out var coreProcessIdHeader);
            if (!string.IsNullOrEmpty(coreProcessIdHeader))
                coreProcessId = coreProcessIdHeader.ToString().ToGuid();

            context.Items.TryGetValue("CoreProcessId", out var coreProcessIdItem);
            if (coreProcessIdItem != null)
                coreProcessId = coreProcessIdHeader.ToString().ToGuid();

            context.Response.StatusCode = exception.HttpStatus();
            var response = exception.ToExceptionResponse(coreProcessId, _clock.CurrentTimestamp());
            if (response is null)
            {
                return;
            }

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
