using log4net;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using PharmaApp.Application.Common.Exceptions;
using PharmaApp.Application.Features.Command.Create;

namespace PharmaApp.API.Extensions;

public static class ErrorHandlerExtensions
{

    private static ILogger _log;

    // Initialize the logger
    public static void InitializeLogger(ILoggerFactory loggerFactory)
    {
        _log = loggerFactory.CreateLogger("ErrorHandlerExtensions");
    }


    // Constructor with dependency injection for ILogger

    public static void UseErrorHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature == null) return;
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";

                var exception = contextFeature.Error;

                // Log the exception using the static logger
                _log?.LogError("Error", exception);

                context.Response.StatusCode = contextFeature.Error switch
                {
                    BadRequestException => (int) HttpStatusCode.BadRequest,
                    OperationCanceledException => (int) HttpStatusCode.ServiceUnavailable,
                    NotFoundException => (int) HttpStatusCode.NotFound,
                    _ => (int) HttpStatusCode.InternalServerError
                };

                var errorResponse = new
                {
                    statusCode = context.Response.StatusCode,
                    message = contextFeature.Error.GetBaseException().Message
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            });
        });
    }
}