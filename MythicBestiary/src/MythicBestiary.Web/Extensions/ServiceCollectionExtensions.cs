using Microsoft.EntityFrameworkCore;
using MythicBestiary.Data;
using MythicBestiary.Repositories;
using MythicBestiary.Repositories.Interfaces;
using MythicBestiary.Validation;

namespace MythicBestiary.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddRazorPages();

        // Кешування є одним із додаткових елементів, передбачених методичкою.
        services.AddResponseCaching();

        // MongoDB використовується для лабораторних робіт №3–5 з NoSQL.
        services.Configure<MongoDbSettings>(
            configuration.GetSection(MongoDbSettings.SectionName));

        services.AddSingleton<MongoDbContext>();

        // EF Core + SQL Server потрібні для виконання вимог другої методички.
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        // DI для роботи з істотами.
        services.AddScoped<ICreatureRepository, CreatureService>();

        // Валідація даних перед створенням або оновленням записів.
        services.AddScoped<CreatureValidator>();
        services.AddValidatorsFromAssemblyContaining<CreatureValidator>();

        services.AddAutoMapper(typeof(Program).Assembly);

        return services;
    }
}