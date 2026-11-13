using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CrawlStatus.CrawlStatusSerializer))]
[Serializable]
public readonly record struct CrawlStatus : IStringEnum
{
    public static readonly CrawlStatus Queued = new(Values.Queued);

    public static readonly CrawlStatus Processing = new(Values.Processing);

    public static readonly CrawlStatus Succeeded = new(Values.Succeeded);

    public static readonly CrawlStatus Failed = new(Values.Failed);

    public static readonly CrawlStatus Skipped = new(Values.Skipped);

    public static readonly CrawlStatus Cancelled = new(Values.Cancelled);

    public CrawlStatus(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static CrawlStatus FromCustom(string value)
    {
        return new CrawlStatus(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(CrawlStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CrawlStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CrawlStatus value) => value.Value;

    public static explicit operator CrawlStatus(string value) => new(value);

    internal class CrawlStatusSerializer : JsonConverter<CrawlStatus>
    {
        public override CrawlStatus Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new CrawlStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CrawlStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CrawlStatus ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new CrawlStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CrawlStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Queued = "queued";

        public const string Processing = "processing";

        public const string Succeeded = "succeeded";

        public const string Failed = "failed";

        public const string Skipped = "skipped";

        public const string Cancelled = "cancelled";
    }
}
