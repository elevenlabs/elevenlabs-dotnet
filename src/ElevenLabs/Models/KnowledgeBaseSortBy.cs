using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs.Agents;

[JsonConverter(typeof(KnowledgeBaseSortBy.KnowledgeBaseSortBySerializer))]
[Serializable]
public readonly record struct KnowledgeBaseSortBy : IStringEnum
{
    public static readonly KnowledgeBaseSortBy Name = new(Values.Name);

    public static readonly KnowledgeBaseSortBy CreatedAt = new(Values.CreatedAt);

    public static readonly KnowledgeBaseSortBy UpdatedAt = new(Values.UpdatedAt);

    public static readonly KnowledgeBaseSortBy Size = new(Values.Size);

    public KnowledgeBaseSortBy(string value)
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
    public static KnowledgeBaseSortBy FromCustom(string value)
    {
        return new KnowledgeBaseSortBy(value);
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

    public static bool operator ==(KnowledgeBaseSortBy value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeBaseSortBy value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeBaseSortBy value) => value.Value;

    public static explicit operator KnowledgeBaseSortBy(string value) => new(value);

    internal class KnowledgeBaseSortBySerializer : JsonConverter<KnowledgeBaseSortBy>
    {
        public override KnowledgeBaseSortBy Read(
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
            return new KnowledgeBaseSortBy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeBaseSortBy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeBaseSortBy ReadAsPropertyName(
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
            return new KnowledgeBaseSortBy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeBaseSortBy value,
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
        public const string Name = "name";

        public const string CreatedAt = "created_at";

        public const string UpdatedAt = "updated_at";

        public const string Size = "size";
    }
}
