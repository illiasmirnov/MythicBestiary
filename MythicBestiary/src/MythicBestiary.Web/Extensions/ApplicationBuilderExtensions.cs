using MythicBestiary.Middleware;

namespace MythicBestiary.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplication UseApplicationPipeline(
        this WebApplication app)
    {
        app.UseCustomExceptionHandling();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseRequestLogging();

        app.UseAuthorization();

        app.UseResponseCaching();

        app.MapRazorPages();

        return app;
    }

    public static WebApplication UseCustomExceptionHandling(
        this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseMiddleware<ErrorHandlingMiddleware>();

        return app;
    }

    public static WebApplication UseRequestLogging(
        this WebApplication app)
    {
        app.UseMiddleware<RequestLoggingMiddleware>();

        return app;
    }
}