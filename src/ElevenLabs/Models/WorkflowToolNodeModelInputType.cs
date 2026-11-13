using ElevenLabs.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ElevenLabs;

[JsonConverter(typeof(WorkflowToolNodeModelInputType.WorkflowToolNodeModelInputTypeSerializer))]
[Serializable]
public readonly record struct WorkflowToolNodeModelInputType : IStringEnum
{
    public static readonly WorkflowToolNodeModelInputType Tool = new(Values.Tool);

    public WorkflowToolNodeModelInputType(string value)
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
    public static WorkflowToolNodeModelInputType FromCustom(string value)
    {
        return new WorkflowToolNodeModelInputType(value);
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

    public static bool operator ==(WorkflowToolNodeModelInputType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(WorkflowToolNodeModelInputType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(WorkflowToolNodeModelInputType value) => value.Value;

    public static explicit operator WorkflowToolNodeModelInputType(string value) => new(value);

    internal class WorkflowToolNodeModelInputTypeSerializer
        : JsonConverter<WorkflowToolNodeModelInputType>
    {
        public override WorkflowToolNodeModelInputType Read(
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
            return new WorkflowToolNodeModelInputType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            WorkflowToolNodeModelInputType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override WorkflowToolNodeModelInputType ReadAsPropertyName(
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
            return new WorkflowToolNodeModelInputType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            WorkflowToolNodeModelInputType value,
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
