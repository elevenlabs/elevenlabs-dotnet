using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(StateUpdateInputType.StateUpdateInputTypeSerializer))]
[Serializable]
public readonly record struct StateUpdateInputType : IStringEnum
{
    public static readonly StateUpdateInputType DynamicVariable = new(Values.DynamicVariable);

    public StateUpdateInputType(string value)
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
    public static StateUpdateInputType FromCustom(string value)
    {
        return new StateUpdateInputType(value);
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

    public static bool operator ==(StateUpdateInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(StateUpdateInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(StateUpdateInputType value) => value.Value;

    public static explicit operator StateUpdateInputType(string value) => new(value);

    internal class StateUpdateInputTypeSerializer : JsonConverter<StateUpdateInputType>
    {
        public override StateUpdateInputType Read(
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
            return new StateUpdateInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            StateUpdateInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override StateUpdateInputType ReadAsPropertyName(
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
            return new StateUpdateInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            StateUpdateInputType value,
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
