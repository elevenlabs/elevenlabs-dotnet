using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(DubbingReleaseChannel.DubbingReleaseChannelSerializer))]
[Serializable]
public readonly record struct DubbingReleaseChannel : IStringEnum
{
    public static readonly DubbingReleaseChannel Stable = new(Values.Stable);

    public static readonly DubbingReleaseChannel Release = new(Values.Release);

    public static readonly DubbingReleaseChannel Experimental = new(Values.Experimental);

    public DubbingReleaseChannel(string value)
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
    public static DubbingReleaseChannel FromCustom(string value)
    {
        return new DubbingReleaseChannel(value);
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

    public static bool operator ==(DubbingReleaseChannel value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DubbingReleaseChannel value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DubbingReleaseChannel value) => value.Value;

    public static explicit operator DubbingReleaseChannel(string value) => new(value);

    internal class DubbingReleaseChannelSerializer : JsonConverter<DubbingReleaseChannel>
    {
        public override DubbingReleaseChannel Read(
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
            return new DubbingReleaseChannel(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DubbingReleaseChannel value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DubbingReleaseChannel ReadAsPropertyName(
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
            return new DubbingReleaseChannel(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DubbingReleaseChannel value,
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
        public const string Stable = "stable";

        public const string Release = "release";

        public const string Experimental = "experimental";
    }
}
