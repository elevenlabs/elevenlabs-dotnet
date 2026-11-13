using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The type of podcast to create.</summary>
[JsonConverter(typeof(PodcastBulletinModeType.PodcastBulletinModeTypeSerializer))]
[Serializable]
public readonly record struct PodcastBulletinModeType : IStringEnum
{
    public static readonly PodcastBulletinModeType Bulletin = new(Values.Bulletin);

    public PodcastBulletinModeType(string value)
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
    public static PodcastBulletinModeType FromCustom(string value)
    {
        return new PodcastBulletinModeType(value);
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

    public static bool operator ==(PodcastBulletinModeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PodcastBulletinModeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PodcastBulletinModeType value) => value.Value;

    public static explicit operator PodcastBulletinModeType(string value) => new(value);

    internal class PodcastBulletinModeTypeSerializer : JsonConverter<PodcastBulletinModeType>
    {
        public override PodcastBulletinModeType Read(
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
            return new PodcastBulletinModeType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PodcastBulletinModeType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PodcastBulletinModeType ReadAsPropertyName(
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
            return new PodcastBulletinModeType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PodcastBulletinModeType value,
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
        public const string Bulletin = "bulletin";
    }
}
