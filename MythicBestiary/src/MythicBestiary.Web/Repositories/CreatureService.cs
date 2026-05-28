using AutoMapper;
using MythicBestiary.DTOs;
using MythicBestiary.Models;
using MythicBestiary.Repositories.Interfaces;
using MythicBestiary.Services.Interfaces;

namespace MythicBestiary.Services;

public class CreatureService : ICreatureService
{
    private readonly ICreatureRepository _creatureRepository;
    private readonly IMapper _mapper;

    public CreatureService(
        ICreatureRepository creatureRepository,
        IMapper mapper)
    {
        _creatureRepository = creatureRepository;
        _mapper = mapper;
    }

    public async Task<List<CreatureListDto>> GetAllAsync()
    {
        var creatures = await _creatureRepository.GetAllAsync();

        var orderedCreatures = creatures
            .OrderBy(c => c.Name)
            .ToList();

        return _mapper.Map<List<CreatureListDto>>(orderedCreatures);
    }

    public async Task<CreatureResponseDto?> GetByIdAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Creature id is required.");
        }

        var creature = await _creatureRepository.GetByIdAsync(id);

        if (creature == null)
        {
            return null;
        }

        return _mapper.Map<CreatureResponseDto>(creature);
    }

    public async Task<CreatureResponseDto?> GetBySlugAsync(string slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
        {
            throw new ArgumentException("Creature slug is required.");
        }

        var creature = await _creatureRepository.GetBySlugAsync(slug);

        if (creature == null)
        {
            return null;
        }

        return _mapper.Map<CreatureResponseDto>(creature);
    }

    public async Task<List<CreatureListDto>> SearchAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return new List<CreatureListDto>();
        }

        var creatures = await _creatureRepository.SearchAsync(query);

        var filteredCreatures = creatures
            .Where(c =>
                !string.IsNullOrWhiteSpace(c.Name) ||
                !string.IsNullOrWhiteSpace(c.Description))
            .OrderBy(c => c.Name)
            .ToList();

        return _mapper.Map<List<CreatureListDto>>(filteredCreatures);
    }

    public async Task<CreatureResponseDto> CreateAsync(CreatureCreateDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        ValidateCreateDto(dto);

        var creature = _mapper.Map<Creature>(dto);

        if (!string.IsNullOrWhiteSpace(creature.Name))
        {
            creature.Slug = GenerateSlug(creature.Name);
        }

        creature.CreatedAt = DateTime.UtcNow;
        creature.UpdatedAt = DateTime.UtcNow;

        await _creatureRepository.CreateAsync(creature);

        return _mapper.Map<CreatureResponseDto>(creature);
    }

    public async Task<bool> UpdateAsync(string id, CreatureUpdateDto dto)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Creature id is required.");
        }

        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        ValidateUpdateDto(dto);

        var existingCreature = await _creatureRepository.GetByIdAsync(id);

        if (existingCreature == null)
        {
            return false;
        }

        _mapper.Map(dto, existingCreature);

        if (!string.IsNullOrWhiteSpace(existingCreature.Name))
        {
            existingCreature.Slug = GenerateSlug(existingCreature.Name);
        }

        existingCreature.UpdatedAt = DateTime.UtcNow;

        await _creatureRepository.UpdateAsync(id, existingCreature);

        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Creature id is required.");
        }

        var exists = await _creatureRepository.ExistsAsync(id);

        if (!exists)
        {
            return false;
        }

        await _creatureRepository.DeleteAsync(id);

        return true;
    }

    public async Task<bool> ExistsAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return false;
        }

        return await _creatureRepository.ExistsAsync(id);
    }

    private static void ValidateCreateDto(CreatureCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Creature name is required.");
        }

        if (dto.Name.Length > 120)
        {
            throw new ArgumentException("Creature name is too long.");
        }

        if (!string.IsNullOrWhiteSpace(dto.Description) &&
            dto.Description.Length > 5000)
        {
            throw new ArgumentException("Creature description is too long.");
        }
    }

    private static void ValidateUpdateDto(CreatureUpdateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Creature name is required.");
        }

        if (dto.Name.Length > 120)
        {
            throw new ArgumentException("Creature name is too long.");
        }

        if (!string.IsNullOrWhiteSpace(dto.Description) &&
            dto.Description.Length > 5000)
        {
            throw new ArgumentException("Creature description is too long.");
        }
    }

    private static string GenerateSlug(string value)
    {
        return value
            .Trim()
            .ToLowerInvariant()
            .Replace(" ", "-")
            .Replace("--", "-");
    }
}