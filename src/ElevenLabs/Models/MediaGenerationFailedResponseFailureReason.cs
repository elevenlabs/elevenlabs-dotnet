using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The category of failure.</summary>
[JsonConverter(
    typeof(MediaGenerationFailedResponseFailureReason.MediaGenerationFailedResponseFailureReasonSerializer)
)]
[Serializable]
public readonly record struct MediaGenerationFailedResponseFailureReason : IStringEnum
{
    public static readonly MediaGenerationFailedResponseFailureReason Timeout = new(Values.Timeout);

    public static readonly MediaGenerationFailedResponseFailureReason ModelError = new(
        Values.ModelError
    );

    public static readonly MediaGenerationFailedResponseFailureReason Moderated = new(
        Values.Moderated
    );

    public static readonly MediaGenerationFailedResponseFailureReason InvalidParameters = new(
        Values.InvalidParameters
    );

    public static readonly MediaGenerationFailedResponseFailureReason DependencyFailed = new(
        Values.DependencyFailed
    );

    public static readonly MediaGenerationFailedResponseFailureReason ChargingFailed = new(
        Values.ChargingFailed
    );

    public static readonly MediaGenerationFailedResponseFailureReason InternalError = new(
        Values.InternalError
    );

    public MediaGenerationFailedResponseFailureReason(string value)
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
    public static MediaGenerationFailedResponseFailureReason FromCustom(string value)
    {
        return new MediaGenerationFailedResponseFailureReason(value);
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
        MediaGenerationFailedResponseFailureReason value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        MediaGenerationFailedResponseFailureReason value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(MediaGenerationFailedResponseFailureReason value) =>
        value.Value;

    public static explicit operator MediaGenerationFailedResponseFailureReason(string value) =>
        new(value);

    internal class MediaGenerationFailedResponseFailureReasonSerializer
        : JsonConverter<MediaGenerationFailedResponseFailureReason>
    {
        public override MediaGenerationFailedResponseFailureReason Read(
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
            return new MediaGenerationFailedResponseFailureReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            MediaGenerationFailedResponseFailureReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override MediaGenerationFailedResponseFailureReason ReadAsPropertyName(
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
            return new MediaGenerationFailedResponseFailureReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            MediaGenerationFailedResponseFailureReason value,
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
        public const string Timeout = "timeout";

        public const string ModelError = "model_error";

        public const string Moderated = "moderated";

        public const string InvalidParameters = "invalid_parameters";

        public const string DependencyFailed = "dependency_failed";

        public const string ChargingFailed = "charging_failed";

        public const string InternalError = "internal_error";
    }
}
