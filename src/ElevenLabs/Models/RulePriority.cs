using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>How strictly the receptionist follows a rule.</summary>
[JsonConverter(typeof(RulePriority.RulePrioritySerializer))]
[Serializable]
public readonly record struct RulePriority : IStringEnum
{
    public static readonly RulePriority Strict = new(Values.Strict);

    public static readonly RulePriority Suggestion = new(Values.Suggestion);

    public RulePriority(string value)
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
    public static RulePriority FromCustom(string value)
    {
        return new RulePriority(value);
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

    public static bool operator ==(RulePriority value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RulePriority value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RulePriority value) => value.Value;

    public static explicit operator RulePriority(string value) => new(value);

    internal class RulePrioritySerializer : JsonConverter<RulePriority>
    {
        public override RulePriority Read(
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
            return new RulePriority(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RulePriority value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RulePriority ReadAsPropertyName(
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
            return new RulePriority(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RulePriority value,
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
        public const string Strict = "strict";

        public const string Suggestion = "suggestion";
    }
}
