using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Predefined background sound preset identifiers.</summary>
[JsonConverter(typeof(BackgroundSoundPresetId.BackgroundSoundPresetIdSerializer))]
[Serializable]
public readonly record struct BackgroundSoundPresetId : IStringEnum
{
    public static readonly BackgroundSoundPresetId Office2 = new(Values.Office2);

    public static readonly BackgroundSoundPresetId Office1 = new(Values.Office1);

    public static readonly BackgroundSoundPresetId Restaurant = new(Values.Restaurant);

    public static readonly BackgroundSoundPresetId City = new(Values.City);

    public static readonly BackgroundSoundPresetId Typing = new(Values.Typing);

    public static readonly BackgroundSoundPresetId Elevator1 = new(Values.Elevator1);

    public static readonly BackgroundSoundPresetId Elevator2 = new(Values.Elevator2);

    public static readonly BackgroundSoundPresetId Elevator3 = new(Values.Elevator3);

    public static readonly BackgroundSoundPresetId Elevator4 = new(Values.Elevator4);

    public BackgroundSoundPresetId(string value)
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
    public static BackgroundSoundPresetId FromCustom(string value)
    {
        return new BackgroundSoundPresetId(value);
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

    public static bool operator ==(BackgroundSoundPresetId value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BackgroundSoundPresetId value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BackgroundSoundPresetId value) => value.Value;

    public static explicit operator BackgroundSoundPresetId(string value) => new(value);

    internal class BackgroundSoundPresetIdSerializer : JsonConverter<BackgroundSoundPresetId>
    {
        public override BackgroundSoundPresetId Read(
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
            return new BackgroundSoundPresetId(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            BackgroundSoundPresetId value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override BackgroundSoundPresetId ReadAsPropertyName(
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
            return new BackgroundSoundPresetId(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BackgroundSoundPresetId value,
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
        public const string Office2 = "office2";

        public const string Office1 = "office1";

        public const string Restaurant = "restaurant";

        public const string City = "city";

        public const string Typing = "typing";

        public const string Elevator1 = "elevator1";

        public const string Elevator2 = "elevator2";

        public const string Elevator3 = "elevator3";

        public const string Elevator4 = "elevator4";
    }
}
