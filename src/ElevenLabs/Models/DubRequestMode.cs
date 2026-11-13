using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The mode in which to run this Dubbing job. Defaults to automatic, use manual if specifically providing a CSV transcript to use. Note that manual mode is experimental and production use is strongly discouraged.</summary>
[JsonConverter(typeof(DubRequestMode.DubRequestModeSerializer))]
[Serializable]
public readonly record struct DubRequestMode : IStringEnum
{
    public static readonly DubRequestMode Automatic = new(Values.Automatic);

    public static readonly DubRequestMode Manual = new(Values.Manual);

    public DubRequestMode(string value)
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
    public static DubRequestMode FromCustom(string value)
    {
        return new DubRequestMode(value);
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

    public static bool operator ==(DubRequestMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubRequestMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubRequestMode value) => value.Value;

    public static explicit operator DubRequestMode(string value) => new(value);

    internal class DubRequestModeSerializer : JsonConverter<DubRequestMode>
    {
        public override DubRequestMode Read(
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
            return new DubRequestMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubRequestMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubRequestMode ReadAsPropertyName(
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
            return new DubRequestMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubRequestMode value,
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
        public const string Automatic = "automatic";

        public const string Manual = "manual";
    }
}
