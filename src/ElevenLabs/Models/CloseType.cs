using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(CloseType.CloseTypeSerializer))]
[Serializable]
public readonly record struct CloseType : IStringEnum
{
    public static readonly CloseType Close = new(Values.Close);

    public CloseType(string value)
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
    public static CloseType FromCustom(string value)
    {
        return new CloseType(value);
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

    public static bool operator ==(CloseType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(CloseType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(CloseType value) => value.Value;

    public static explicit operator CloseType(string value) => new(value);

    internal class CloseTypeSerializer : JsonConverter<CloseType>
    {
        public override CloseType Read(
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
            return new CloseType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CloseType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CloseType ReadAsPropertyName(
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
            return new CloseType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CloseType value,
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
        public const string Close = "close";
    }
}
