using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(VoiceLabellingStatus.VoiceLabellingStatusSerializer))]
[Serializable]
public readonly record struct VoiceLabellingStatus : IStringEnum
{
    public static readonly VoiceLabellingStatus InReview = new(Values.InReview);

    public static readonly VoiceLabellingStatus ReviewComplete = new(Values.ReviewComplete);

    public VoiceLabellingStatus(string value)
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
    public static VoiceLabellingStatus FromCustom(string value)
    {
        return new VoiceLabellingStatus(value);
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

    public static bool operator ==(VoiceLabellingStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VoiceLabellingStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VoiceLabellingStatus value) => value.Value;

    public static explicit operator VoiceLabellingStatus(string value) => new(value);

    internal class VoiceLabellingStatusSerializer : JsonConverter<VoiceLabellingStatus>
    {
        public override VoiceLabellingStatus Read(
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
            return new VoiceLabellingStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            VoiceLabellingStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override VoiceLabellingStatus ReadAsPropertyName(
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
            return new VoiceLabellingStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            VoiceLabellingStatus value,
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
        public const string InReview = "in_review";

        public const string ReviewComplete = "review_complete";
    }
}
