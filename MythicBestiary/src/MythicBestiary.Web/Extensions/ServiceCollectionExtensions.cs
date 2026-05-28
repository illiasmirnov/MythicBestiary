using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MythicBestiary.Middleware;

namespace MythicBestiary.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseMythicBestiaryPipeline(
        this IApplicationBuilder app,
        IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseMiddleware<RequestLoggingMiddleware>();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });

        return app;
    }

    public static IApplicationBuilder UseMythicBestiaryMiddleware(
        this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseMiddleware<RequestLoggingMiddleware>();

        return app;
    }

    public static IApplicationBuilder UseMythicBestiaryStaticFiles(
        this IApplicationBuilder app)
    {
        app.UseHttpsRedirection();

        app.UseStaticFiles();

        return app;
    }

    public static IApplicationBuilder UseMythicBestiaryRouting(
        this IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });

        return app;
    }
}