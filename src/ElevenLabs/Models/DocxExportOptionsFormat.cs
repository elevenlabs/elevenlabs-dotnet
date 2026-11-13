using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(DocxExportOptionsFormat.DocxExportOptionsFormatSerializer))]
[Serializable]
public readonly record struct DocxExportOptionsFormat : IStringEnum
{
    public static readonly DocxExportOptionsFormat Docx = new(Values.Docx);

    public DocxExportOptionsFormat(string value)
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
    public static DocxExportOptionsFormat FromCustom(string value)
    {
        return new DocxExportOptionsFormat(value);
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

    public static bool operator ==(DocxExportOptionsFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DocxExportOptionsFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DocxExportOptionsFormat value) => value.Value;

    public static explicit operator DocxExportOptionsFormat(string value) => new(value);

    internal class DocxExportOptionsFormatSerializer : JsonConverter<DocxExportOptionsFormat>
    {
        public override DocxExportOptionsFormat Read(
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
            return new DocxExportOptionsFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DocxExportOptionsFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DocxExportOptionsFormat ReadAsPropertyName(
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
            return new DocxExportOptionsFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DocxExportOptionsFormat value,
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
        public const string Docx = "docx";
    }
}
