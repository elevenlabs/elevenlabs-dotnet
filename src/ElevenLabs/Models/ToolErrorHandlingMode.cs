using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>Controls how tool errors are processed before being shared with the agent.</summary>
[JsonConverter(typeof(ToolErrorHandlingMode.ToolErrorHandlingModeSerializer))]
[Serializable]
public readonly record struct ToolErrorHandlingMode : IStringEnum
{
    public static readonly ToolErrorHandlingMode Auto = new(Values.Auto);

    public static readonly ToolErrorHandlingMode Summarized = new(Values.Summarized);

    public static readonly ToolErrorHandlingMode Passthrough = new(Values.Passthrough);

    public static readonly ToolErrorHandlingMode Hide = new(Values.Hide);

    public ToolErrorHandlingMode(string value)
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
    public static ToolErrorHandlingMode FromCustom(string value)
    {
        return new ToolErrorHandlingMode(value);
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

    public static bool operator ==(ToolErrorHandlingMode value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ToolErrorHandlingMode value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ToolErrorHandlingMode value) => value.Value;

    public static explicit operator ToolErrorHandlingMode(string value) => new(value);

    internal class ToolErrorHandlingModeSerializer : JsonConverter<ToolErrorHandlingMode>
    {
        public override ToolErrorHandlingMode Read(
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
            return new ToolErrorHandlingMode(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ToolErrorHandlingMode value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ToolErrorHandlingMode ReadAsPropertyName(
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
            return new ToolErrorHandlingMode(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ToolErrorHandlingMode value,
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

        public const string Summarized = "summarized";

        public const string Passthrough = "passthrough";

        public const string Hide = "hide";
    }
}
