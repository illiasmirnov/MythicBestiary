using MongoDB.Bson.Serialization.Attributes;

namespace MythicBestiary.Web.Models
{
    public class ImageResource
    {
        [BsonElement("url")]
        public string Url { get; set; } = string.Empty;

        [BsonElement("altText")]
        public string AltText { get; set; } = string.Empty;

        [BsonElement("caption")]
        public string Caption { get; set; } = string.Empty;

        [BsonElement("isPrimary")]
        public bool IsPrimary { get; set; }

        [BsonElement("sortOrder")]
        public int SortOrder { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("title")]
        public string? Title { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("imageType")]
        public string? ImageType { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("source")]
        public string? Source { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("author")]
        public string? Author { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("thumbnailUrl")]
        public string? ThumbnailUrl { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("width")]
        public int? Width { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("height")]
        public int? Height { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("contentType")]
        public string? ContentType { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }

        [BsonElement("uploadedAt")]
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}