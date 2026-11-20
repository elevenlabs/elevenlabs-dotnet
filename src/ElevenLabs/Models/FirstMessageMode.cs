using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How the receptionist's greeting plays.</summary>
[JsonConverter(typeof(FirstMessageMode.FirstMessageModeSerializer))]
[Serializable]
public readonly record struct FirstMessageMode : IStringEnum
{
    public static readonly FirstMessageMode Interruptible = new(Values.Interruptible);

    public static readonly FirstMessageMode Uninterruptible = new(Values.Uninterruptible);

    public static readonly FirstMessageMode RecordingNotice = new(Values.RecordingNotice);

    public FirstMessageMode(string value)
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
    public static FirstMessageMode FromCustom(string value)
    {
        return new FirstMessageMode(value);
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

    public static bool operator ==(FirstMessageMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FirstMessageMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FirstMessageMode value) => value.Value;

    public static explicit operator FirstMessageMode(string value) => new(value);

    internal class FirstMessageModeSerializer : JsonConverter<FirstMessageMode>
    {
        public override FirstMessageMode Read(
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
            return new FirstMessageMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FirstMessageMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FirstMessageMode ReadAsPropertyName(
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
            return new FirstMessageMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FirstMessageMode value,
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
        public const string Interruptible = "interruptible";

        public const string Uninterruptible = "uninterruptible";

        public const string RecordingNotice = "recording_notice";
    }
}
