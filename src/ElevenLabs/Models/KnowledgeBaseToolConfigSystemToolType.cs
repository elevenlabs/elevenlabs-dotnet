using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(KnowledgeBaseToolConfigSystemToolType.KnowledgeBaseToolConfigSystemToolTypeSerializer)
)]
[Serializable]
public readonly record struct KnowledgeBaseToolConfigSystemToolType : IStringEnum
{
    public static readonly KnowledgeBaseToolConfigSystemToolType KnowledgeBase = new(
        Values.KnowledgeBase
    );

    public KnowledgeBaseToolConfigSystemToolType(string value)
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
    public static KnowledgeBaseToolConfigSystemToolType FromCustom(string value)
    {
        return new KnowledgeBaseToolConfigSystemToolType(value);
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

    public static bool operator ==(KnowledgeBaseToolConfigSystemToolType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeBaseToolConfigSystemToolType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeBaseToolConfigSystemToolType value) =>
        value.Value;

    public static explicit operator KnowledgeBaseToolConfigSystemToolType(string value) =>
        new(value);

    internal class KnowledgeBaseToolConfigSystemToolTypeSerializer
        : JsonConverter<KnowledgeBaseToolConfigSystemToolType>
    {
        public override KnowledgeBaseToolConfigSystemToolType Read(
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
            return new KnowledgeBaseToolConfigSystemToolType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeBaseToolConfigSystemToolType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeBaseToolConfigSystemToolType ReadAsPropertyName(
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
            return new KnowledgeBaseToolConfigSystemToolType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeBaseToolConfigSystemToolType value,
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
        public const string KnowledgeBase = "knowledge_base";
    }
}
