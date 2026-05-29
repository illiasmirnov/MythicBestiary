using MythicBestiary.Web.DTOs;
using MythicBestiary.Web.Models;

namespace MythicBestiary.Web.Mapping;

public class CreatureMappingProfile : Profile
{
    private const int ShortDescriptionLength = 180;

    public CreatureMappingProfile()
    {
        // Перетворення DTO на модель.

        CreateMap<CreatureCreateDto, Creature>()
            .ForMember(destination => destination.Id, options => options.Ignore())
            .ForMember(destination => destination.CreatedAt, options => options.MapFrom(_ => DateTime.UtcNow))
            .ForMember(destination => destination.UpdatedAt, options => options.MapFrom(_ => DateTime.UtcNow))
            .ForMember(destination => destination.RelatedCreatures, options => options.NullSubstitute(new List<RelatedCreature>()))
            .ForMember(destination => destination.HistoricalNotes, options => options.NullSubstitute(new List<HistoricalNote>()))
            .ForMember(destination => destination.Images, options => options.NullSubstitute(new List<ImageResource>()))
            .ForMember(destination => destination.Abilities, options => options.NullSubstitute(new List<string>()));

        CreateMap<CreatureUpdateDto, Creature>()
            .ForMember(destination => destination.Id, options => options.Ignore())
            .ForMember(destination => destination.CreatedAt, options => options.Ignore())
            .ForMember(destination => destination.UpdatedAt, options => options.MapFrom(_ => DateTime.UtcNow))
            .ForMember(destination => destination.RelatedCreatures, options => options.NullSubstitute(new List<RelatedCreature>()))
            .ForMember(destination => destination.HistoricalNotes, options => options.NullSubstitute(new List<HistoricalNote>()))
            .ForMember(destination => destination.Images, options => options.NullSubstitute(new List<ImageResource>()))
            .ForMember(destination => destination.Abilities, options => options.NullSubstitute(new List<string>()));

        // Перетворення моделі на DTO.

        CreateMap<Creature, CreatureResponseDto>()
            .ForMember(destination => destination.Abilities, options => options.NullSubstitute(new List<string>()))
            .ForMember(destination => destination.RelatedCreatures, options => options.NullSubstitute(new List<RelatedCreature>()))
            .ForMember(destination => destination.HistoricalNotes, options => options.NullSubstitute(new List<HistoricalNote>()))
            .ForMember(destination => destination.Images, options => options.NullSubstitute(new List<ImageResource>()));

        CreateMap<Creature, CreatureListDto>()
            .ForMember(destination => destination.ShortDescription, options => options.MapFrom(source =>
                BuildShortDescription(source.Description)))
            .ForMember(destination => destination.ThumbnailUrl, options => options.MapFrom(source =>
                source.Images != null && source.Images.Count > 0
                    ? source.Images[0].Url
                    : string.Empty));

        CreateMap<RelatedCreature, RelatedCreature>();
        CreateMap<HistoricalNote, HistoricalNote>();
        CreateMap<ImageResource, ImageResource>();
    }

    private static string BuildShortDescription(string? description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return string.Empty;
        }

        var normalizedDescription = description.Trim();

        if (normalizedDescription.Length <= ShortDescriptionLength)
        {
            return normalizedDescription;
        }

        var trimmedDescription = normalizedDescription[..ShortDescriptionLength];
        var lastSpaceIndex = trimmedDescription.LastIndexOf(' ');

        if (lastSpaceIndex > 0)
        {
            trimmedDescription = trimmedDescription[..lastSpaceIndex];
        }

        return $"{trimmedDescription}…";
    }
}