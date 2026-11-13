using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(KnowledgeBaseRagToolStatus.KnowledgeBaseRagToolStatusSerializer))]
[Serializable]
public readonly record struct KnowledgeBaseRagToolStatus : IStringEnum
{
    public static readonly KnowledgeBaseRagToolStatus Success = new(Values.Success);

    public static readonly KnowledgeBaseRagToolStatus NoDocuments = new(Values.NoDocuments);

    public static readonly KnowledgeBaseRagToolStatus NoResults = new(Values.NoResults);

    public KnowledgeBaseRagToolStatus(string value)
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
    public static KnowledgeBaseRagToolStatus FromCustom(string value)
    {
        return new KnowledgeBaseRagToolStatus(value);
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

    public static bool operator ==(KnowledgeBaseRagToolStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeBaseRagToolStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeBaseRagToolStatus value) => value.Value;

    public static explicit operator KnowledgeBaseRagToolStatus(string value) => new(value);

    internal class KnowledgeBaseRagToolStatusSerializer : JsonConverter<KnowledgeBaseRagToolStatus>
    {
        public override KnowledgeBaseRagToolStatus Read(
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
            return new KnowledgeBaseRagToolStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeBaseRagToolStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeBaseRagToolStatus ReadAsPropertyName(
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
            return new KnowledgeBaseRagToolStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeBaseRagToolStatus value,
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
        public const string Success = "success";

        public const string NoDocuments = "no_documents";

        public const string NoResults = "no_results";
    }
}
