using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(PreToolSpeechMode.PreToolSpeechModeSerializer))]
[Serializable]
public readonly record struct PreToolSpeechMode : IStringEnum
{
    public static readonly PreToolSpeechMode Auto = new(Values.Auto);

    public static readonly PreToolSpeechMode Force = new(Values.Force);

    public static readonly PreToolSpeechMode Off = new(Values.Off);

    public PreToolSpeechMode(string value)
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
    public static PreToolSpeechMode FromCustom(string value)
    {
        return new PreToolSpeechMode(value);
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

    public static bool operator ==(PreToolSpeechMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PreToolSpeechMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PreToolSpeechMode value) => value.Value;

    public static explicit operator PreToolSpeechMode(string value) => new(value);

    internal class PreToolSpeechModeSerializer : JsonConverter<PreToolSpeechMode>
    {
        public override PreToolSpeechMode Read(
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
            return new PreToolSpeechMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreToolSpeechMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreToolSpeechMode ReadAsPropertyName(
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
            return new PreToolSpeechMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreToolSpeechMode value,
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
        public const string Auto = "auto";

        public const string Force = "force";

        public const string Off = "off";
    }
}
