using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(
    typeof(ModerationStatusResponseModelWarningStatus.ModerationStatusResponseModelWarningStatusSerializer)
)]
[Serializable]
public readonly record struct ModerationStatusResponseModelWarningStatus : IStringEnum
{
    public static readonly ModerationStatusResponseModelWarningStatus Warning = new(Values.Warning);

    public static readonly ModerationStatusResponseModelWarningStatus WarningCleared = new(
        Values.WarningCleared
    );

    public ModerationStatusResponseModelWarningStatus(string value)
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
    public static ModerationStatusResponseModelWarningStatus FromCustom(string value)
    {
        return new ModerationStatusResponseModelWarningStatus(value);
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
        ModerationStatusResponseModelWarningStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ModerationStatusResponseModelWarningStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ModerationStatusResponseModelWarningStatus value) =>
        value.Value;

    public static explicit operator ModerationStatusResponseModelWarningStatus(string value) =>
        new(value);

    internal class ModerationStatusResponseModelWarningStatusSerializer
        : JsonConverter<ModerationStatusResponseModelWarningStatus>
    {
        public override ModerationStatusResponseModelWarningStatus Read(
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
            return new ModerationStatusResponseModelWarningStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ModerationStatusResponseModelWarningStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ModerationStatusResponseModelWarningStatus ReadAsPropertyName(
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
            return new ModerationStatusResponseModelWarningStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ModerationStatusResponseModelWarningStatus value,
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
        public const string Warning = "warning";

        public const string WarningCleared = "warning_cleared";
    }
}
