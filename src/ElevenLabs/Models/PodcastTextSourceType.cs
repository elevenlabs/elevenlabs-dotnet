using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of source to create.</summary>
[JsonConverter(typeof(PodcastTextSourceType.PodcastTextSourceTypeSerializer))]
[Serializable]
public readonly record struct PodcastTextSourceType : IStringEnum
{
    public static readonly PodcastTextSourceType Text = new(Values.Text);

    public PodcastTextSourceType(string value)
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
    public static PodcastTextSourceType FromCustom(string value)
    {
        return new PodcastTextSourceType(value);
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

    public static bool operator ==(PodcastTextSourceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PodcastTextSourceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PodcastTextSourceType value) => value.Value;

    public static explicit operator PodcastTextSourceType(string value) => new(value);

    internal class PodcastTextSourceTypeSerializer : JsonConverter<PodcastTextSourceType>
    {
        public override PodcastTextSourceType Read(
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
            return new PodcastTextSourceType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PodcastTextSourceType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PodcastTextSourceType ReadAsPropertyName(
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
            return new PodcastTextSourceType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PodcastTextSourceType value,
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
        public const string Text = "text";
    }
}
