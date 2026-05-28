using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MythicBestiary.Models;

namespace MythicBestiary.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    // Колекція міфічних істот
    public IMongoCollection<Creature> Creatures { get; }

    // MongoDB клієнт
    public MongoClient MongoClient { get; }

    // Назва бази даних
    public string DatabaseName { get; }

    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        var mongoDbSettings = settings.Value;

        if (string.IsNullOrWhiteSpace(mongoDbSettings.ConnectionString))
        {
            throw new InvalidOperationException(
                "Рядок підключення MongoDB не налаштований.");
        }

        if (string.IsNullOrWhiteSpace(mongoDbSettings.DatabaseName))
        {
            throw new InvalidOperationException(
                "Назва бази даних MongoDB не налаштована.");
        }

        if (string.IsNullOrWhiteSpace(mongoDbSettings.CreaturesCollectionName))
        {
            throw new InvalidOperationException(
                "Назва колекції істот MongoDB не налаштована.");
        }

        var mongoClientSettings = MongoClientSettings
            .FromConnectionString(mongoDbSettings.ConnectionString);

        mongoClientSettings.ConnectTimeout =
            TimeSpan.FromSeconds(mongoDbSettings.ConnectionTimeoutSeconds);

        mongoClientSettings.ServerSelectionTimeout =
            TimeSpan.FromSeconds(mongoDbSettings.ConnectionTimeoutSeconds);

        MongoClient = new MongoClient(mongoClientSettings);

        DatabaseName = mongoDbSettings.DatabaseName;

        _database = MongoClient.GetDatabase(DatabaseName);

        Creatures = _database.GetCollection<Creature>(
            mongoDbSettings.CreaturesCollectionName);
    }

    // Отримання колекції MongoDB за назвою
    public IMongoCollection<TDocument> GetCollection<TDocument>(
        string collectionName)
    {
        if (string.IsNullOrWhiteSpace(collectionName))
        {
            throw new ArgumentException(
                "Назва колекції не може бути порожньою.",
                nameof(collectionName));
        }

        return _database.GetCollection<TDocument>(collectionName);
    }

    // Перевірка доступності MongoDB
    public async Task<bool> CanConnectAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _database.RunCommandAsync(
                (Command<MongoDB.Bson.BsonDocument>)"{ping:1}",
                cancellationToken: cancellationToken);

            return true;
        }
        catch
        {
            return false;
        }
    }
}