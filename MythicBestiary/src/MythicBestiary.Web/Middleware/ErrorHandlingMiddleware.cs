using System.Net;
using System.Text.Json;

namespace MythicBestiary.Middleware;

public sealed class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Під час обробки HTTP-запиту сталася непередбачена помилка.");

            await HandleExceptionAsync(context);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context)
    {
        if (context.Response.HasStarted)
        {
            return;
        }

        context.Response.Clear();
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json; charset=utf-8";

        var response = new
        {
            statusCode = context.Response.StatusCode,
            message = "Сталася внутрішня помилка сервера. Спробуйте повторити запит пізніше."
        };

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}