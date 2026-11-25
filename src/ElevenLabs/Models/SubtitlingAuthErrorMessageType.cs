using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(SubtitlingAuthErrorMessageType.SubtitlingAuthErrorMessageTypeSerializer))]
[Serializable]
public readonly record struct SubtitlingAuthErrorMessageType : IStringEnum
{
    public static readonly SubtitlingAuthErrorMessageType AuthError = new(Values.AuthError);

    public SubtitlingAuthErrorMessageType(string value)
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
    public static SubtitlingAuthErrorMessageType FromCustom(string value)
    {
        return new SubtitlingAuthErrorMessageType(value);
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

    public static bool operator ==(SubtitlingAuthErrorMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubtitlingAuthErrorMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubtitlingAuthErrorMessageType value) => value.Value;

    public static explicit operator SubtitlingAuthErrorMessageType(string value) => new(value);

    internal class SubtitlingAuthErrorMessageTypeSerializer
        : JsonConverter<SubtitlingAuthErrorMessageType>
    {
        public override SubtitlingAuthErrorMessageType Read(
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
            return new SubtitlingAuthErrorMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubtitlingAuthErrorMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubtitlingAuthErrorMessageType ReadAsPropertyName(
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
            return new SubtitlingAuthErrorMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubtitlingAuthErrorMessageType value,
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
        public const string AuthError = "auth_error";
    }
}
