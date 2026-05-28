using MythicBestiary.Models;

namespace MythicBestiary.Repositories.Interfaces;

public interface ICreatureRepository
{
    // Получение всех существ
    Task<List<Creature>> GetAllAsync();

    // Получение существа по идентификатору
    Task<Creature?> GetByIdAsync(string id);

    // Получение существа по slug
    Task<Creature?> GetBySlugAsync(string slug);

    // Создание существа
    Task CreateAsync(Creature creature);

    // Обновление существа
    Task UpdateAsync(string id, Creature creature);

    // Удаление существа
    Task DeleteAsync(string id);

    // Проверка существования существа
    Task<bool> ExistsAsync(string id);

    // Проверка существования существа по slug
    Task<bool> ExistsBySlugAsync(string slug);

    // Поиск существ
    Task<List<Creature>> SearchAsync(string query);

    // Поиск по названию
    Task<List<Creature>> SearchByTitleAsync(string title);

    // Поиск по месту обитания
    Task<List<Creature>> GetByHabitatAsync(string habitat);

    // Поиск по статусу
    Task<List<Creature>> GetByStatusAsync(string status);

    // Получение существ по уровню опасности
    Task<List<Creature>> GetByDangerLevelAsync(double minimumDangerLevel);

    // Получение существ по способности
    Task<List<Creature>> GetByAbilityAsync(string ability);

    // Получение существ по типу
    Task<List<Creature>> GetByTypeAsync(string type);

    // Получение существ по климату
    Task<List<Creature>> GetByClimateAsync(string climate);

    // Получение существ с историческими заметками
    Task<List<Creature>> GetWithHistoricalNotesAsync();

    // Получение существ с изображениями
    Task<List<Creature>> GetWithImagesAsync();

    // Получение связанных существ
    Task<List<Creature>> GetRelatedCreaturesAsync(string creatureId);

    // Получение последних добавленных существ
    Task<List<Creature>> GetLatestAsync(int count);

    // TODO:
    // Добавить пагинацию

    // TODO:
    // Добавить фильтрацию

    // TODO:
    // Добавить сортировку

    // TODO:
    // Добавить batch operations

    // TODO:
    // Добавить soft delete
}