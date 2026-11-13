using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(AutoRebaseOutcome.AutoRebaseOutcomeSerializer))]
[Serializable]
public readonly record struct AutoRebaseOutcome : IStringEnum
{
    public static readonly AutoRebaseOutcome Succeeded = new(Values.Succeeded);

    public static readonly AutoRebaseOutcome Conflict = new(Values.Conflict);

    public static readonly AutoRebaseOutcome NoCommonAncestor = new(Values.NoCommonAncestor);

    public static readonly AutoRebaseOutcome Rejected = new(Values.Rejected);

    public static readonly AutoRebaseOutcome Error = new(Values.Error);

    public AutoRebaseOutcome(string value)
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
    public static AutoRebaseOutcome FromCustom(string value)
    {
        return new AutoRebaseOutcome(value);
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

    public static bool operator ==(AutoRebaseOutcome value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AutoRebaseOutcome value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AutoRebaseOutcome value) => value.Value;

    public static explicit operator AutoRebaseOutcome(string value) => new(value);

    internal class AutoRebaseOutcomeSerializer : JsonConverter<AutoRebaseOutcome>
    {
        public override AutoRebaseOutcome Read(
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
            return new AutoRebaseOutcome(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AutoRebaseOutcome value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AutoRebaseOutcome ReadAsPropertyName(
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
            return new AutoRebaseOutcome(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AutoRebaseOutcome value,
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
        public const string Succeeded = "succeeded";

        public const string Conflict = "conflict";

        public const string NoCommonAncestor = "no_common_ancestor";

        public const string Rejected = "rejected";

        public const string Error = "error";
    }
}
