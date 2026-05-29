
namespace MythicBestiary.Web.Models;

public sealed class ImageResource
{
    [BsonElement("Path")]
    public string Path { get; set; } = string.Empty;

    [BsonElement("AltText")]
    public string AltText { get; set; } = string.Empty;

    [BsonElement("Caption")]
    [BsonIgnoreIfNull]
    public string? Caption { get; set; }

    [BsonElement("IsPrimary")]
    public bool IsPrimary { get; set; }

    [BsonElement("SortOrder")]
    public int SortOrder { get; set; }

    [BsonElement("Title")]
    [BsonIgnoreIfNull]
    public string? Title { get; set; }

    [BsonElement("ImageType")]
    [BsonIgnoreIfNull]
    public string? ImageType { get; set; }

    [BsonElement("Author")]
    [BsonIgnoreIfNull]
    public string? Author { get; set; }

    [BsonElement("Width")]
    [BsonIgnoreIfNull]
    public int? Width { get; set; }

    [BsonElement("Height")]
    [BsonIgnoreIfNull]
    public int? Height { get; set; }

    [BsonElement("ContentType")]
    [BsonIgnoreIfNull]
    public string? ContentType { get; set; }

    [BsonElement("Metadata")]
    [BsonIgnoreIfNull]
    public Dictionary<string, string>? Metadata { get; set; }

    [BsonElement("UploadedAt")]
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public bool HasLocalImage()
    {
        return !string.IsNullOrWhiteSpace(Path)
            && Path.StartsWith("/images/", StringComparison.OrdinalIgnoreCase);
    }
}