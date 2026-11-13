using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TemplateImageOutputFailureReason.TemplateImageOutputFailureReasonSerializer))]
[Serializable]
public readonly record struct TemplateImageOutputFailureReason : IStringEnum
{
    public static readonly TemplateImageOutputFailureReason Timeout = new(Values.Timeout);

    public static readonly TemplateImageOutputFailureReason ModelError = new(Values.ModelError);

    public static readonly TemplateImageOutputFailureReason Moderated = new(Values.Moderated);

    public static readonly TemplateImageOutputFailureReason InvalidParameters = new(
        Values.InvalidParameters
    );

    public static readonly TemplateImageOutputFailureReason DependencyFailed = new(
        Values.DependencyFailed
    );

    public static readonly TemplateImageOutputFailureReason ChargingFailed = new(
        Values.ChargingFailed
    );

    public static readonly TemplateImageOutputFailureReason InternalError = new(
        Values.InternalError
    );

    public TemplateImageOutputFailureReason(string value)
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
    public static TemplateImageOutputFailureReason FromCustom(string value)
    {
        return new TemplateImageOutputFailureReason(value);
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

    public static bool operator ==(TemplateImageOutputFailureReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplateImageOutputFailureReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplateImageOutputFailureReason value) => value.Value;

    public static explicit operator TemplateImageOutputFailureReason(string value) => new(value);

    internal class TemplateImageOutputFailureReasonSerializer
        : JsonConverter<TemplateImageOutputFailureReason>
    {
        public override TemplateImageOutputFailureReason Read(
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
            return new TemplateImageOutputFailureReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateImageOutputFailureReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplateImageOutputFailureReason ReadAsPropertyName(
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
            return new TemplateImageOutputFailureReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateImageOutputFailureReason value,
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
