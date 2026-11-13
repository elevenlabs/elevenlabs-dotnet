using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(TemplateStringOutputFailureReason.TemplateStringOutputFailureReasonSerializer)
)]
[Serializable]
public readonly record struct TemplateStringOutputFailureReason : IStringEnum
{
    public static readonly TemplateStringOutputFailureReason Timeout = new(Values.Timeout);

    public static readonly TemplateStringOutputFailureReason ModelError = new(Values.ModelError);

    public static readonly TemplateStringOutputFailureReason Moderated = new(Values.Moderated);

    public static readonly TemplateStringOutputFailureReason InvalidParameters = new(
        Values.InvalidParameters
    );

    public static readonly TemplateStringOutputFailureReason DependencyFailed = new(
        Values.DependencyFailed
    );

    public static readonly TemplateStringOutputFailureReason ChargingFailed = new(
        Values.ChargingFailed
    );

    public static readonly TemplateStringOutputFailureReason InternalError = new(
        Values.InternalError
    );

    public TemplateStringOutputFailureReason(string value)
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
    public static TemplateStringOutputFailureReason FromCustom(string value)
    {
        return new TemplateStringOutputFailureReason(value);
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

    public static bool operator ==(TemplateStringOutputFailureReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplateStringOutputFailureReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplateStringOutputFailureReason value) => value.Value;

    public static explicit operator TemplateStringOutputFailureReason(string value) => new(value);

    internal class TemplateStringOutputFailureReasonSerializer
        : JsonConverter<TemplateStringOutputFailureReason>
    {
        public override TemplateStringOutputFailureReason Read(
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
            return new TemplateStringOutputFailureReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateStringOutputFailureReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplateStringOutputFailureReason ReadAsPropertyName(
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
            return new TemplateStringOutputFailureReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateStringOutputFailureReason value,
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
