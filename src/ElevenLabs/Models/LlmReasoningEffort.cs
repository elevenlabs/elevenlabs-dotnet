using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(LlmReasoningEffort.LlmReasoningEffortSerializer))]
[Serializable]
public readonly record struct LlmReasoningEffort : IStringEnum
{
    public static readonly LlmReasoningEffort None = new(Values.None);

    public static readonly LlmReasoningEffort Minimal = new(Values.Minimal);

    public static readonly LlmReasoningEffort Low = new(Values.Low);

    public static readonly LlmReasoningEffort Medium = new(Values.Medium);

    public static readonly LlmReasoningEffort High = new(Values.High);

    public static readonly LlmReasoningEffort Xhigh = new(Values.Xhigh);

    public static readonly LlmReasoningEffort Max = new(Values.Max);

    public LlmReasoningEffort(string value)
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
    public static LlmReasoningEffort FromCustom(string value)
    {
        return new LlmReasoningEffort(value);
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

    public static bool operator ==(LlmReasoningEffort value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LlmReasoningEffort value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LlmReasoningEffort value) => value.Value;

    public static explicit operator LlmReasoningEffort(string value) => new(value);

    internal class LlmReasoningEffortSerializer : JsonConverter<LlmReasoningEffort>
    {
        public override LlmReasoningEffort Read(
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
            return new LlmReasoningEffort(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LlmReasoningEffort value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LlmReasoningEffort ReadAsPropertyName(
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
            return new LlmReasoningEffort(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LlmReasoningEffort value,
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
        public const string None = "none";

        public const string Minimal = "minimal";

        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";

        public const string Xhigh = "xhigh";

        public const string Max = "max";
    }
}
