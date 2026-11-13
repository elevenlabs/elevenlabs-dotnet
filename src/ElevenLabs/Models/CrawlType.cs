using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CrawlType.CrawlTypeSerializer))]
[Serializable]
public readonly record struct CrawlType : IStringEnum
{
    public static readonly CrawlType Discovery = new(Values.Discovery);

    public static readonly CrawlType Sitemap = new(Values.Sitemap);

    public CrawlType(string value)
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
    public static CrawlType FromCustom(string value)
    {
        return new CrawlType(value);
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

    public static bool operator ==(CrawlType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CrawlType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(CrawlType value) => value.Value;

    public static explicit operator CrawlType(string value) => new(value);

    internal class CrawlTypeSerializer : JsonConverter<CrawlType>
    {
        public override CrawlType Read(
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
            return new CrawlType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CrawlType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CrawlType ReadAsPropertyName(
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
            return new CrawlType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CrawlType value,
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
        public const string Discovery = "discovery";

        public const string Sitemap = "sitemap";
    }
}
