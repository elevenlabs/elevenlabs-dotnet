using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ConditionStrength.ConditionStrengthSerializer))]
[Serializable]
public readonly record struct ConditionStrength : IStringEnum
{
    public static readonly ConditionStrength Low = new(Values.Low);

    public static readonly ConditionStrength Medium = new(Values.Medium);

    public static readonly ConditionStrength High = new(Values.High);

    public static readonly ConditionStrength Xhigh = new(Values.Xhigh);

    public ConditionStrength(string value)
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
    public static ConditionStrength FromCustom(string value)
    {
        return new ConditionStrength(value);
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

    public static bool operator ==(ConditionStrength value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConditionStrength value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConditionStrength value) => value.Value;

    public static explicit operator ConditionStrength(string value) => new(value);

    internal class ConditionStrengthSerializer : JsonConverter<ConditionStrength>
    {
        public override ConditionStrength Read(
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
            return new ConditionStrength(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConditionStrength value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConditionStrength ReadAsPropertyName(
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
            return new ConditionStrength(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConditionStrength value,
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
        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";

        public const string Xhigh = "xhigh";
    }
}
