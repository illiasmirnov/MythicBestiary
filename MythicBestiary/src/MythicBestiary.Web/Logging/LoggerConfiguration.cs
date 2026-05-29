
namespace MythicBestiary.Web.Logging;

public static class LoggerConfiguration
{
    public static WebApplicationBuilder ConfigureLogging(
        this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        builder.Logging.AddConfiguration(
            builder.Configuration.GetSection("Logging"));

        builder.Logging.AddSimpleConsole(options =>
        {
            options.FormatterName = ConsoleFormatterNames.Simple;
            options.IncludeScopes = true;
            options.SingleLine = false;
            options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
        });

        builder.Logging.AddDebug();

        ConfigureEnvironmentLogging(builder);
        AddApplicationFilters(builder.Logging);

        return builder;
    }

    public static IServiceCollection AddApplicationLogging(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();

            loggingBuilder.AddConfiguration(
                configuration.GetSection("Logging"));

            loggingBuilder.AddSimpleConsole(options =>
            {
                options.FormatterName = ConsoleFormatterNames.Simple;
                options.IncludeScopes = true;
                options.SingleLine = false;
                options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
            });

            loggingBuilder.AddDebug();
            loggingBuilder.SetMinimumLevel(LogLevel.Information);

            AddApplicationFilters(loggingBuilder);
        });

        return services;
    }

    private static void ConfigureEnvironmentLogging(WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            // У режимі розробки виводимо докладніші діагностичні повідомлення.
            builder.Logging.SetMinimumLevel(LogLevel.Debug);
            builder.Logging.AddFilter("MythicBestiary", LogLevel.Debug);
        }
        else
        {
            // У робочому середовищі залишаємо лише інформаційні та важливіші повідомлення.
            builder.Logging.SetMinimumLevel(LogLevel.Information);
            builder.Logging.AddFilter("MythicBestiary", LogLevel.Information);
        }
    }

    private static void AddApplicationFilters(ILoggingBuilder loggingBuilder)
    {
        loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);
        loggingBuilder.AddFilter("System", LogLevel.Warning);
        loggingBuilder.AddFilter("Microsoft.AspNetCore", LogLevel.Warning);
    }
}