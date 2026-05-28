using Microsoft.Extensions.Logging.Console;

namespace MythicBestiary.Logging;

public static class LoggerConfiguration
{
    public static IServiceCollection AddApplicationLogging(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var loggingSection = configuration.GetSection("Logging");

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();

            loggingBuilder.AddConfiguration(loggingSection);

            loggingBuilder.AddConsole(options =>
            {
                options.FormatterName = ConsoleFormatterNames.Simple;
            });

            loggingBuilder.AddSimpleConsole(options =>
            {
                options.IncludeScopes = true;
                options.SingleLine = false;
                options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
            });

            loggingBuilder.AddDebug();

            loggingBuilder.SetMinimumLevel(LogLevel.Information);

            loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
            loggingBuilder.AddFilter("System", LogLevel.Warning);
            loggingBuilder.AddFilter(
                "Microsoft.AspNetCore",
                LogLevel.Warning);

            // TODO:
            // Добавить file logging

            // TODO:
            // Добавить structured logging

            // TODO:
            // Добавить external logging providers

            // TODO:
            // Добавить telemetry logging
        });

        return services;
    }

    public static WebApplicationBuilder ConfigureLogging(
        this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        builder.Logging.AddConfiguration(
            builder.Configuration.GetSection("Logging"));

        builder.Logging.AddConsole();

        builder.Logging.AddSimpleConsole(options =>
        {
            options.IncludeScopes = true;
            options.SingleLine = false;
            options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
        });

        builder.Logging.AddDebug();

        if (builder.Environment.IsDevelopment())
        {
            builder.Logging.SetMinimumLevel(LogLevel.Debug);
        }
        else
        {
            builder.Logging.SetMinimumLevel(LogLevel.Information);
        }

        builder.Logging.AddFilter(
            "Microsoft",
            LogLevel.Warning);

        builder.Logging.AddFilter(
            "System",
            LogLevel.Warning);

        builder.Logging.AddFilter(
            "Microsoft.AspNetCore",
            LogLevel.Warning);

        builder.Logging.AddFilter(
            "MythicBestiary",
            LogLevel.Information);

        // TODO:
        // Добавить environment specific logging

        // TODO:
        // Добавить JSON logging

        // TODO:
        // Добавить file logging configuration

        // TODO:
        // Добавить correlation logging

        return builder;
    }

    // TODO:
    // Добавить методы настройки production logging

    // TODO:
    // Добавить методы настройки development logging

    // TODO:
    // Добавить методы настройки monitoring logging
}