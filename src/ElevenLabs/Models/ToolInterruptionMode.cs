using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(ToolInterruptionMode.ToolInterruptionModeSerializer))]
[Serializable]
public readonly record struct ToolInterruptionMode : IStringEnum
{
    public static readonly ToolInterruptionMode Allow = new(Values.Allow);

    public static readonly ToolInterruptionMode DisableDuringTool = new(Values.DisableDuringTool);

    public static readonly ToolInterruptionMode DisableDuringToolAndTurn = new(
        Values.DisableDuringToolAndTurn
    );

    public ToolInterruptionMode(string value)
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
    public static ToolInterruptionMode FromCustom(string value)
    {
        return new ToolInterruptionMode(value);
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

    public static bool operator ==(ToolInterruptionMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ToolInterruptionMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ToolInterruptionMode value) => value.Value;

    public static explicit operator ToolInterruptionMode(string value) => new(value);

    internal class ToolInterruptionModeSerializer : JsonConverter<ToolInterruptionMode>
    {
        public override ToolInterruptionMode Read(
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
            return new ToolInterruptionMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ToolInterruptionMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ToolInterruptionMode ReadAsPropertyName(
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
            return new ToolInterruptionMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ToolInterruptionMode value,
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
        public const string Allow = "allow";

        public const string DisableDuringTool = "disable_during_tool";

        public const string DisableDuringToolAndTurn = "disable_during_tool_and_turn";
    }
}
