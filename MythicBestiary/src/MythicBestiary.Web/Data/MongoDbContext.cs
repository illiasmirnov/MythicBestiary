using MongoDB.Bson;
using MongoDB.Driver;
using MythicBestiary.Models;

namespace MythicBestiary.Data;

public sealed class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoClient MongoClient { get; }

    public string DatabaseName { get; }

    public IMongoCollection<Creature> Creatures { get; }

    public MongoDbContext(IOptions<MongoDbSettings> options)
    {
        ArgumentNullException.ThrowIfNull(options);

        MongoDbSettings settings = options.Value
            ?? throw new InvalidOperationException("Налаштування MongoDB не задано.");

        ValidateSettings(settings);

        MongoClientSettings clientSettings =
            MongoClientSettings.FromConnectionString(settings.ConnectionString);

        TimeSpan timeout = TimeSpan.FromSeconds(settings.ConnectionTimeoutSeconds);

        clientSettings.ConnectTimeout = timeout;
        clientSettings.ServerSelectionTimeout = timeout;

        MongoClient = new MongoClient(clientSettings);
        DatabaseName = settings.DatabaseName;

        _database = MongoClient.GetDatabase(DatabaseName);

        Creatures = _database.GetCollection<Creature>(
            settings.CreaturesCollectionName);
    }

    public IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName)
    {
        if (string.IsNullOrWhiteSpace(collectionName))
        {
            throw new ArgumentException(
                "Назва колекції не може бути порожньою.",
                nameof(collectionName));
        }

        return _database.GetCollection<TDocument>(collectionName);
    }

    public async Task<bool> CanConnectAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _database.RunCommandAsync<BsonDocument>(
                new BsonDocument("ping", 1),
                cancellationToken: cancellationToken);

            return true;
        }
        catch (MongoException)
        {
            return false;
        }
        catch (TimeoutException)
        {
            return false;
        }
    }

    private static void ValidateSettings(MongoDbSettings settings)
    {
        if (string.IsNullOrWhiteSpace(settings.ConnectionString))
        {
            throw new InvalidOperationException(
                "Рядок підключення до MongoDB не налаштовано.");
        }

        if (string.IsNullOrWhiteSpace(settings.DatabaseName))
        {
            throw new InvalidOperationException(
                "Назву бази даних MongoDB не налаштовано.");
        }

        if (string.IsNullOrWhiteSpace(settings.CreaturesCollectionName))
        {
            throw new InvalidOperationException(
                "Назву колекції міфічних істот MongoDB не налаштовано.");
        }

        if (settings.ConnectionTimeoutSeconds <= 0)
        {
            throw new InvalidOperationException(
                "Час очікування підключення до MongoDB має бути більшим за 0 секунд.");
        }
    }
}