using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(TemplateArrayOutputFailureReason.TemplateArrayOutputFailureReasonSerializer))]
[Serializable]
public readonly record struct TemplateArrayOutputFailureReason : IStringEnum
{
    public static readonly TemplateArrayOutputFailureReason Timeout = new(Values.Timeout);

    public static readonly TemplateArrayOutputFailureReason ModelError = new(Values.ModelError);

    public static readonly TemplateArrayOutputFailureReason Moderated = new(Values.Moderated);

    public static readonly TemplateArrayOutputFailureReason InvalidParameters = new(
        Values.InvalidParameters
    );

    public static readonly TemplateArrayOutputFailureReason DependencyFailed = new(
        Values.DependencyFailed
    );

    public static readonly TemplateArrayOutputFailureReason ChargingFailed = new(
        Values.ChargingFailed
    );

    public static readonly TemplateArrayOutputFailureReason InternalError = new(
        Values.InternalError
    );

    public TemplateArrayOutputFailureReason(string value)
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
    public static TemplateArrayOutputFailureReason FromCustom(string value)
    {
        return new TemplateArrayOutputFailureReason(value);
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

    public static bool operator ==(TemplateArrayOutputFailureReason value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplateArrayOutputFailureReason value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplateArrayOutputFailureReason value) => value.Value;

    public static explicit operator TemplateArrayOutputFailureReason(string value) => new(value);

    internal class TemplateArrayOutputFailureReasonSerializer
        : JsonConverter<TemplateArrayOutputFailureReason>
    {
        public override TemplateArrayOutputFailureReason Read(
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
            return new TemplateArrayOutputFailureReason(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateArrayOutputFailureReason value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplateArrayOutputFailureReason ReadAsPropertyName(
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
            return new TemplateArrayOutputFailureReason(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateArrayOutputFailureReason value,
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
