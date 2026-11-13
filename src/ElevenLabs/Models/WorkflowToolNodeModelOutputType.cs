using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WorkflowToolNodeModelOutputType.WorkflowToolNodeModelOutputTypeSerializer))]
[Serializable]
public readonly record struct WorkflowToolNodeModelOutputType : IStringEnum
{
    public static readonly WorkflowToolNodeModelOutputType Tool = new(Values.Tool);

    public WorkflowToolNodeModelOutputType(string value)
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
    public static WorkflowToolNodeModelOutputType FromCustom(string value)
    {
        return new WorkflowToolNodeModelOutputType(value);
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

    public static bool operator ==(WorkflowToolNodeModelOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WorkflowToolNodeModelOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WorkflowToolNodeModelOutputType value) => value.Value;

    public static explicit operator WorkflowToolNodeModelOutputType(string value) => new(value);

    internal class WorkflowToolNodeModelOutputTypeSerializer
        : JsonConverter<WorkflowToolNodeModelOutputType>
    {
        public override WorkflowToolNodeModelOutputType Read(
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
            return new WorkflowToolNodeModelOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowToolNodeModelOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkflowToolNodeModelOutputType ReadAsPropertyName(
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
            return new WorkflowToolNodeModelOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowToolNodeModelOutputType value,
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
        public const string Tool = "tool";
    }
}
