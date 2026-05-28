using System.Net;
using System.Text.Json;

namespace MythicBestiary.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(
        RequestDelegate next,
        ILogger<ErrorHandlingMiddleware> logger)
    {
        // Сохранение middleware pipeline

        // Сохранение logger

        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Передача запроса дальше по pipeline

            await _next(context);
        }
        catch (Exception exception)
        {
            // Логирование ошибки

            _logger.LogError(
                exception,
                "Unhandled exception occurred. Path: {Path}, Method: {Method}, TraceId: {TraceId}",
                context.Request.Path,
                context.Request.Method,
                context.TraceIdentifier);

            // Обработка исключения

            // Формирование error response

            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        // Установка content-type

        // Установка status code

        // Формирование объекта ошибки

        // Сериализация ответа

        context.Response.ContentType = "application/json";

        var statusCode = GetStatusCode(exception);

        context.Response.StatusCode = statusCode;

        var response = new
        {
            // TODO:
            // Добавить error code

            // TODO:
            // Добавить trace id

            StatusCode = statusCode,

            TraceId = context.TraceIdentifier,

            Path = context.Request.Path.Value,

            Method = context.Request.Method,

            Timestamp = DateTime.UtcNow,

            Message = GetErrorMessage(statusCode),

            Details = exception.Message
        };

        var jsonResponse = JsonSerializer.Serialize(
            response,
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

        await context.Response.WriteAsync(jsonResponse);
    }

    private static int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,

            ArgumentNullException => (int)HttpStatusCode.BadRequest,

            ArgumentException => (int)HttpStatusCode.BadRequest,

            InvalidOperationException => (int)HttpStatusCode.BadRequest,

            KeyNotFoundException => (int)HttpStatusCode.NotFound,

            _ => (int)HttpStatusCode.InternalServerError
        };
    }

    private static string GetErrorMessage(int statusCode)
    {
        return statusCode switch
        {
            (int)HttpStatusCode.BadRequest =>
                "Bad request",

            (int)HttpStatusCode.NotFound =>
                "Requested resource was not found",

            (int)HttpStatusCode.Unauthorized =>
                "Unauthorized access",

            (int)HttpStatusCode.InternalServerError =>
                "Internal server error",

            _ =>
                "Unexpected application error"
        };
    }

    // TODO:
    // Добавить environment based responses

    // TODO:
    // Добавить custom exception mapping

    // TODO:
    // Добавить validation error handling

    // TODO:
    // Добавить problem details support
}