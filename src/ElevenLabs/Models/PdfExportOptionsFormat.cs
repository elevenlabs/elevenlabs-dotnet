using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(PdfExportOptionsFormat.PdfExportOptionsFormatSerializer))]
[Serializable]
public readonly record struct PdfExportOptionsFormat : IStringEnum
{
    public static readonly PdfExportOptionsFormat Pdf = new(Values.Pdf);

    public PdfExportOptionsFormat(string value)
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
    public static PdfExportOptionsFormat FromCustom(string value)
    {
        return new PdfExportOptionsFormat(value);
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

    public static bool operator ==(PdfExportOptionsFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PdfExportOptionsFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PdfExportOptionsFormat value) => value.Value;

    public static explicit operator PdfExportOptionsFormat(string value) => new(value);

    internal class PdfExportOptionsFormatSerializer : JsonConverter<PdfExportOptionsFormat>
    {
        public override PdfExportOptionsFormat Read(
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
            return new PdfExportOptionsFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PdfExportOptionsFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PdfExportOptionsFormat ReadAsPropertyName(
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
            return new PdfExportOptionsFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PdfExportOptionsFormat value,
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
        public const string Pdf = "pdf";
    }
}
