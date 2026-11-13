using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(KnowledgeBaseToolStatus.KnowledgeBaseToolStatusSerializer))]
[Serializable]
public readonly record struct KnowledgeBaseToolStatus : IStringEnum
{
    public static readonly KnowledgeBaseToolStatus Success = new(Values.Success);

    public static readonly KnowledgeBaseToolStatus NoMatchingDocuments = new(
        Values.NoMatchingDocuments
    );

    public static readonly KnowledgeBaseToolStatus NoResults = new(Values.NoResults);

    public KnowledgeBaseToolStatus(string value)
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
    public static KnowledgeBaseToolStatus FromCustom(string value)
    {
        return new KnowledgeBaseToolStatus(value);
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

    public static bool operator ==(KnowledgeBaseToolStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeBaseToolStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeBaseToolStatus value) => value.Value;

    public static explicit operator KnowledgeBaseToolStatus(string value) => new(value);

    internal class KnowledgeBaseToolStatusSerializer : JsonConverter<KnowledgeBaseToolStatus>
    {
        public override KnowledgeBaseToolStatus Read(
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
            return new KnowledgeBaseToolStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeBaseToolStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeBaseToolStatus ReadAsPropertyName(
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
            return new KnowledgeBaseToolStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeBaseToolStatus value,
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

        public const string NoMatchingDocuments = "no_matching_documents";

        public const string NoResults = "no_results";
    }
}
