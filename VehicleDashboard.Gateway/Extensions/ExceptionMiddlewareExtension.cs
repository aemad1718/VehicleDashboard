using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using VehicleDashboard.CrossCutting;
using VehicleDashboard.CrossCutting.Exceptions;

namespace VehicleDashboard.Gateway.Extensions
{
    /// <summary>
    /// Middleware class to handle all the errors and exceptions.
    /// </summary>
    public static class ExceptionMiddlewareExtension
    {
        /// <summary>
        /// Catch the exceptions and wrap the error in a model to be sent to the user.
        /// Log the exception.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="logger"></param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        logger.LogError(contextFeature.Error.ToString());

                        await context.Response.WriteAsync(new ErrorModel()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}
