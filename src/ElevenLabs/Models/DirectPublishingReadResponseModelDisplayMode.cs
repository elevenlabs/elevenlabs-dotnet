using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DirectPublishingReadResponseModelDisplayMode.DirectPublishingReadResponseModelDisplayModeSerializer)
)]
[Serializable]
public readonly record struct DirectPublishingReadResponseModelDisplayMode : IStringEnum
{
    public static readonly DirectPublishingReadResponseModelDisplayMode Text = new(Values.Text);

    public static readonly DirectPublishingReadResponseModelDisplayMode AudioOnly = new(
        Values.AudioOnly
    );

    public static readonly DirectPublishingReadResponseModelDisplayMode TextWithAudio = new(
        Values.TextWithAudio
    );

    public DirectPublishingReadResponseModelDisplayMode(string value)
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
    public static DirectPublishingReadResponseModelDisplayMode FromCustom(string value)
    {
        return new DirectPublishingReadResponseModelDisplayMode(value);
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

    public static bool operator ==(
        DirectPublishingReadResponseModelDisplayMode value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DirectPublishingReadResponseModelDisplayMode value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(DirectPublishingReadResponseModelDisplayMode value) =>
        value.Value;

    public static explicit operator DirectPublishingReadResponseModelDisplayMode(string value) =>
        new(value);

    internal class DirectPublishingReadResponseModelDisplayModeSerializer
        : JsonConverter<DirectPublishingReadResponseModelDisplayMode>
    {
        public override DirectPublishingReadResponseModelDisplayMode Read(
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
            return new DirectPublishingReadResponseModelDisplayMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DirectPublishingReadResponseModelDisplayMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DirectPublishingReadResponseModelDisplayMode ReadAsPropertyName(
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
            return new DirectPublishingReadResponseModelDisplayMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DirectPublishingReadResponseModelDisplayMode value,
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

        public const string AudioOnly = "audio-only";

        public const string TextWithAudio = "text-with-audio";
    }
}
