using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>A newly created generation is always `pending`.</summary>
[JsonConverter(
    typeof(MediaGenerationCreateResponseStatus.MediaGenerationCreateResponseStatusSerializer)
)]
[Serializable]
public readonly record struct MediaGenerationCreateResponseStatus : IStringEnum
{
    public static readonly MediaGenerationCreateResponseStatus Pending = new(Values.Pending);

    public MediaGenerationCreateResponseStatus(string value)
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
    public static MediaGenerationCreateResponseStatus FromCustom(string value)
    {
        return new MediaGenerationCreateResponseStatus(value);
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

    public static bool operator ==(MediaGenerationCreateResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(MediaGenerationCreateResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(MediaGenerationCreateResponseStatus value) =>
        value.Value;

    public static explicit operator MediaGenerationCreateResponseStatus(string value) => new(value);

    internal class MediaGenerationCreateResponseStatusSerializer
        : JsonConverter<MediaGenerationCreateResponseStatus>
    {
        public override MediaGenerationCreateResponseStatus Read(
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
            return new MediaGenerationCreateResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MediaGenerationCreateResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MediaGenerationCreateResponseStatus ReadAsPropertyName(
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
            return new MediaGenerationCreateResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MediaGenerationCreateResponseStatus value,
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
        public const string Pending = "pending";
    }
}
