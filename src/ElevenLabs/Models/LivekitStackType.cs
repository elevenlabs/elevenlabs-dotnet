using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(LivekitStackType.LivekitStackTypeSerializer))]
[Serializable]
public readonly record struct LivekitStackType : IStringEnum
{
    public static readonly LivekitStackType Standard = new(Values.Standard);

    public static readonly LivekitStackType Static = new(Values.Static);

    public LivekitStackType(string value)
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
    public static LivekitStackType FromCustom(string value)
    {
        return new LivekitStackType(value);
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

    public static bool operator ==(LivekitStackType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LivekitStackType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LivekitStackType value) => value.Value;

    public static explicit operator LivekitStackType(string value) => new(value);

    internal class LivekitStackTypeSerializer : JsonConverter<LivekitStackType>
    {
        public override LivekitStackType Read(
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
            return new LivekitStackType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LivekitStackType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LivekitStackType ReadAsPropertyName(
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
            return new LivekitStackType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LivekitStackType value,
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
        public const string Standard = "standard";

        public const string Static = "static";
    }
}
