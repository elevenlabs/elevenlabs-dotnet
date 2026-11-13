using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TxtExportOptionsFormat.TxtExportOptionsFormatSerializer))]
[Serializable]
public readonly record struct TxtExportOptionsFormat : IStringEnum
{
    public static readonly TxtExportOptionsFormat Txt = new(Values.Txt);

    public TxtExportOptionsFormat(string value)
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
    public static TxtExportOptionsFormat FromCustom(string value)
    {
        return new TxtExportOptionsFormat(value);
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

    public static bool operator ==(TxtExportOptionsFormat value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TxtExportOptionsFormat value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TxtExportOptionsFormat value) => value.Value;

    public static explicit operator TxtExportOptionsFormat(string value) => new(value);

    internal class TxtExportOptionsFormatSerializer : JsonConverter<TxtExportOptionsFormat>
    {
        public override TxtExportOptionsFormat Read(
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
            return new TxtExportOptionsFormat(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TxtExportOptionsFormat value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TxtExportOptionsFormat ReadAsPropertyName(
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
            return new TxtExportOptionsFormat(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TxtExportOptionsFormat value,
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
        public const string Txt = "txt";
    }
}
