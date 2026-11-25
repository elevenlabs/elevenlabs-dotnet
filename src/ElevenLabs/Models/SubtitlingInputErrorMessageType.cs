using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SubtitlingInputErrorMessageType.SubtitlingInputErrorMessageTypeSerializer))]
[Serializable]
public readonly record struct SubtitlingInputErrorMessageType : IStringEnum
{
    public static readonly SubtitlingInputErrorMessageType InputError = new(Values.InputError);

    public SubtitlingInputErrorMessageType(string value)
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
    public static SubtitlingInputErrorMessageType FromCustom(string value)
    {
        return new SubtitlingInputErrorMessageType(value);
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

    public static bool operator ==(SubtitlingInputErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubtitlingInputErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubtitlingInputErrorMessageType value) => value.Value;

    public static explicit operator SubtitlingInputErrorMessageType(string value) => new(value);

    internal class SubtitlingInputErrorMessageTypeSerializer
        : JsonConverter<SubtitlingInputErrorMessageType>
    {
        public override SubtitlingInputErrorMessageType Read(
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
            return new SubtitlingInputErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubtitlingInputErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubtitlingInputErrorMessageType ReadAsPropertyName(
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
            return new SubtitlingInputErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubtitlingInputErrorMessageType value,
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
        public const string InputError = "input_error";
    }
}
