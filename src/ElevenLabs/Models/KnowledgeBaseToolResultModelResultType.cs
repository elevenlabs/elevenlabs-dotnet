using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(KnowledgeBaseToolResultModelResultType.KnowledgeBaseToolResultModelResultTypeSerializer)
)]
[Serializable]
public readonly record struct KnowledgeBaseToolResultModelResultType : IStringEnum
{
    public static readonly KnowledgeBaseToolResultModelResultType KnowledgeBaseSuccess = new(
        Values.KnowledgeBaseSuccess
    );

    public KnowledgeBaseToolResultModelResultType(string value)
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
    public static KnowledgeBaseToolResultModelResultType FromCustom(string value)
    {
        return new KnowledgeBaseToolResultModelResultType(value);
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

    public static bool operator ==(KnowledgeBaseToolResultModelResultType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeBaseToolResultModelResultType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeBaseToolResultModelResultType value) =>
        value.Value;

    public static explicit operator KnowledgeBaseToolResultModelResultType(string value) =>
        new(value);

    internal class KnowledgeBaseToolResultModelResultTypeSerializer
        : JsonConverter<KnowledgeBaseToolResultModelResultType>
    {
        public override KnowledgeBaseToolResultModelResultType Read(
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
            return new KnowledgeBaseToolResultModelResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeBaseToolResultModelResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeBaseToolResultModelResultType ReadAsPropertyName(
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
            return new KnowledgeBaseToolResultModelResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeBaseToolResultModelResultType value,
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
        public const string KnowledgeBaseSuccess = "knowledge_base_success";
    }
}
