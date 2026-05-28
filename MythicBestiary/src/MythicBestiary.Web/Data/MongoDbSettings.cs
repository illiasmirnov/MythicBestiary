namespace MythicBestiary.Data;

/// <summary>
/// Конфигурационные настройки подключения к MongoDB.
/// Используются через IOptions для централизованного управления параметрами базы данных.
/// </summary>
public class MongoDbSettings
{
    // Рядок підключення до MongoDB
    public string ConnectionString { get; set; } = string.Empty;

    // Назва бази даних
    public string DatabaseName { get; set; } = string.Empty;

    // Назва секції конфігурації
    public const string SectionName = "MongoDbSettings";

    // Назва колекції міфічних істот
    public string CreaturesCollectionName { get; set; } = "notes_1";

    // Назва колекції рас
    public string UsersCollectionName { get; set; } = "users_1";

    // Таймаут підключення у секундах
    public int ConnectionTimeoutSeconds { get; set; } = 30;

    // Кількість повторних спроб підключення
    public int RetryCount { get; set; } = 3;

    // Затримка між повторними спробами у мілісекундах
    public int RetryDelayMilliseconds { get; set; } = 1000;

    // Чи дозволене автоматичне створення індексів
    public bool EnableAutoIndexCreation { get; set; } = true;

    // Чи дозволене логування MongoDB-запитів
    public bool EnableMongoLogging { get; set; } = false;
}