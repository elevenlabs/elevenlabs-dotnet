using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SubtitlingStatusMessageType.SubtitlingStatusMessageTypeSerializer))]
[Serializable]
public readonly record struct SubtitlingStatusMessageType : IStringEnum
{
    public static readonly SubtitlingStatusMessageType Status = new(Values.Status);

    public SubtitlingStatusMessageType(string value)
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
    public static SubtitlingStatusMessageType FromCustom(string value)
    {
        return new SubtitlingStatusMessageType(value);
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

    public static bool operator ==(SubtitlingStatusMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubtitlingStatusMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubtitlingStatusMessageType value) => value.Value;

    public static explicit operator SubtitlingStatusMessageType(string value) => new(value);

    internal class SubtitlingStatusMessageTypeSerializer
        : JsonConverter<SubtitlingStatusMessageType>
    {
        public override SubtitlingStatusMessageType Read(
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
            return new SubtitlingStatusMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubtitlingStatusMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubtitlingStatusMessageType ReadAsPropertyName(
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
            return new SubtitlingStatusMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubtitlingStatusMessageType value,
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
        public const string Status = "status";
    }
}
