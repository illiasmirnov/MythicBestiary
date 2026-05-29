namespace MythicBestiary.Data;

/// <summary>
/// Налаштування підключення до MongoDB.
/// Використовуються через IOptions для централізованого керування параметрами бази даних.
/// </summary>
public sealed class MongoDbSettings
{
    public const string SectionName = "MongoDbSettings";

    // Рядок підключення до MongoDB Atlas або локального сервера MongoDB.
    public string ConnectionString { get; set; } = string.Empty;

    // Назва бази даних MongoDB.
    public string DatabaseName { get; set; } = "notes_db";

    // Назва колекції міфічних істот.
    public string CreaturesCollectionName { get; set; } = "notes_1";

    // Назва колекції рас міфічного світу.
    public string RacesCollectionName { get; set; } = "users_1";

    // Назва колекції геоданих для демонстрації роботи з GeoJSON.
    public string GeoLocationsCollectionName { get; set; } = "geo_locations";

    // Час очікування підключення в секундах.
    public int ConnectionTimeoutSeconds { get; set; } = 30;

    // Кількість повторних спроб підключення.
    public int RetryCount { get; set; } = 3;

    // Затримка між повторними спробами в мілісекундах.
    public int RetryDelayMilliseconds { get; set; } = 1000;

    // Дозволяє автоматичне створення індексів.
    public bool EnableAutoIndexCreation { get; set; } = true;

    // Дозволяє логування MongoDB-запитів.
    public bool EnableMongoLogging { get; set; } = false;
}