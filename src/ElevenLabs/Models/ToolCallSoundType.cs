using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Predefined tool call sounds; ``None`` means no sound.</summary>
[JsonConverter(typeof(ToolCallSoundType.ToolCallSoundTypeSerializer))]
[Serializable]
public readonly record struct ToolCallSoundType : IStringEnum
{
    public static readonly ToolCallSoundType Typing = new(Values.Typing);

    public static readonly ToolCallSoundType Elevator1 = new(Values.Elevator1);

    public static readonly ToolCallSoundType Elevator2 = new(Values.Elevator2);

    public static readonly ToolCallSoundType Elevator3 = new(Values.Elevator3);

    public static readonly ToolCallSoundType Elevator4 = new(Values.Elevator4);

    public ToolCallSoundType(string value)
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
    public static ToolCallSoundType FromCustom(string value)
    {
        return new ToolCallSoundType(value);
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

    public static bool operator ==(ToolCallSoundType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ToolCallSoundType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ToolCallSoundType value) => value.Value;

    public static explicit operator ToolCallSoundType(string value) => new(value);

    internal class ToolCallSoundTypeSerializer : JsonConverter<ToolCallSoundType>
    {
        public override ToolCallSoundType Read(
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
            return new ToolCallSoundType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ToolCallSoundType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ToolCallSoundType ReadAsPropertyName(
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
            return new ToolCallSoundType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ToolCallSoundType value,
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
        public const string Typing = "typing";

        public const string Elevator1 = "elevator1";

        public const string Elevator2 = "elevator2";

        public const string Elevator3 = "elevator3";

        public const string Elevator4 = "elevator4";
    }
}
