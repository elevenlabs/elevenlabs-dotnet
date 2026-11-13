using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Determines how the tool call sound should be played.</summary>
[JsonConverter(typeof(ToolCallSoundBehavior.ToolCallSoundBehaviorSerializer))]
[Serializable]
public readonly record struct ToolCallSoundBehavior : IStringEnum
{
    public static readonly ToolCallSoundBehavior Auto = new(Values.Auto);

    public static readonly ToolCallSoundBehavior Always = new(Values.Always);

    public ToolCallSoundBehavior(string value)
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
    public static ToolCallSoundBehavior FromCustom(string value)
    {
        return new ToolCallSoundBehavior(value);
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

    public static bool operator ==(ToolCallSoundBehavior value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ToolCallSoundBehavior value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ToolCallSoundBehavior value) => value.Value;

    public static explicit operator ToolCallSoundBehavior(string value) => new(value);

    internal class ToolCallSoundBehaviorSerializer : JsonConverter<ToolCallSoundBehavior>
    {
        public override ToolCallSoundBehavior Read(
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
            return new ToolCallSoundBehavior(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ToolCallSoundBehavior value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ToolCallSoundBehavior ReadAsPropertyName(
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
            return new ToolCallSoundBehavior(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ToolCallSoundBehavior value,
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
        public const string Auto = "auto";

        public const string Always = "always";
    }
}
