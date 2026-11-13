using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(FineTuningResponseState.FineTuningResponseStateSerializer))]
[Serializable]
public readonly record struct FineTuningResponseState : IStringEnum
{
    public static readonly FineTuningResponseState NotStarted = new(Values.NotStarted);

    public static readonly FineTuningResponseState Queued = new(Values.Queued);

    public static readonly FineTuningResponseState FineTuning = new(Values.FineTuning);

    public static readonly FineTuningResponseState FineTuned = new(Values.FineTuned);

    public static readonly FineTuningResponseState Failed = new(Values.Failed);

    public static readonly FineTuningResponseState Delayed = new(Values.Delayed);

    public FineTuningResponseState(string value)
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
    public static FineTuningResponseState FromCustom(string value)
    {
        return new FineTuningResponseState(value);
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

    public static bool operator ==(FineTuningResponseState value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FineTuningResponseState value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FineTuningResponseState value) => value.Value;

    public static explicit operator FineTuningResponseState(string value) => new(value);

    internal class FineTuningResponseStateSerializer : JsonConverter<FineTuningResponseState>
    {
        public override FineTuningResponseState Read(
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
            return new FineTuningResponseState(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FineTuningResponseState value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FineTuningResponseState ReadAsPropertyName(
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
            return new FineTuningResponseState(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FineTuningResponseState value,
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
        public const string NotStarted = "not_started";

        public const string Queued = "queued";

        public const string FineTuning = "fine_tuning";

        public const string FineTuned = "fine_tuned";

        public const string Failed = "failed";

        public const string Delayed = "delayed";
    }
}
