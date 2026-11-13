using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WorkflowStartNodeModelOutputType.WorkflowStartNodeModelOutputTypeSerializer))]
[Serializable]
public readonly record struct WorkflowStartNodeModelOutputType : IStringEnum
{
    public static readonly WorkflowStartNodeModelOutputType Start = new(Values.Start);

    public WorkflowStartNodeModelOutputType(string value)
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
    public static WorkflowStartNodeModelOutputType FromCustom(string value)
    {
        return new WorkflowStartNodeModelOutputType(value);
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

    public static bool operator ==(WorkflowStartNodeModelOutputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WorkflowStartNodeModelOutputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WorkflowStartNodeModelOutputType value) => value.Value;

    public static explicit operator WorkflowStartNodeModelOutputType(string value) => new(value);

    internal class WorkflowStartNodeModelOutputTypeSerializer
        : JsonConverter<WorkflowStartNodeModelOutputType>
    {
        public override WorkflowStartNodeModelOutputType Read(
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
            return new WorkflowStartNodeModelOutputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowStartNodeModelOutputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkflowStartNodeModelOutputType ReadAsPropertyName(
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
            return new WorkflowStartNodeModelOutputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowStartNodeModelOutputType value,
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
        public const string Start = "start";
    }
}
