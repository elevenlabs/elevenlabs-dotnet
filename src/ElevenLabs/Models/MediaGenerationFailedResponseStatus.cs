using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The lifecycle status of the generation.</summary>
[JsonConverter(
    typeof(MediaGenerationFailedResponseStatus.MediaGenerationFailedResponseStatusSerializer)
)]
[Serializable]
public readonly record struct MediaGenerationFailedResponseStatus : IStringEnum
{
    public static readonly MediaGenerationFailedResponseStatus Failed = new(Values.Failed);

    public MediaGenerationFailedResponseStatus(string value)
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
    public static MediaGenerationFailedResponseStatus FromCustom(string value)
    {
        return new MediaGenerationFailedResponseStatus(value);
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

    public static bool operator ==(MediaGenerationFailedResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MediaGenerationFailedResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MediaGenerationFailedResponseStatus value) =>
        value.Value;

    public static explicit operator MediaGenerationFailedResponseStatus(string value) => new(value);

    internal class MediaGenerationFailedResponseStatusSerializer
        : JsonConverter<MediaGenerationFailedResponseStatus>
    {
        public override MediaGenerationFailedResponseStatus Read(
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
            return new MediaGenerationFailedResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MediaGenerationFailedResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MediaGenerationFailedResponseStatus ReadAsPropertyName(
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
            return new MediaGenerationFailedResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MediaGenerationFailedResponseStatus value,
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
        public const string Failed = "failed";
    }
}
