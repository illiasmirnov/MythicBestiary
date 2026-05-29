
namespace MythicBestiary.Web.Repositories.Interfaces;

public interface ICreatureRepository
{
    Task<List<Creature>> GetAllAsync();

    Task<List<Creature>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        string? searchQuery = null,
        string? status = null,
        string? sortBy = null);

    Task<int> CountAsync(
        string? searchQuery = null,
        string? status = null);

    Task<Creature?> GetByIdAsync(string id);

    Task CreateAsync(Creature creature);

    Task UpdateAsync(string id, Creature creature);

    Task DeleteAsync(string id);

    Task<bool> ExistsAsync(string id);

    Task<List<Creature>> SearchAsync(string query);

    Task<List<Creature>> SearchByTitleAsync(string title);

    Task<List<Creature>> GetByHabitatAsync(string habitat);

    Task<List<Creature>> GetByStatusAsync(string status);

    Task<List<Creature>> GetByDangerLevelAsync(double minimumDangerLevel);

    Task<List<Creature>> GetByAbilityAsync(string ability);

    Task<List<Creature>> GetByTypeAsync(string type);

    Task<List<Creature>> GetByClimateAsync(string climate);

    Task<List<Creature>> GetWithHistoricalNotesAsync();

    Task<List<Creature>> GetWithImagesAsync();

    Task<List<Creature>> GetRelatedCreaturesAsync(string creatureId);

    Task<List<Creature>> GetLatestAsync(int count);

    // Пошук істот поблизу заданої точки GeoJSON.
    Task<List<Creature>> GetNearAsync(
        double longitude,
        double latitude,
        double maxDistanceMeters);
}