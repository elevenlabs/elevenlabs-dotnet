using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(DirectPublishingReadResponseModelTargetAudience.DirectPublishingReadResponseModelTargetAudienceSerializer)
)]
[Serializable]
public readonly record struct DirectPublishingReadResponseModelTargetAudience : IStringEnum
{
    public static readonly DirectPublishingReadResponseModelTargetAudience Children = new(
        Values.Children
    );

    public static readonly DirectPublishingReadResponseModelTargetAudience YoungAdult = new(
        Values.YoungAdult
    );

    public static readonly DirectPublishingReadResponseModelTargetAudience Adult = new(
        Values.Adult
    );

    public static readonly DirectPublishingReadResponseModelTargetAudience AllAges = new(
        Values.AllAges
    );

    public DirectPublishingReadResponseModelTargetAudience(string value)
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
    public static DirectPublishingReadResponseModelTargetAudience FromCustom(string value)
    {
        return new DirectPublishingReadResponseModelTargetAudience(value);
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
        DirectPublishingReadResponseModelTargetAudience value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        DirectPublishingReadResponseModelTargetAudience value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(DirectPublishingReadResponseModelTargetAudience value) =>
        value.Value;

    public static explicit operator DirectPublishingReadResponseModelTargetAudience(string value) =>
        new(value);

    internal class DirectPublishingReadResponseModelTargetAudienceSerializer
        : JsonConverter<DirectPublishingReadResponseModelTargetAudience>
    {
        public override DirectPublishingReadResponseModelTargetAudience Read(
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
            return new DirectPublishingReadResponseModelTargetAudience(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DirectPublishingReadResponseModelTargetAudience value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DirectPublishingReadResponseModelTargetAudience ReadAsPropertyName(
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
            return new DirectPublishingReadResponseModelTargetAudience(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DirectPublishingReadResponseModelTargetAudience value,
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
        public const string Children = "children";

        public const string YoungAdult = "young adult";

        public const string Adult = "adult";

        public const string AllAges = "all ages";
    }
}
