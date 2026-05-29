
namespace MythicBestiary.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplication UseApplicationPipeline(this WebApplication app)
    {
        app.UseCustomExceptionHandling();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseMiddleware<RequestLoggingMiddleware>();

        app.UseResponseCaching();

        app.UseAuthorization();

        app.MapRazorPages();

        return app;
    }

    private static WebApplication UseCustomExceptionHandling(this WebApplication app)
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
}