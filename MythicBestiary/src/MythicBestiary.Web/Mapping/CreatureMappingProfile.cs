using AutoMapper;
using MythicBestiary.DTOs;
using MythicBestiary.Models;

namespace MythicBestiary.Mapping;

public class CreatureMappingProfile : Profile
{
    public CreatureMappingProfile()
    {
        // DTO -> Model

        CreateMap<CreatureCreateDto, Creature>()
            .ForMember(
                destination => destination.Id,
                options => options.Ignore())
            .ForMember(
                destination => destination.CreatedAt,
                options => options.MapFrom(_ => DateTime.UtcNow))
            .ForMember(
                destination => destination.UpdatedAt,
                options => options.MapFrom(_ => DateTime.UtcNow))
            .ForMember(
                destination => destination.RelatedCreatures,
                options => options.NullSubstitute(new List<RelatedCreature>()))
            .ForMember(
                destination => destination.HistoricalNotes,
                options => options.NullSubstitute(new List<HistoricalNote>()))
            .ForMember(
                destination => destination.Images,
                options => options.NullSubstitute(new List<ImageResource>()))
            .ForMember(
                destination => destination.Abilities,
                options => options.NullSubstitute(new List<string>()));

        CreateMap<CreatureUpdateDto, Creature>()
            .ForMember(
                destination => destination.Id,
                options => options.Ignore())
            .ForMember(
                destination => destination.CreatedAt,
                options => options.Ignore())
            .ForMember(
                destination => destination.UpdatedAt,
                options => options.MapFrom(_ => DateTime.UtcNow));

        // Model -> DTO

        CreateMap<Creature, CreatureResponseDto>()
            .ForMember(
                destination => destination.RelatedCreatures,
                options => options.MapFrom(source => source.RelatedCreatures))
            .ForMember(
                destination => destination.HistoricalNotes,
                options => options.MapFrom(source => source.HistoricalNotes))
            .ForMember(
                destination => destination.Images,
                options => options.MapFrom(source => source.Images))
            .ForMember(
                destination => destination.Abilities,
                options => options.NullSubstitute(new List<string>()));

        CreateMap<Creature, CreatureListDto>()
            .ForMember(
                destination => destination.ShortDescription,
                options => options.MapFrom(source =>
                    string.IsNullOrWhiteSpace(source.Description)
                        ? string.Empty
                        : source.Description.Length > 180
                            ? source.Description.Substring(0, 180) + "..."
                            : source.Description))
            .ForMember(
                destination => destination.ThumbnailUrl,
                options => options.MapFrom(source =>
                    source.Images != null &&
                    source.Images.Any()
                        ? source.Images.First().Url
                        : string.Empty));

        // RelatedCreature mappings

        CreateMap<RelatedCreature, RelatedCreature>()
            .ReverseMap();

        // HistoricalNote mappings

        CreateMap<HistoricalNote, HistoricalNote>()
            .ReverseMap();

        // ImageResource mappings

        CreateMap<ImageResource, ImageResource>()
            .ReverseMap();
    }
}