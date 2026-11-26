using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(StateUpdateOutputType.StateUpdateOutputTypeSerializer))]
[Serializable]
public readonly record struct StateUpdateOutputType : IStringEnum
{
    public static readonly StateUpdateOutputType DynamicVariable = new(Values.DynamicVariable);

    public StateUpdateOutputType(string value)
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
    public static StateUpdateOutputType FromCustom(string value)
    {
        return new StateUpdateOutputType(value);
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

    public static bool operator ==(StateUpdateOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StateUpdateOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StateUpdateOutputType value) => value.Value;

    public static explicit operator StateUpdateOutputType(string value) => new(value);

    internal class StateUpdateOutputTypeSerializer : JsonConverter<StateUpdateOutputType>
    {
        public override StateUpdateOutputType Read(
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
            return new StateUpdateOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StateUpdateOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StateUpdateOutputType ReadAsPropertyName(
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
            return new StateUpdateOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StateUpdateOutputType value,
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
        public const string DynamicVariable = "dynamic_variable";
    }
}
