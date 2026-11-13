using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

/// <summary>The source to extract the value from. Currently only 'response' is supported.</summary>
[JsonConverter(typeof(DynamicVariableAssignmentSource.DynamicVariableAssignmentSourceSerializer))]
[Serializable]
public readonly record struct DynamicVariableAssignmentSource : IStringEnum
{
    public static readonly DynamicVariableAssignmentSource Response = new(Values.Response);

    public DynamicVariableAssignmentSource(string value)
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
    public static DynamicVariableAssignmentSource FromCustom(string value)
    {
        return new DynamicVariableAssignmentSource(value);
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

    public static bool operator ==(DynamicVariableAssignmentSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DynamicVariableAssignmentSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DynamicVariableAssignmentSource value) => value.Value;

    public static explicit operator DynamicVariableAssignmentSource(string value) => new(value);

    internal class DynamicVariableAssignmentSourceSerializer
        : JsonConverter<DynamicVariableAssignmentSource>
    {
        public override DynamicVariableAssignmentSource Read(
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
            return new DynamicVariableAssignmentSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DynamicVariableAssignmentSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DynamicVariableAssignmentSource ReadAsPropertyName(
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
            return new DynamicVariableAssignmentSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DynamicVariableAssignmentSource value,
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
        public const string Response = "response";
    }
}
