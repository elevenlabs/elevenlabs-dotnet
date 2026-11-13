using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SrtExportOptionsFormat.SrtExportOptionsFormatSerializer))]
[Serializable]
public readonly record struct SrtExportOptionsFormat : IStringEnum
{
    public static readonly SrtExportOptionsFormat Srt = new(Values.Srt);

    public SrtExportOptionsFormat(string value)
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
    public static SrtExportOptionsFormat FromCustom(string value)
    {
        return new SrtExportOptionsFormat(value);
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

    public static bool operator ==(SrtExportOptionsFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SrtExportOptionsFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SrtExportOptionsFormat value) => value.Value;

    public static explicit operator SrtExportOptionsFormat(string value) => new(value);

    internal class SrtExportOptionsFormatSerializer : JsonConverter<SrtExportOptionsFormat>
    {
        public override SrtExportOptionsFormat Read(
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
            return new SrtExportOptionsFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SrtExportOptionsFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SrtExportOptionsFormat ReadAsPropertyName(
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
            return new SrtExportOptionsFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SrtExportOptionsFormat value,
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
        public const string Srt = "srt";
    }
}
