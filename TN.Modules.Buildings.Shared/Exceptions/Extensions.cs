using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace TN.Modules.Buildings.Shared.Exceptions
{
    public static class Extensions
    {
        public static IServiceCollection AddErrorHandling(this IServiceCollection services)
            => services
                .AddScoped<ErrorHandlerMiddleware>();

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ErrorHandlerMiddleware>();

        public static ExceptionResponse ToExceptionResponse(this Exception ex, Guid coreProcessId, long timestamp) => ex switch
        {
            BaseException bex => new (coreProcessId, bex.Errors.Select(q => new ExceptionResponse.Error(q.Code, q.Message, q.Type)).ToList(), timestamp),
            _ => new (coreProcessId, new List<ExceptionResponse.Error> { new ExceptionResponse.Error("999", ex.Message, ex.GetType().Name) }, timestamp)
        };

        public static int HttpStatus(this Exception ex) => ex switch
        {
            BaseException bex => bex.HttpStatus,
            _ => (int)HttpStatusCode.InternalServerError
        };
    }
}
