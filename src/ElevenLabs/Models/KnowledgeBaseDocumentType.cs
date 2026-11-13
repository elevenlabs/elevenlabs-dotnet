using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(KnowledgeBaseDocumentType.KnowledgeBaseDocumentTypeSerializer))]
[Serializable]
public readonly record struct KnowledgeBaseDocumentType : IStringEnum
{
    public static readonly KnowledgeBaseDocumentType File = new(Values.File);

    public static readonly KnowledgeBaseDocumentType Url = new(Values.Url);

    public static readonly KnowledgeBaseDocumentType Text = new(Values.Text);

    public static readonly KnowledgeBaseDocumentType Folder = new(Values.Folder);

    public KnowledgeBaseDocumentType(string value)
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
    public static KnowledgeBaseDocumentType FromCustom(string value)
    {
        return new KnowledgeBaseDocumentType(value);
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

    public static bool operator ==(KnowledgeBaseDocumentType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(KnowledgeBaseDocumentType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(KnowledgeBaseDocumentType value) => value.Value;

    public static explicit operator KnowledgeBaseDocumentType(string value) => new(value);

    internal class KnowledgeBaseDocumentTypeSerializer : JsonConverter<KnowledgeBaseDocumentType>
    {
        public override KnowledgeBaseDocumentType Read(
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
            return new KnowledgeBaseDocumentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            KnowledgeBaseDocumentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override KnowledgeBaseDocumentType ReadAsPropertyName(
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
            return new KnowledgeBaseDocumentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            KnowledgeBaseDocumentType value,
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

        public const string Text = "text";

        public const string Folder = "folder";
    }
}
