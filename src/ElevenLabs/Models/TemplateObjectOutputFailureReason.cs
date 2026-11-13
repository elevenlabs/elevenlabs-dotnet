using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TemplateObjectOutputFailureReason.TemplateObjectOutputFailureReasonSerializer)
)]
[Serializable]
public readonly record struct TemplateObjectOutputFailureReason : IStringEnum
{
    public static readonly TemplateObjectOutputFailureReason Timeout = new(Values.Timeout);

    public static readonly TemplateObjectOutputFailureReason ModelError = new(Values.ModelError);

    public static readonly TemplateObjectOutputFailureReason Moderated = new(Values.Moderated);

    public static readonly TemplateObjectOutputFailureReason InvalidParameters = new(
        Values.InvalidParameters
    );

    public static readonly TemplateObjectOutputFailureReason DependencyFailed = new(
        Values.DependencyFailed
    );

    public static readonly TemplateObjectOutputFailureReason ChargingFailed = new(
        Values.ChargingFailed
    );

    public static readonly TemplateObjectOutputFailureReason InternalError = new(
        Values.InternalError
    );

    public TemplateObjectOutputFailureReason(string value)
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
    public static TemplateObjectOutputFailureReason FromCustom(string value)
    {
        return new TemplateObjectOutputFailureReason(value);
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

    public static bool operator ==(TemplateObjectOutputFailureReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplateObjectOutputFailureReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplateObjectOutputFailureReason value) => value.Value;

    public static explicit operator TemplateObjectOutputFailureReason(string value) => new(value);

    internal class TemplateObjectOutputFailureReasonSerializer
        : JsonConverter<TemplateObjectOutputFailureReason>
    {
        public override TemplateObjectOutputFailureReason Read(
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
            return new TemplateObjectOutputFailureReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateObjectOutputFailureReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplateObjectOutputFailureReason ReadAsPropertyName(
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
            return new TemplateObjectOutputFailureReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateObjectOutputFailureReason value,
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
