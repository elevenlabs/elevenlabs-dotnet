using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(KnowledgeBaseRagToolResultModelResultType.KnowledgeBaseRagToolResultModelResultTypeSerializer)
)]
[Serializable]
public readonly record struct KnowledgeBaseRagToolResultModelResultType : IStringEnum
{
    public static readonly KnowledgeBaseRagToolResultModelResultType KnowledgeBaseRagSuccess = new(
        Values.KnowledgeBaseRagSuccess
    );

    public KnowledgeBaseRagToolResultModelResultType(string value)
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
    public static KnowledgeBaseRagToolResultModelResultType FromCustom(string value)
    {
        return new KnowledgeBaseRagToolResultModelResultType(value);
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

    public static bool operator ==(
        KnowledgeBaseRagToolResultModelResultType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        KnowledgeBaseRagToolResultModelResultType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeBaseRagToolResultModelResultType value) =>
        value.Value;

    public static explicit operator KnowledgeBaseRagToolResultModelResultType(string value) =>
        new(value);

    internal class KnowledgeBaseRagToolResultModelResultTypeSerializer
        : JsonConverter<KnowledgeBaseRagToolResultModelResultType>
    {
        public override KnowledgeBaseRagToolResultModelResultType Read(
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
            return new KnowledgeBaseRagToolResultModelResultType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeBaseRagToolResultModelResultType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeBaseRagToolResultModelResultType ReadAsPropertyName(
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
            return new KnowledgeBaseRagToolResultModelResultType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeBaseRagToolResultModelResultType value,
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
        public const string KnowledgeBaseRagSuccess = "knowledge_base_rag_success";
    }
}
