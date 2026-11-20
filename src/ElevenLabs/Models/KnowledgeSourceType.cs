using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Type of knowledge source.</summary>
[JsonConverter(typeof(KnowledgeSourceType.KnowledgeSourceTypeSerializer))]
[Serializable]
public readonly record struct KnowledgeSourceType : IStringEnum
{
    public static readonly KnowledgeSourceType File = new(Values.File);

    public static readonly KnowledgeSourceType Url = new(Values.Url);

    public KnowledgeSourceType(string value)
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
    public static KnowledgeSourceType FromCustom(string value)
    {
        return new KnowledgeSourceType(value);
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

    public static bool operator ==(KnowledgeSourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeSourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeSourceType value) => value.Value;

    public static explicit operator KnowledgeSourceType(string value) => new(value);

    internal class KnowledgeSourceTypeSerializer : JsonConverter<KnowledgeSourceType>
    {
        public override KnowledgeSourceType Read(
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
            return new KnowledgeSourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeSourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeSourceType ReadAsPropertyName(
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
            return new KnowledgeSourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeSourceType value,
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
        public const string File = "file";

        public const string Url = "url";
    }
}
