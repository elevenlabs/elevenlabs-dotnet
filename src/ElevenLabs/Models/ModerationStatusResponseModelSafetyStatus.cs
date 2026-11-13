using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ModerationStatusResponseModelSafetyStatus.ModerationStatusResponseModelSafetyStatusSerializer)
)]
[Serializable]
public readonly record struct ModerationStatusResponseModelSafetyStatus : IStringEnum
{
    public static readonly ModerationStatusResponseModelSafetyStatus AppealApproved = new(
        Values.AppealApproved
    );

    public static readonly ModerationStatusResponseModelSafetyStatus AppealDenied = new(
        Values.AppealDenied
    );

    public static readonly ModerationStatusResponseModelSafetyStatus FalsePositive = new(
        Values.FalsePositive
    );

    public ModerationStatusResponseModelSafetyStatus(string value)
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
    public static ModerationStatusResponseModelSafetyStatus FromCustom(string value)
    {
        return new ModerationStatusResponseModelSafetyStatus(value);
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
        ModerationStatusResponseModelSafetyStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ModerationStatusResponseModelSafetyStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ModerationStatusResponseModelSafetyStatus value) =>
        value.Value;

    public static explicit operator ModerationStatusResponseModelSafetyStatus(string value) =>
        new(value);

    internal class ModerationStatusResponseModelSafetyStatusSerializer
        : JsonConverter<ModerationStatusResponseModelSafetyStatus>
    {
        public override ModerationStatusResponseModelSafetyStatus Read(
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
            return new ModerationStatusResponseModelSafetyStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ModerationStatusResponseModelSafetyStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ModerationStatusResponseModelSafetyStatus ReadAsPropertyName(
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
            return new ModerationStatusResponseModelSafetyStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ModerationStatusResponseModelSafetyStatus value,
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
        public const string AppealApproved = "appeal_approved";

        public const string AppealDenied = "appeal_denied";

        public const string FalsePositive = "false_positive";
    }
}
